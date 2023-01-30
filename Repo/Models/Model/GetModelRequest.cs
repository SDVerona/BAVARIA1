using Titaet2.Repo.Pagination;

namespace Repo.Models.Model;

public class GetModelRequest : IPaginationRequest
{
    public long? ID { get; set; } = null;

    public Page Page { get; set; } = new Page();
}