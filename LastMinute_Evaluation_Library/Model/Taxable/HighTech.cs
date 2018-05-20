using System;
using System.Collections.Generic;
using System.Text;
using LastMinute_Evaluation_Library.Model.Base;
using static LastMinute_Evaluation_Library.Utils.Utility;

namespace LastMinute_Evaluation_Library.Model.Taxable
{
    public class HighTech : TaxableItem, IEquatable<HighTech>
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Typology { get; set; }

        public HighTech(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        public override StringBuilder generateBaseToString()
        {
            return new StringBuilder()
                       .Append(Quantity)
                       .Append(AddWhiteSpaceIfNotBlank(true, 
                                                       QuantityMultiplier, 
                                                       Typology, 
                                                       Description, 
                                                       Brand, 
                                                       Name, 
                                                       At));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HighTech);
        }

        public bool Equals(HighTech other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Name == other.Name &&
                   Brand == other.Brand &&
                   Typology == other.Typology;
        }

        public override int GetHashCode()
        {
            var hashCode = Int32.MaxValue;
            hashCode = hashCode * Int32.MinValue + base.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Brand);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Typology);
            return hashCode;
        }
    }
}
