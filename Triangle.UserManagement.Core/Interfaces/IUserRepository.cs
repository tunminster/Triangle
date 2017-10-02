using System;
using System.Collections.Generic;
using System.Text;
using Triangle.UserManagement.Core.Model.UserAggregate;

namespace Triangle.UserManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        List<User> GetUserList();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
