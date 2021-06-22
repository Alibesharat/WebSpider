using System.Threading.Tasks;
using WebSpider.Insfrastracture.Dtos;

namespace WebSpider.Services
{
    public interface IStoreService
    {

        Task<ResponseDto<bool>> SaveAsync(string Data,string FileName);
    }
}
