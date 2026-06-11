# SchoolProject - Schulverwaltung

Dieses Projekt enthält zwei einfache Versionen einer Schulverwaltungs-App.

## Inhalt

- `SchoolWeb/` - ASP.NET Core Backend mit Entity Framework und SQLite
- `SchoolWebFrontend/` - Angular Frontend für das Backend
- `LowCodeApp/` - einfache Low-Code/KI-Prototyp-App mit HTML, CSS und JavaScript
- `docs/` - kurze Projektdokumentation und Präsentationsnotizen

## Angular-App starten

Voraussetzungen:

- Node.js
- npm
- laufendes Backend aus `SchoolWeb/`

Befehle:

```bash
cd SchoolWebFrontend
npm install
npm start
```

Danach im Browser öffnen:

```text
http://localhost:4200
```

## Angular-App testen und bauen

```bash
cd SchoolWebFrontend
npm test
npm run build
```

## Backend starten

Voraussetzung:

- .NET 8 SDK

Befehl:

```bash
cd SchoolWeb
dotnet run
```

Die Angular-App verwendet standardmäßig diese API-Adresse:

```text
http://localhost:5296/api
```

## Low-Code-App starten

```bash
cd LowCodeApp
```

Dann `index.html` direkt im Browser öffnen.

## Funktionen der Angular-App

- Dashboard mit Anzahl von Schülern, Lehrern und Räumen
- Schüler anzeigen
- Schüler speichern
- Lehrer anzeigen
- Klassenräume anzeigen
- einfache Statistik anzeigen

## Funktionen der Low-Code-App

- Dashboard mit Beispieldaten
- Schüler hinzufügen
- Schüler löschen
- Lehrer und Räume anzeigen
- Speicherung im Browser mit `localStorage`

## Vergleich

Die Angular-App ist besser strukturiert und verwendet ein Backend.
Die Low-Code-App ist schneller erstellt und einfacher, aber weniger professionell und nicht direkt an das Backend angebunden.
