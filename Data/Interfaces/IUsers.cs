using UrFUCoworkingsAdminPanel.Data.Entities;

namespace UrFUCoworkingsAdminPanel.Data.Interfaces
{
    public interface IUsers
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUser(int id);
        public void UpdateUser(User user);
    }
}
