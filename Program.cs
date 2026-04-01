// ============================================================
//  Aufgabe: Programmablaufplan – BMI-Rechner
//  Fach:    C# Grundlagen
//  Name:    [Ehrhardt Stefan]
//  Datum:   [01. April 2026]
// ============================================================
//
// AUFGABE 1 – Beantworte folgende Fragen hier als Kommentar:
//
// Frage 1: Wie viele Entscheidungsknoten (Rauten) hat der PAP?
// Antwort: 6 Stück
//
// Frage 2: Unter welchen Bedingungen endet das Programm frühzeitig?
// Antwort: Wenn TryParse fehlschlägt (ungültige Eingabe). Dies ist der Fall bei Gewicht und Größe. Zusätzlich wird das Programm auch frühzeitig beendet, wenn die eingegebene Größe kleiner 0 ist.
//
// Frage 3: Warum wird TryParse statt Convert.ToDouble() verwendet?
// Antwort: Weil ei ungültiger Eingabe (z.B. Buchstaben statt Zahlen) TryParse nicht abstürzt, sondern einfach false zurückgibt.
//
// Frage 4: Welchen Datentyp sollen gewicht und groesse haben, und warum?
// Antwort: double, weil es sich um Dezimalzahlen handelt (z.B. 70.5 kg oder 1.75 m).
//
// ============================================================

// TODO: Schreibe dein Programm unterhalb dieser Zeile.
//       Orientiere dich dabei am PAP in der README.md.
//       Jeder Schritt im PAP sollte einer Zeile / einem Block in deinem Code entsprechen.

// ── Schritt 1: Programmtitel ausgeben ───────────────────────
// Tipp: Nutze Console.WriteLine() für die Titelbox.
// TODO: Ausgabe der Titelzeile (wie im Beispiel in der README)
Console.WriteLine("╔══════════════════════════════════╗");
Console.WriteLine("║        BMI-Rechner v1.0          ║");
Console.WriteLine("╚══════════════════════════════════╝");
Console.WriteLine("");

// ── Schritt 2: Eingabe – Name ────────────────────────────────
// TODO: Benutzernamen einlesen (string, kein TryParse nötig)
string Benutzername;
Console.Write("Bitte gib deinen Namen ein: ");
Benutzername = Console.ReadLine();


// ── Schritt 3: Eingabe – Gewicht mit Validierung ─────────────
// TODO: Gewicht als Text einlesen
// TODO: Mit double.TryParse() in eine Zahl umwandeln
// TODO: Falls ungültig → Fehlermeldung ausgeben und Programm beenden (return)
string eingabeGewicht;
double gewicht;
gewicht = -1; // Initialisierung mit ungültigem Wert, damit die Validierung funktioniert
Console.Write("Bitte gib dein Gewicht in kg ein: ");
eingabeGewicht = Console.ReadLine();
if (!double.TryParse(eingabeGewicht, out gewicht))
{
    Console.WriteLine("Ungültige Eingabe für Gewicht. Bitte eine Zahl eingeben.");
    return;
}


// ── Schritt 4: Eingabe – Größe mit Validierung ───────────────
// TODO: Körpergröße als Text einlesen
// TODO: Mit double.TryParse() in eine Zahl umwandeln
// TODO: Falls ungültig → Fehlermeldung ausgeben und Programm beenden (return)
// TODO: Zusätzlich prüfen: Ist die Größe größer als 0?
//       Falls nicht → eigene Fehlermeldung und Programm beenden (return)
string eingabeGroesse;
double groesse;
groesse = -1; // Initialisierung mit ungültigem Wert, damit die Validierung funktioniert
Console.Write("Bitte gib deine Körpergröße in Metern ein: ");
eingabeGroesse = Console.ReadLine();
if (!double.TryParse(eingabeGroesse, out groesse))
{
    Console.WriteLine("Ungültige Eingabe für Körpergröße. Bitte eine Zahl eingeben.");
    return;
}
else if (groesse <= 0)
{
    Console.WriteLine("Ungültige Eingabe für Körpergröße. Die Größe muss größer als 0 sein.");
    return;
}


// ── Schritt 5: BMI berechnen ─────────────────────────────────
// Formel: BMI = Gewicht / (Größe * Größe)
// TODO: BMI berechnen und in einer Variablen speichern
double bmi = gewicht / (groesse * groesse);

// ── Schritt 6: Kategorie bestimmen ───────────────────────────
// TODO: Erstelle eine string-Variable "kategorie"
// TODO: Bestimme die Kategorie über eine if-else-if-Kette:
//       BMI < 18.5        → "Untergewicht"
//       BMI < 25.0        → "Normalgewicht"
//       BMI < 30.0        → "Übergewicht"
//       sonst (else)      → "Starkes Übergewicht"
//
// 💭 Denkfrage: Warum reicht bei "Normalgewicht" die Bedingung BMI < 25.0 aus,
//               obwohl laut WHO-Tabelle auch BMI >= 18.5 gelten muss?
//  Antwort zur Denkfrage: BMI >= 18.5 muss nicht geprüft werden, weil die vorherige Bedingung (BMI < 18.5) bereits alle Werte unter 18.5 abfängt.

string[] kategorie;
if (bmi < 18.5)
{
    kategorie = new string[] { "Untergewicht" };
}
else if (bmi < 25.0)
{
    kategorie = new string[] { "Normalgewicht" };
}
else if (bmi < 30.0)
{
    kategorie = new string[] { "Übergewicht" };
}
else
{
    kategorie = new string[] { "Starkes Übergewicht" };
}


// ── Schritt 7: Ergebnis ausgeben ─────────────────────────────
// TODO: Gib Name, BMI (auf 2 Dezimalstellen) und Kategorie formatiert aus
// Tipp: Nutze z.B. $"{bmi:F2}" für 2 Nachkommastellen
Console.WriteLine("");
Console.WriteLine("──────────────────────────────────");
Console.WriteLine($"Ergebnis für {Benutzername}");
Console.WriteLine("──────────────────────────────────");
Console.WriteLine($"BMI:       {bmi:F2}");
Console.WriteLine($"Kategorie: {kategorie[0]}");
Console.WriteLine("──────────────────────────────────");
