using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Option;
using Titaet2.Repo.Pagination;

namespace Repo.Services;

public class OptionService : IOptionService
{
	private readonly ApplicationContext _db;

	public OptionService(ApplicationContext db)
	{
		_db = db;
	}

	public async Task<Option> Add(long optionTypID, string name, string img, long price)
	{
		
		var option = new Option
		{
			OptionTypID = optionTypID,
			Name = name,
			IMG = img,
			Price = price
		};
		await _db.AddAsync(option);
		await _db.SaveChangesAsync();
		
		return option;

	}

	public async Task<GetOptionResponse> GetAllOptionsAsync(GetOptionRequest request)
	{
		return await _db.Options.GetPageAsync<GetOptionResponse, Option, OptionShortModel>(request, option =>
			new OptionShortModel
			{
				ID = option.ID,
				OptionTypID = option.OptionTypID,
				Name = option.Name,
				IMG = option.IMG
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



	public async Task<GetOptionResponse> GetOptionAsync(GetOptionRequest request)
	{
		return await _db.Options.GetPageAsync<GetOptionResponse, Option, OptionShortModel>(request, option =>
			new OptionShortModel
			{
				ID = option.ID,
				OptionTypID = option.OptionTypID,
				Name = option.Name,
				IMG = option.IMG
			});
		
	}

	
	public async Task Update(long id, long optionTypID, string name, string img, long price)
	{
		var option = await _db.Options.FirstOrDefaultAsync(x => x.ID == id);
		if (option is null)
			throw new BAVException($" ID = {id} is not found!", EnumErrorCode.EntityIsNotFound);
		
		if (optionTypID > 0)
		{
			option.OptionTypID = optionTypID;
		}
		
		if (!string.IsNullOrWhiteSpace(name))
			option.Name = name;

		
		await _db.SaveChangesAsync();
	}


	public async Task Delete(long id)
	{
		var option = await _db.Options.FirstOrDefaultAsync(x=> x.ID == id);
		if (option is null)
			throw new BAVException("Option is not exists!", EnumErrorCode.EntityIsNotFound);

		_db.Options.Remove(option);
		await _db.SaveChangesAsync();
	}


}
