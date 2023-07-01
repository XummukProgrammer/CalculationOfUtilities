namespace CalculationOfUtilities.States
{
    public class InitializationState : IState
    {
        public void OnEnter(Core.Context context)
        {
            context.TranslationsManager.CurrentLangType = Translations.TranslationLangType.Russia;
            context.TranslationsManager.AddTranslationText("ENTER_RESIDENTS", Translations.TranslationLangType.Russia, "Введите кол-во людей, которые проживают в квартире: ");
            context.TranslationsManager.AddTranslationText("ENTER_RESIDENTS", Translations.TranslationLangType.English, "Enter the number of people living in the apartment: ");
            context.TranslationsManager.AddTranslationText("SERVICE_TITLE", Translations.TranslationLangType.Russia, "Услуга: {0}");
            context.TranslationsManager.AddTranslationText("SERVICE_TITLE", Translations.TranslationLangType.English, "Service: {0}");
            context.TranslationsManager.AddTranslationText("DO_YOU_HAVE_COUNTER", Translations.TranslationLangType.Russia, "Имеете ли вы прибор учёта (Счётчик)? (y/n): ");
            context.TranslationsManager.AddTranslationText("DO_YOU_HAVE_COUNTER", Translations.TranslationLangType.English, "Do you have a service accounting device (y/n)?: ");
            context.TranslationsManager.AddTranslationText("ENTER_CURRENT_INDICATIONS", Translations.TranslationLangType.Russia, "Введите текущие показания: ");
            context.TranslationsManager.AddTranslationText("ENTER_CURRENT_INDICATIONS", Translations.TranslationLangType.English, "Enter the current indications: ");
            context.TranslationsManager.AddTranslationText("ENTER_PREV_INDICATIONS", Translations.TranslationLangType.Russia, "Введите предыдущие показания: ");
            context.TranslationsManager.AddTranslationText("ENTER_PREV_INDICATIONS", Translations.TranslationLangType.English, "Enter the previous indications: ");
            context.TranslationsManager.AddTranslationText("DAY_TIME", Translations.TranslationLangType.Russia, "Дневное время");
            context.TranslationsManager.AddTranslationText("DAY_TIME", Translations.TranslationLangType.English, "Daytime");
            context.TranslationsManager.AddTranslationText("NIGHT_TIME", Translations.TranslationLangType.Russia, "Ночное время");
            context.TranslationsManager.AddTranslationText("NIGHT_TIME", Translations.TranslationLangType.English, "Night time");
            context.TranslationsManager.AddTranslationText("ELECTRICITY_ENTER_CURRENT_INDICATIONS", Translations.TranslationLangType.Russia, "Введите текущие показания ({0}): ");
            context.TranslationsManager.AddTranslationText("ELECTRICITY_ENTER_CURRENT_INDICATIONS", Translations.TranslationLangType.English, "Enter the current indications ({0}): ");
            context.TranslationsManager.AddTranslationText("ELECTRICITY_ENTER_PREV_INDICATIONS", Translations.TranslationLangType.Russia, "Введите предыдущие показания ({0}): ");
            context.TranslationsManager.AddTranslationText("ELECTRICITY_ENTER_PREV_INDICATIONS", Translations.TranslationLangType.English, "Enter the previous indications ({0}): ");
            context.TranslationsManager.AddTranslationText("CALCULATED_SERVICE_INFO", Translations.TranslationLangType.Russia, "Услуга: {0}, Начисление: {1}");
            context.TranslationsManager.AddTranslationText("CALCULATED_SERVICE_INFO", Translations.TranslationLangType.English, "Service: {0}, Price: {1}");
            context.TranslationsManager.AddTranslationText("TOTAL_SUM", Translations.TranslationLangType.Russia, "Общая сумма: {0}");
            context.TranslationsManager.AddTranslationText("TOTAL_SUM", Translations.TranslationLangType.English, "Total sum: {0}");
            context.TranslationsManager.AddTranslationText(typeof(Services.ColdWaterSupplyService).Name, Translations.TranslationLangType.Russia, "Холодное водоснабжение (ХВС)");
            context.TranslationsManager.AddTranslationText(typeof(Services.ColdWaterSupplyService).Name, Translations.TranslationLangType.English, typeof(Services.ColdWaterSupplyService).Name);
            context.TranslationsManager.AddTranslationText(typeof(Services.HotWaterSupplyHeatCarrierService).Name, Translations.TranslationLangType.Russia, "Горячее водоснабжение (ГВС): Теплоноситель");
            context.TranslationsManager.AddTranslationText(typeof(Services.HotWaterSupplyHeatCarrierService).Name, Translations.TranslationLangType.English, typeof(Services.HotWaterSupplyHeatCarrierService).Name);
            context.TranslationsManager.AddTranslationText(typeof(Services.HotWaterSupplyThermalEnergyService).Name, Translations.TranslationLangType.Russia, "Горячее водоснабжение (ГВС): Тепловая энергия");
            context.TranslationsManager.AddTranslationText(typeof(Services.HotWaterSupplyThermalEnergyService).Name, Translations.TranslationLangType.English, typeof(Services.HotWaterSupplyThermalEnergyService).Name);
            context.TranslationsManager.AddTranslationText(typeof(Services.ElectricityService).Name, Translations.TranslationLangType.Russia, "Электроэнергия (ЭЭ)");
            context.TranslationsManager.AddTranslationText(typeof(Services.ElectricityService).Name, Translations.TranslationLangType.English, typeof(Services.ElectricityService).Name);

            context.Database.Load();

            ConsoleUI.ResidentsDialog residentsDialog = new ConsoleUI.ResidentsDialog(context);
            residentsDialog.Exec();
            context.Residents = residentsDialog.Residents;

            Factory.ServiceFactory serviceFactory = new Factory.ServiceFactory();
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ServiceDialog, Services.ColdWaterSupplyService>(context));
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ServiceDialog, Services.HotWaterSupplyHeatCarrierService>(context));
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ServiceDialog, Services.HotWaterSupplyThermalEnergyService>(context));
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ElectricityServiceDialog, Services.ElectricityService>(context));
        }

        public void OnExit(Core.Context context)
        {
        }

        public void OnUpdate(Core.Context context)
        {
            context.StatesManager.SetCurrentState<ShowResultsState>();
        }
    }
}
