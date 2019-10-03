using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IProductRepository :IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProductById(Guid id);

    }
}
