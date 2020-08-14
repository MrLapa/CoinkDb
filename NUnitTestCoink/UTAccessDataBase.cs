using DataLayer.AccessDB;
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
        public async Task TestExecuteProcedureAsync()
        {
            DataTable dtResult = await AccessDataBase.ExecuteProcedureAsync("GetUsers");
            Assert.IsTrue(dtResult != null);            
        }
    }
}