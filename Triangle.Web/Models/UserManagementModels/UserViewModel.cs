using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triangle.Web.Models.UserManagementModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Added { get; set; }
    }
}
