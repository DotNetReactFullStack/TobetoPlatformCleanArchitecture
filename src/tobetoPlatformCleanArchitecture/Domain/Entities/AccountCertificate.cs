using Core.Persistence.Repositories;

namespace Domain.Entities;

public class AccountCertificate : Entity<int>
{
    public int AccountId { get; set; }
    public int CertificateId { get; set; }
    public int Priority { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Certificate? Certificate { get; set; }

    public AccountCertificate()
    {

    }

    public AccountCertificate(int id, int accountId, int certificateId, int priority) : this()
    {
        Id = id;
        AccountId = accountId;
        CertificateId = certificateId;
        Priority = priority;
    }
}
