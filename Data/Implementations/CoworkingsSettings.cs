using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    public class CoworkingsSettings : ICoworkingsSettings
    {
        private readonly EFDBContext Context;
        public CoworkingsSettings(EFDBContext context) => Context = context;
        public void DeleteCoworkingSettings(int id)
        {
            Context.CoworkingSettings.Remove(GetCoworkingSettings(id));
            Context.SaveChanges();
        }

        public IEnumerable<CoworkingSettings> GetCoworkingSettings()
        {
            return Context.CoworkingSettings;
        }

        public CoworkingSettings GetCoworkingSettings(int id)
        {
            return Context.CoworkingSettings.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCoworkingSettings(CoworkingSettings coworkingSettings)
        {
            if (coworkingSettings.Id == 0)
                Context.CoworkingSettings.Add(coworkingSettings);
            else 
                Context.Entry(coworkingSettings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
