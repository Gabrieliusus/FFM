import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SchoolApiService } from './services/school-api.service';
import {
  Frauenanteil,
  Geschlechterverteilung,
  Klassenraum,
  Lehrer,
  Schueler
} from './models/school.models';

@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  title = 'Schulverwaltung';
  aktiveSeite = 'dashboard';

  schueler: Schueler[] = [];
  lehrer: Lehrer[] = [];
  klassenraeume: Klassenraum[] = [];
  frauenanteil: Frauenanteil[] = [];
  geschlechterverteilung: Geschlechterverteilung[] = [];

  loading = false;
  fehler = '';
  erfolg = '';

  neuerSchueler = {
    klasse: '',
    geburtstag: '',
    geschlecht: 'weiblich'
  };

  constructor(private api: SchoolApiService) {}

  ngOnInit(): void {
    this.ladeDashboard();
  }

  setSeite(seite: string): void {
    this.aktiveSeite = seite;
    this.fehler = '';
    this.erfolg = '';

    if (seite === 'dashboard') {
      this.ladeDashboard();
    } else if (seite === 'schueler') {
      this.ladeSchueler();
    } else if (seite === 'lehrer') {
      this.ladeLehrer();
    } else if (seite === 'raeume') {
      this.ladeKlassenraeume();
    } else if (seite === 'statistik') {
      this.ladeStatistik();
    }
  }

  ladeDashboard(): void {
    this.loading = true;
    this.fehler = '';

    this.api.getSchueler().subscribe({
      next: (daten) => {
        this.schueler = daten;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.fehler = 'Backend nicht erreichbar. Bitte SchoolWeb starten.';
      }
    });

    this.api.getLehrer().subscribe({
      next: (daten) => {
        this.lehrer = daten;
      },
      error: () => {
        this.lehrer = [];
      }
    });

    this.api.getKlassenraeume().subscribe({
      next: (daten) => {
        this.klassenraeume = daten;
      },
      error: () => {
        this.klassenraeume = [];
      }
    });
  }

  ladeSchueler(): void {
    this.loading = true;
    this.api.getSchueler().subscribe({
      next: (daten) => {
        this.schueler = daten;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.fehler = 'Schüler konnten nicht geladen werden.';
      }
    });
  }

  ladeLehrer(): void {
    this.loading = true;
    this.api.getLehrer().subscribe({
      next: (daten) => {
        this.lehrer = daten;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.fehler = 'Lehrer konnten nicht geladen werden.';
      }
    });
  }

  ladeKlassenraeume(): void {
    this.loading = true;
    this.api.getKlassenraeume().subscribe({
      next: (daten) => {
        this.klassenraeume = daten;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.fehler = 'Klassenräume konnten nicht geladen werden.';
      }
    });
  }

  ladeStatistik(): void {
    this.loading = true;
    this.api.getFrauenanteil().subscribe({
      next: (daten) => {
        this.frauenanteil = daten;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.fehler = 'Statistik konnte nicht geladen werden.';
      }
    });

    this.api.getGeschlechterverteilung().subscribe({
      next: (daten) => {
        this.geschlechterverteilung = daten;
      },
      error: () => {
        this.geschlechterverteilung = [];
      }
    });
  }

  schuelerSpeichern(): void {
    this.fehler = '';
    this.erfolg = '';

    if (!this.neuerSchueler.klasse || !this.neuerSchueler.geburtstag || !this.neuerSchueler.geschlecht) {
      this.fehler = 'Bitte alle Felder ausfüllen.';
      return;
    }

    this.api.addSchueler(this.neuerSchueler).subscribe({
      next: () => {
        this.erfolg = 'Schüler wurde gespeichert.';
        this.neuerSchueler = {
          klasse: '',
          geburtstag: '',
          geschlecht: 'weiblich'
        };
        this.ladeSchueler();
      },
      error: () => {
        this.fehler = 'Schüler konnte nicht gespeichert werden.';
      }
    });
  }
}
