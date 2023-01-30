using Repo.Models.Model;
using Repo.Models.OptionTypes;
using Titaet2.Repo.Pagination;

namespace Repo.Models.OptionType;

public class GetOptionTypeResponse : IPaginationResponse<OptionTypeShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<OptionTypeShortModel> Items { get; set; }
}
