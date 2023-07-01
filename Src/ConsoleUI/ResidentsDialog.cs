namespace CalculationOfUtilities.ConsoleUI
{
    public class ResidentsDialog
    {
        public uint Residents { private set; get; }

        public void Exec()
        {
            System.Console.Write("Enter the number of people living in the apartment: ");
            Residents = uint.Parse(System.Console.ReadLine());
            System.Console.Clear();
        }
    }
}
