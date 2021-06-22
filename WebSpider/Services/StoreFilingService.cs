using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using WebSpider.Insfrastracture;
using WebSpider.Insfrastracture.Dtos;

namespace WebSpider.Services
{
    public class StoreFilingService : IStoreService
    {
        private readonly string _Path;
        public StoreFilingService(IOptions<StorageOptions> options)
        {
            _Path = options.Value.FilingSavepath;
        }


        public async Task<ResponseDto<bool>> SaveAsync(string Data, string FileName)
        {
            try
            {
                if (!Directory.Exists(_Path))
                    Directory.CreateDirectory(_Path);
                using StreamWriter writer = new StreamWriter($"{_Path}/{FileName}.html");
                await writer.WriteAsync(Data);
                return new ResponseDto<bool>() {Data=true,Statuse=true,Message="Data saved SuccesFully" };
            }
            catch (Exception ex)
            {
                //log ex 
                return new ResponseDto<bool>() { Data = false, Statuse = false, Message =ex.Message };
            }
         
        }
    }
}
