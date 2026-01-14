namespace json_uebung.Model;

public class Buslinien
{
    public String LinienNummer { get; set; }
    public String Fahrer {get; set;}

    public List<Haltestellen> Haltestellen { get; set; } = new();


}