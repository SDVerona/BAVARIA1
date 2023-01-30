using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Model;
using Repo.Models.OptionType;
using Repo.Models.OptionTypes;
using Titaet2.Repo.Pagination;

namespace Repo.Services;

public class OptionTypeService : IOptionTypeService
{
	private readonly ApplicationContext _db;

	public OptionTypeService(ApplicationContext db)
	{
		_db = db;
	}

	public async Task<OptionType> Add(long typID, string name)
	{
		
		var optiontype = new OptionType
		{
			TypID = typID,
			Name = name
		};
		await _db.AddAsync(optiontype);
		await _db.SaveChangesAsync();
		
		return optiontype;

	}

	public async Task<GetOptionTypeResponse> GetAllOptionTypesAsync(GetOptionTypeRequest request)
	{
		return await _db.OptionTypes.GetPageAsync<GetOptionTypeResponse, OptionType, OptionTypeShortModel>(request, optionType =>
			new OptionTypeShortModel
			{
				ID = optionType.ID,
				TypID = optionType.TypID,
				Name = optionType.Name
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



	public async Task<GetOptionTypeResponse> GetOptionTypeAsync(GetOptionTypeRequest request)
	{
		return await _db.OptionTypes.GetPageAsync<GetOptionTypeResponse, OptionType, OptionTypeShortModel>(request, optionType =>
			new OptionTypeShortModel
			{
				ID = optionType.ID,
				TypID = optionType.TypID,
				Name = optionType.Name
			});
		
	}

	
	public async Task Update(long id, long typID, string name)
	{
		var optionType = await _db.OptionTypes.FirstOrDefaultAsync(x => x.ID == id);
		if (optionType is null)
			throw new BAVException($" ID = {id} is not found!", EnumErrorCode.EntityIsNotFound);
		
		if (typID > 0)
		{
			optionType.TypID = typID;
		}
		
		if (!string.IsNullOrWhiteSpace(name))
			optionType.Name = name;
		
		await _db.SaveChangesAsync();
	}


	public async Task Delete(long id)
	{
		var optionType = await _db.OptionTypes.FirstOrDefaultAsync(x=> x.ID == id);
		if (optionType is null)
			throw new BAVException("Option type is not exists!", EnumErrorCode.EntityIsNotFound);

		_db.OptionTypes.Remove(optionType);
		await _db.SaveChangesAsync();
	}


}
