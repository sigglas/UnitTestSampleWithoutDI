namespace 測試模型.Interface
{
    public interface IFlow<T>
    {
        decimal Value { get; set; }
        
        T Work();
    }
}
