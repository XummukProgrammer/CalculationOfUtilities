namespace CalculationOfUtilities.Services
{
    public class ServiceCalculatedInfo
    {
        public string Name { private set; get; }
        public float Price { private set; get; }

        public ServiceCalculatedInfo(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}
