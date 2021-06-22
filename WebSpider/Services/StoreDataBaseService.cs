using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using WebSpider.Insfrastracture;
using WebSpider.Insfrastracture.Dtos;

namespace WebSpider.Services
{
    public class StoreDataBaseService : IStoreService
    {
        private readonly string _ConnectionString;
        public StoreDataBaseService(IOptions<StorageOptions> options)
        {
            _ConnectionString = options.Value.ConnectionString;
        }



        public Task<ResponseDto<bool>> SaveAsync(string Data,string FileName)
        {
            throw new NotImplementedException();
        }
    }
}
