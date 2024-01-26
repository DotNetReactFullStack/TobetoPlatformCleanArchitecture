using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class AccountContract : Entity<int>
    {
        public int AccountId { get; set; }
        public int ContractId { get; set; }
        public bool IsAccept { get; set; }

        public Account? Account { get; set; }
        public Contract? Contract { get; set; }

        public AccountContract()
        {

        }

        public AccountContract(int id, int accountId, int contractId, bool isAccept, Account? account, Contract? contract) : this()
        {
            Id = id;
            AccountId = accountId;
            ContractId = contractId;
            IsAccept = isAccept;
            Account = account;
            Contract = contract;
        }
    }
}

