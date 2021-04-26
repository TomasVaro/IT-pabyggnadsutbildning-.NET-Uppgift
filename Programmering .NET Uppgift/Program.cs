using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Programmering_.NET_Uppgift
{
    class Program
    {
        class Player
        {
            public string Name;
            public int Health;
            public int Strength;
            public int Luck;
        }
        static void Main(string[] args)
        {
            bool changeColor = true;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj den funktion som önskas genom att mata in siffra 1-16 eller 0 för att avsluta:\n" +
                    " 1 - Skriv ut 'Hello World' i konsollen\n" +
                    " 2 - Mata in förnamn, efternamn, ålder\n" +
                    " 3 - Ändra färgen på texten i konsolen\n" +
                    " 4 - Skriv ut dagens datum\n" +
                    " 5 - Anger det största av två inmatade tal\n" +
                    " 6 - Gissa ett tal mellan 1 och 100\n" +
                    " 7 - Spara en text på hårddisken\n" +
                    " 8 - Läsa in en fil från hårddisken\n" +
                    " 9 - Beräknar roten ur, upphöjt till 2 och upphöjt till 10 på ett decimaltal\n" +
                    "10 - Skriv ut en multiplikationstabell från 1 till 10\n" +
                    "11 - Skapa två arrayer\n" +
                    "12 - Kontrollerar om palindrom eller ej\n" +
                    "13 - Skriver ut alla siffror mellan två tal\n" +
                    "14 - Sorterar siffror efter udda och jämna\n" +
                    "15 - Adderar siffror och skriver ut svaret\n" +
                    "16 - Ange karaktär och motståndare som sparas i en instans\n" +
                    " 0 - Avsluta applikationen\n"
                    );

                int number = EnterAndCheckNumbers();
                while (number > 16)
                {
                    Console.WriteLine("\nSiffrorna skall vara mellan 0 och 16! Skriv in funktionsnumret igen.");
                    number = EnterAndCheckNumbers();
                }
                if (number == 0)
                {
                    break;
                }
                else if (number == 1)
                {
                    WriteHelloWorld();
                }
                else if (number == 2)
                {
                    EnterNameAndAge();
                }
                else if (number == 3)
                {
                    changeColor = ChangeConsoleColor(changeColor);
                }
                else if (number == 4)
                {
                    TodaysDate();
                }
                else if (number == 5)
                {
                    CheckHighestNumber();
                }
                else if (number == 6)
                {
                    GessANumber();
                }
                else if (number == 7)
                {
                    SaveTextToFile();
                }
                else if (number == 8)
                {
                    ReadTextFromFile();
                }
                else if (number == 9)
                {
                    CountMath();
                }
                else if (number == 10)
                {
                    PrintMultiplicationChart();
                }
                else if (number == 11)
                {
                    CreateArrays();
                }
                else if (number == 12)
                {
                    CheckIfPalindrome();
                }
                else if (number == 13)
                {
                    ShowAllNumbersBetweenTwoNumbers();
                }
                else if (number == 14)
                {
                    SortingNumbers();
                }
                else if (number == 15)
                {
                    AddingNumbers();
                }
                else if (number == 16)
                {
                    CaractersSavedInAnInstance();
                }
            }
        }
        static void WriteHelloWorld()
        {
            Console.WriteLine("\nHello World!");
            CheckIfKeyPressed();
        }
        static void EnterNameAndAge()
        {
            Console.WriteLine("\nSkriv in förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nSkriv in efternamn:");
            string lastName = Console.ReadLine();
            Console.WriteLine("\nSkriv in ålder:");
            int age = EnterAndCheckNumbers();
            Console.WriteLine("\nDu heter " + firstName + " " + lastName + " och är " + age + " år gammal.");
            CheckIfKeyPressed();
        }
        static bool ChangeConsoleColor(bool changeColor)
        {
            if (changeColor == true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                return changeColor = false;
            }
            else
            {
                Console.ResetColor();
                return changeColor = true;
            }
        }
        static void TodaysDate()
        {
            Console.WriteLine("\nDagens datum är " + DateTime.Now.ToString("d/M/yyyy"));
            CheckIfKeyPressed();
        }
        static void CheckHighestNumber()
        {
            Console.WriteLine("\nSkriv in ett tal:");
            int firstNr = EnterAndCheckNumbers();
            Console.WriteLine("\nSkriv in ett annat tal:");
            int secondNr = EnterAndCheckNumbers();
            Console.WriteLine("\nDet största talet av dom två är " + Math.Max(firstNr, secondNr));
            CheckIfKeyPressed();
        }
        static void GessANumber()
        {
            Console.WriteLine("\nGissa ett tal mellan 1 och 100. Skriv din gissning.");
            Random rnd = new Random();
            int rndNr = rnd.Next(1, 101);
            bool proceed = true;
            int counter = 0;
            while (proceed)
            {
                int guessedNr = EnterAndCheckNumbers();
                counter++;
                if (guessedNr > rndNr)
                {
                    Console.WriteLine("\nDu gissade på ett för högt tal. Gissa på ett lägre tal.");
                }
                else if (guessedNr < rndNr)
                {
                    Console.WriteLine("\nDu gissade på ett för lågt tal. Gissa på ett högre tal.");
                }
                else
                {
                    Console.WriteLine("\nDu gissade rätt på " + counter + " försök! Talet var " + rndNr + "!");
                    proceed = false;
                }
            }
            CheckIfKeyPressed();
        }
        static void SaveTextToFile()
        {
            Console.WriteLine("\nSkriv en text som därefter sparas till en fil på datorn.");
            string text = Console.ReadLine();
            System.IO.File.WriteAllText(@"C:\Temp\Text.txt", text);
            CheckIfKeyPressed();
        }
        static void ReadTextFromFile()
        {
            try
            {
                string fileContent = System.IO.File.ReadAllText(@"C:\Temp\Text.txt");
                Console.WriteLine("\nFöljande text är sparad i filen:\n" + fileContent);
                CheckIfKeyPressed();
            }
            catch
            {
                Console.WriteLine("\nDet finns ingen sparad text-fil i C:\\Temp");
                SaveTextToFile();
            }
        }
        static void CountMath()
        {
            Console.WriteLine("\nSkriv in ett tal/decimaltal");
            double decimalNumber = EnterAndCheckDecimalNumbers();
            if(decimalNumber < 0)
            {
                Console.WriteLine("\nDet går inte att beräkna roten ur ett negativt tal!");
            }
            else
            {
                Console.WriteLine("\nRoten ur " + decimalNumber + " är " + string.Format("{0:N}", Math.Sqrt(decimalNumber)));
            }
            Console.WriteLine(decimalNumber + " upphöjt till 2 är " + string.Format("{0:N}", Math.Pow(decimalNumber, 2)));
            Console.WriteLine(decimalNumber + " upphöjt till 10 är " + string.Format("{0:N}", Math.Pow(decimalNumber, 10)));
            CheckIfKeyPressed();
        }
        static void PrintMultiplicationChart()
        {
            Console.WriteLine();
            for(int i = 1; i < 11; i++ )
            {
                for (int j = 1; j < 11; j++)
                {
                    Console.Write(i + "*" + j + "=" + i*j + "\t");
                }
                Console.WriteLine();
            }
            CheckIfKeyPressed();
        }
        static void CreateArrays()
        {
            Random rnd = new Random();
            int[] rndNumbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                int rndNr = rnd.Next(1, 101);
                rndNumbers[i] = rndNr;
            }
            int[] sortedNumbers = (from i in rndNumbers orderby i ascending select i).ToArray();
            Console.WriteLine("\nDen osorterade arrayen är: " + string.Join(", ", rndNumbers));
            Console.WriteLine("Den sorterade arrayen är: " + string.Join(", ", sortedNumbers));
            CheckIfKeyPressed();
        }
        static void CheckIfPalindrome()
        {
            Console.WriteLine("\nSkriv in ett ord eller en mening för att testa om det är en palindrom.");
            string text = Console.ReadLine().ToLower();
            //Remove special characters
            text = Regex.Replace(text, "[^a-zA-Z0-9]+", "", RegexOptions.Compiled);
            if (text == "")
            {
                Console.WriteLine("Du måste skriva en text! Försök igen!");
                CheckIfPalindrome();
            }
            else
            {
                if (text.SequenceEqual(text.Reverse()))
                {
                    Console.WriteLine("\nTexten du skrev in är en palindrom!");
                }
                else
                {
                    Console.WriteLine("\nTexten du skrev in är INTE en palindrom!");
                }
                CheckIfKeyPressed();
            }
        }
        static void ShowAllNumbersBetweenTwoNumbers()
        {
            Console.WriteLine("\nAnge första talet");
            int firstNr = EnterAndCheckNumbers();
            Console.WriteLine("\nAnge andra talet");
            int secondNr = EnterAndCheckNumbers();
            int[] numbers;
            if(Math.Abs(secondNr-firstNr) < 2)
            {
                Console.WriteLine("\nTalen måste skilja åt med minst 2. Försök igen.");
                ShowAllNumbersBetweenTwoNumbers();
            }
            else
            {
                if (secondNr > firstNr)
                    {
                        numbers = Enumerable.Range(firstNr + 1, secondNr - firstNr - 1).ToArray();
                    }
                else
                {
                    numbers = Enumerable.Range(secondNr + 1, firstNr - secondNr - 1).ToArray();
                }
                Console.WriteLine("\nTalen mellan " + firstNr + " och " + secondNr + " är:\n" + string.Join(", ", numbers));
                CheckIfKeyPressed();
            }
        }
        static void SortingNumbers()
        {
            Console.WriteLine("\nSkriv in ett valfritt antal, slumpvisa, kommaseparerade, tal:");
            string stringNr = Console.ReadLine().Replace(" ", string.Empty);
            try
            {
                int[] numbers = Array.ConvertAll(stringNr.Split(','), int.Parse);
                Array.Sort(numbers);
                int n = numbers.Length;
                int[] evenNr = new int[n];
                int[] oddNr = new int[n];
                int i, j = 0, k = 0;
                for (i = 0; i < n; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        evenNr[j] = numbers[i];
                        j++;
                    }
                    else
                    {
                        oddNr[k] = numbers[i];
                        k++;
                    }
                }               
                if(j == 0)
                {
                    Console.WriteLine("\nDet finns inga jämna tal");
                }
                else
                { 
                    Console.WriteLine("\nDom jämna talen är:");
                    for (i = 0; i < j; i++)
                    {
                        Console.Write(evenNr[i] + " ");
                    }
                    Console.WriteLine();
                }
                if (k == 0)
                {
                    Console.WriteLine("\nDet finns inga udda tal");
                }
                else
                {
                    Console.WriteLine("\nDom udda talen är:");
                    for (i = 0; i < k; i++)
                    {
                        Console.Write(oddNr[i] + " ");
                    }
                    Console.WriteLine();
                }
                CheckIfKeyPressed();
            }
            catch
            {
                Console.WriteLine("\nDu får bara mata in siffror separerade med kommatecken! Försök igen.");
                SortingNumbers();
            }
        }
        static void AddingNumbers()
        {
            Console.WriteLine("\nSkriv in ett valfritt antal, slumpvisa, kommaseparerade, tal:");
            string stringNr = Console.ReadLine().Replace(" ", string.Empty);
            int[] numbers;
            try
            {
                numbers = Array.ConvertAll(stringNr.Split(','), int.Parse);
                Console.WriteLine("\nSumman av dom inmatade talen är " + numbers.Sum());
                CheckIfKeyPressed();
            }
            catch
            {
                Console.WriteLine("Du får bara mata in siffror separerade med kommatecken! Försök igen.");
                AddingNumbers();
            }
        }
        static void CaractersSavedInAnInstance()
        {
            Console.WriteLine("\nAnge namnet på din karaktär:");
            string caracterName = Console.ReadLine();
            Console.WriteLine("\nAnge namnet på din motspelare:");
            string opponentName = Console.ReadLine();
            Random rnd = new Random();
            Player[] players = new Player[]
            {
                new Player { Name = caracterName, Health = rnd.Next(1, 11), Strength = rnd.Next(1, 11), Luck = rnd.Next(1, 11)},
                new Player { Name = opponentName, Health = rnd.Next(1, 11), Strength = rnd.Next(1, 11), Luck = rnd.Next(1, 11)}
            };
            Console.WriteLine("\nDin karaktär heter " + players[0].Name + ". Den har " + players[0].Health + " i Hälsa, " + players[0].Strength + " i Styrka och " + players[0].Luck + " i Tur.");
            Console.WriteLine("Din motståndares karaktär heter " + players[1].Name + ". Den har " + players[1].Health + " i Hälsa, " + players[1].Strength + " i Styrka och " + players[1].Luck + " i Tur.");
            CheckIfKeyPressed();
        }
        static int EnterAndCheckNumbers()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("\nDu får bara mata in heltal! Försök igen.");
            }
            return number;
        }
        static double EnterAndCheckDecimalNumbers()
        {
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("\nDu får bara mata in heltal eller decimaltal! Försök igen.");
            }
            return number;
        }
        static void CheckIfKeyPressed()
        {
            Console.WriteLine("\nTryck på en valfri tangent för att starta om");
            Console.ReadKey();            
        }
    }
}