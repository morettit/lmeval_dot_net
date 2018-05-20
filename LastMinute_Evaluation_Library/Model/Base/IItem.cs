namespace LastMinute_Evaluation_Library.Model.Base
{
    public interface IItem
    {
        string Description { get; set; }
        bool Imported { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }

        decimal GetTotalPrice();
        decimal GetTotalTaxes();
        string ToString();
    }
}