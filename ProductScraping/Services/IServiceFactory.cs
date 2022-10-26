using System;
namespace ProductScraping.Services
{
    public interface IServiceFactory
    {
        IServiceFactory<T> GetService<T>() where T : class;
    }
}

