namespace Application.Features.Accounts.Constants;

public static class AccountsBusinessMessages
{
    public const string AccountNotExists = "Account not exists.";
    public const string UserCanHaveAtMostOneAccount = "Bir kullanıcı birden fazla hesaba sahip olamaz.";
    public const string NationalIdentificationNumberMustBeUnique = "Girilen kimlik numarası sistemde zaten kayıtlıdır.";
    public const string UserCanOnlyUpdateTheirOwnAccount = "Kullanıcı yalnızca kendi hesabına ait verileri düzenleyebilir.";
}