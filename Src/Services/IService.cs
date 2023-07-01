namespace CalculationOfUtilities.Services
{
    public interface IService
    {
        float GetPrice();
        float GetStandart();
        Counter.ICounter GetCounter();
    }
}
