using System;

namespace 測試模型.Models.ToDoService
{
    internal class RecordService
    {
        public DTO.RecordTypeVO recordType { get; set; }


        public bool Save(decimal value, decimal total)
        {
            bool result = false;
            if (recordType == DTO.RecordTypeVO.ToDataBase)
            {
                var context = new DbModel.DataContext(Startup._Configuration);
                context.UserValues.Add(new DbModel.UserValues
                {
                    Value = value,
                    Total = total
                });
                try
                {
                    context.SaveChanges();
                    result = true;
                }
                catch
                {
                    //log
                    result = false;
                }

            }
            else
            {
                Interface.IFileAccess file = recordType switch
                {
                    DTO.RecordTypeVO.ToSFTP => new FtpModel.SFtp(),
                    DTO.RecordTypeVO.ToFTP => new FtpModel.Ftp(),
                    _ => throw new NotImplementedException(),
                };

                try
                {
                    var response = file.Write("192.168.0.xxx", $"{value},{total}");

                    if (response == true)
                        result = true;
                }
                catch
                {
                    //log
                    result = false;
                }
            }

            return result;

        }
    }
}
