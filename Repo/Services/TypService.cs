using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Typ;
using Titaet2.Repo.Pagination;

namespace Repo.Services;

public class TypService : ITypService
{
	private readonly ApplicationContext _db;

	public TypService(ApplicationContext db)
	{
		_db = db;
	}

	public async Task<Typ> Add(string name)
	{
		
		var typ = new Typ
		{
			Name = name
		};
		await _db.AddAsync(typ);
		await _db.SaveChangesAsync();
		
		return typ;

	}

	public async Task<GetTypResponse> GetAllTypesAsync(GetTypRequest request)
	{
		return await _db.Types.GetPageAsync<GetTypResponse, Typ, TypShortModel>(request, typ =>
			new TypShortModel
			{
				ID = typ.ID,
				Name = typ.Name,
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



	public async Task<GetTypResponse> GetTypAsync(GetTypRequest request)
	{
		return await _db.Types.GetPageAsync<GetTypResponse, Typ, TypShortModel>(request, typ =>
			new TypShortModel
			{ID = typ.ID,
				Name =typ.Name,
			});
		
	}

	
	public async Task Update(long id, string name)
	{
		var typ = await _db.Types.FirstOrDefaultAsync(x => x.ID == id);
		if (typ is null)
			throw new BAVException($" ID = {id} is not found!", EnumErrorCode.EntityIsNotFound);
		
		if (!string.IsNullOrWhiteSpace(name))
			typ.Name = name;
		
		await _db.SaveChangesAsync();
	}


	public async Task Delete(long id)
	{
		var typ = await _db.Types.FirstOrDefaultAsync(x=> x.ID == id);
		if (typ is null)
			throw new BAVException("Type is not exists!", EnumErrorCode.EntityIsNotFound);

		_db.Types.Remove(typ);
		await _db.SaveChangesAsync();
	}


}
