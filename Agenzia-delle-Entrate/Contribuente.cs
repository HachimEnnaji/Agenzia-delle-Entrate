using System;

namespace Agenzia_delle_Entrate
{
    internal class Contribuente
    {
        // Proprietà della classe
        private string _nome;
        public string Nome
        {
            get => _nome; set => _nome = value;
        }

        private string _cognome;

        public string Cognome
        {
            get => _cognome; set => _cognome = value;
        }
        private DateTime _dataNascita;
        public DateTime DataNascita
        {
            get => _dataNascita; set => _dataNascita = value;
        }
        private string _codiceFiscale;
        public string CodiceFiscale
        {
            get => _codiceFiscale; set => _codiceFiscale = value;
        }
        private string _sesso;
        public string Sesso
        {
            get => _sesso; set => _sesso = value;
        }
        private string _comuneResidenza;
        public string ComuneResidenza
        {
            get => _comuneResidenza; set => _comuneResidenza = value;
        }
        private double _redditoAnnuale;
        public double RedditoAnnuale

        {
            get => _redditoAnnuale; set => _redditoAnnuale = value;
        }
        private double _imposta;
        public double Imposta
        {
            get => _imposta; set => _imposta = value;
        }

        // Metodo per calcolare l'imposta in base al reddito annuale
        public void CalcolaAliquota()
        {
            switch (RedditoAnnuale)
            {
                case double value when value >= 0 && value <= 15000:
                    Imposta = RedditoAnnuale * 23 / 100;
                    break;
                case double value when value > 15000 && value <= 28000:
                    Imposta = 3450 + ((RedditoAnnuale - 15000) * 27 / 100);
                    break;
                case double value when value > 28000 && value <= 55000:
                    Imposta = 6960 + ((RedditoAnnuale - 28000) * 38 / 100);
                    break;
                case double value when value > 55000 && value <= 75000:
                    Imposta = 17220 + ((RedditoAnnuale - 55000) * 41 / 100);
                    break;
                case double value when value > 75000:
                    Imposta = 25420 + ((RedditoAnnuale - 75900) * 43 / 100);
                    break;
                default:
                    break;
            }

            // Output delle informazioni sul contribuente
            Console.WriteLine($"\nContribuente: {CapitalizeFirstLetter(Nome)} {CapitalizeFirstLetter(Cognome)}");
            Console.WriteLine($"\nNato il: {DataNascita.ToString("dd/MM/yyyy")} ({CapitalizeFirstLetter(Sesso)})");
            Console.WriteLine($"\nResidente in: {CapitalizeFirstLetter(ComuneResidenza)}");
            Console.WriteLine($"\nCodice Fiscale: {CodiceFiscale.ToUpper()}\n");
            Console.WriteLine($"\nReddito Lordo Dichiarato: {RedditoAnnuale} Euro");
            Console.WriteLine($"\nReddito Netto: {RedditoAnnuale - Imposta} Euro\n");
            Console.WriteLine($"\nIMPOSTA DA VERSARE: {Imposta} Euro\n");


        }

        // Metodo statico per rendere maiuscola la prima lettera di una stringa
        //paramtro in entrata stringa con la prima lettera da rendere maiuscola
        //ritorna prima lettera Maiuscola
        public static string CapitalizeFirstLetter(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return char.ToUpper(input[0]) + input.Substring(1);
            }
            else
            {
                return input;
            }
        }
    }
}
