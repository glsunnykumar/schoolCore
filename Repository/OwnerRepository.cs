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
    public class OwnerRepository :RepositoryBase<Owner>, IOwnerRepository
    {
        private RepositoryContext _repositryContext; 
        public OwnerRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            _repositryContext = repositoryContext;
        }

        public void CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            Create(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }

        public IEnumerable<Owner> GetAllOwner()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCollection(owner => owner.Id == ownerId)
                .DefaultIfEmpty(new Owner())
                .FirstOrDefault();
        }

        public OwnerExtended GetOwnerWithDetails(Guid ownerId)
        {
            return new OwnerExtended(GetOwnerById(ownerId))
            {
                Accounts = _repositryContext.Accounts
                .Where(a => a.OwnerId == ownerId)
            };
        }

        public void UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Map(owner);
            Update(dbOwner);
        }
    }
}
