using BeerCrate;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("---Dein Bierkasten---" +
                          "\n -- STEUERUNG -- " +
                          "\n -- t = 1 Getränk trinken --" +
                          "\n -- f = ein Getränk auffüllen--" +
                          "\n -- q = programm schließen ");
        Crate crate = InitializeCrate(6);

        while (true)
        {
            string input = Console.ReadLine();
            AnalyzeInputs(input, crate);
        }
    }


    static void AnalyzeInputs(string input, Crate crate)
    {
        if (WantsDrink(input))
        {
            crate.TakeDrink();
        }
        else if (WantsToFillCrate(input))
        {
            crate.FillCrate(1);
        }
        else if (WantsToQuit(input))
        {
            Environment.Exit(0);
        }
    }


    private static Crate InitializeCrate(int amount)
    {
        Crate crate = new Crate(new List<Drink>(), amount);
        return crate;
    }

    private static bool WantsToFillCrate(string input)
    {
        return input == "f";
    }


    private static bool WantsDrink(string input)
    {
        return input == "t";
    }

    private static bool WantsToQuit(string input)
    {
        return input == "q";
    }
}
