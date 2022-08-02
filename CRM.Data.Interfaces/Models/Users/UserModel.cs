using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool RememberLogin
        {
            get;
            set;
        }
        public string ReturnUrl
        {
            get;
            set;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return new List<UserModel>() { new UserModel { Id = 101, UserName = "anet", Name = "Anet", EmailId = "anet@test.com", Password = "anet123",Role="Admin" } };
        }
    }
}
