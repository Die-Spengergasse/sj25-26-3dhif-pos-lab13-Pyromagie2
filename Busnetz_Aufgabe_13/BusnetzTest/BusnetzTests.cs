using System.Collections.Generic;
using Busnetz_Aufgabe_13;
using Xunit;

public class BusnetzTests
{
    [Fact]
    public void Datenklassen_KönnenErstelltUndGespeichertWerden()
    {
        
        var busnetz = new Busnetz
        {
            Buslinien = new List<Buslinie>
            {
                new Buslinie("42", "Herr Müller")
                {
                    Haltestellen = new List<Haltestelle>
                    {
                        new Haltestelle("Zentralplatz", "08:00"),
                        new Haltestelle("Schulzentrum", "08:05")
                    }
                }
            }
        };

        
        var linie = busnetz.Buslinien[0];

        Assert.Equal("42", linie.LinienNummer);      
        Assert.Equal("Herr Müller", linie.Fahrer);
        Assert.Equal(2, linie.Haltestellen.Count);
    }

    [Fact]
    public void GetHaltestellenVonFahrer_Gibt_KorrekteAnzahlZurück()
    {
        
        var busnetz = new Busnetz
        {
            Buslinien = new List<Buslinie>
            {
                new Buslinie("42", "Herr Müller")
                {
                    Haltestellen = new List<Haltestelle>
                    {
                        new Haltestelle("Zentralplatz", "08:00"),
                        new Haltestelle("Schulzentrum", "08:05")
                    }
                },
                new Buslinie("55", "Frau Becker")
                {
                    Haltestellen = new List<Haltestelle>
                    {
                        new Haltestelle("Hauptbahnhof", "09:00"),
                        new Haltestelle("Museum", "09:08")
                    }
                }
            }
        };

        var einlesen = new EinlesenFürTests(busnetz);

        
        var haltestellen = einlesen.GetHaltestellenVonFahrer("Herr Müller");

        
        Assert.Equal(2, haltestellen.Count);

     
        Assert.Contains(haltestellen, h => h.Name == "Zentralplatz");
    }
}
