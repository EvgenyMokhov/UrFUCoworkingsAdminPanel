using UrFUCoworkingsAdminPanel.Data.Entities;
using UrFUCoworkingsAdminPanel.Data.Interfaces;

namespace UrFUCoworkingsAdminPanel.Data.Implementations
{
    internal class Users : IUsers
    {
        private readonly EFDBContext Context;
        public Users(EFDBContext context) => Context = context;
    }
}
