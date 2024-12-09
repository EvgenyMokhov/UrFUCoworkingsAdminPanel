using UrFUCoworkingsAdminPanel.Data;
using UrFUCoworkingsModels.Data.Entities;

namespace UrFUCoworkingsAdminPanel.BusinessLogic.Services
{
    public class DeleteDataBackgroundService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        public DeleteDataBackgroundService(IServiceProvider provider) => serviceProvider = provider;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            DataManager dataManager = scope.ServiceProvider.GetRequiredService<DataManager>();
            List<CoworkingSettings> allSettings = new();
            while (!stoppingToken.IsCancellationRequested)
            {
                allSettings = await dataManager.CoworkingsSettings.GetAllSettings();
                foreach (CoworkingSettings settings in allSettings)
                {
                    if (DateOnly.FromDateTime(DateTime.Now) > settings.Day)
                    {
                        await dataManager.CoworkingsSettings.DeleteCoworkingSettingsAsync(settings);
                    }
                }
                await EndOperation(stoppingToken);
            }
        }

        private async Task EndOperation(CancellationToken stoppingToken) => await Task.Delay(TimeSpan.FromHours(12), stoppingToken);
    }
}
