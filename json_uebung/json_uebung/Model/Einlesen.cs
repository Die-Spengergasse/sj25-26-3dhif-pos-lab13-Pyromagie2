using System.Collections.Frozen;
using System.Text.Json;
using System.Xml.Serialization;

namespace json_uebung.Model;

public class Einlesen
{
    public void einlesen()
    {

        string json = File.ReadAllText("busnetz.json");
        
        Busnetz? busnetz = JsonSerializer.Deserialize<Busnetz>(json);

        if (busnetz == null)
        {
            busnetz = new Busnetz();
        }

        busnetz.Buslinien = new List<Buslinien>();
        
        Buslinien? linie34 = busnetz.Buslinien.FirstOrDefault(b => b.LinienNummer == "34");
        if (linie34 == null)
        {
            linie34 = new Buslinien();
            linie34.LinienNummer = "34";
            linie34.Fahrer = "Emil Sack";
            linie34.Haltestellen.Add(new Haltestellen
            {
                Name = "Wien"
                , Zeit = "7:30"
            });
            busnetz.Buslinien.Add(linie34);
        }
        else
        {
            linie34.Fahrer = "Emil Sack";
            linie34.Haltestellen.Add(new Haltestellen
            {
                Name = "Wien"
                , Zeit = "7:30"
            });
        }
        
        var options = new JsonSerializerOptions{WriteIndented=true};
        string json2 = JsonSerializer.Serialize(busnetz, options);
        
        File.WriteAllText("busnetz.json", json2);

    }

  


    
}