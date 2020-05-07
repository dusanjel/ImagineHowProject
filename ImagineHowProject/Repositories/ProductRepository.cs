using ImagineHowProject.Interfaces;
using ImagineHowProject.Models;
using ImagineHowProject.Repositories;

namespace ImagineHowProject.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ImagineHowProjectContext context) : base(context)
        {
        }

        public ImagineHowProjectContext ImagineHowProjectContext
        {
            get { return Context as ImagineHowProjectContext; }
        }
    }
}
