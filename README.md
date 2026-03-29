# Abysalto Test

**Kratki opis:**  
Testni projekt u kojem korisnik može upravljati narudžbama. Korisnik može dodavati nove narudžbe, pregledavati postojeće, mijenjati status narudžbi, izračunavati ukupni iznos računa i sortirati prikaz narudžbi prema ukupnom iznosu.

## Glavne funkcionalnosti
- Dodavanje novih narudžbi  
- Pregledavanje postojećih narudžbi  
- Mijenjanje statusa narudžbi  
- Izračunavanje ukupnog iznosa računa  
- Sortiranje prikaza narudžbi prema ukupnom iznosu  

## Tehnologije i alati
*Baza podataka je u Firebase-u*

## Instalacija
1. Nakon preuzimanja programa, potrebno je zamjeniti firebase-key.json koji se nalazi u programu sa firebase-key.json koji sam poslao na mail prilikom predaje testnog zadatka (Github ne dozvoljava push-anje file-ova unutar kojih postoje credentials). U slučaju komplikacija me možete kontaktirati.
2. Pokrenite PowerShell i pokrenite program:
   ```
   dotnet run --project "...\PutanjaPrograma\AbySalto.Junior.csproj"
   ```
   Npr. u mom slučaju je to
   ```
   dotnet run --project "E:\AbysaltoTest\AbysaltoTest\AbySalto.Junior\AbySalto.Junior.csproj"
   ```
3. Prilikom pokretanja možete vidjeti poruku "Connected to database: True" što znači da je program povezan na bazu podataka. Otvorite link od localhost-a koji vam program ponudi

## Primjer 
<img width="1276" height="247" alt="image" src="https://github.com/user-attachments/assets/c0c7c9db-f359-4cab-be17-4b990acd53d6" />


