using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Triangle.UserManagement.Core.Interfaces;
using Triangle.UserManagement.Core.Model.UserAggregate;

namespace Triangle.UserManagement.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserManagementContext _context;

        public UserRepository(IUserManagementContext context)
        {
            this._context = context;
        }

        public User GetUser(int id)
        {
            var result = _context.FindBy<User>(x => x.Id == id).FirstOrDefault();
            return result;           
        }

        public List<User> GetUserList()
        {
            var result = _context.GetAll<User>().ToList();
            return result;
        }

        public void AddUser(User user)
        {
            _context.Add<User>(user);
            _context.Commit();
        }

        public void UpdateUser(User user)
        {
            _context.Edit<User>(user);
            _context.Commit();
        }

        public void DeleteUser(User user)
        {
            _context.Delete(user);
             _context.Commit();
        }

    }
}
