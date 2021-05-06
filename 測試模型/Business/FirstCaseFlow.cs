using 測試模型.Models.DTO;

namespace 測試模型.Business
{
    public class FirstCaseFlow : Interface.IFlow<Models.DTO.CaseResponse>
    {
        public decimal Value { get; set; }

        public CaseResponse Work()
        {
            //這個流程假設了使用加法的邏輯
            var response = new CaseResponse();
            Interface.IMathService service = new Models.ToDoService.PlusService();
            service.X = Value;
            service.Y = Value;

            //由RecordService決定實際寫入的資料對象，這邊不選擇ToDataBase，因為沒有建DB，雖然應該可以模擬，但多於代碼容易造成問題失真故不實作
            var record = new Models.ToDoService.RecordService();
            record.recordType = RecordTypeVO.ToFTP;

            try
            {
                //透過IMathService，在實際執行時，我們不需要在意Service是使用哪種邏輯，只要記得運算它即可
                response.Total = service.Calculate();

                //RecordService不使用介面的原因，它不一定適用透過介面來整合的情境，因此這邊故意用這種方式來表達
                var saveDone = record.Save(Value, response.Total);
                if (saveDone)
                {
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            catch
            {
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
