using System;
using System.Collections.Generic;
using System.Text;
using LastMinute_Evaluation_Library.Model.Base;
using static LastMinute_Evaluation_Library.Utils.Utility;

namespace LastMinute_Evaluation_Library.Model.Taxable
{
    public class Audio : TaxableItem, IEquatable<Audio>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Typology { get; set; }
        public string RecordIndustry { get; set; }

        public Audio(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        public override StringBuilder generateBaseToString()
        {
            return new StringBuilder()
                       .Append(Quantity)
                       .Append(AddWhiteSpaceIfNotBlank(true, 
                                                       QuantityMultiplier, 
                                                       Description, 
                                                       Typology, 
                                                       Title, 
                                                       AddWhiteSpaceIfNotBlank("by", Author, "with"), 
                                                       RecordIndustry, 
                                                       At));
        }

        public override bool Equals(object obj) => Equals(obj as Audio);

        public bool Equals(Audio other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Title == other.Title &&
                   Author == other.Author &&
                   Typology == other.Typology &&
                   RecordIndustry == other.RecordIndustry;
        }

        public override int GetHashCode()
        {
            var hashCode = Int32.MaxValue;
            hashCode = hashCode * Int32.MinValue + base.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Typology);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(RecordIndustry);
            return hashCode;
        }
    }
}
