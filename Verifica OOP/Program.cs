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
        public string nome;
        private string cognome;
        public string Nome
        {
            get => nome;
            set
            {
                if (value.Length > 2 || value != null)
                {
                    nome = value;
                }
                else
                {
                    Console.WriteLine("Nome troppo corto o non assegnato");
                }
            }
        }
        public string Cognome
        {
            get => cognome;
            set
            {
                if (value.Length > 2 || value != null)
                {
                    cognome = value;
                }
                else
                {
                    Console.WriteLine("Cognome troppo corto o non assegnato");
                }
            }
        }

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

        public Conto()
        {
            Euro = 0;
            Chiuso = true;
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
        private Conto[] conti = new Conto[100];
        public Banca()
        {
            for (int i = 0; i < 100; i++)
            {
                conti[i] = new Conto();
            }
        }
        public void ApriConto(string nomeTitolare)
        {
            for (int i = 0; i < 100; i++)
            {
                if (conti[i].Chiuso)
                {
                    conti[i].AzzeraConto();
                    conti[i].nome = nomeTitolare;
                    conti[i].Apri();
                    return;
                }
            }
            Console.WriteLine("Limite massimo di conti raggiunto.");
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
                float cifra = float.Parse(Console.ReadLine());
                conti[numeroConto - 1].Deposita(cifra);
            }

        }
        public void PrelevaDaConto()
        {
            Console.Write("Inserisci il numero del conto su cui vuoi prelevare soldi: ");
            if (int.TryParse(Console.ReadLine(), out int numeroConto) && numeroConto > 0)
            {
                Console.Write("Inserisci l'importo da prelevare: ");
                float cifra = float.Parse(Console.ReadLine());
                conti[numeroConto - 1].Preleva(cifra);
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
            Console.WriteLine("0. Esci");

            Console.Write("Scegli un'opzione: ");
            if (int.TryParse(Console.ReadLine(), out scelta))
            {
                switch (scelta)
                {
                    case 1:
                        Console.Write("Inserisci il nome del titolare del conto: ");
                        string nomeTitolare = Console.ReadLine();
                        banca.ApriConto(nomeTitolare);
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
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;

                }
            }
        } while (scelta != 0);
    }
}
