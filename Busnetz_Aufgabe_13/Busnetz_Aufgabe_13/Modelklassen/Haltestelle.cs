namespace Busnetz_Aufgabe_13;

public class Haltestelle
{
    public String Name { get; set; }
    public String Zeit { get; set; }

    public Haltestelle(String name, String zeit)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Haltestelle name cannot be null or empty.");
        }

        Name = name;
        if (string.IsNullOrEmpty(zeit))
        {
            throw new Exception("Haltestelle zeit cannot be null or empty.");
        }

        Zeit = zeit;
    }
}