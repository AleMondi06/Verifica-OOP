using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verifica_OOP;

namespace Verifica_OOP
{
    class Persona
    {
        private bool IsValidName(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length > 2;
        }

        public string nome;
        public string Nome
        {
            get => nome;
            set
            {
                if (IsValidName(value))
                {
                    nome = value;
                }
                else
                {
                    Console.WriteLine("Cognome troppo corto o non assegnato");
                }
            }
        }
        public string Provincia { get; set; }
    }
    class Conto : Persona
    {

        private double euro;
        private bool chiuso;

        public double Euro
        {
            get { return euro; }
            set { euro = value; }
        }

        public bool Chiuso
        {
            get { return chiuso; }
            set { chiuso = value; }
        }

        public Conto(string _provincia)
        {
            Euro = 0;
            Chiuso = true;
            Provincia = _provincia;
        }
        public void AzzeraConto()
        {
            euro = 0;
            chiuso = true;
        }

        public void Apri()
        {
            Chiuso = false;
        }

        public void Deposita(float cifra)
        {
            if (!chiuso)
                euro += cifra;
        }

        public void Preleva(float cifra)
        {
            if (!chiuso && euro >= cifra)
                euro -= cifra;
        }

        public double Saldo()
        {
            Console.WriteLine($"Il saldo dell' account del signor {Nome}, è di {Euro}");
            return Euro;
        }

        public void Chiusura()
        {
            chiuso = true;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Nome: {Nome}");
            if (chiuso == false)
            {
                Console.WriteLine($"Saldo: {euro} Euro , Stato: Aperto");
            }
            else
                Console.WriteLine("Stato: chiuso");
        }
    }
    class Banca
    {
        private bool IsValidName(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length > 2;
        }

        private Conto[] conti = new Conto[100];
        public Banca()
        {
            for (int i = 0; i < 100; i++)
            {
                conti[i] = new Conto("ProvinciaDiDefault"); // Puoi impostare una provincia di default o chiedere all'utente di inserirla.
            }
        }
        public void ApriConto(string nomeTitolare, string provincia)
        {
            if (IsValidName(nomeTitolare))
            {
                for (int i = 0; i < 100; i++)
                {
                    if (conti[i].Chiuso)
                    {
                        conti[i].AzzeraConto();
                        conti[i].Nome = nomeTitolare;
                        conti[i].Provincia = provincia;
                        conti[i].Apri();
                        return;
                    }
                }
                Console.WriteLine("Limite massimo di conti raggiunto.");
            }
            else
            {
                Console.WriteLine("Nome del titolare del conto non valido.");
            }
        }
        public void ChiudiConto()
        {
            Console.Write("Inserisci il numero del conto da chiudere: ");
            if (int.TryParse(Console.ReadLine(), out int numeroConto) && numeroConto > 0)
            {
                conti[numeroConto - 1].Chiusura();
            }
        }
        public void DepositaSuConto()
        {
            Console.Write("Inserisci il numero del conto su cui vuoi aggiungere soldi: ");
            if (int.TryParse(Console.ReadLine(), out int numeroConto) && numeroConto > 0)
            {
                Console.Write("Inserisci l'importo da depositare: ");
                if (float.TryParse(Console.ReadLine(), out float cifra) && cifra > 0)
                {
                    conti[numeroConto - 1].Deposita(cifra);
                }
                else
                {
                    Console.WriteLine("Importo non valido.");
                }
            }
        }
        public void PrelevaDaConto()
        {
            Console.Write("Inserisci il numero del conto su cui vuoi prelevare soldi: ");
            if (int.TryParse(Console.ReadLine(), out int numeroConto) && numeroConto > 0)
            {
                Console.Write("Inserisci l'importo da prelevare: ");
                if (float.TryParse(Console.ReadLine(), out float cifra) && cifra > 0)
                {
                    conti[numeroConto - 1].Preleva(cifra);
                }
                else
                {
                    Console.WriteLine("Importo non valido.");
                }
            }
        }
        public void VediSaldoConto()
        {
            Console.Write("Inserisci il numero del conto su cui vuoi vedere i soldi: ");
            if (int.TryParse(Console.ReadLine(), out int numeroConto) && numeroConto > 0)
            {
                conti[numeroConto - 1].Saldo();
            }
        }
        public void VediInfoConto()
        {
            Console.Write("Inserisci il numero del conto di cui vedere le informazioni: ");
            if (int.TryParse(Console.ReadLine(), out int numeroConto) && numeroConto > 0)
            {
                conti[numeroConto - 1].GetInfo();
            }
        }
        public double SaldoTotaleProvincia(string provincia)
        {
            double saldoTotale = 0;

            foreach (Conto conto in conti)
            {
                if (!conto.Chiuso && conto.Nome != null && conto.Provincia == provincia)
                {
                    saldoTotale += conto.Euro;
                }
            }

            Console.WriteLine($"Il saldo totale per la provincia {provincia} è di {saldoTotale} Euro.");
            return saldoTotale;
        }
    }
    }

class Program
{
    static void Main()
    {
        Banca banca = new Banca();
        int scelta;

        do
        {
            Console.WriteLine("1. Apri Conto");
            Console.WriteLine("2. Chiudi Conto");
            Console.WriteLine("3. Deposita su Conto");
            Console.WriteLine("4. Preleva da Conto");
            Console.WriteLine("5. Vedi Saldo Conto");
            Console.WriteLine("6. Vedi Info Conto");
            Console.WriteLine("7. Vedi Saldo totale di una provincia");
            Console.WriteLine("0. Esci");

            Console.Write("Scegli un'opzione: ");
            if (int.TryParse(Console.ReadLine(), out scelta))
            {
                switch (scelta)
                {
                    case 1:
                        Console.Write("Inserisci il nome del titolare del conto: ");
                        string nomeTitolare = Console.ReadLine();
                        Console.Write("Inserisci la provincia del titolare del conto: ");
                        string provinciaTitolare = Console.ReadLine();
                        banca.ApriConto(nomeTitolare, provinciaTitolare);
                        break;
                    case 2:
                        banca.ChiudiConto();
                        break;
                    case 3:
                        banca.DepositaSuConto();
                        break;
                    case 4:
                        banca.PrelevaDaConto();
                        break;
                    case 5:
                        banca.VediSaldoConto();
                        break;
                    case 6:
                        banca.VediInfoConto();
                        break;
                    case 7:
                        Console.Write("Inserisci il nome della provincia: ");
                        string provincia = Console.ReadLine();
                        banca.SaldoTotaleProvincia(provincia);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Inserisci un numero valido.");
            }
        } while (scelta != 0);
    }
}
