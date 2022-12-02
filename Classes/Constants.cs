using System.Collections.Generic;

namespace Cub.Classes
{
    public class Constants
    {
        private readonly static List<string> treeTypeList = new List<string>()
        {
            "Brad", "Carpen", "Cer (L)", "Cer (S)", "Cires Pasaresc", "Fag", "Frasin", "Gorun (L)",
            "Gorun (S)", "Jugastru", "Larice", "Mesteacan", "Molid", "Paltin de Munte", "Salcam",
            "Stejar Pedunculat (L)", "Stejar Pedunculat (S)", "Tei"
        };

        private readonly static Dictionary<string, List<int>> specieIdDict = new Dictionary<string, List<int>>()
        {
            //string ->               id, id_tab3, id_tab4, id_tab5
            {"Brad", new List<int>(){ 15, 15, 15} },
            {"Carpen", new List<int>(){ 143, 143, 143} },
            {"Cer (L)", new List<int>(){ 32, 31, 38} },
            {"Cer (S)", new List<int>(){ 31, 31, 38} },
            {"Cires Pasaresc", new List<int>(){ 144, 144, 38} },
            {"Fag", new List<int>(){ 24, 24, 24} },
            {"Frasin", new List<int>(){ 145, 145, 38} },
            {"Gorun (L)", new List<int>(){ 36, 35, 38} },
            {"Gorun (S)", new List<int>(){ 35, 35, 38} },
            {"Jugastru", new List<int>(){ 150, 150, 143} },
            {"Larice", new List<int>(){ 17, 17, 18} },
            {"Mesteacan", new List<int>(){ 151, 151, 38} },
            {"Molid", new List<int>(){ 18, 18, 18} },
            {"Paltin de Munte", new List<int>(){ 153, 153, 38} },
            {"Salcam", new List<int>(){ 154, 154, 154} },
            {"Stejar Pedunculat (L)", new List<int>(){ 39, 38, 38} },
            {"Stejar Pedunculat (S)", new List<int>(){ 38, 38, 38} },
            {"Tei", new List<int>(){ 74, 74, 38} }
        };

        private readonly static Dictionary<int, List<double>> tabel3Dict = new Dictionary<int, List<double>>()
        {
            //id_tab3         ->         a0         a1       a2        a3       a4
            { 15, new List<double>(){ -4.46414, 2.19479, -0.12498, 1.04645, -0.016848 } },
            { 143, new List<double>(){ -4.23139, 2.15204, -0.00988, 0.59652, 0.112810 } },
            { 31, new List<double>(){ -3.68707, 2.03534, -0.06747, -0.15871, 0.500372 } },
            { 144, new List<double>(){ -3.59371, 1.95047, 0.04086, -0.12835, 0.374948 } },
            { 24, new List<double>(){ -4.11122, 1.30216, 0.23636, 1.26562, -0.079661 } },
            { 145, new List<double>(){ -3.53048, 1.26636, 0.31105, 0.52368, 0.082743 } },
            { 35, new List<double>(){ -4.17315, 2.27662, -0.09084, 0.57596, 0.093429 } },
            { 150, new List<double>(){ -3.22096, 1.58409, 0.13567, -0.08677, 0.313054 } },
            { 17, new List<double>(){ -4.59667, 2.26066, -0.13256, 1.02582, 0.007491 } },
            { 151, new List<double>(){ -4.16999, 2.27038, -0.21540, 0.30765, 0.368258 } },
            { 18, new List<double>(){ -4.18161, 2.08131, -0.11819, 0.70119, 0.148181 } },
            { 153, new List<double>(){ -4.06012, 1.81478, 0.07283, 0.76688, 0.006155 } },
            { 154, new List<double>(){ -3.37551, 1.80802, 0.02827, -0.33554, 0.51215 } },
            { 38, new List<double>(){ -4.13329, 1.88001, 0.0488, 0.95371, -0.063638 } },
            { 74, new List<double>(){ -4.80605, 1.92424, 0.02214, 1.96408, -0.452969 } },
        };

        private readonly static Dictionary<string, List<double>> tabel4Dict = new Dictionary<string, List<double>>()
        {
            //id_tabS         ->            b0       b1       b2 
            { "18_0", new List<double>(){ -1.004, -0.0103, -0.000082 } },
            { "18_1", new List<double>(){ -0.982, -0.0191, -0.000229 } },
            { "15_0", new List<double>(){ -0.235, 0.0498, -0.000080 } },
            { "15_1", new List<double>(){ -2.247, -0.0123, -0.000352 } },
            { "24_0", new List<double>(){ -0.921, -0.0138, -0.000416 } },
            { "24_1", new List<double>(){ -0.904, -0.0411, -0.000289 } },
            { "38_0", new List<double>(){ -1.406, -0.0135, -0.000057 } },
            { "38_1", new List<double>(){ -0.594, -0.0095, -0.000150 } },
            { "143_0", new List<double>(){ -0.125, -0.0580, -0.000500 } },
            { "143_1", new List<double>(){ -1.1625, -0.0030, -0.000075 } },
            { "154_0", new List<double>(){ -0.7025, -0.0131, -0.000125 } },
            { "154_1", new List<double>(){ -0.5125, -0.0107, -0.000250 } }
        };

        private readonly static Dictionary<string, List<double>> tabel5Dict = new Dictionary<string, List<double>>()
        {
            //id_tabS         ->            c0         c1         c2        c3      c4  c5  c6
            { "18_0", new List<double>(){ 0.702300, 0.020310, -0.000120, -0.000002, 0.0, 0.0, 0.0 } },
            { "18_1", new List<double>(){ -0.749000, 0.044470, -0.000238, 0.000088, -0.000002, 0.0000000189, -0.0000000000778 } },
            { "15_0", new List<double>(){ -2.520800, 0.242840, -0.011460, 0.000312, -0.000005, 0.0000000414, -0.0000000001444 } },
            { "15_1", new List<double>(){ -0.312000, 0.007326, 0.001352, -0.000053, 0.000001, -0.0000000099, 0.0000000000382 } },
            { "24_0", new List<double>(){ -0.607000, 0.023290, -0.000365, 0.000003, 0.0, 0.0, 0.0 } },
            { "24_1", new List<double>(){ -0.609500, 0.033970, -0.000929, 0.000015, 0.0, 0.0000000006, 0.0 } },
            { "38_0", new List<double>(){ -0.327000, 0.007819, -0.000150, 0.000003, 0.0, 0.0000000002, 0.0 } },
            { "38_1", new List<double>(){ -0.747900, 0.013720, 0.000645, -0.000029, 0.0, -0.0000000020, 0.0 } },
            { "143_0", new List<double>(){ -1.296000, 0.100450, -0.002870, 0.000029, 0.0, 0.0, 0.0 } },
            { "143_1", new List<double>(){ -0.382800, 0.006640, -0.000018, 0.0, 0.0, 0.0, 0.0 } },
            { "154_0", new List<double>(){ -0.877000, 0.023750, -0.000120, -0.000002, 0.0, 0.0, 0.0 } },
            { "154_1", new List<double>(){ -1.020000, 0.036990, -0.000705, -0.000006, 0.0, 0.0, 0.0 } }
        };

        public static List<string> TreeTypeList => treeTypeList;

        public static Dictionary<string, List<int>> SpecieIdDict => specieIdDict;

        public static Dictionary<int, List<double>> Tabel3Dict => tabel3Dict;

        public static Dictionary<string, List<double>> Tabel4Dict => tabel4Dict;

        public static Dictionary<string, List<double>> Tabel5Dict => tabel5Dict;
    }
}
