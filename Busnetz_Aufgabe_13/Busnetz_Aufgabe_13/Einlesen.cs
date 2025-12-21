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

    protected Busnetz busnetz;
    String json = File.ReadAllText("busnetz.json");

    public void Laden()
    {
        busnetz = JsonSerializer.Deserialize<Busnetz>(json) ?? new Busnetz();
        
        
    }
    public void neuschreiben()
    {
        busnetz.Buslinien ??= new List<Buslinie>();
        var Linie45 = busnetz.Buslinien.FirstOrDefault(b => b.LinienNummer == "45");
        if (Linie45 == null)
        {
            Linie45 = new Buslinie("45","Emil Sack");
            Linie45.Haltestellen.Add(new Haltestelle("Himberg Hauptplatz", "6:45"));
            
            busnetz.Buslinien.Add(Linie45);
            
        }
        else
        {
            Linie45.Fahrer = "Emil Sack";
            Linie45.Haltestellen.Add(new Haltestelle("Himberg Hauptplatz", "6:45"));
            
        }

        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        
        var newjson = JsonSerializer.Serialize(busnetz,options);
        File.WriteAllText("busnetz_neu.json", newjson);

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
    protected void SetBusnetz(Busnetz bn) => busnetz = bn;
    public List<Haltestelle> GetHaltestellenVonFahrer(string fahrerName)
    {
        if (busnetz?.Buslinien == null)
            return new List<Haltestelle>();  
    
        return busnetz.Buslinien
            .Where(l => l.Fahrer == fahrerName)      
            .SelectMany(l => l.Haltestellen)       
            .ToList();                              
    }

}
