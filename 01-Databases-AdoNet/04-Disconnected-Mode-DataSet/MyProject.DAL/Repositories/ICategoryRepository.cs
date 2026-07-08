namespace MyProject.DAL.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> TopFiveCategoryAsync();
    }
}
