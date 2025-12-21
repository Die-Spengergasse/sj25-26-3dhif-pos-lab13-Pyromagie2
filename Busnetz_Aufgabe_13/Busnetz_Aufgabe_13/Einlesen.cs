using System.Text.Json;

namespace Busnetz_Aufgabe_13;

public class Einlesen
{
    public static void Main(String[] args)
    {
        Einlesen einlesen = new Einlesen();
        einlesen.ausgeben();
    }

    private Busnetz busnetz;
    String json = File.ReadAllText("busnetz.json");
   

    public void ausgeben()
    {
        busnetz = JsonSerializer.Deserialize<Busnetz>(json);
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