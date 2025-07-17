using Movie.Core.Dtos;

namespace Movie.Services.Contracts
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task PutAsync(int id, T item);
        Task PostAsync(T item);
        Task DeleteAsync(int id);
    }
}