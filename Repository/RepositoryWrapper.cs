using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;

        private IOwnerRepository _owner;

        private IAccountRepository _account;

        public IOwnerRepository Owner
        {
            get
            {
                if(_owner == null)
                {
                    _owner = new OwnerRepository(_repositoryContext);
                }
                return _owner;
            }
        }

        public IAccountRepository Acccount
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repositoryContext);
                }
                return _account;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
