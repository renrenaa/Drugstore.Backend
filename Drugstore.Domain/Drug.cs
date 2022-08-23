namespace Drugstore.Domain
{
    public class Drug
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Tittle { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsOnPrescription { get; set; }

    }
}
