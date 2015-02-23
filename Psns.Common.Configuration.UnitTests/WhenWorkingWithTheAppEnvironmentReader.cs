using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Configuration;

using Psns.Common.Test.BehaviorDrivenDevelopment;

using Psns.Common.Configuration;

namespace Psns.Common.Configuration.UnitTests
{
    public class WhenWorkingWithTheAppEnvironmentReader : BehaviorDrivenDevelopmentCaseTemplate
    {
        protected AppEnvironmentReader Reader;
        protected AppEnvironment Result;

        public override void Arrange()
        {
            base.Arrange();

            Reader = new AppEnvironmentReader();
        }

        public override void Act()
        {
            base.Act();

            Result = Reader.Current;
        }
    }

    [TestClass]
    public class AndEnvironmentIsLocal : WhenWorkingWithTheAppEnvironmentReader
    {
        public override void Arrange()
        {
            base.Arrange();

            ConfigurationManager.AppSettings["Environment"] = "Local";
        }

        [TestMethod]
        public void ThenLocalShouldBeReturned()
        {
            Assert.AreEqual<AppEnvironment>(AppEnvironment.Local,
                Result);
        }
    }

    [TestClass]
    public class AndEnvironmentIsDev : WhenWorkingWithTheAppEnvironmentReader
    {
        public override void Arrange()
        {
            base.Arrange();

            ConfigurationManager.AppSettings["Environment"] = "Development";
        }

        [TestMethod]
        public void ThenDevShouldBeReturned()
        {
            Assert.AreEqual<AppEnvironment>(AppEnvironment.Development,
                Result);
        }
    }

    [TestClass]
    public class AndEnvironmentIsTest : WhenWorkingWithTheAppEnvironmentReader
    {
        public override void Arrange()
        {
            base.Arrange();

            ConfigurationManager.AppSettings["Environment"] = "Test";
        }

        [TestMethod]
        public void ThenTestShouldBeReturned()
        {
            Assert.AreEqual<AppEnvironment>(AppEnvironment.Test,
                Result);
        }
    }

    [TestClass]
    public class AndEnvironmentIsProduction : WhenWorkingWithTheAppEnvironmentReader
    {
        public override void Arrange()
        {
            base.Arrange();

            ConfigurationManager.AppSettings["Environment"] = "Production";
        }

        [TestMethod]
        public void ThenProductionShouldBeReturned()
        {
            Assert.AreEqual<AppEnvironment>(AppEnvironment.Production,
                Result);
        }
    }

    [TestClass]
    public class AndEnvironmentIsInvalid : WhenWorkingWithTheAppEnvironmentReader
    {
        public override void Arrange()
        {
            base.Arrange();

            ConfigurationManager.AppSettings["Environment"] = "Something";
        }

        public override void Act()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThenAnInvalidOperationExceptionShouldBeThrown()
        {
            Result = Reader.Current;
            Assert.Fail();
        }
    }
}
