namespace Navicon.Configuration.Common
{
    using System;
    using global::Common.Logging;

    public class TestClass
    {
        public void TestMethod()
        {
            ILog logger = LogManager.GetLogger(GetType().FullName);
            logger.Info("Hello world!");
        }
    }
}