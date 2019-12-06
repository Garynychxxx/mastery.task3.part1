using NUnit.Framework;

namespace Core
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void Setup()
        {
           //TODO to be defined
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Current.Close();
        }
    }
}