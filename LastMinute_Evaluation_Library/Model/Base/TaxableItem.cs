using System;

namespace LastMinute_Evaluation_Library.Model.Base
{
    public class TaxableItem : Item
    {
        public TaxableItem(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        protected override decimal GetTaxes() => decimal.Round(GetImportationTaxes() + (Price / 10), 2, MidpointRounding.AwayFromZero);
    }
}
