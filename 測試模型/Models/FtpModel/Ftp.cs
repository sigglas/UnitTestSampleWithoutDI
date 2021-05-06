namespace 測試模型.Models.FtpModel
{
    public class Ftp : Interface.IFileAccess
    {
        public string Read(string path)
        {
            throw new System.NotImplementedException();
        }

        public bool Write(string path, string data)
        {
            return true;
        }
    }
}
