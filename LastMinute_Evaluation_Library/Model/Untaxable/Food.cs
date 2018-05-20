using System;
using System.Collections.Generic;
using System.Text;
using LastMinute_Evaluation_Library.Model.Base;
using static LastMinute_Evaluation_Library.Utils.Utility;

namespace LastMinute_Evaluation_Library.Model.Untaxable
{
    public class Food : UntaxableItem, IEquatable<Food>
    {

        public DateTime? ExpirationDate { get; set; }
        public string Typology { get; set; }

        public Food(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        public override StringBuilder generateBaseToString()
        {
            return new StringBuilder()
                       .Append(Quantity)
                       .Append(AddWhiteSpaceIfNotBlank(true,
                                                       QuantityMultiplier,
                                                       Typology,
                                                       Description,
                                                       AddWhiteSpaceIfNotBlank("with", DateTimeFormatter(ExpirationDate)),
                                                       At)); ;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Food);
        }

        public bool Equals(Food other)
        {
            return other != null &&
                   base.Equals(other) &&
                   ExpirationDate == other.ExpirationDate &&
                   Typology == other.Typology;
        }

        public override int GetHashCode()
        {
            var hashCode = Int32.MaxValue;
            hashCode = hashCode * Int32.MinValue + base.GetHashCode();
            hashCode = hashCode * Int32.MinValue + ExpirationDate.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Typology);
            return hashCode;
        }
    }
}
