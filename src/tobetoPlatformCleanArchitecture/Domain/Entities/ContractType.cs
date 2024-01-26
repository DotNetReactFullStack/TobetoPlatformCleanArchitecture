using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ContractType : Entity<int>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Contract>? Contracts { get; set; }

        public ContractType()
        {

        }

        public ContractType(int id, string name, bool isActive) : this()
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
    }
}

