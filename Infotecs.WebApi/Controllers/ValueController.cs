using Infotecs.Application.Common.Exceptions;
using Infotecs.Application.Interfaces;
using Infotecs.Application.Results.Commands.CreateResult;
using Infotecs.Application.Results.Commands.DeleteResult;
using Infotecs.Application.Values.Commands.CreateValue;
using Infotecs.Application.Values.Commands.DeleteValue;
using Infotecs.Application.Values.Queries.GetValueList;
using Infotecs.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Xml.Linq;

namespace Infotecs.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValueController : BaseController
    {
        private readonly ICSVService _csvService;

        public ValueController(ICSVService cSVService) => _csvService = cSVService;

        /// <summary>
        /// Запрашивает файл => парсит данные => записывает в таблицу Values + посчитанные данные в Results
        /// </summary>
        /// <remarks>
        /// POST /Value/Method 1
        /// </remarks>
        /// <param name="file" example="test.csv">File (csv)</param>
        /// <response code="200">Всё хорошо</response>
        /// <response code="500">Медиатр не инициализирован</response>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ParseFileException"></exception>
        /// <exception cref="ValidationProblemDetails"></exception>
        [HttpPost("Method 1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetValuesCSV(IFormFileCollection file)
        {
            if (file.Count == 0)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (file[0].ContentType != "text/csv")
            {
                throw new ArgumentException("Wrong format file", nameof(file));
            }

            string fileName = file[0].FileName;

            var values = _csvService.ReadCSV(file[0].OpenReadStream(), fileName);

            if (Mediator != null)
            {
                if (values.Any())
                {
                    // Команда удаления для Value
                    var deleteValuesCommand = new DeleteValueCommand
                    {
                        FileName = fileName
                    };

                    await Mediator.Send(deleteValuesCommand);

                    // Команда удаления для Result
                    var deleteResultCommand = new DeleteResultCommand
                    {
                        FileName = fileName
                    };

                    await Mediator.Send(deleteResultCommand);

                    // Переменные для счета значений Result
                    bool NeedInitParams = true;
                    DateTime minDateTime = new(), maxDateTime = new();
                    int avgSeconds = 0;
                    int maxSeconds = 0, minSeconds = 0;
                    float avgIndicator = 0, medianIndicator = 0, minIndicator = 0, maxIndicator = 0;
                    int rowCount = values.Count();


                    foreach (var value in values)
                    {
                        // Команда добавления для Value
                        var createValueCommand = new CreateValueCommand
                        {
                            FileName = value.FileName!,
                            DateAndTime = value.DateAndTime,
                            Seсonds = value.Seсonds,
                            Indicator = value.Indicator,
                        };

                        await Mediator.Send(createValueCommand);

                        #region Считаем значения для таблицы RESULT
                        avgSeconds += value.Seсonds;
                        avgIndicator += value.Indicator;

                        if (NeedInitParams)
                        {
                            minSeconds = maxSeconds = value.Seсonds;
                            minDateTime = value.DateAndTime;
                            maxDateTime = value.DateAndTime;
                            NeedInitParams = false;
                        }
                        else
                        {
                            maxSeconds = (value.Seсonds > maxSeconds) ? value.Seсonds : maxSeconds;
                            minSeconds = (value.Seсonds < minSeconds) ? value.Seсonds : minSeconds;
                            minDateTime = (value.DateAndTime < minDateTime) ? value.DateAndTime : minDateTime;
                            maxDateTime = (value.DateAndTime > minDateTime) ? value.DateAndTime : minDateTime;
                        }
                        #endregion

                    }

                    #region Считаем значения для таблицы RESULT
                    var allTime = maxDateTime - minDateTime;
                    avgSeconds /= values.Count();
                    avgIndicator /= values.Count();

                    var fr = values.OrderBy(x => x.Indicator).ToList();

                    if (fr.Count % 2 == 0)
                    {
                        medianIndicator = (fr.ElementAt((fr.Count / 2) - 1).Indicator + fr.ElementAt(fr.Count / 2).Indicator) / 2;
                    }
                    else
                    {
                        var ind = Convert.ToInt32(Math.Floor(fr.Count / 2.0));
                        medianIndicator = fr.ElementAt(ind).Indicator;
                    }

                    minIndicator = fr.First().Indicator;
                    maxIndicator = fr.Last().Indicator;
                    #endregion

                    // Команда добавления для Result
                    var createResultCommand = new CreateResultCommand
                    {
                        FileName = fileName,
                        AllTime = allTime,
                        MinDateAndTime = minDateTime,
                        AvgSeсonds = avgSeconds,
                        AvgIndicator = avgIndicator,
                        MedianIndicator = medianIndicator,
                        MinIndicator = minIndicator,
                        MaxIndicator = maxIndicator,
                        CountStrings = rowCount
                    };

                    await Mediator.Send(createResultCommand);

                    return Ok();
                }
                
                // Пустой файл
                return Ok(new ParseFileException(file[0].FileName));
            }

            return Problem(statusCode: 500);
        }


        /// <summary>
        /// Список всех записей из таблицы Values по имени файла
        /// </summary>
        /// <param name="fileName" example="test.csv">Имя файла</param>
        /// <returns>Возвращает ValueListVm</returns>
        /// <response code="200">Всё хорошо</response>
        /// <response code="500">Медиатр не инициализирован</response>
        [HttpPost("Method 3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ValueListVm>> GetAll(string fileName)
        {
            var query = new GetValueListQuery()
            {
                FileName = fileName
            };

            if (Mediator != null)
            {
                var vm = await Mediator.Send(query);

                return Ok(vm);
            }

            return Problem(statusCode: 500);
        }
    }
}
