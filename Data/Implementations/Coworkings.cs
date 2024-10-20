using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    public class Coworkings : ICoworkings
    {
        private readonly EFDBContext Context;
        public Coworkings(EFDBContext context) => Context = context;
        public void DeleteCoworking(int id)
        {
            Context.Coworkings.Remove(GetCoworking(id));
            Context.SaveChanges();
        }

        public Coworking GetCoworking(int id)
        {
            return Context.Coworkings.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Coworking> GetCoworkings()
        {
            return Context.Coworkings;
        }

        public void UpdateCoworking(Coworking coworking)
        {
            if (coworking.Id == 0)
                Context.Coworkings.Add(coworking);
            else 
                Context.Entry(coworking).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
