using CvApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CvApi.Services.UserService
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        string Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(Guid id);
    }
}
