using Titaet2.Repo.Pagination;

namespace Repo.Models.OptionType;

public class GetOptionTypeRequest : IPaginationRequest
{
    public long? ID { get; set; } = null;

    public Page Page { get; set; } = new Page();
}