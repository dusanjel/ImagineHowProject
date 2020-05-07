using System;

namespace ImagineHowProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int SaveChanges();
    }
}
