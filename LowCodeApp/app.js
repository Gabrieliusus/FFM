const lehrer = [
  { name: 'Müller Martin', fach: 'Informatik' },
  { name: 'Huber Anna', fach: 'Mathematik' },
  { name: 'Gruber Thomas', fach: 'Deutsch' }
];

const raeume = [
  { name: 'E101', plaetze: 24 },
  { name: 'E202', plaetze: 28 },
  { name: 'Labor 1', plaetze: 18 }
];

let schueler = JSON.parse(localStorage.getItem('schueler')) || [
  { name: 'Max Mustermann', klasse: '3AHIF', geschlecht: 'männlich' },
  { name: 'Anna Beispiel', klasse: '3AHIF', geschlecht: 'weiblich' }
];

function speichern() {
  localStorage.setItem('schueler', JSON.stringify(schueler));
}

function anzeigen() {
  document.getElementById('anzahlSchueler').textContent = schueler.length;
  document.getElementById('anzahlLehrer').textContent = lehrer.length;
  document.getElementById('anzahlRaeume').textContent = raeume.length;

  const tbody = document.getElementById('schuelerTabelle');
  tbody.innerHTML = '';

  schueler.forEach((eintrag, index) => {
    const zeile = document.createElement('tr');
    zeile.innerHTML = `
      <td>${eintrag.name}</td>
      <td>${eintrag.klasse}</td>
      <td>${eintrag.geschlecht}</td>
      <td><button onclick="loeschen(${index})">Löschen</button></td>
    `;
    tbody.appendChild(zeile);
  });

  const lehrerListe = document.getElementById('lehrerListe');
  lehrerListe.innerHTML = '';
  lehrer.forEach(l => {
    const li = document.createElement('li');
    li.textContent = `${l.name} (${l.fach})`;
    lehrerListe.appendChild(li);
  });

  const raumListe = document.getElementById('raumListe');
  raumListe.innerHTML = '';
  raeume.forEach(r => {
    const li = document.createElement('li');
    li.textContent = `${r.name}: ${r.plaetze} Plätze`;
    raumListe.appendChild(li);
  });
}

function loeschen(index) {
  schueler.splice(index, 1);
  speichern();
  anzeigen();
}

document.getElementById('schuelerForm').addEventListener('submit', event => {
  event.preventDefault();

  const neuerSchueler = {
    name: document.getElementById('name').value,
    klasse: document.getElementById('klasse').value,
    geschlecht: document.getElementById('geschlecht').value
  };

  schueler.push(neuerSchueler);
  speichern();
  event.target.reset();
  anzeigen();
});

anzeigen();
