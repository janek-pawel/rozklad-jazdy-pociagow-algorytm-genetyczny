# Program do wyliczania rozkładów jazdy przy wykorzystaniu algorytmu genetycznego

Program wykonany przy wykorzystaniu pracy autorstwa P. Tormosa (A Genetic Algorithm for Railway Scheduling Problems), wykonany w ramach zajęć na uczelni
Jest to program, który wylicza sposób najszybszego przejazdu wielu pociągów na linii jednotorowej, gdzie pociągi starają się jak najszybciej przejechać w najkrótszym czasie.

Program działa jako .exe, oraz został wykonany w C#. Zarazem wymaga języka Python z matplotlib do wyświetlania wykresu wartości fitness

Znane błędy:
- Brak limitu pojemności na stacjach, przez co wiele pociągów naraz zatrzymuje się na jednej stacji. W przypadku dalszego rozwinięcia programu dodałbym do programu funkcjonalności związaną z ilością torów na stacjach

Funkcjonalnościo związane z krzyżowaniem jak i mutacją są bazowane na funkcjach wspomnianych w pracy.
