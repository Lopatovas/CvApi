using CvApi.Models.DataTransferObject;
using CvApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace CvApi.Services.UserService
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(Guid id);
        string Create(UserDTO user, string password);
        void Update(UserDTO user, string password = null);
        void Delete(Guid id);
    }
}
