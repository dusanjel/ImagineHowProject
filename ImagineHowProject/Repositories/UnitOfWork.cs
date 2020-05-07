using ImagineHowProject.Interfaces;
using ImagineHowProject.Models;

namespace ImagineHowProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImagineHowProjectContext _context;

        public UnitOfWork(ImagineHowProjectContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }

        public IProductRepository Products { get; private set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
