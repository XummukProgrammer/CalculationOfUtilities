﻿namespace CalculationOfUtilities.Core
{
    public class Context
    {
        public Services.ServicesManager ServicesManager { private set; get; } = new Services.ServicesManager();
        public Counter.ICounter Counter { get; set; }
    }
}
