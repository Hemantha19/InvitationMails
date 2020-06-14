using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvitationMail;

namespace UnitTestProject
{
    [TestClass]
    public class SendMailTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", 
            "Data.csv",
            "Data.csv", DataAccessMethod.Sequential)]
        public void Test_Exceldata()
        {
            SendMailBody sm = new SendMailBody
            {
                title = TestContext.DataRow["Title"].ToString(),
                Firstname = TestContext.DataRow["FirstName"].ToString(),
                surname = TestContext.DataRow["Surname"].ToString(),
                Productname = TestContext.DataRow["ProductName"].ToString(),
                payoutamount = TestContext.DataRow["PayoutAmount"].ToString(),
                annualpremium = TestContext.DataRow["AnnualPremium"].ToString()
            };

            Assert.IsNotNull(sm.title);
            Assert.IsNotNull(sm.Firstname);
            Assert.IsNotNull(sm.surname);
            Assert.IsNotNull(sm.Productname);
            Assert.IsNotNull(sm.payoutamount);
            Assert.IsNotNull(sm.annualpremium);
        }
    }
}


