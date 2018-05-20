using System;
using System.Collections.Generic;
using System.Text;
using static LastMinute_Evaluation_Library.Utils.Utility;

namespace LastMinute_Evaluation_Library.Model.Base
{
    public abstract class Item : IItem
    {
        private string _description;
        private decimal _price;
        public string Description { get { return Imported ? "Imported " + _description : _description; } set { _description = value; } }
        public int Quantity { get; set; }
        public decimal Price { get { return _price; } set { _price = decimal.Round(value, 2, MidpointRounding.AwayFromZero); } }
        public bool Imported { get; set; }


        public Item(string description, int quantity, decimal price, bool imported)
        {
            Description = description;
            Quantity = quantity;
            Price = price;
            Imported = imported;
        }

        protected decimal GetImportationTaxes() => decimal.Round((Imported ? (Math.Ceiling(Price) / 20) : decimal.Zero), 2, MidpointRounding.AwayFromZero);

        protected abstract decimal GetTaxes();

        public decimal GetTotalTaxes() => decimal.Round(GetTaxes() * Quantity, 2, MidpointRounding.AwayFromZero);

        public decimal GetTotalPrice() => decimal.Round(((GetTaxes() + Price) * Quantity), 2, MidpointRounding.AwayFromZero);

        public virtual StringBuilder generateBaseToString()
        {
            return new StringBuilder()
                       .Append(Quantity)
                       .Append(WhiteSpace)
                       .Append(Description)
                       .Append(At);
        }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   Description == item.Description &&
                   Price == item.Price &&
                   Imported == item.Imported;
        }

        public override int GetHashCode()
        {
            var hashCode = int.MaxValue;
            hashCode = hashCode * int.MinValue + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * int.MinValue + Imported.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return generateBaseToString()
                       .Append(GetTotalPrice())
                       .ToString();
        }

        public string ToStringWithoutTaxes()
        {
            return generateBaseToString()
                       .Append(GetTotalPrice() - GetTotalTaxes())
                       .ToString();
        }
    }
}
