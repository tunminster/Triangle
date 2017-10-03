using System;
using System.Xml;
using Triangle.SharedKernel;

namespace Triangle.UserManagement.Core.Model.UserAggregate
{
    public class User 
    {
        public User() { }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
    }
}