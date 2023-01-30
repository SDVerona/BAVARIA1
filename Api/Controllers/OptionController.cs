using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repo.Interfaces;
using Repo.Models.ModelOption;
using Repo.Models.Option;
using Service.Model;

namespace Api.Controllers;

    /// <summary>
    ///     Опции
    /// </summary>
    [Route("/[Controller]")]
    [Produces("application/json")]
    public class OptionController
    {
        private readonly IOptionService _option;

		public OptionController(IOptionService option)
		{
			_option = option;
		}

		/// <summary>
		///     Добавить
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[Route($"{nameof(Add)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<long>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse<long>> Add([FromQuery] AddOptionRequest option)
		{
			var result = await _option.Add(option.OptionTypID, option.Name, option.IMG, option.Price);
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
		///     Получить список всех 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route($"{nameof(Get)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse<GetOptionResponse>))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		public async Task<BaseResponse<GetOptionResponse>> Get([FromQuery] GetOptionRequest request)
		{
			var result = await _option.GetAllOptionsAsync(request);
			return new BaseResponse<GetOptionResponse>(result);
		}

		/// <summary>
		///     Переименовать 
		/// </summary>
		/// <returns></returns>
		[HttpPatch]
		[Route($"{nameof(Rename)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse> Rename([FromQuery] long id, [FromQuery] long optiontypID,[FromQuery] string name, [FromQuery] string img, [FromQuery] long price)
		{
			await _option.Update(id,optiontypID,name,img,price);
			return new BaseResponse();
		}

		/// <summary>
		///     Удалить
		/// </summary>
		/// <returns></returns>
		[HttpDelete]
		[Route($"{nameof(Delete)}")]
		[ProducesResponseType(200, Type = typeof(BaseResponse))]
		[ProducesResponseType(400, Type = typeof(BaseResponse))]
		//[Authorize]
		public async Task<BaseResponse> Delete([FromQuery] long id)
		{
			await _option.Delete(id);
			return new BaseResponse();
		}
    }