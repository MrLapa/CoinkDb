using DataLayer.AccessDB;
using DataLayer.Entities;
using NUnit.Framework;
using System.Data;
using System.Threading.Tasks;

namespace NUnitTestCoink
{
    public class UTAccessDataBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestExecuteProcedureQueryAsync()
        {
            User user = new User();
            DataTable dtResult = await AccessDataBase.ExecuteProcedureQueryAsync("GetUsers", user);
            Assert.IsTrue(dtResult != null);
        }

        [Test]
        public async Task TestExecuteProcedureInsertAsync()
        {
            User user = new User
            {
                Name = "Maria Aristizabal",
                Phone = "0800-222-2676",
                Address = "Estadio La Bombonera",
                CityId = 2,
            };
            int lastId = await AccessDataBase.ExecuteProcedureInsertAsync("AddUser", user);
            Assert.IsTrue(lastId > 0);
        }
    }
}