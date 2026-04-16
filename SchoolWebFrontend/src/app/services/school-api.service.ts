import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  Frauenanteil,
  Geschlechterverteilung,
  Klassenraum,
  Lehrer,
  Schueler
} from '../models/school.models';

@Injectable({
  providedIn: 'root'
})
export class SchoolApiService {
  private readonly baseUrl = 'http://localhost:5296/api';

  constructor(private http: HttpClient) {}

  getSchueler(): Observable<Schueler[]> {
    return this.http.get<Schueler[]>(`${this.baseUrl}/Schueler`);
  }

  addSchueler(schueler: Partial<Schueler>): Observable<Schueler> {
    return this.http.post<Schueler>(`${this.baseUrl}/Schueler`, schueler);
  }

  getLehrer(): Observable<Lehrer[]> {
    return this.http.get<Lehrer[]>(`${this.baseUrl}/Lehrer`);
  }

  getKlassenraeume(): Observable<Klassenraum[]> {
    return this.http.get<Klassenraum[]>(`${this.baseUrl}/Klassenraum`);
  }

  getFrauenanteil(): Observable<Frauenanteil[]> {
    return this.http.get<Frauenanteil[]>(`${this.baseUrl}/Statistik/frauenanteil`);
  }

  getGeschlechterverteilung(): Observable<Geschlechterverteilung[]> {
    return this.http.get<Geschlechterverteilung[]>(`${this.baseUrl}/Statistik/geschlechterverteilung`);
  }
}
