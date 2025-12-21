namespace Busnetz_Aufgabe_13;

public class Buslinie
{
    public String LinienNummer  { get; set; }
    public String Fahrer { get; set; }
    public List<Haltestelle> Haltestellen { get; set; } = new();

    public Buslinie(){}
    
    public Buslinie(String linienNummer, String fahrer)
    {
        if (String.IsNullOrEmpty(linienNummer))
        {
            throw new Exception("LinienNummer is null or empty");
        }

        if (String.IsNullOrEmpty(fahrer))
        {
            throw new Exception("Fahrer is null or empty");
        }
        LinienNummer = linienNummer;
        Fahrer = fahrer;
    }
}