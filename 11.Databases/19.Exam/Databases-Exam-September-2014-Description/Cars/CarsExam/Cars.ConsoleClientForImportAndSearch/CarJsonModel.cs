namespace Cars.ConsoleClientForImportAndSearch
{
    using Cars.Models;

    public class CarJsonModel
    {
        public int Year { get; set; }
        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerJsonModel Dealer { get; set; }
    }
}
