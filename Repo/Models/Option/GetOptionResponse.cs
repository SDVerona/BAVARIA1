using Titaet2.Repo.Pagination;

namespace Repo.Models.Option;

public class GetOptionResponse : IPaginationResponse<OptionShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<OptionShortModel> Items { get; set; }
}