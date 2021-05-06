using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using 測試模型.Business;
using 測試模型.Interface;
using 測試模型.Models.DTO;

namespace UnitTestProject1
{
    /// <summary>
    /// Flow一定是public開放層級，因為模組可以搬移至另一個子專案，不需要依賴在Web專案上
    /// </summary>
    [TestClass]
    public class 測流程
    {
        [TestMethod]
        public void FirstCaseFlowTest()
        {
            //參數
            decimal value = 1;

            //預期
            bool isSuccess = true;
            decimal total = 2;

            IFlow<CaseResponse> flow = new FirstCaseFlow();
            flow.Value = value;

            //結果
            var result = flow.Work();

            Assert.AreEqual(isSuccess, result.IsSuccess);
            Assert.AreEqual(total, result.Total);

        }


        [TestMethod]
        public void SecondCaseFlowTest()
        {
            //參數
            decimal value = 2;

            //預期
            bool isSuccess = true;
            decimal total = 4;

            IFlow<CaseResponse> flow = new SecondCaseFlow();
            flow.Value = value;

            //結果
            var result = flow.Work();

            Assert.AreEqual(isSuccess, result.IsSuccess);
            Assert.AreEqual(total, result.Total);

        }
    }
}
