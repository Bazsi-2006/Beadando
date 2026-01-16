using electromosautok;
using System.Globalization;
using System.Text;

List<Auto> autok = [];

Console.OutputEncoding = Encoding.UTF8;

using StreamReader sr = new("autok.txt", Encoding.UTF8);

string? elsoSor = sr.ReadLine();

autok.Add(new Auto(elsoSor));

while (!sr.EndOfStream)
{
    string sor = sr.ReadLine()!;
    if (sor == elsoSor) continue;
    if (string.IsNullOrWhiteSpace(sor)) continue;
    autok.Add(new Auto(sor));
}

Console.WriteLine($"5. feladat: beolvasott autók száma: {autok.Count}\n");

// 6. feladat:
Console.WriteLine("6. feladat: autók adatai:\n");
foreach (var a in autok)
{
    Console.WriteLine(a);
    Console.WriteLine();
}

// 7. feladat:
Console.WriteLine("7. feladat:");
var f7 = autok
    .Where(a => a.VezetesiMod == "manuális" && a.SAE == "félautomatikus")
    .ToList();

if (f7.Any())
    Console.WriteLine($"\tA feltételeknek megfelelő autók száma: {f7.Count}\n");
else
    Console.WriteLine("\tNincs olyan autó, ami félautomatikus és manuális módban fut.\n");

// 8. feladat:
Console.WriteLine("8. feladat: legkevésbé önálló autók:");
int maxBeav = autok.Max(a => a.VezevoiBeav);
var f8 = autok.Where(a => a.VezevoiBeav == maxBeav).ToList();

foreach (var a in f8)
{
    Console.WriteLine(a);
    Console.WriteLine();
}
Console.WriteLine($"\t[{maxBeav}] vezetői beavatkozás értékkel rendelkező autók száma: {f8.Count}\n");

// 9. feladat:
Console.WriteLine($"9. feladat: legkisebb szélességi koordináta: {Feladat09(autok)}\n");

// 10. feladat:
Console.WriteLine("10. feladat: a jelenleg automatikus módban futó autók gyártói:");
var f10 = autok
    .Where(a => a.VezetesiMod == "automatikus")
    .Select(a => a.Marka)
    .Distinct()
    .Order()
    .ToList();

if (f10.Any())
    Console.WriteLine("\t" + string.Join(", ", f10) + "\n");
else
    Console.WriteLine("\tNincs jelenleg automatikus módban futó autó.\n");

// 11. feladat:
Console.WriteLine("11. feladat: a [85; 95] km/h sebességű min. 3 szenzoros autók sorszámai:");
var f11 = autok
    .Where(a => a.Sebesseg >= 85 && a.Sebesseg <= 95)
    .Where(a => SzamlalSzenzorok(a.Szenzorok) >= 3)
    .Select(a => autok.IndexOf(a) + 1)
    .ToList();

if (f11.Any())
    Console.WriteLine("\t" + string.Join(". ", f11) + ".\n");
else
    Console.WriteLine("\tNincs ilyen autó.\n");

// 13. feladat:
 List<string> sorok = autok
    .Select(a => $"{a.NagyBetu()}; {a.SAE}")
    .ToList();

 File.WriteAllLines("autok_nagybetus.txt", sorok, Encoding.UTF8);

static double Feladat09(List<Auto> lista)
{
    return lista
        .Select(a => SzelessegiKoordinata(a.Gps))
        .Min();
}

static double SzelessegiKoordinata(string gps)
{
    string[] reszek = gps.Split(',', StringSplitOptions.TrimEntries);

    if (reszek.Length < 1 || string.IsNullOrWhiteSpace(reszek[0]))
        throw new Exception($"Hibás GPS formátum: {gps}");

    return double.Parse(reszek[0], CultureInfo.InvariantCulture);
}


static int SzamlalSzenzorok(string szenzorok)
{
    var parts = szenzorok
        .Split(new[] { ", ", ",", "; ", ";" }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

    return parts.Length;
}
