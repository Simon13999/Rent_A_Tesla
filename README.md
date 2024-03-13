Rent a Tesla

Rent a Tesla została stworzona z myślą o miłośnikach nowoczesnych technologii i ekologicznego trybu życia, którzy planują swoją podróż lub pobyt na pięknej wyspie Majorka. Nasza platforma oferuje wyjątkowe doświadczenie wynajmu luksusowych samochodów Tesla, łącząc w sobie wygodę, styl i troskę o środowisko naturalne.

Funkcje

1. Zakładka "Our Models"
	- dla niezalogowanych i zalogowanych na zwykłych kontach użytkowników zakładka umożliwia przeglądanie modeli posiadanych w wypożyczalniach.
	- administrator ma możliwość dodawania innych modeli oraz edycję i usuwanie już istniejących.
	- przy dodawaniu zdjęcia modelu samochodu należy je umieścić w "/images/cars".

2. Zakładka "Our Locations" 
	- podobnie jak w przypadku zakładki "Our Models" dla niezalogowanych i zalogowanych na zwykłych kontach użytkowników zakładka umożliwia przeglądanie lokalizacji wypożyczalni. Dodatkowo pokazuje jakie samochody znajdują się w poszczególnych wypożyczalniach i jaka jest cena ich wypożyczenia na dzień.
	- administrator ma możliwość dodawania innych lokalizacji oraz edycję i usuwanie już istniejących.
	- przy dodawaniu zdjęcia lokalizacji należy je tym razem umieścić w "/images/locations"

3. Zakładka "Reserve a Tesla!"
	- Pozwala zalogowanym użytkownikom dodawanie rezerwacji aut znajdujących się w wybranej lokalizacji i w wybranym terminie. Samochód po terminie rezerwacji będzie dostępny w miejscu zwrotu (ufamy wynajmującym, że oddadzą czyste i zatankowane auto). Po wybraniu Lokalizacji odebrania, zwrotu i czasu wynajmu pokażą nam się dostępne auta (jeżeli jest więcej takich samych modeli to będzie wyświetlony tylko jeden(zakładam, że samochody są dokłądnie takie same)). Po wybraniu auta pokaże nam się całkowity koszt wynajmu.
	- Ta zakładka wymaga zalogowania się

4. Zakładka "My reservations"
	- Dla zalogowanych użytkowników zakładka pokazuje wszystkie dokonane rezerwacje oraz daje możliwość usunięcia ich.
	- Dla konta admina daje wgląd we wszystkie rezerwacje wykonane przez użytkowników. Może je także usuwać. 
	- Dodatkowo ta zakładka pojawia się dopiero po zalogowaniu

5. Zakładka "Nasze auta"
	- Zakładka jest dostępna tylko dla admina
	- umożliwia przeglądanie samochodów, które są obecnie we wszystkich lokalizacjach, pokazując w jakich lokalizacjach się znajdują.
	- Admin może usuwać i dodawać samochody.
	- Przy dodawaniu samochodu możemy dodać zdjęcie samochodu, które jest haszowane i umieszczane bezpośrednio w folderze images.
6. Logowanie/Wylogowywanie i rejestracja
	- Umożliwia zalogowanie/wylogowanie użytkownika i rejestrację nowego użytkownika
	- Tylko rola Administratora została wyszczególniona.

Uruchomienie

1. Baza danych jest ustawiona na localdb. Można oczywiście użyć innej bazy danych, a poprzez seedery zawarte w projekcie modele samochodów i lokalizacje zawsze będą takie same. 
2. Poszczególne samochody musimy dodać logując się na konto admina. Ustawiamy podstawowe informacje, lokalizację początkową i dodajemy(lub nie) zdjęcie.
3. Aby zalogować się do konta admina używamy e-maila: admin1@admin.com i hasła:Qwe123!. Oczywiście możemy to zmienić w Program.cs
