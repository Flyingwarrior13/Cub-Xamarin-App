using System;
using System.Collections.Generic;

namespace Cub.Classes
{
    public class Calcul
    {
        private readonly string specia;
        private readonly Dictionary<int, int> mult;
        private readonly int dm;
        private readonly double hm;
        private double dg;
        private string idSpecial;

        public Calcul(string specia, Dictionary<int, int> mult, int dm, double hm)
        {
            this.specia = specia;
            this.mult = mult;
            this.hm = hm;
            this.dm = dm;
        }

        public double FinalResult()
        {
            SolveDg();

            idSpecial = Constants.SpecieIdDict[specia][2].ToString() + "_" + ((dm / dg >= 1) ? "1" : "0");

            double volSum = 0;
            foreach (KeyValuePair<int, int> kvp in mult)
            {
                double vuni = (kvp.Key < dg) ? DLessDg(kvp.Key) : DMoreDg(kvp.Key);
                volSum += vuni * kvp.Value;
            }

            return Math.Round(volSum, 4);
        }

        private void SolveDg()
        {
            //solve suprafata medie (J50)
            double cumSum = 0;
            int multValSum = 0;

            foreach (KeyValuePair<int, int> mu in mult)
            {
                cumSum += mu.Value * (mu.Key / 200.0) * (mu.Key / 200.0) * Math.PI;
                multValSum += mu.Value;
            }

            double supraMedie = cumSum / multValSum;

            //solve diam mediu (J51)
            dg = Math.Sqrt(supraMedie / Math.PI) * 200;
        }

        private double SolveI63()
        {
            double c0 = Constants.Tabel5Dict[idSpecial][0];
            double c1 = Constants.Tabel5Dict[idSpecial][1];
            double c2 = Constants.Tabel5Dict[idSpecial][2];
            double c3 = Constants.Tabel5Dict[idSpecial][3];
            double c4 = Constants.Tabel5Dict[idSpecial][4];
            double c5 = Constants.Tabel5Dict[idSpecial][5];
            double c6 = Constants.Tabel5Dict[idSpecial][6];

            return (c0 + c1 * dg + c2 * Math.Pow(dg, 2) +
                c3 * Math.Pow(dg, 3) + c4 * Math.Pow(dg, 4) +
                c5 * Math.Pow(dg, 5) + c6 * Math.Pow(dg, 6));
        }

        private double SolveI60()
        {
            double b0 = Constants.Tabel4Dict[idSpecial][0];
            double b1 = Constants.Tabel4Dict[idSpecial][1];
            double b2 = Constants.Tabel4Dict[idSpecial][2];
            return (b0 + b1 * dg + b2 * dg * dg);
        }

        private double SolveHr()
        {
            return Math.Pow(Math.E, SolveI63() * (Math.Pow(dm / dg, SolveI60()) - 1));
        }

        private double SolveVg()
        {
            int id_tab3 = Constants.SpecieIdDict[specia][1];
            double a0 = Constants.Tabel3Dict[id_tab3][0];
            double a1 = Constants.Tabel3Dict[id_tab3][1];
            double a2 = Constants.Tabel3Dict[id_tab3][2];
            double a3 = Constants.Tabel3Dict[id_tab3][3];
            double a4 = Constants.Tabel3Dict[id_tab3][4];

            double logDg = Math.Log10(dg);
            double logHg = Math.Log10(hm / SolveHr());

            double logVg = a0 + a1 * logDg + a2 * Math.Pow(logDg, 2) + a3 * logHg + a4 * Math.Pow(logHg, 2);

            return Math.Pow(10, logVg);
        }

        private double DLessDg(int m)
        {
            return (-0.162 + 1.162 * Math.Pow((m / dg), 2) +
                0.186 * Math.Pow(Math.E, -4.89 * (m / dg))) * SolveVg();
        }

        private double DMoreDg(int m)
        {
            return ((1.451 - 0.016 * dg + 0.000133 * dg * dg) *
                (Math.Pow(m / dg, 2) - 1) + 1) * SolveVg();
        }
    }
}
