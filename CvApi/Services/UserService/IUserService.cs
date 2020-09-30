using System.Collections.Generic;
using CvApi.Models.Entities;

namespace CvApi.Services.UserService
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        string Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
