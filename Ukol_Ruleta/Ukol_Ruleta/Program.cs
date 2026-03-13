using System.Globalization;

Random rnd = new Random();

int kredit = 0;
int kreditPlus = 0;
int currentBetAmount = 0;
int currentBetNumber;
int currentLucky;
bool runBet = true;

Console.WriteLine("Vítejte v programu ruleta");
while (true)
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("Vložte kredit, nebo zadejte \"konec\" pro ukončení programu.");
    Console.ResetColor();
    Console.Write("Vložte kredit: ");    
    string kreditInput = Console.ReadLine();
    if (kreditInput == "konec")
    {
        break;
    }
    while (!int.TryParse(kreditInput, out kreditPlus) || kreditPlus < 0)
    {
        Console.Write("Neplatný vstup! Zadejte prosím kladné číslo: ");
        kreditInput = Console.ReadLine();
    }
    kredit += kreditPlus;
    
    while (runBet)
    {
        Console.Write($"Stav vašeho kreditu je: {kredit}\nKolik chcete vsadit: ");
        string betInput =  Console.ReadLine();
        while (!int.TryParse(betInput, out currentBetAmount) || currentBetAmount < 1) 
        {
                Console.Write("Neplatný vstup! Zadejte prosím kladné číslo větší než 0: ");
                betInput = Console.ReadLine();
        }

        if (currentBetAmount > kredit)
        {
            Console.WriteLine("Nedostatečný zůstatek kreditu! Chcete vložit další? (ano/ne)");
            string moreCreditInput = Console.ReadLine();
            if (moreCreditInput == "ano")
            {
                Console.Write("Vložte kredit: ");    
                kreditInput = Console.ReadLine();
                if (kreditInput == "konec")
                {
                    break;
                }
                while (!int.TryParse(kreditInput, out kreditPlus) || kreditPlus < 0)
                {
                        Console.Write("Neplatný vstup! Zadejte prosím kladné číslo: ");
                        kreditInput = Console.ReadLine();
                }
                kredit += kreditPlus;
            }
            else
            {
                while (currentBetAmount > kredit)
                {
                    Console.Write($"Uveďte nižší částku nebo částku rovnou vašemu kreditu({kredit}): "); 
                    betInput =  Console.ReadLine();
                    while (!int.TryParse(betInput, out currentBetAmount) || currentBetAmount < 1) 
                    {
                            Console.Write("Neplatný vstup! Zadejte prosím kladné číslo větší než 0: ");
                            betInput = Console.ReadLine();
                    }
                }
            }
        }

        Console.Write("Uveďte číslo, na které chcete vsadit (0-36): ");
        while (!int.TryParse(Console.ReadLine(), out currentBetNumber) || currentBetNumber < 0 || currentBetNumber > 36)
        {
            Console.Write("Neplatný vstup! Zadejte prosím číslo v rozmezí 0-36: ");
        }

        Console.Write("\nHod kuličkou");
        for (int i = 1; i <= 5; i++)
        {
            Thread.Sleep(1000);
            Console.Write(".");
            if (i == 5)
            {
                Console.Write("\n\n");
            }
        }

        while (runBet)
        {
            currentLucky = rnd.Next(0, 37);
            Console.WriteLine($"Losované číslo je {currentLucky}");
            if (currentLucky == currentBetNumber)
            {
                kredit += currentBetAmount;
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Gratuluji, vyhrál jsi!");
                Console.ResetColor();
            }
            else
            {
                kredit -= currentBetAmount;
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bohužel, prohrál jsi!");
                Console.ResetColor();
            }
            
            Console.WriteLine($"Stav vašeho kreditu je: {kredit}");

            Console.WriteLine("Chcete hrát znovu? (ano/ne)");
            string runBetInput = Console.ReadLine();
            if (runBetInput == "ano")
            {
                break;
            } else if (runBetInput == "ne")
            {
                break;
            }
        }
    }

    Console.WriteLine($"Stav vašeho koncového kreditu je {kredit}");

}