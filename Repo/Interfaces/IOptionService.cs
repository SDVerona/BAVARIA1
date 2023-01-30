using Data.Models;
using Repo.Models.Option;
using Repo.Models.Typ;

namespace Repo.Interfaces;

public interface IOptionService
{
    Task<Option> Add(long OptionTypID, string name, string IMG, long price);

    Task<GetOptionResponse> GetAllOptionsAsync(GetOptionRequest model);
    
    Task Update(long ID, long OptionTypID, string name, string IMG, long price);
    
    Task Delete(long ID);
}