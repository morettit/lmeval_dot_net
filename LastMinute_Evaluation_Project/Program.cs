using System;
using System.Collections.Generic;
using System.Linq;
using LastMinute_Evaluation_Library.Model.Base;
using LastMinute_Evaluation_Library.Model.Taxable;
using LastMinute_Evaluation_Library.Model.Untaxable;

namespace LastMinute_Evaluation_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LastMinute Evaluation Project";
            Console.WriteLine("Generating products for simulation ...");
            Dictionary<int, Item> products = generate();
            Dictionary<int, Item> userChoice = new Dictionary<int, Item>();
            String userInput = "";
            while (!userInput.Equals("N"))
            {
                Console.WriteLine("Check product list and make your choice.");
                foreach (KeyValuePair<int, Item> p in products)
                {
                    if (!userChoice.ContainsKey(p.Key))
                    {
                        Console.WriteLine(p.Key + " - " + p.Value.ToStringWithoutTaxes());
                    }
                }
                while (!userInput.Equals("DONE"))
                {
                    Console.WriteLine("Please, insert ONLY the number of the item: ");
                    try
                    {
                        int key = int.Parse(Console.ReadLine());
                        if (key >= 1 && key <= 11)
                        {
                            Console.WriteLine("Please, insert the requested quantity: ");
                            int quantity = int.Parse(Console.ReadLine());
                            Item choicedItem;
                            if (!userChoice.ContainsKey(key))
                            {
                                choicedItem = products.First(p => p.Key.Equals(key)).Value;
                                choicedItem.Quantity = quantity;
                                userChoice.Add(key, choicedItem);
                            }
                            else
                            {
                                choicedItem = userChoice.First(p => p.Key.Equals(key)).Value;
                                choicedItem.Quantity = choicedItem.Quantity + quantity;
                                userChoice.Remove(key);
                                if (choicedItem.Quantity > 0)
                                {
                                    userChoice.Add(key, choicedItem);
                                }
                            }
                            userInput = "DONE";
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Error.WriteLine("Invalid Format!");
                    }
                }
                while (!userInput.Equals("Y") && !userInput.Equals("N"))
                {
                    Console.WriteLine("Did you want to choice another product? (Y/N)");
                    userInput = Console.ReadLine().ToUpper();
                }
            }
            Console.WriteLine("Checking chart content...");
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------- CHART ----------");
            Console.WriteLine("-------------------------");
            decimal totalPrice = decimal.Zero;
            decimal totalTaxes = decimal.Zero;
            foreach (Item i in userChoice.Values)
            {
                Console.WriteLine(i.ToString());
                totalPrice = totalPrice + i.GetTotalPrice();
                totalTaxes = totalTaxes + i.GetTotalTaxes();
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Sales Taxes: " + totalTaxes);
            Console.WriteLine("Total: " + totalPrice);
            Console.WriteLine("-------------------------");
            Console.WriteLine("--------  END  ----------");
            Console.WriteLine("-------------------------");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        private static Dictionary<int, Item> generate()
        {
            Dictionary<int, Item> products = new Dictionary<int, Item>();

            /* BOOKS */
            Book b1 = new Book("Book", 1, (decimal)22.49, true);
            b1.Author = "Valerio Massimo Manfredi";
            b1.Title = "Lo scudo di Talos";
            b1.Language = "ITA";
            Book b2 = new Book("Book", 1, (decimal)10.62, false);
            b2.Author = "Licia Troisi";
            b2.Title = "Nihal della Terra del Vento";
            b2.IsbnCode = "9788532520036";
            /* DRUGS */
            Drug d1 = new Drug("Box of pils", 1, (decimal)6.99, false);
            d1.PharmaceuticalIndustry = "Bayer";
            d1.Name = "VIVIN C";
            d1.NeedPrescription = false;
            /* FOODS */
            Food f1 = new Food("Apples", 1, (decimal)1.58, true);
            f1.ExpirationDate = new DateTime(2018,02,15);
            f1.Typology = "Unpackaged";
            Food f2 = new Food("chocolates", 1, (decimal)8.67, false);
            f2.ExpirationDate = new DateTime(2018,12,29);
            f2.Typology = "Box of";
            /* AUDIO */
            Audio a1 = new Audio("Vynile", 1, (decimal)52.43, true);
            a1.Author = "Metallica";
            a1.Title = "Master of Puppets";
            a1.RecordIndustry = "Elektra Records";
            a1.Typology = "Heavy Metal";
            Audio a2 = new Audio("Music CD", 1, (decimal)22.01, true);
            a2.Author = "Ed Sheeran";
            a2.Title = "Divide";
            a2.RecordIndustry = "Atlantics Records";
            a2.Typology = "Pop Folk";
            /* COSMETICS */
            Cosmetic c1 = new Cosmetic("Cream", 1, (decimal)3.43, false);
            c1.Name = "Soft";
            c1.CosmeticIndustry = "Nivea";
            c1.QuantityOfProduct = "300ml";
            Cosmetic c2 = new Cosmetic("Deodorant", 1, (decimal)2.90, false);
            c2.Name = "Original";
            c2.CosmeticIndustry = "Dove";
            c2.Typology = "Spray";
            /* HIGH TECH */
            HighTech h1 = new HighTech("", 1, (decimal)799.89, false);
            h1.Brand = "ASUS";
            h1.Name = "ZenBook Pro Serie UX550VD";
            h1.Typology = "Ultrabook";
            HighTech h2 = new HighTech("Desktop", 1, (decimal)3899.00, true);
            h2.Brand = "DELL";
            h2.Name = "Alienware Area 51";

            products.Add(1, a1);
            products.Add(2, a2);
            products.Add(3, b1);
            products.Add(4, b2);
            products.Add(5, c1);
            products.Add(6, c2);
            products.Add(7, d1);
            products.Add(8, f1);
            products.Add(9, f2);
            products.Add(10, h1);
            products.Add(11, h2);
            return products;
        }
    }
}
