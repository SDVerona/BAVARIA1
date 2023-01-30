using Data.Models;
using Repo.Models.Model;

namespace Repo.Interfaces;

public interface IModelService
{
    Task<Model> Add(long modelId, string name, long baseprice);

    Task<GetModelResponse> GetAllModelsAsync(GetModelRequest model);
    
    Task Update(long id, string name, long baseprice);
    
    Task Delete(long ID);
}