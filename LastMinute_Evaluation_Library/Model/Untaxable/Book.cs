using System;
using System.Collections.Generic;
using System.Text;
using LastMinute_Evaluation_Library.Model.Base;
using static LastMinute_Evaluation_Library.Utils.Utility;

namespace LastMinute_Evaluation_Library.Model.Untaxable
{
    public class Book : UntaxableItem, IEquatable<Book>
    {
        public string Language { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string IsbnCode { get; set; }

        public Book(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        public override StringBuilder generateBaseToString()
        {
            return new StringBuilder()
                       .Append(Quantity)
                       .Append(AddWhiteSpaceIfNotBlank(true,
                                                       QuantityMultiplier,
                                                       Description,
                                                       Title,
                                                       Language,
                                                       AddWhiteSpaceIfNotBlank("by", Author),
                                                       AddWhiteSpaceIfNotBlank("ISBN", IsbnCode),
                                                       At)); ;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }

        public bool Equals(Book other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Language == other.Language &&
                   Title == other.Title &&
                   Author == other.Author &&
                   IsbnCode == other.IsbnCode;
        }

        public override int GetHashCode()
        {
            var hashCode = Int32.MaxValue;
            hashCode = hashCode * Int32.MinValue + base.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Language);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(IsbnCode);
            return hashCode;
        }
    }
}
