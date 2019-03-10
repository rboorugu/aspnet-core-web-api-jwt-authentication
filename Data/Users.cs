using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Data
{
    public class Users
    {
        /// <summary>
        /// Return lists of dummy users for testing off course my all favorites!
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User { Id = 1, FirstName = "Michael", LastName = "Jordon", Username = "mjordon", Password = "jordon123$" } ,
                new User { Id = 2, FirstName = "Lebron", LastName = "James", Username = "ljames", Password = "james123$" }
            };
        }
    }
}
