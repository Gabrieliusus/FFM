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
  title = 'SchoolWeb Frontend';
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
    }
    if (seite === 'schueler') {
      this.ladeSchueler();
    }
    if (seite === 'lehrer') {
      this.ladeLehrer();
    }
    if (seite === 'raeume') {
      this.ladeKlassenraeume();
    }
    if (seite === 'statistik') {
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
        this.fehler = 'Backend nicht erreichbar. Starte SchoolWeb zuerst.';
      }
    });

    this.api.getLehrer().subscribe({
      next: (daten) => {
        this.lehrer = daten;
      }
    });

    this.api.getKlassenraeume().subscribe({
      next: (daten) => {
        this.klassenraeume = daten;
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
