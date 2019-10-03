using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Entities;
using Contracts;
using System.Linq;
using Entities.ExtendedModels;
using Entities.Extensions;

namespace Repository
{
    public class ProductRepositry : RepositoryBase<Product>, IProductRepository
    {
        private RepositoryContext _repositryContext;
        public ProductRepositry(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositryContext = repositoryContext;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
