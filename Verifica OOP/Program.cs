using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verifica_OOP
{
    class Persona
    {
        private string Nome;
        private string Cognome;
        public string _Nome
        {
            get => Nome;
            set
            {
                if (value.Length > 2 || value != null)
                {
                    Nome = value;
                }
                else
                {
                    Console.WriteLine("Nome troppo corto o non assegnato");
                }
            }
        }
        public string _Cognome
        {
            get => Cognome;
            set
            {
                if (value.Length > 2 || value != null)
                {
                    Cognome = value;
                }
                else
                {
                    Console.WriteLine("Nome troppo corto o non assegnato");
                }
            }
        }
       
    }
    class Conto : Persona
    {
        private double Saldo;
        
        public double _Saldo
        {
            get => Saldo;
            set
            {
                if (value > 0  )
                {
                    Saldo = value;
                }
                else
                {
                    Console.WriteLine("Inserire un saldo maggiore di 0");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Persona p1 = new Persona { };
            p1._Nome = "Alessio";
        }
    }
}
