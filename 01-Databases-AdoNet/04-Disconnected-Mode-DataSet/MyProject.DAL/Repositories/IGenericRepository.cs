namespace MyProject.DAL.Repositories
{
    public interface IGenericRepository<T>
    {


        //Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);


        //Task DeleteAsync(int id);
        //Task<int> AddRangeAsync(IEnumerable<T> list);
        //Task ReplaceAsync(T t);
        //Task<int> AddAsync(T t);
    }
}
