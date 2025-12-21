using System.Collections.Generic;
using Busnetz_Aufgabe_13;
using Xunit;

public class BusnetzTests
{
    [Fact]
    public void Datenklassen_KönnenErstelltUndGespeichertWerden()
    {
        // Arrange: Busnetz mit einer Linie und zwei Haltestellen
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

        // Act: „Speichern“ simulieren – hier nur in Variable lassen
        var linie = busnetz.Buslinien[0];

        // Assert: prüfen, ob alles korrekt gesetzt wurde
        Assert.Equal("42", linie.LinienNummer);      // Beispiel für Assert.Equal
        Assert.Equal("Herr Müller", linie.Fahrer);
        Assert.Equal(2, linie.Haltestellen.Count);
    }

    [Fact]
    public void GetHaltestellenVonFahrer_Gibt_KorrekteAnzahlZurück()
    {
        // Arrange: Einlesen-Objekt mit bekanntem Busnetz
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

        var einlesen = new EinlesenFürTests(busnetz); // kleine Hilfsklasse, siehe unten

        // Act: LINQ-Methode aufrufen
        var haltestellen = einlesen.GetHaltestellenVonFahrer("Herr Müller");

        // Assert: Anzahl prüfen (Assert.Equal)
        Assert.Equal(2, haltestellen.Count);

        // Assert.Contains: prüfen, ob eine bestimmte Haltestelle enthalten ist
        Assert.Contains(haltestellen, h => h.Name == "Zentralplatz");
    }
}
