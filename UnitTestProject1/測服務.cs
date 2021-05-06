using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 測試模型.Interface;
using 測試模型.Models.ToDoService;

namespace UnitTestProject1
{
    /// <summary>
    /// Service是internal保護層級，因此要測試需要在主專案上加入System.Runtime.CompilerServices.InternalsVisibleToAttribute，可以查看.csproj的內容
    /// 雖然也可以透過在各個Service上各自加入Attribute，但過於繁瑣因此不採用
    /// </summary>
    [TestClass]
    public class 測服務
    {
        [TestMethod]
        public void MultiplyServiceTest()
        {
            //參數
            decimal x = 1;
            decimal y = 1;

            //預期
            decimal total = 1;

            IMathService service = new MultiplyService();
            service.X = x;
            service.Y = y;

            //結果
            var result = service.Calculate();

            Assert.AreEqual(total, result);
        }

        [TestMethod]
        public void PlusServiceTest()
        {
            //參數
            decimal x = 1;
            decimal y = 1;

            //預期
            decimal total = 2;

            IMathService service = new PlusService();
            service.X = x;
            service.Y = y;

            //結果
            var result = service.Calculate();

            Assert.AreEqual(total, result);
        }

        [TestMethod]
        public void RecordServiceTest()
        {
            //ToDataBase日常不測

            //參數
            var recordType = 測試模型.Models.DTO.RecordTypeVO.ToFTP;
            decimal value = 1;
            decimal total = 1;

            //預期
            bool expected = true;

            var service = new RecordService();
            service.recordType = recordType;

            //結果
            var result = service.Save(value, total);

            Assert.AreEqual(expected, result);
        }
        
    }
}
