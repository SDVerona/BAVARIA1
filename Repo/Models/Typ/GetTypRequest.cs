using Titaet2.Repo.Pagination;

namespace Repo.Models.Typ{

public class GetTypRequest : IPaginationRequest
{
	public long? ID { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}