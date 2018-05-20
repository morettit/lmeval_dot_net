using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LastMinute_Evaluation_Library.Model.Taxable;
using LastMinute_Evaluation_Library.Model.Untaxable;


namespace LastMinute_Evaluation_Test
{
    [TestClass]
    public class LybraryTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal expectedTotalPrice = decimal.Round((decimal)29.83, 2, MidpointRounding.AwayFromZero);
            decimal expectedTotalTaxes = decimal.Round((decimal)1.50, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Input1:");
            Book b = new Book("book", 1, (decimal)12.49, false);
            Audio a = new Audio("music CD", 1, (decimal)14.99, false);
            Food f = new Food("chocolate bar", 1, (decimal)0.85, false);
            Console.WriteLine(b.ToStringWithoutTaxes());
            Console.WriteLine(a.ToStringWithoutTaxes());
            Console.WriteLine(f.ToStringWithoutTaxes());
            Console.WriteLine("Output1:");
            Console.WriteLine(b.ToString());
            Console.WriteLine(a.ToString());
            Console.WriteLine(f.ToString());
            decimal totalTaxes = b.GetTotalTaxes() + a.GetTotalTaxes() + f.GetTotalTaxes();
            decimal totalPrice = b.GetTotalPrice() + a.GetTotalPrice() + f.GetTotalPrice();
            Console.WriteLine("Sales Taxes: " + totalTaxes);
            Console.WriteLine("Total: " + totalPrice);
            Assert.AreEqual(totalTaxes, expectedTotalTaxes);
            Assert.AreEqual(totalPrice, expectedTotalPrice);
        }

        [TestMethod]
        public void TestMethod2()
        {
            decimal expectedTotalPrice = decimal.Round((decimal)65.15, 2, MidpointRounding.AwayFromZero);
            decimal expectedTotalTaxes = decimal.Round((decimal)7.65, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Input2:");
            Food f = new Food("box of chocolates", 1, (decimal)10.00, true);
            Cosmetic c = new Cosmetic("bottle of perfume", 1, (decimal)47.50, true);
            Console.WriteLine(c.ToStringWithoutTaxes());
            Console.WriteLine(f.ToStringWithoutTaxes());
            Console.WriteLine("Output1:");
            Console.WriteLine(c.ToString());
            Console.WriteLine(f.ToString());
            decimal totalTaxes = c.GetTotalTaxes() + f.GetTotalTaxes();
            decimal totalPrice = c.GetTotalPrice() + f.GetTotalPrice();
            Console.WriteLine("Sales Taxes: " + totalTaxes);
            Console.WriteLine("Total: " + totalPrice);
            Assert.AreEqual(totalTaxes, expectedTotalTaxes);
            Assert.AreEqual(totalPrice, expectedTotalPrice);
        }

        [TestMethod]
        public void TestMethod3()
        {
            decimal expectedTotalPrice = decimal.Round((decimal)74.68, 2, MidpointRounding.AwayFromZero);
            decimal expectedTotalTaxes = decimal.Round((decimal)6.70, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Input3:");
            Cosmetic c1 = new Cosmetic("bottle of perfume", 1, (decimal)27.99, true);
            Cosmetic c2 = new Cosmetic("bottle of perfume", 1, (decimal)18.99, false);
            Drug d = new Drug("packet of headache pills", 1, (decimal)9.75, false);
            Food f = new Food("box of chocolates", 1, (decimal)11.25, true);
            Console.WriteLine(c1.ToStringWithoutTaxes());
            Console.WriteLine(c2.ToStringWithoutTaxes());
            Console.WriteLine(d.ToStringWithoutTaxes());
            Console.WriteLine(f.ToStringWithoutTaxes());
            Console.WriteLine("Output1:");
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(d.ToString());
            Console.WriteLine(f.ToString());
            decimal totalTaxes = c1.GetTotalTaxes() + c2.GetTotalTaxes() + d.GetTotalTaxes() + f.GetTotalTaxes();
            decimal totalPrice = c1.GetTotalPrice() + c2.GetTotalPrice() + d.GetTotalPrice() + f.GetTotalPrice();
            Console.WriteLine("Sales Taxes: " + totalTaxes);
            Console.WriteLine("Total: " + totalPrice);
            Assert.AreEqual(totalTaxes, expectedTotalTaxes);
            Assert.AreEqual(totalPrice, expectedTotalPrice);
        }
    }
}
