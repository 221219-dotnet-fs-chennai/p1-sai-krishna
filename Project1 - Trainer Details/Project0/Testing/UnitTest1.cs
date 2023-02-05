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

        
    }
}