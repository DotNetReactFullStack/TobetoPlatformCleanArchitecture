using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountForeignLanguageMetadatas.Queries.GetListByAccountId;
public class GetListByAccountIdAccountForeingLanguageMetaDataItemDto : IDto
{
    public int Id { get; set; }
    public string ForeingLanguageName { get; set; }
    public string ForeignLanguageLevelName { get; set; }
}
