using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCrate
{
    public class Crate
    {
        public List<Drink> Drinks { get; set;}

        public string ImageLink { get; set; }
        public Crate (List<Drink> drinks, int amount)
        {
            Drinks = drinks;
            ImageLink = "../../../CrateImage.txt";
            FillCrate(amount);
        }


        public void TakeDrink()
        {
            if (Drinks.Any())
            {
                Drinks.RemoveAt(Drinks.Count - 1);
            }
            else
            {
                Console.WriteLine("Crate is empty, press 'f' to add Drinks");
            }
            DrawCrateAndDrinks();
        }
        
        public void DrawCrateAndDrinks()
        {
            DrawDrinks();
            DrawCrate();
        }

        public void DrawDrinks()
        {
            if (Drinks.Any())
            {
                using (StreamReader sr = new StreamReader(Drinks[0].ImageLink))
                {
                    string line = "";
                    string outputLine = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        outputLine = "";
                        for (int i = 0; i < Drinks.Count; i++)
                        {
                            outputLine += line;
                        }
                        Console.WriteLine(outputLine);
                    }
                }
            }
        }

        public void DrawCrate()
        {
            using (StreamReader sr = new StreamReader(ImageLink))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void FillCrate(int amount)
        {
            if (CrateIsFull())
            {
                Console.WriteLine("In einen Kasten passen nicht mehr als " + Drinks.Count + " Getränke rein!");
            }
            else {
                for (int i = 0; i < amount; i++)
                {
                    Drinks.Add(new Beer());
                }
            }
            DrawCrateAndDrinks();
        }

        private bool CrateIsFull()
        {
            return Drinks.Count == 6;
        }

    }
}
