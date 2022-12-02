using System.Collections.Generic;
using Xamarin.Forms;
using Cub.Classes;
using System;

namespace Cub
{
    public partial class Main : ContentPage
    {
        private readonly List<string> treeTypeList;
        private readonly Dictionary<int, Entry> entries = new Dictionary<int, Entry>();
        private string language;

        public Main()
        {
            InitializeComponent();
            language = "Magyar";
            treeTypeList = Constants.TreeTypeList; 
            treeType.ItemsSource = treeTypeList;

            generateTable(6, 22, 0);
            generateTable(24, 40, 1);
            generateTable(42, 58, 2);

            void generateTable(int start, int end, int column)
            {
                for (int i = start, j = 0; i <= end; i += 2, j++)
                {
                    Label lbl = new Label
                    {
                        Text = i.ToString() + ":",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.End
                    };

                    Entry entry = new Entry
                    {
                        MaxLength = 3,
                        Keyboard = Keyboard.Numeric,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        VerticalOptions = LayoutOptions.End,
                        HorizontalTextAlignment = TextAlignment.Center,
                        HeightRequest = lbl.Height
                    };

                    entry.TextChanged += Entry_TextChanged;

                    entries.Add(i, entry);

                    multGridContent.Children.Add(lbl, column * 2 + 0, j);
                    multGridContent.Children.Add(entry, column * 2 + 1, j);
                }
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string crtText = e.NewTextValue;
            if (string.IsNullOrEmpty(crtText)) 
                return;

            if (!char.IsDigit(crtText[crtText.Length - 1]))
            {
                ((Entry)sender).Text = crtText.Remove(crtText.Length - 1, 1);
                return;
            }

            double top = 0.0;
            double bottom = 0.0;
            foreach (KeyValuePair<int, Entry> entry in entries)
            {
                string text = entry.Value.Text;
                double val = string.IsNullOrEmpty(text) ? 0.0 : int.Parse(text);
                top += val * entry.Key * entry.Key;
                bottom += val;
            }

            if (bottom == 0)
            {
                dm.Text = "0";
                return;
            }

            double dmValue = Math.Round(Math.Sqrt(top / bottom));
            dm.Text = ((int)dmValue).ToString();
        }

        private void Run_Clicked(object sender, EventArgs e)
        {
            if (treeType.SelectedIndex == -1)
            {
                if (language == "Magyar")
                    DisplayAlert("Atenţie", "Alege o specie!", "OK");
                else DisplayAlert("Figyelem", "Válasszon ki egy fajt!", "OK");
                return;
            }

            if (string.IsNullOrEmpty(hm.Text))
            {
                if (language == "Magyar")
                    DisplayAlert("Atenţie", "Introduceți o valoare pentru hm!", "OK");
                else DisplayAlert("Figyelem", "Írjon be értéket a hm mezőhöz!", "OK");
                return;
            }

            if (dm.Text == "0")
            {
                if (language == "Magyar")
                    DisplayAlert("Atenţie", "Introduceți cel puțin o valoare în tabel!", "OK");
                else DisplayAlert("Figyelem", "Írjon be legalább egy értéket a táblázatba!", "OK");
                return;
            }

            string selectedTreeType = treeTypeList[treeType.SelectedIndex];

            Dictionary<int, int> mult = new Dictionary<int, int>();
            foreach(KeyValuePair<int, Entry> entry in entries)
            {
                string text = entry.Value.Text;
                int val = string.IsNullOrEmpty(text) ? 0 : int.Parse(text);
                mult.Add(entry.Key, val);
            }

            int dmNew = int.Parse(dm.Text);
            double hmNew = string.IsNullOrEmpty(hm.Text) ? 0.0 : double.Parse(hm.Text);

            Calcul solve = new Calcul(selectedTreeType, mult, dmNew, hmNew);
            double retValue = solve.FinalResult();
            result.TextColor = Color.DarkGreen;
            result.Text = retValue.ToString();
        }

        private void Lang_Clicked(object sender, EventArgs e)
        {
            ((ToolbarItem)sender).Text = (language == "Magyar") ? "Română" : "Magyar";
            language = (language == "Magyar") ? "Română" : "Magyar";
            speciaLbl.Text = (speciaLbl.Text == "Specia:") ? "Fajok:" : "Specia:";
            treeType.Title = (treeType.Title == "Specia") ? "Fajok" : "Specia";
            diamLbl.Text = (diamLbl.Text == "Diametre:") ? "Átmérők:" : "Diametre:";
            button.Text = (button.Text == "Calcul") ? "Számítás" : "Calcul";
            resultLbl.Text = (resultLbl.Text == "Rezultat:") ? "Eredmény:" : "Rezultat:";
            deleteBtn.Text = (deleteBtn.Text == "Şterge") ? "Törlés" : "Şterge";
        }

        private void Hm_TextChanged(object sender, TextChangedEventArgs e)
        {
            string crtText = hm.Text;
            if (string.IsNullOrEmpty(crtText))
                return;

            try
            {
                if (double.Parse(crtText) > 60.0)
                {
                    hm.Text = "60.0";
                }
            }
            catch (FormatException) { }
            
        }

        private void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            treeType.SelectedIndex = -1;

            foreach (KeyValuePair<int, Entry> entry in entries)
            {
                entry.Value.Text = "";
            }

            dm.Text = "0";
            hm.Text = "";
            result.TextColor = Color.LightGray;
        }
    }
}
