using Infotecs.Application.Results.Queries.GetResultList;
using Infotecs.Application.Results.Queries.GetResultListFilter;
using Infotecs.Application.Values.Queries.GetValueList;
using Infotecs.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Drawing;

namespace Infotecs.WebApi.Controllers
{
    public struct Indictator
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }

    [Route("api/[controller]")]
    public class ResultController : BaseController
    {
        /// <summary>
        /// Список всех записей из таблицы Results
        /// </summary>
        /// <remarks>
        /// GET /Result/Method 2
        /// </remarks>
        /// <returns>Возвращает ResultListVm</returns>
        /// <response code="200">Всё хорошо</response>
        /// <response code="500">Медиатр не инициализирован</response>
        [HttpGet("Method 2")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultListVm>> GetAllResults()
        {
            var query = new GetResultListQuery();

            if (Mediator != null)
            {
                var vm = await Mediator.Send(query);

                return new JsonResult(vm);
            }

            return Problem(statusCode: 500);
        }


        /// <summary>
        /// Список записей подходящих под введеные фильтры
        /// </summary>
        /// <remarks>
        /// Поле FileName example="test.csv" - Имя файла<br /> 
        /// Поле FromDate example="2010-03-18 09:17:17" - Фильтр от какой даты<br /> 
        /// Поле ToDate example="2023-1-1" - Фильтр до какой даты<br /> 
        /// Поле SecondsLowerBoundle example="500" - Фильтр нижней границы для среднего времени выполнения (секунды)<br /> 
        /// Поле SecondsUpperBoundle example="1300" - Фильтр верхней границы для  среднего времени выполнения (секунды)<br /> 
        /// Поле IndicatorLowerBoundle example="300.5" - Фильтр нижней границы для среднего показателя<br /> 
        /// Поле IndicatorUpperBoundle example="1600.9" - Фильтр верхней границы для среднего показателя
        /// </remarks>
        /// <param name="filters"></param>
        /// <returns>Возвращает ResultListVm</returns>
        /// <response code="200">Всё хорошо</response>
        /// <response code="500">Медиатр не инициализирован</response>
        [HttpPost("Method 2")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResultListVm>> GetAllResultsFilter([FromForm] InputFilter filters)
        {
            var query = new GetResultListFilterQuery()
            {
                FileName = filters.FileName,
                FromDate = filters.FromDate,
                ToDate = filters.ToDate,
                SecondsLowerBoundle = filters.SecondsLowerBoundle,
                SecondsUpperBoundle = filters.SecondsUpperBoundle,
                IndicatorLowerBoundle = filters.IndicatorLowerBoundle,
                IndicatorUpperBoundle = filters.IndicatorUpperBoundle,
            };

            if (Mediator != null)
            {
                var vm = await Mediator.Send(query);

                return new JsonResult(vm);
            }

            return Problem(statusCode: 500);
        }
    }
}
