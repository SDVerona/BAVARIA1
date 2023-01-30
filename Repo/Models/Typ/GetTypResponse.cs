using System.Collections.Generic;
using Data.Models;
using Repo.Models.Typ;
using Titaet2.Repo.Pagination;

namespace Repo.Models.Typ
{

public class GetTypResponse : IPaginationResponse<TypShortModel>
{
	public Page Page { get; set; } = new Page();

	public long Count { get; set; }

	public IReadOnlyCollection<TypShortModel> Items { get; set; }
}
}