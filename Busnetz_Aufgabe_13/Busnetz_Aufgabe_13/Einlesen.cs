using System.Text.Json;

namespace Busnetz_Aufgabe_13;

public class Einlesen
{
    public static void Main(String[] args)
    {
        Einlesen einlesen = new Einlesen();
        einlesen.Laden();
        einlesen.neuschreiben();
    }

    private Busnetz busnetz;
    String json = File.ReadAllText("busnetz.json");

    public void Laden()
    {
        busnetz = JsonSerializer.Deserialize<Busnetz>(json)
                  ?? new Busnetz();
        
        Console.WriteLine($"Geladene Linien: {busnetz.Buslinien?.Count}");
    }
    public void neuschreiben()
    {
        busnetz.Buslinien ??= new List<Buslinie>();
        var Linie43 = busnetz.Buslinien.FirstOrDefault(b => b.LinienNummer == "43");
        if (Linie43 == null)
        {
            Linie43 = new Buslinie("43","Bernd Wendel");
            Linie43.Haltestellen.Add(new Haltestelle("Wien Matzleinsdorferplatz", "9:51"));
            busnetz.Buslinien.Add(Linie43);
        }
        
        else
        {
            Linie43.Fahrer = "Bernd Wendel";
            Linie43.Haltestellen.Add(new Haltestelle("Bernd Wendel", "9:51"));
        }
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        Console.WriteLine($"Linien im Busnetz vor dem Speichern: {busnetz.Buslinien?.Count}");
        foreach (var l in busnetz.Buslinien)
        {
            Console.WriteLine($"Linie {l.LinienNummer}, Fahrer {l.Fahrer}, Haltestellen: {l.Haltestellen?.Count}");
        }
        

        string neujson = JsonSerializer.Serialize<Busnetz>(busnetz, options);
        File.WriteAllText("busnetz_neu.json", neujson);
        Console.WriteLine(Path.GetFullPath("busnetz_neu.json"));

        File.WriteAllText("busnetz_neu.json", neujson);
    }
    
    
    
    public void ausgeben()
    {
        Console.WriteLine("Busnetz - vollständige Übersicht:");
        for (int i = 0; i < busnetz.Buslinien.Count; i++)
        {
            Console.WriteLine($"Linie {busnetz.Buslinien[i].LinienNummer} - Fahrer: {busnetz.Buslinien[i].Fahrer}");
            Console.WriteLine("Haltestellen:");
            for (int j = 0; j < busnetz.Buslinien[i].Haltestellen.Count; j++)
            {
                Console.WriteLine($"- {busnetz.Buslinien[i].Haltestellen[j].Name} um {busnetz.Buslinien[i].Haltestellen[j].Zeit}");
            }
        }

        
    }
    
    

}