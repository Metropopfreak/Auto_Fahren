using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Auto_Fahren
{
    class Program
    {
        static void Main(string[] args)
        {
            // boolsche Werte der Laufzeitschleife
            bool wahl = false;
            bool blVelo = false;
            Auto auto = new Auto();

            // Eingabe der MaxGeschwindigkeit
            while (blVelo == false)
            {
                try
                {
                    Write("Bitte gib die Maximalgeschwindigkeit ein: ");
                    auto.MaxGeschwindigkeit = Convert.ToUInt32(ReadLine());
                    blVelo = true;
                }
                catch (FormatException)
                {
                    WriteLine("Fehler: Bitte gib eine ganze positive Zahl ein.");
                }
                catch (Exception)
                {
                    WriteLine("Fehler: Bitte gib eine ganze positive Zahl ein.");
                }
            }
            // Programschliefe

            while (wahl == false)
            {
                WriteLine("Bitte wähle (M)otor an, M(o)tor aus, (G)as geben oder (B)remsen." +
                    "\nDrücke Q zum Beenden");
                WriteLine($"Dein Fahrzeug fährt mit {auto.Geschwindigkeit} km/h.");
                // ConsoleKeyInfo 
                ConsoleKeyInfo key = ReadKey();
                Clear();
                switch (key.Key)
                {
                    case ConsoleKey.M:
                        auto.MotorAn();
                        break;
                    case ConsoleKey.O:
                        auto.MotorAus();
                        break;
                    case ConsoleKey.G:
                        auto.GasGeben();
                        break;
                    case ConsoleKey.B:
                        auto.Bremsen();
                        break;
                    case ConsoleKey.Q:
                        wahl = true;
                        break;
                    default:
                        break;
                }
            }
            WriteLine("Programm wurde beendet.");
            ReadKey();
        }
    }
    
    class Auto
    {
        // private Variablen - die werden nur innerhalb der Klasse benutzt
        // uint -> unary integer: Natürliche Zahlen mit 0 
        private uint geschwindigkeit = 0;
        private uint maxGeschwindigkeit;
        private bool motorAn = false;

        // Eigenschaften
        public uint Geschwindigkeit
        {
            get
            {
                // liest die private Variable geschwindigkeit
                WriteLine("Eigenschaft Geschwindigkeit wurde gelesen");
                return geschwindigkeit;
            }
        }

        public uint MaxGeschwindigkeit
        {
            get
            {
                // liest die private Variable maxGeschwindigkeit
                WriteLine("Eigenschaft MaxGeschwindigkeit wurde gelesen");
                return maxGeschwindigkeit;
            }
            set 
            {
                // schreibt in die private Variable maxGeschwindigkeit
                WriteLine("Eigeschaft MaxGeschwindigkeit wurde geschrieben");
                maxGeschwindigkeit = value;
            }
        }

        // Methoden - Es passiert was 
        public void GasGeben()
        {
            if (motorAn == true)
            {
                if (geschwindigkeit < maxGeschwindigkeit)
                {
                    geschwindigkeit++;
                    WriteLine($"Beschleunigt auf {geschwindigkeit} km/h.");
                }
                else
                {
                    WriteLine("Maximale Geschwindigkeit erreicht.");
                }
            }
            else
            {
                WriteLine("Der Motor ist aus. Schalte den Motor an.");
            }
        }

        public void Bremsen()
        {
            if (geschwindigkeit > 0)
            {
                geschwindigkeit--;
                WriteLine($"Gebremst auf {geschwindigkeit} km/h.");
            }
            else
            {
                WriteLine("Dein Fahrzeug ist stehen geblieben.");
            }
        }

        public void MotorAn()
        {
            if (motorAn == false)
            {
                motorAn = true;
                WriteLine("Du hast den Motor eingeschaltet.");
            }
            else
            {
                WriteLine("Der Motor ist bereits an.");
            }
        }

        public void MotorAus()
        {
            if (motorAn == true)
            {
                if (geschwindigkeit == 0)
                {
                    motorAn = false;
                    WriteLine("Du hast den Motor ausgeschaltet.");
                }
                else
                {
                    WriteLine("Du musst erst zum stehen kommen.");
                }
            }
            else
            {
                WriteLine("Der Motor ist bereits aus.");
            }
        }
    }
}
