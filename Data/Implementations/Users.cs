using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Users : IUsers
    {
        private readonly EFDBContext Context;
        public Users(EFDBContext context) => Context = context;
        public IEnumerable<User> GetAllUsers()
        {
            return Context.Users;
        }

        public User GetUser(int id)
        {
            return Context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateUser(User user)
        {
            if (user.Id == 0)
                Context.Users.Add(user);
            else
                Context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
