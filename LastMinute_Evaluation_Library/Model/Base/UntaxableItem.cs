using System;

namespace LastMinute_Evaluation_Library.Model.Base
{
    public class UntaxableItem : Item
    {
        public UntaxableItem(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        protected override decimal GetTaxes() => decimal.Round(GetImportationTaxes(), 2, MidpointRounding.AwayFromZero);
    }
}
