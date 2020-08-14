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
    }
}