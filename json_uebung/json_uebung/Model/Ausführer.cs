namespace json_uebung.Model;

public class Ausführer
{
    public static void Main(String[] args)
    {
        Einlesen lesen = new Einlesen();
        lesen.einlesen();
        lesen.einlesenxml();
    }
}