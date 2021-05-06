namespace 測試模型.Models.ToDoService
{
    internal class MultiplyService : Interface.IMathService
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public decimal Calculate()
        {
            return X * Y;
        }
    }
}
