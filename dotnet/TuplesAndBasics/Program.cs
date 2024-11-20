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
            TestKrotki(krotka);
            int @class = 365;
            Console.WriteLine($"wartość zmiennej class: {@class}");
            TestSystemArrays();
            TestAnonimowejKrotki();
            Console.WriteLine();
            DrawCard("Krzychu", "Kula", 'O',paddingTop: 5, paddingBottom: 2);
            CountMyTypes2("skibidi, 3.14, 23.34, 0, 5.78");

        }

        static void TestKrotki((String imie, String nazwisko, int wiek, int placa) tuple)
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

            string[] fruits = { "Apple", "Banana", "Orange", "Grapes" };

            Console.WriteLine("Tablica przed odwróceniem: " + string.Join(", ", fruits));
            Array.Reverse(fruits);
            Console.WriteLine("Tablica po odwróceniu: " + string.Join(", ", fruits));

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            Console.WriteLine("Tablica: " + string.Join(", ", vowels));
            int indexOfI = Array.IndexOf(vowels, 'i');
            Console.WriteLine("Indeks elementu 'i': " + indexOfI);
            double[] prices = { 19.99, 29.99, 39.99, 49.99 };

            Console.WriteLine("Tablica: " + string.Join(", ", prices));

            Array.Clear(prices, 1, 2);

            Console.WriteLine("Tablica po czyszczeniu: " + string.Join(", ", prices));


            string[] sourceArray = { "one", "two", "three", "four" };

            Console.WriteLine("Tablica: " + string.Join(", ", sourceArray));
    
            string[] destinationArray = new string[sourceArray.Length];

            Array.Copy(sourceArray, destinationArray, sourceArray.Length);

            Console.WriteLine("Skopiowana tablica: " + string.Join(", ", destinationArray));
        }

        static void TestAnonimowejKrotki()
        {
            var anonimowa = new { imie = "Ania", nazwisko = "Majka", wiek = 21, placa = 0 };

            Console.WriteLine($"imie: {anonimowa.imie}, nazwisko: {anonimowa.nazwisko}, wiek: {anonimowa.wiek}, placa: {anonimowa.placa}");
        }

        static void DrawCard(String pierwszaLinia, String drugaLinia = "Kowalski", Char znak = 'X', int szerokoscObramowania = 2, int minSzerokoscCalosci = 20, int paddingTop = 1, int paddingBottom=1)
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

            int wolneMiejsce = minSzerokoscCalosci - (2 * szerokoscObramowania);

            int wolneMiejsce1 = wolneMiejsce - pierwszaLinia.Length;

            int wolneMiejsce2 = wolneMiejsce - drugaLinia.Length;

            int[] miejsca = { wolneMiejsce1, wolneMiejsce2 };
            String[] linie = {pierwszaLinia, drugaLinia };

            for (int i = 0; i < szerokoscObramowania; i++)
            {
                for (int j = 0; j < minSzerokoscCalosci; j++)
                {
                    Console.Write(znak.ToString());
                }
                Console.Write("\n");
            }

            for (int j=0; j<paddingTop;j++)
            {
                for (int i = 0; i < szerokoscObramowania; i++)
                {
                    Console.Write(znak.ToString());
                }

                for (int i = 0; i < wolneMiejsce; i++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < szerokoscObramowania; i++)
                {
                    Console.Write(znak.ToString());
                }

                Console.Write("\n");
            }
            

            for (int j=0;j<linie.Length;j++)
            {
                for (int i = 0; i < szerokoscObramowania; i++)
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

                for (int i = 0; i < szerokoscObramowania; i++)
                {
                    Console.Write(znak.ToString());
                }
                Console.Write("\n");
            }

            for (int j = 0; j < paddingBottom; j++)
            {
                for (int i = 0; i < szerokoscObramowania; i++)
                {
                    Console.Write(znak.ToString());
                }

                for (int i = 0; i < wolneMiejsce; i++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < szerokoscObramowania; i++)
                {
                    Console.Write(znak.ToString());
                }

                Console.Write("\n");
            }

            for (int i = 0; i < szerokoscObramowania; i++)
            {
                for (int j = 0; j < minSzerokoscCalosci; j++)
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


