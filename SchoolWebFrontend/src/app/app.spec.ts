import { of } from 'rxjs';
import { TestBed } from '@angular/core/testing';
import { App } from './app';
import { SchoolApiService } from './services/school-api.service';

class SchoolApiMock {
  getSchueler() {
    return of([]);
  }

  getLehrer() {
    return of([]);
  }

  getKlassenraeume() {
    return of([]);
  }

  getFrauenanteil() {
    return of([]);
  }

  getGeschlechterverteilung() {
    return of([]);
  }

  addSchueler() {
    return of({});
  }
}

describe('App', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [App],
      providers: [
        { provide: SchoolApiService, useClass: SchoolApiMock }
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(App);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should render title', async () => {
    const fixture = TestBed.createComponent(App);
    fixture.detectChanges();
    await fixture.whenStable();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Schulverwaltung');
  });
});
