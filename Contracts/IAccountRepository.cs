using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IAccountRepository:IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountByOwner(Guid ownerId);
        IEnumerable<Account> GetAllAccount();

        Account GetAccountById(Guid id);
    }
}
