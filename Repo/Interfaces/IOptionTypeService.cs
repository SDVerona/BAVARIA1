using Data.Models;
using Repo.Models.OptionType;

namespace Repo.Interfaces;

public interface IOptionTypeService
{
    Task<OptionType> Add(long TypID, string name);

    Task<GetOptionTypeResponse> GetAllOptionTypesAsync(GetOptionTypeRequest model);
    
    Task Update(long ID, long TypID, string name);
    
    Task Delete(long ID);
}