using System;
using System.Collections.Generic;
using System.Text;
using LastMinute_Evaluation_Library.Model.Base;
using static LastMinute_Evaluation_Library.Utils.Utility;

namespace LastMinute_Evaluation_Library.Model.Taxable
{
    public class Cosmetic : TaxableItem, IEquatable<Cosmetic>
    {
        public string Name { get; set; }
        public string QuantityOfProduct { get; set; }
        public string Typology { get; set; }
        public string CosmeticIndustry { get; set; }

        public Cosmetic(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        public override StringBuilder generateBaseToString()
        {
            return new StringBuilder()
                       .Append(Quantity)
                       .Append(AddWhiteSpaceIfNotBlank(true, 
                                                       QuantityMultiplier, 
                                                       Description, 
                                                       CosmeticIndustry, 
                                                       Name, 
                                                       Typology, 
                                                       QuantityOfProduct, 
                                                       At));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cosmetic);
        }

        public bool Equals(Cosmetic other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Name == other.Name &&
                   QuantityOfProduct == other.QuantityOfProduct &&
                   Typology == other.Typology &&
                   CosmeticIndustry == other.CosmeticIndustry;
        }

        public override int GetHashCode()
        {
            var hashCode = Int32.MaxValue;
            hashCode = hashCode * Int32.MinValue + base.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(QuantityOfProduct);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Typology);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(CosmeticIndustry);
            return hashCode;
        }
    }
}
