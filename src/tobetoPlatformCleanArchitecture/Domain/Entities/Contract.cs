using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Contract : Entity<int>
    {
        public int ContractTypeId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsActive { get; set; }

        public virtual ContractType? ContractType { get; set; }

        public Contract()
        {

        }

        public Contract(int id, int contractTypeId, string name, string path, bool isActive) : this()
        {
            Id = id;
            ContractTypeId = contractTypeId;
            Name = name;
            Path = path;
            IsActive = isActive;
        }
    }
}

