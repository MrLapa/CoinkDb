using DataLayer.AccessDB;
using DataLayer.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestCoink.UTDataLayer
{
    public class UTUserAccessDataBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestGetUsersAsync()
        {   
            List<User> users = await UserAccessDataBase.GetUsersAsync(new User());
            Assert.IsTrue(users != null);
            Assert.IsTrue(users.Count > 0);
        }

        [Test]
        public async Task TestAddUsersAsync()
        {
            User user = new User
            {
                Name = "Juan Fernando",
                Phone = "0800-222-9999",
                Address = "Estadio Barranquilla",
                CityId = 1,
            };
            int lastId = await AccessDataBase.ExecuteProcedureInsertAsync("AddUser", user);
            Assert.IsTrue(lastId > 0);
        }
    }
}
