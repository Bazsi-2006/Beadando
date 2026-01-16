using System;

namespace electromosautok
{
    public class Auto
    {
        string marka;
        string model;
        string sae;
        int sebesseg;
        string szenzorok;
        string gps;
        int vezevoiBeav;
        string vezetesiMod;

        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string SAE { get => sae; set => sae = value; }
        public int Sebesseg { get => sebesseg; set => sebesseg = value; }
        public string Szenzorok { get => szenzorok; set => szenzorok = value; }
        public string Gps { get => gps; set => gps = value; }
        public int VezevoiBeav { get => vezevoiBeav; set => vezevoiBeav = value; }
        public string VezetesiMod { get => vezetesiMod; set => vezetesiMod = value; }

        public Auto(string sor)
        {
            string[] adatok = sor.Split("; ");

            string[] markaModel = adatok[0].Split(' ');
            Marka = markaModel[0];
            Model = string.Join(" ", markaModel[1..]);

            SAE = adatok[1];
            Sebesseg = int.Parse(adatok[2]);
            Szenzorok = adatok[3];
            Gps = adatok[4];
            VezevoiBeav = int.Parse(adatok[5]);
            VezetesiMod = adatok[6];
        }

        public override string ToString()
        {
            return $"Márka: {Marka} {Model}\n" +
                   $"\tSAE: {SAE}\n" +
                   $"\tSebesség: {Sebesseg}\n" +
                   $"\tSzenzorok: {Szenzorok}\n" +
                   $"\tGPS: {Gps}\n" +
                   $"\tBeavatkozás: {VezevoiBeav}\n" +
                   $"\tMód: {VezetesiMod}";
        }

        public string NagyBetu()
        {
            return $"{Marka.ToUpper()} {Model.ToUpper()}";
        }
    }
}
