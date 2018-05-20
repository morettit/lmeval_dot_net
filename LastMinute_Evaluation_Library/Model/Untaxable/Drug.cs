using System;
using System.Collections.Generic;
using System.Text;
using LastMinute_Evaluation_Library.Model.Base;
using static LastMinute_Evaluation_Library.Utils.Utility;


namespace LastMinute_Evaluation_Library.Model.Untaxable
{
    public class Drug : UntaxableItem, IEquatable<Drug>
    {
        public string Name { get; set; }
        public decimal Dose { get; set; }
        public string Unity { get; set; }
        public bool NeedPrescription { get; set; }
        public string PharmaceuticalIndustry { get; set; }

        public Drug(string description, int quantity, decimal price, bool imported) : base(description, quantity, price, imported) { }

        public override StringBuilder generateBaseToString()
        {
            return new StringBuilder()
                       .Append(Quantity)
                       .Append(AddWhiteSpaceIfNotBlank(true,
                                                       QuantityMultiplier,
                                                       Description,
                                                       PharmaceuticalIndustry,
                                                       Name,
                                                       Dose.ToString(),
                                                       Unity,
                                                       At));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Drug);
        }

        public bool Equals(Drug other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Name == other.Name &&
                   Dose == other.Dose &&
                   Unity == other.Unity &&
                   NeedPrescription == other.NeedPrescription &&
                   PharmaceuticalIndustry == other.PharmaceuticalIndustry;
        }

        public override int GetHashCode()
        {
            var hashCode = Int32.MaxValue;
            hashCode = hashCode * Int32.MinValue + base.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * Int32.MinValue + Dose.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(Unity);
            hashCode = hashCode * Int32.MinValue + NeedPrescription.GetHashCode();
            hashCode = hashCode * Int32.MinValue + EqualityComparer<string>.Default.GetHashCode(PharmaceuticalIndustry);
            return hashCode;
        }
    }
}
