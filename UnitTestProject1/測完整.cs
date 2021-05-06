using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using 測試模型.Controllers;

namespace UnitTestProject1
{
    /// <summary>
    /// Controller一定是public開放層級
    /// </summary>
    [TestClass]
    public class 測完整
    {
        [TestMethod]
        public void MainControllerTest()
        {
            //參數
            decimal value = 1;

            //預期
            bool isSuccess = true;
            decimal total = 2;

           var controller = new MainController(new MyLoggerAdapter<MainController>());
      

            //結果
            var result = controller.Post(new 測試模型.Models.DTO.CaseRequest
            {
                AValue = value,
                condition = 測試模型.Models.DTO.SomeCondition.CaseA
            });

            Assert.AreEqual(isSuccess, result.IsSuccess);
            Assert.AreEqual(total, result.Total);

        }


        class MyLoggerAdapter<T> : ILogger<T>, IDisposable
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return this;
            }

            public void Dispose()
            {
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
            }
        }
    }
}
