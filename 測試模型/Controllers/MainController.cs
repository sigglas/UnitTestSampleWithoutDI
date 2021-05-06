using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 測試模型.Models.DTO;

namespace 測試模型.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public CaseResponse Post([FromBody] CaseRequest request)
        {
            CaseResponse response = default;

            //DI可能無法正確表現我想要的測試模型，可能會遺漏很多概念上的資訊，所以這專案全部都用new Object()的方式來表達

            //條件可能來自request 也可能來自config 也可能寫死 依照需求；甚至也可能只靠DI介面進來，但為表現測試狀況的切換，這邊用request
            Interface.IFlow<CaseResponse> workFlow = request.condition switch
            {
                SomeCondition.CaseA => new Business.FirstCaseFlow(),
                SomeCondition.CaseB => new Business.SecondCaseFlow(),
                _ => null
            };
            workFlow.Value = request.AValue;

            try
            {
                response = workFlow.Work();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error by workFlow.Work");
            }

            return response;

        }

    }
}
