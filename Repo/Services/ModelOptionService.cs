using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.ModelOption;
using Titaet2.Repo.Pagination;

namespace Repo.Services;

public class ModelOptionService : IModelOptionService
{
	private readonly ApplicationContext _db;

	public ModelOptionService(ApplicationContext db)
	{
		_db = db;
	}

	public async Task<ModelOption> Add(long id, long modelID,long optionID)
	{
		
		var modelOption = new ModelOption
		{
			ID = id,
			ModelID = modelID,
			OptionID = optionID,
		};
		await _db.AddAsync(modelOption);
		await _db.SaveChangesAsync();
		
		return modelOption;

	}
	
	public async Task<GetModelOptionResponse> GetAllModelOptionsAsync(GetModelOptionRequest request)
	{
		return await _db.ModelOptions.GetPageAsync<GetModelOptionResponse, ModelOption, ModelOptionShortModel>(request, modelOption =>
			new ModelOptionShortModel
			{
				ID = modelOption.ID,
				ModelID = modelOption.ModelID,
				OptionID = modelOption.OptionID,
			});
	}

	/*public async Task<SearchCardResponse> SearchCard(CardGetModel model)
	{
		return await _db.Cards
			.Where(x =>
				x.PersonId.ToString().Contains(model.Search)
				|| (x.Id.ToString()).Contains(model.Search)
				).GetPageAsync<SearchCardResponse, Card, CardShortModel>(model, x => new CardShortModel
			{
				Id =x.Id,
				DiscontId = x.DiscontId,
				PersonId = x.PersonId,

			
			});
	}*/



	public async Task<GetModelOptionResponse> GetModelOptionsAsync(GetModelOptionRequest request)
	{
		return await _db.ModelOptions.GetPageAsync<GetModelOptionResponse, ModelOption, ModelOptionShortModel>(request, modelOption =>
			new ModelOptionShortModel
			{
				ID = modelOption.ID,
				ModelID = modelOption.ModelID,
				OptionID = modelOption.OptionID,
			});
		
	}

	
	public async Task Update(long id, long modelID, long optionID)
	{
		var modelOption = await _db.ModelOptions.FirstOrDefaultAsync(x => x.ID == id);
		if (modelOption is null)
			throw new BAVException($" ID = {id} is not found!", EnumErrorCode.EntityIsNotFound);

		if (optionID > 0)
		{
			modelOption.OptionID = optionID;
		}
		await _db.SaveChangesAsync();
	}


	public async Task Delete(long id)
	{
		var modelOption = await _db.ModelOptions.FirstOrDefaultAsync(x=> x.ID == id);
		if (modelOption is null)
			throw new BAVException("Model option is not exists!", EnumErrorCode.EntityIsNotFound);

		_db.ModelOptions.Remove(modelOption);
		await _db.SaveChangesAsync();
	}


}
