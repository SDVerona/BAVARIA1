using Data.Models;
using Repo.Models.ModelOption;

namespace Repo.Interfaces;

public interface IModelOptionService
{
    Task<ModelOption> Add(long ID, long ModelID, long optionID);

    Task<GetModelOptionResponse> GetAllModelOptionsAsync(GetModelOptionRequest model);
    
    Task Update(long ID, long ModelID, long optionID);
    
    Task Delete(long ID);
}