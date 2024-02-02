using System;
using System.Linq;

namespace Agenzia_delle_Entrate
{
    internal class AgenziaDelleEntrate
    {
        // Metodo per visualizzare un messaggio di benvenuto e gestire la registrazione
        public static void Benvenuto()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("A G E N Z I A  D E L L E  E N T R A T E");
            Console.WriteLine("=======================================\n");

            Console.Write("Benvenuto allo sportello, vuoi registrarti? y/n \t");
            string sceltaRegistrazione = Console.ReadLine();

            if (sceltaRegistrazione?.ToLower() == "y")
            {
                Registrazione(); // Se la risposta è 'y', avvia il processo di registrazione
            }
            else
            {
                Console.WriteLine("Arrivederci, premi un tasto per chiudere lo sportello.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        // Metodo per la registrazione di un nuovo contribuente
        //parametri nessuno
        //ritorna il valore inserito da input se corretto
        public static void Registrazione()
        {
            Contribuente cittadino = new Contribuente(); // Creazione di un nuovo oggetto Contribuente

            Console.Write("\nInserire il nome:\t");
            cittadino.Nome = CheckString(); // Chiamata al metodo per verificare la correttezza del nome

            Console.Write("\nInserire il cognome:\t");
            cittadino.Cognome = CheckString(); // Chiamata al metodo per verificare la correttezza del cognome

            cittadino.DataNascita = CheckData(); // Chiamata al metodo per verificare la correttezza della data di nascita

            cittadino.CodiceFiscale = CheckCodiceFiscale(); // Chiamata al metodo per verificare la correttezza del codice fiscale

            cittadino.Sesso = CheckSesso(); // Chiamata al metodo per verificare la correttezza del sesso

            Console.WriteLine(cittadino.CodiceFiscale); // Stampa del codice fiscale inserito

            Console.WriteLine("\nPrego inserire il Comune di Residenza: \t");
            cittadino.ComuneResidenza = CheckString(); // Chiamata al metodo per verificare la correttezza del comune di residenza

            cittadino.RedditoAnnuale = CheckReddito(); // Chiamata al metodo per verificare la correttezza del reddito annuale

            cittadino.CalcolaAliquota(); // Calcolo dell'imposta in base al reddito annuale

            MenuDiUscita();
        }

        // Metodo per verificare che una stringa contenga solo caratteri alfabetici
        //parametri nessuno
        //ritorna il valore inserito da input se corretto
        public static string CheckString()
        {
            string input = Console.ReadLine();

            if (input != null && input.All(char.IsLetter))
            {
                return input;
            }
            else
            {
                Console.WriteLine("\nValore errato, prego inserire solo caratteri alfabetici");
                return CheckString(); // Se l'input non è corretto, richiama ricorsivamente il metodo
            }
        }

        // Metodo per verificare la correttezza della data di nascita
        //parametri nessuno
        //ritorna il valore inserito da input se corretto
        public static DateTime CheckData()
        {
            Console.Write("\nInserire data di nascita:\t");
            Console.Write("Formato accettato  GG/MM/YYYY \t");
            DateTime input;

            // Ciclo finché l'input non è valido
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out input) || input.Year > 2006 || input > DateTime.Now)
            {
                if (input > DateTime.Now)
                {
                    Console.WriteLine("\nPurtroppo o fortunatamente nel futuro non calcoliamo più le imposte!");
                }
                else if (input.Year > 2006)
                {
                    Console.WriteLine("\nNon puoi procedere, sei ancora minorenne!");
                }
                else
                {
                    Console.WriteLine("\nData di nascita non valida !");
                }
                Console.WriteLine("Prego reinserire la data di nascita nel formato GG/MM/YYYY");
            }

            return input; // Restituisce la data valida
        }

        // Metodo per verificare la correttezza del codice fiscale
        //parametri nessuno
        //ritorna il valore inserito da input se corretto
        public static string CheckCodiceFiscale()
        {
            Console.Write("\nInserire codice fiscale:\t");
            string input = Console.ReadLine();

            if (input != null && input.Length == 16)
            {
                return input;
            }
            else
            {
                Console.WriteLine("Errore: Codice fiscale non valido.");
                Console.Write("\nPrego reinserire il codice fiscale:\t deve essere di 16 cifre: \t");
                return CheckCodiceFiscale(); // Se l'input non è corretto, richiama ricorsivamente il metodo
            }
        }

        // Metodo per verificare la correttezza del sesso
        //parametri nessuno
        //ritorna il valore inserito da input se corretto
        public static string CheckSesso()
        {
            Console.Write("\nInserire Sesso:\t");
            string input = Console.ReadLine();

            if (input.ToLower() == "maschio" || input.ToLower() == "femmina" || input.ToLower() == "m" || input.ToLower() == "f")
            {
                return input;
            }
            else
            {
                Console.WriteLine("Errore: Sesso non valido.");
                Console.Write("\nPrego reinserire il Sesso:\t");
                return CheckSesso(); // Se l'input non è corretto, richiama ricorsivamente il metodo
            }
        }

        // Metodo per verificare la correttezza del reddito annuale
        //parametri nessuno
        //ritorna il valore inserito da input se corretto
        public static double CheckReddito()
        {
            try
            {
                Console.WriteLine("\nInserire il proprio reddito annuale");
                double input = Convert.ToDouble(Console.ReadLine());

                if (input >= 0)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Valore errato o inferiore a 0, prego riprovare");
                    return CheckReddito(); // Se l'input non è corretto, richiama ricorsivamente il metodo
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore di formato. Inserisci un valore numerico.");
                return CheckReddito(); // Se si verifica un'eccezione di formato, richiama ricorsivamente il metodo
            }
            catch (OverflowException)
            {
                Console.WriteLine("Errore di overflow. Inserisci un valore più piccolo.");
                return CheckReddito(); // Se si verifica un'eccezione di overflow, richiama ricorsivamente il metodo
            }
        }

        // Metodo statico per gestire l'opzione di uscita o ricominciare il processo di registrazione
        //parametri nessuno
        public static void MenuDiUscita()
        {
            // Chiede all'utente se desidera ricalcolare le imposte
            Console.WriteLine("Vuoi Ricalcolare le tue imposte? \t y/n");
            string response = Console.ReadLine();

            // Verifica la risposta dell'utente in minuscolo per rendere la verifica case-insensitive
            if (response.ToLower() == "y")
            {
                // Se l'utente sceglie 'y', avvia nuovamente il processo di registrazione
                Registrazione();
            }
            else if (response.ToLower() == "n")
            {
                // Se l'utente sceglie 'n', visualizza un messaggio di arrivederci e chiude l'applicazione
                Console.WriteLine("\nArrivederci!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                // Se l'utente inserisce una risposta non valida ricorsione
                Console.WriteLine("\nSelezione non valida, si prega di riprovare!");
                MenuDiUscita();
            }
        }

    }
}
