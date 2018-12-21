using log4net.Config;
using log4net.Layout;
using log4net.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unity;
using Unity.log4net;

namespace log4net.Tests
{
    [TestClass]
    public class Log4netFixture
    {
        private static IUnityContainer _container;
        private static ILoggerRepository _repository;
        private static StringAppender _apender;
        private LoggedType _instance;
        private string _message;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _apender = new StringAppender() { Layout = new PatternLayout("[%p] %c %M - %m") };
            _repository = LogManager.CreateRepository(Guid.NewGuid().ToString());
            BasicConfigurator.Configure(_apender);
        }

        [TestInitialize]
        public void TestSetup()
        {
            _container = new UnityContainer();
            _container.AddNewExtension<Log4NetExtension>();

            _apender.Reset();
            _message = Guid.NewGuid().ToString();
            _instance = _container.Resolve<LoggedType>();
        }

        [TestMethod]
        public void Log4net_can_resolve_test_type()
        {
            Assert.IsNotNull(_instance);
            Assert.IsNotNull(_instance.ResolvedLogger);
            Assert.IsNotNull(_instance.StaticLogger);
        }

        [TestMethod]
        public void Log4net_default_name()
        {
            _instance.StaticLogger.Info(_message);
            var message1 = _apender.ToString();

            _apender.Reset();

            _instance.ResolvedLogger.Info(_message);
            var message2 = _apender.ToString();

            Assert.AreEqual(message1, message2);
        }

        [TestMethod]
        public void Log4net_correct_type()
        {
            _apender.Layout = new PatternLayout("%c");
            _instance.ResolvedLogger.Info(_message);
            Assert.AreEqual(typeof(LoggedType).FullName, _apender.ToString());
        }

        [TestMethod]
        public void Log4net_change_name()
        {
            _apender.Layout = new PatternLayout("%c");

            _container.RegisterType<LoggedType>(typeof(LoggedType).Name)
                      .Configure<Log4NetExtension>()
                      .GetName = (t) => $"{t.Name}";

            var instance = _container.Resolve<LoggedType>(typeof(LoggedType).Name);
            instance.ResolvedLogger.Info(_message);

            Assert.AreEqual($"{typeof(LoggedType).Name}", _apender.ToString());
        }


        public class LoggedType
        {
            public LoggedType(ILog log)
            {
                ResolvedLogger = log;
                StaticLogger = LogManager.GetLogger(typeof(LoggedType));
            }

            public ILog ResolvedLogger { get; }


            public ILog StaticLogger { get; }
        }
    }
}
