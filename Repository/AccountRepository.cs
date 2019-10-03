using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Entities;
using Contracts;
using System.Linq;

namespace Repository
{
    public class AccountRepository :RepositoryBase<Account>,IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }

        public IEnumerable<Account> AccountByOwner(Guid ownerId)
        {
            return FindByCollection(a => a.OwnerId.Equals(ownerId));
        }

        public Account GetAccountById(Guid id)
        {
            return FindByCollection(ac => ac.Id == id)
                 .DefaultIfEmpty(new Account())
                 .FirstOrDefault();
        }

        public IEnumerable<Account> GetAllAccount()
        {
            return FindAll()
                .OrderBy(Ac => Ac.AccountType)
                .ToList();
        }
    }
}
