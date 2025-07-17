namespace Movie.Core.DomainContracts;

public interface IBaseRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetAsync(int id);
    Task PutAsync(int id, T item);
    Task PostAsync(T item);
    Task DeleteAsync(int id);
}