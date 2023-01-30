using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Model;
using Titaet2.Repo.Pagination;

namespace Repo.Services;

public class ModelService : IModelService
{
	private readonly ApplicationContext _db;

	public ModelService(ApplicationContext db)
	{
		_db = db;
	}

	public async Task<Model> Add(long modelId, string name, long baseprice)
	{
		
		var model = new Model
		{
			ID = modelId,
			Name = name,
			BasePrice = baseprice
		};
		await _db.AddAsync(model);
		await _db.SaveChangesAsync();
		
		return model;

	}

	public async Task<GetModelResponse> GetAllModelsAsync(GetModelRequest request)
	{
		return await _db.Models.GetPageAsync<GetModelResponse, Model, ModelShortModel>(request, model =>
			new ModelShortModel
			{
				ID = model.ID,
				Name = model.Name,
				BasePrice = model.BasePrice
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



	public async Task<GetModelResponse> GetModelAsync(GetModelRequest request)
	{
		return await _db.Models.GetPageAsync<GetModelResponse, Model, ModelShortModel>(request, model =>
			new ModelShortModel
			{
				ID = model.ID,
				Name =model.Name,
				BasePrice = model.BasePrice,
			});
		
	}

	
	public async Task Update(long id, string name, long baseprice)
	{
		var model = await _db.Models.FirstOrDefaultAsync(x => x.ID == id);
		if (model is null)
			throw new BAVException($" ID = {id} is not found!", EnumErrorCode.EntityIsNotFound);
		
		if (!string.IsNullOrWhiteSpace(name))
			model.Name = name;

		if (baseprice > 0)
		{
			model.BasePrice = baseprice;	
			
		}
		await _db.SaveChangesAsync();
	}


	public async Task Delete(long id)
	{
		//if (await _db.Models.AnyAsync(x => x.ID == id))
		var model = await _db.Models.FirstOrDefaultAsync(x => x.ID == id);
		if (model is null)
			throw new BAVException("Model is not exists!", EnumErrorCode.EntityIsNotFound);

		_db.Models.Remove(model);
		await _db.SaveChangesAsync();
	}


}
