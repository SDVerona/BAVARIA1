using Repo.Models.Typ;
using Titaet2.Repo.Pagination;

namespace Repo.Models.Model;

public class GetModelResponse : IPaginationResponse<ModelShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ModelShortModel> Items { get; set; }
}