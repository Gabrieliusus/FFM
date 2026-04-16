export interface Schueler {
  id: number;
  klasse: string;
  geschlecht: string;
  geburtstag: string;
  alter: number;
}

export interface Lehrer {
  id: number;
  vorname: string;
  nachname: string;
  kuerzel: string;
  email: string;
  fachbereich: string;
  erfahrung: number;
  istKlassenlehrer: boolean;
}

export interface Klassenraum {
  id: number;
  name: string;
  raumInQm: number;
  plaetze: number;
  hasCynap: boolean;
}

export interface Frauenanteil {
  klasse: string;
  anteil: number;
}

export interface Geschlechterverteilung {
  geschlecht: string;
  anzahl: number;
}
