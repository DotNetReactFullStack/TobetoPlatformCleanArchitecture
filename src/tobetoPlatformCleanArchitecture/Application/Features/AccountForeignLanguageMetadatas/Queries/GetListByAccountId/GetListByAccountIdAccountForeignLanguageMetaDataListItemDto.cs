using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountForeignLanguageMetadatas.Queries.GetListByAccountId;
public class GetListByAccountIdAccountForeignLanguageMetaDataListItemDto : IDto
{
    public int Id { get; set; }
    public string ForeignLanguageName { get; set; }
    public string ForeignLanguageLevelName { get; set; }
}
