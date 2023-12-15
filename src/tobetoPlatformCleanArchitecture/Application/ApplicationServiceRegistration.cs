using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Accounts;
using Application.Services.Cities;
using Application.Services.Countries;
using Application.Services.Addresses;
using Application.Services.Districts;
using Application.Services.Capabilities;
using Application.Services.AccountCapabilities;
using Application.Services.ForeignLanguageLevels;
using Application.Services.ForeignLanguages;
using Application.Services.AccountForeignLanguageMetadatas;
using Application.Services.Certificates;
using Application.Services.AccountCertificates;
using Application.Services.SocialMediaPlatforms;
using Application.Services.AccountSocialMediaPlatforms;
using Application.Services.GraduationStatuses;
using Application.Services.Colleges;
using Application.Services.EducationPrograms;
using Application.Services.AccountCollageMetadatas;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<IAccountsService, AccountsManager>();
        services.AddScoped<ICitiesService, CitiesManager>();
        services.AddScoped<ICountriesService, CountriesManager>();
        services.AddScoped<IAddressesService, AddressesManager>();
        services.AddScoped<IDistrictsService, DistrictsManager>();
        services.AddScoped<ICapabilitiesService, CapabilitiesManager>();
        services.AddScoped<IAccountCapabilitiesService, AccountCapabilitiesManager>();
        services.AddScoped<IForeignLanguageLevelsService, ForeignLanguageLevelsManager>();
        services.AddScoped<IForeignLanguagesService, ForeignLanguagesManager>();
        services.AddScoped<IAccountForeignLanguageMetadatasService, AccountForeignLanguageMetadatasManager>();
        services.AddScoped<ICertificatesService, CertificatesManager>();
        services.AddScoped<IAccountCertificatesService, AccountCertificatesManager>();
        services.AddScoped<ISocialMediaPlatformsService, SocialMediaPlatformsManager>();
        services.AddScoped<IAccountSocialMediaPlatformsService, AccountSocialMediaPlatformsManager>();
        services.AddScoped<IGraduationStatusesService, GraduationStatusesManager>();
        services.AddScoped<ICollegesService, CollegesManager>();
        services.AddScoped<IEducationProgramsService, EducationProgramsManager>();
        services.AddScoped<IAccountCollageMetadatasService, AccountCollageMetadatasManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
