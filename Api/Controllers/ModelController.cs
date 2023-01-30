using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo.Interfaces;
using Repo.Models.Model;
using Service.Model;

namespace Api.Controllers;

	/// <summary>
	///     Модели
	/// </summary>
	[Route("/[Controller]")]
	[Produces("application/json")]
	public class ModelController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IModelService _model;

		public ModelController(IModelService model)
		{
			_model = model;
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
		public async Task<BaseResponse<long>> Add([FromQuery] AddModelRequest model)
		{//[FromQuery] long id, [FromQuery] string name, [FromQuery] long baseprice
			var result = await _model.Add(model.ID,model.Name,model.BasePrice);
			return new BaseResponse<long>(result?.ID ?? 0);
		}
		
		/// <summary>
		///     Получить список всех Моделей
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route($"{nameof(Get)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<GetModelResponse>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		public async Task<BaseResponse<GetModelResponse>> Get([FromQuery] GetModelRequest request)
		{
			var result = await _model.GetAllModelsAsync(request);
			return new BaseResponse<GetModelResponse>(result);
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
		public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] string name, [FromQuery] long baseprice)
		{
			await _model.Update(id, name, baseprice);
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
			await _model.Delete(id);
			return new BaseResponse();
		}
	}
