using NUnit.Framework;

namespace SeleniumWithPageObjectDemo
{
    [SetUpFixture]
    public class Hooks
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTestRun()
        {
            //TODO to be defined
        }

        [OneTimeTearDown]
        public void RunAfterAnyTestRun()
        {
            //TODO to be defined
        }
    }
}