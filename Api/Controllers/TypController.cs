using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo.Interfaces;
using Repo.Models.Model;
using Repo.Models.Typ;
using Service.Model;

namespace Api.Controllers;

/// <summary>
///     Модели
/// </summary>
[Route("/[Controller]")]
[Produces("application/json")]

public class TypController : Microsoft.AspNetCore.Mvc.Controller
{
    		private readonly ITypService _typ;

		public TypController(ITypService typ)
		{
			_typ = typ;
		}

		/// <summary>
		///     Добавить модель
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[Route($"{nameof(Add)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse<long>> Add([FromQuery] AddTypRequest typ)
		{
			var result = await _typ.Add(typ.Name);
			return new BaseResponse<long>(result?.ID ?? 0);
		}

		/// <summary>
		///     Получить список всех факультетов
		/// </summary>
		/// <returns></returns>
		/*[HttpGet]
		[Route($"{nameof(Search)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<GetModelResponse>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		public async Task<BaseResponse<GetModelResponse>> Search([FromQuery] ModelGetModel model)
		{
			var result = await _card.SearchCard(model);
			return new BaseResponse<SearchCardResponse>(result);
		}*/
		
		/// <summary>
		///     Получить список всех Моделей
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route($"{nameof(Get)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<GetTypResponse>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		public async Task<BaseResponse<GetTypResponse>> Get([FromQuery] GetTypRequest request)
		{
			var result = await _typ.GetAllTypesAsync(request);
			return new BaseResponse<GetTypResponse>(result);
		}

		/// <summary>
		///     Переименовать Модель
		/// </summary>
		/// <returns></returns>
		[HttpPatch]
		[Route($"{nameof(Rename)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string name)
		{
			await _typ.Update(id, name);
			return new BaseResponse();
		}

		/// <summary>
		///     Удалить Модель
		/// </summary>
		/// <returns></returns>
		[HttpDelete]
		[Route($"{nameof(Delete)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse> Delete([FromQuery] long id)
		{
			await _typ.Delete(id);
			return new BaseResponse();
		}
}