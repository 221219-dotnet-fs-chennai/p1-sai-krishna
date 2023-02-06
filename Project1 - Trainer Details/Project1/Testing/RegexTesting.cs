using BusinessLogic;
using EF=Data__FluentApi.Entities;
using Models;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using System.Reflection;

namespace Testing
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        [TestCase ("Sai@gmail.com",true)]
        [TestCase("Sai@gmacom", false)]
        public void TestEmail(string email,bool expectedResult)
        {
            Assert.AreEqual(RegexValidation.isValidEmail(email),expectedResult);
        }


        [Test]
        [TestCase("sai123", false)]
        [TestCase("saiKrishna", false)]
        [TestCase("saiKrishna123", true)]
        public void TestPassword(string password, bool expectedResult)
        {
            Assert.AreEqual(RegexValidation.isValidPassword(password), expectedResult);
        }
        
        [Test]
        [TestCase("8105811256", true)]
        [TestCase("91 8105811256", false)]
        [TestCase("815855", false)]
        public void TestPhone(string phone, bool expectedResult)
        {
            Assert.AreEqual(RegexValidation.isValidPhone(phone), expectedResult);
        }
       
        [Test]
        [TestCase("5626", false)]
        [TestCase("603103", true)]
        public void TestZipcode(string zipcode, bool expectedResult)
        {
            Assert.AreEqual(RegexValidation.isValidZipcode(zipcode), expectedResult);
        }

        [Test]
        [TestCase("Male", false)]
        [TestCase("female", false)]
        [TestCase("Boy", false)]
        [TestCase("M", true)]
        [TestCase("F", true)]
        public void TestGender(string gender, bool expectedResult)
        {
            Assert.AreEqual(RegexValidation.isValidGender(gender), expectedResult);
        }

        [Test]
        [TestCase("02/2022", true)]
        [TestCase("25/12/25", false)]
        public void TestStartDate(string startDate, bool expectedResult)
        {
            Assert.AreEqual(RegexValidation.isValidStartDate(startDate), expectedResult);
        }

        [Test]
        [TestCase("02/2019", true)]
        [TestCase("02/12/20", false)]
        [TestCase("Present", true)]
        public void TestEndDate(string endDate, bool expectedResult)
        {
            Assert.AreEqual(RegexValidation.isValidEndDate(endDate), expectedResult);
        }

    }
}