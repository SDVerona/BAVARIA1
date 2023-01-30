using Data.Models;
using Repo.Models.Typ;

namespace Repo.Interfaces;

public interface ITypService
{
    Task<Typ> Add(string name);

    Task<GetTypResponse> GetAllTypesAsync(GetTypRequest model);
    
    Task Update(long ID, string name);
    
    Task Delete(long ID);
}