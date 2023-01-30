using Titaet2.Repo.Pagination;

namespace Repo.Models.Option;

public class GetOptionRequest : IPaginationRequest
{
    public long? ID { get; set; } = null;

    public Page Page { get; set; } = new Page();
}