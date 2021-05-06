namespace 測試模型.Interface
{
    interface IFileAccess
    {
        string Read(string path);
        bool Write(string path, string data);

    }
}
