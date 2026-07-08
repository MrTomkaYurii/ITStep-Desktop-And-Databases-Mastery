using MyProject.DAL.Repositories;

namespace ConsoleApp
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public void GetAllInfoAboutCategory()
        {
            int id = 1;
            var product = _unitOfWork._categoryRepository.GetAsync(id).Result;
            Console.WriteLine("Інфорпмація про продукт - {0}", product.Name);

            Console.WriteLine("Job is Done! from the Console Product Service");
        }
    }
}
