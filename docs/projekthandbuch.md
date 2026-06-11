# Projekthandbuch - Schulverwaltung

## 1. Arbeitsauftrag

Für die Schulverwaltung wurden zwei Varianten einer Anwendung erstellt:

1. Eine Angular-Applikation als Frontend für das vorhandene Backend.
2. Ein einfacher Low-Code/KI-Prototyp als Vergleichsanwendung.

Zusätzlich soll das Projekt präsentiert und der Unterschied zwischen den beiden Ansätzen erklärt werden.

## 2. Ziel des Projekts

Ziel ist eine einfache Anwendung, mit der Schulverwaltungsdaten übersichtlich angezeigt werden können.
Dazu gehören Schüler, Lehrer, Klassenräume und einfache Statistiken.

## 3. Projektstrukturplan

- Planung
  - Anforderungen lesen
  - vorhandenes Backend prüfen
- Umsetzung Angular
  - Oberfläche erstellen
  - API-Service verwenden
  - Daten anzeigen
  - Schülerformular erstellen
- Umsetzung Low-Code/KI
  - einfache Oberfläche erstellen
  - Beispieldaten verwenden
  - lokale Speicherung ergänzen
- Testen
  - Angular Build ausführen
  - Angular Tests ausführen
  - Low-Code-App im Browser prüfen
- Präsentation
  - Projekt erklären
  - beide Apps zeigen
  - Vergleich erklären

## 4. Organisationsstrukturplan

- Projektleitung: Schüler
- Entwicklung Angular: Schüler
- Entwicklung Low-Code/KI-Prototyp: Schüler mit KI-Unterstützung
- Test und Präsentation: Schüler

## 5. Umweltanalyse

- Lehrer: bewertet die Umsetzung und Präsentation
- Schüler: entwickelt und präsentiert das Projekt
- Schule: stellt den fachlichen Rahmen
- Technologien: Angular, ASP.NET Core, HTML, CSS, JavaScript

## 6. Angular-App

Die Angular-App ist eine einfache Frontend-Anwendung. Sie verwendet einen Service, um Daten vom Backend zu laden.
Es gibt Seiten für Dashboard, Schüler, Lehrer, Räume und Statistik.

Vorteile:

- klare Struktur
- echte Backend-Anbindung
- besser erweiterbar

Nachteile:

- mehr Setup notwendig
- etwas komplexer als ein einfacher Prototyp

## 7. Low-Code/KI-App

Die Low-Code-App ist ein einfacher Prototyp im Ordner `LowCodeApp`.
Sie besteht aus HTML, CSS und JavaScript und speichert Schülerdaten im Browser.

Vorteile:

- sehr schnell erstellt
- einfach zu verstehen
- kein Build notwendig

Nachteile:

- keine echte Backend-Anbindung
- weniger professionell
- für größere Projekte nicht ideal

## 8. Lessons Learned

- Angular eignet sich besser für eine richtige Webanwendung.
- Low-Code/KI eignet sich gut für schnelle Prototypen.
- Tests sind wichtig, damit Fehler früh gefunden werden.
- Eine gute Dokumentation hilft bei der Präsentation.

## 9. Fazit

Beide Varianten erfüllen unterschiedliche Zwecke. Die Angular-App ist technisch sauberer und besser erweiterbar.
Die Low-Code-App zeigt, wie schnell man mit einfachen Mitteln einen Prototyp erstellen kann.
