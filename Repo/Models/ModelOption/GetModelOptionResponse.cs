using Repo.Models.Model;
using Titaet2.Repo.Pagination;

namespace Repo.Models.ModelOption;

public class GetModelOptionResponse : IPaginationResponse<ModelOptionShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ModelOptionShortModel> Items { get; set; }
}

