using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo.Interfaces;
using Repo.Models.Model;
using Repo.Models.ModelOption;
using Service.Model;

namespace Api.Controllers;

    /// <summary>
	///     Модели
	/// </summary>
	[Route("/[Controller]")]
	[Produces("application/json")]
	public class ModelOptionController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IModelOptionService _modelOption;

		public ModelOptionController(IModelOptionService modelOption)
		{
			_modelOption = modelOption;
		}

		/// <summary>
		///     Добавить Опцию модели
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[Route($"{nameof(Add)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse<long>> Add([FromQuery] AddModelOptionRequest modelOption)
		{
			var result = await _modelOption.Add(modelOption.ID, modelOption.ModelID, modelOption.OptionID);
			return new BaseResponse<long>(result?.ModelID ?? 0);
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
		///     Получить список всех Опций Модели
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route($"{nameof(Get)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<GetModelOptionResponse>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		public async Task<BaseResponse<GetModelOptionResponse>> Get([FromQuery] GetModelOptionRequest request)
		{
			var result = await _modelOption.GetAllModelOptionsAsync(request);
			return new BaseResponse<GetModelOptionResponse>(result);
		}

		/// <summary>
		///     Переименовать Опцию модели
		/// </summary>
		/// <returns></returns>
		[HttpPatch]
		[Route($"{nameof(Rename)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse> Rename([FromQuery] long id,[FromQuery] long modelID, [FromQuery] long optionID)
		{
			await _modelOption.Update(id, modelID, optionID);
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
			await _modelOption.Delete(id);
			return new BaseResponse();
		}
	}
