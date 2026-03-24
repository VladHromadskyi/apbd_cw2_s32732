# System Wypożyczalni Sprzętu - APBD Ćwiczenia 3

Projekt przedstawia system konsolowy do zarządzania wypożyczaniem sprzętu uniwersyteckiego (Laptopy, Aparaty, Projektory) dla Studentów oraz Pracowników.

## Decyzje Projektowe i Zasady SOLID

Architektura systemu została zaprojektowana zgodnie z zasadami **SOLID** oraz wzorcami czystego kodu:

### 1. Single Responsibility Principle (SRP) - Zasada jednej odpowiedzialności
* **Modele (Models):** Przechowują jedynie dane (np. `User`, `Equipment`).
* **RentalManager:** Odpowiada wyłącznie za logikę biznesową (walidacja limitów, proces wypożyczania).
* **PenaltyCalculator:** Dedykowany serwis do obliczania kar za opóźnienia.

### 2. Open/Closed Principle (OCP) - Zasada otwarte-zamknięte
System jest łatwo rozszerzalny bez modyfikacji istniejącego kodu:
* Aby dodać nowy typ sprzętu (np. **Tablet**), wystarczy stworzyć nową klasę dziedziczącą po `Equipment`.
* Aby zmienić sposób naliczania kar, można stworzyć nową klasę implementującą interfejs `IPenaltyCalculator`.

### 3. Liskov Substitution Principle (LSP) - Zasada podstawienia Liskov
Klasa `RentalManager` operuje na bazowej klasie `User`. Dzięki temu, że `Student` i `Employee` nadpisują właściwość `MaxRentalLimit`, menedżer traktuje ich polimorficznie, nie musząc znać ich konkretnego typu.

### 4. Dependency Inversion Principle (DIP) - Zasada odwrócenia zależności
`RentalManager` nie zależy od konkretnej implementacji kalkulatora, lecz od interfejsu `IPenaltyCalculator`. Umożliwia to łatwą wymianę logiki naliczania opłat (np. inne stawki dla weekendów).

## Zaimplementowane Funkcjonalności
* **Limity wypożyczeń:** Studenci mogą wypożyczyć do 2 przedmiotów, Pracownicy do 5.
* **Śledzenie dostępności:** System blokuje wypożyczenie przedmiotu, który jest już zajęty.
* **Automatyczne kary:** Obliczanie opłat za zwrot po terminie przy użyciu typu `decimal` dla zachowania precyzji finansowej.
* **Raportowanie:** Statystyki systemu oraz ostrzeżenia o przekroczonych terminach w konsoli.

## Przepływ Pracy Git (Git Workflow)
Projekt realizowany był z wykorzystaniem gałęzi funkcjonalnych (feature branches):
* `feature/domain-models`: Struktura klas i modeli danych.
* `feature/rental-logic`: Implementacja serwisów i logiki biznesowej.
