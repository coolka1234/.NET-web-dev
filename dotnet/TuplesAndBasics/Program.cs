// See https://aka.ms/new-console-template for more information

using System;
using System.ComponentModel;
using System.Numerics;

namespace Lista6
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            (String imie, String nazwisko, int wiek, int placa) krotka = ("Krzysztof", "Kulka", 21, 0);
            tuple(krotka);
            int @class = 365;
            Console.WriteLine($"wartość zmiennej class: {@class}");
            TestSystemArrays();
            an_tuple();
            Console.WriteLine();
            DrawCard("Krzychu", "Kula", 'O',headerPadding: 5, lowerPadding: 2);
            DrawCard();
            CountMyTypes2("skibidi, 3.14, 23.34, 0, 5.78");

        }

        static void tuple((String imie, String nazwisko, int wiek, int placa) tuple)
        {
            var (imie, nazwisko, wiek, placa) = (tuple.imie, tuple.nazwisko, tuple.wiek, tuple.placa);

            Console.WriteLine($"imie: {tuple.Item1}, nazwisko: {tuple.Item2}, wiek: {tuple.Item3}, placa: {tuple.Item4}");
            Console.WriteLine($"imie: {tuple.imie}, nazwisko: {tuple.nazwisko}, wiek: {tuple.wiek}, placa: {tuple.placa}");
            Console.WriteLine($"imie: {imie}, nazwisko: {nazwisko}, wiek: {wiek}, placa: {placa}");
        }

        static void TestSystemArrays()
        {
            int[] numbers = { 7, 0, 2, 1, 2, 5 };
            Console.WriteLine("Tablica przed sortowaniem: " + string.Join(", ", numbers));
            Array.Sort(numbers);

            Console.WriteLine("Posortowana tablica: " + string.Join(", ", numbers));
            System.Console.WriteLine("Typ tablicy: " + numbers.GetType());

            string[] animals = { "Cat", "Dog", "Maupa" };
            Console.WriteLine("Tablica przed odwróceniem: " + string.Join(", ", animals));
            Array.Reverse(animals);
            Console.WriteLine("Tablica po odwróceniu: " + string.Join(", ", animals));

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            Console.WriteLine("Tablica: " + string.Join(", ", vowels));
            int indexOfI = Array.IndexOf(vowels, 'i');
            Console.WriteLine("Indeks elementu 'i': " + indexOfI);
            double[] prices = { 21.37, 2.0, 13.13, 5.50 };

            Console.WriteLine("Tablica: " + string.Join(", ", prices));

            Array.Clear(prices, 1, 2);

            Console.WriteLine("Tablica po czyszczeniu: " + string.Join(", ", prices));


            string[] sourceArray = { "one", "two", "three", "four" };

            Console.WriteLine("Tablica: " + string.Join(", ", sourceArray));
    
            string[] destinationArray = new string[sourceArray.Length];

            Array.Copy(sourceArray, destinationArray, sourceArray.Length);

            Console.WriteLine("Skopiowana tablica: " + string.Join(", ", destinationArray));
        }

        static void an_tuple()
        {
            var anonimowa = new { imie = "Krzychu", nazwisko = "Kulcia", wiek = 21, placa = 99999 };

            Console.WriteLine($"imie: {anonimowa.imie}, nazwisko: {anonimowa.nazwisko}, wiek: {anonimowa.wiek}, placa: {anonimowa.placa}");
        }

        static void DrawCard(String pierwszaLinia="Janusz", String drugaLinia = "Kowalski", Char znak = 'X', int szer = 2, int minOverallWidth = 20, int headerPadding = 1, int lowerPadding = 1)
        {
            char[] pierwszaLiniaZeSpacjami = new char[pierwszaLinia.Length * 2 - 1];
            for (int i = 0; i < pierwszaLinia.Length; i++)
            {
                pierwszaLiniaZeSpacjami[i * 2] = pierwszaLinia[i];
                if (i < pierwszaLinia.Length - 1)
                {
                    pierwszaLiniaZeSpacjami[i * 2 + 1] = ' ';
                }
            }

            pierwszaLinia = new String(pierwszaLiniaZeSpacjami);

            char[] drugaLiniaZeSpacjami = new char[drugaLinia.Length * 2 - 1];
            for (int i = 0; i < drugaLinia.Length; i++)
            {
                drugaLiniaZeSpacjami[i * 2] = drugaLinia[i];
                if (i < drugaLinia.Length - 1)
                {
                    drugaLiniaZeSpacjami[i * 2 + 1] = ' ';
                }
            }

            drugaLinia = new string(drugaLiniaZeSpacjami);

            int wolneMiejsce = minOverallWidth - (2 * szer);

            int wolneMiejsce1 = wolneMiejsce - pierwszaLinia.Length;

            int wolneMiejsce2 = wolneMiejsce - drugaLinia.Length;

            int[] miejsca = { wolneMiejsce1, wolneMiejsce2 };
            String[] linie = {pierwszaLinia, drugaLinia };

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < minOverallWidth; j++)
                {
                    Console.Write(znak.ToString());
                }
                Console.Write("\n");
            }

            for (int j=0; j<headerPadding;j++)
            {
                for (int i = 0; i < szer; i++)
                {
                    Console.Write(znak.ToString());
                }

                for (int i = 0; i < wolneMiejsce; i++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < szer; i++)
                {
                    Console.Write(znak.ToString());
                }

                Console.Write("\n");
            }
            

            for (int j=0;j<linie.Length;j++)
            {
                for (int i = 0; i < szer; i++)
                {
                    Console.Write(znak.ToString());
                }

                if (miejsca[j] % 2 == 0)
                {
                    for (int i = 0; i < miejsca[j] / 2; i++)
                    {
                        Console.Write(" ");
                    }
                    
                    Console.Write(linie[j]);

                    for (int i = 0; i < miejsca[j] / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    for (int i = 0; i < (miejsca[j] / 2) + 1; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(linie[j]);
                    for (int i = 0; i < miejsca[j] / 2; i++)
                    {
                        Console.Write(" ");
                    }
                }

                for (int i = 0; i < szer; i++)
                {
                    Console.Write(znak.ToString());
                }
                Console.Write("\n");
            }

            for (int j = 0; j < lowerPadding; j++)
            {
                for (int i = 0; i < szer; i++)
                {
                    Console.Write(znak.ToString());
                }

                for (int i = 0; i < wolneMiejsce; i++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < szer; i++)
                {
                    Console.Write(znak.ToString());
                }

                Console.Write("\n");
            }

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < minOverallWidth; j++)
                {
                    Console.Write(znak.ToString());
                }
                Console.Write("\n");
            }
        }

        static void CountMyTypes(String ciag)
        {
            string[] elementy = ciag.Split(',');

            int licznikLiczbyCalkowite = 0;
            int licznikLiczbyPrzecinkowe = 0;
            int licznikNapisy = 0;
            int licznikInne = 0;

            foreach(var element in elementy)
            {
                string cleanedElement = element.Trim();

                switch (GetElementType(cleanedElement))
                {
                    case ElementType.Integer:
                        licznikLiczbyCalkowite++;
                        break;

                    case ElementType.Double:
                        licznikLiczbyPrzecinkowe++;
                        break;

                    case ElementType.String:
                        licznikNapisy++;
                        break;

                    default:
                        licznikInne++;
                        break;
                }
            }

            Console.WriteLine($"Ilość liczb całkowitych: {licznikLiczbyCalkowite}");
            Console.WriteLine($"Ilość liczb rzeczywistych: {licznikLiczbyPrzecinkowe}");
            Console.WriteLine($"Ilość napisów: {licznikNapisy}");
            Console.WriteLine($"Inne: {licznikInne}");
        }
        static void CountMyTypes2(string ciag){
            string[] elementy = ciag.Split(',');
            int licznikLiczbyCalkowite = 0;
            int licznikLiczbyPrzecinkowe = 0;
            int licznikNapisy = 0;
            int licznikInne = 0;
            foreach (var element in elementy)
            {
                string cleanedElement = element.Trim();
                switch (GetElementType(cleanedElement))
                {
                    case ElementType.Integer:
                        licznikLiczbyCalkowite++;
                        break;
                    case ElementType.Double:
                        licznikLiczbyPrzecinkowe++;
                        break;
                    case ElementType.String:
                        licznikNapisy++;
                        break;
                    default:
                        licznikInne++;
                        break;
                }
            }
            Console.WriteLine($"NATURAL: {licznikLiczbyCalkowite}");
            Console.WriteLine($"FLOAT: {licznikLiczbyPrzecinkowe}");
            Console.WriteLine($"STRINGS: {licznikNapisy}");
            Console.WriteLine($"OTHERS: {licznikInne}");
        }
        static ElementType GetElementType(string element)
        {
            Console.WriteLine(element);
            int liczbaCalkowita;
            double liczbaPrzecinkowa;

            if (int.TryParse(element, out liczbaCalkowita))
            {
                return ElementType.Integer;
            }
            else if (double.TryParse(element, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out liczbaPrzecinkowa) && liczbaPrzecinkowa > 0)
            {
                return ElementType.Double;
            }
            else if(double.TryParse(element, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out liczbaPrzecinkowa) && liczbaPrzecinkowa <= 0)
            {
                return ElementType.Other;
            }
            else if (element.Length >= 5)
            {
                return ElementType.String;
            }
            else
            {
                return ElementType.Other;
            }
        }

    }

    enum ElementType
    {
        Integer,
        Double,
        String,
        Other
    }

}


