using Property.Web.Models;

namespace Property.Web.Services.Base
{
    public interface IApiService<T>
    {
        Task<ApiResponseModel<T>> GetAsync(int? id);
        Task<ApiResponseModel<IEnumerable<T>>> GetAllAsync();
        Task<ApiResponseModel<T>> AddAsync(T modelType);
        Task<ApiResponseModel<T>> UpdateAsync(T modelType);
        Task<ApiResponseModel<T>> DeleteAsync(int? id);
    }
}
