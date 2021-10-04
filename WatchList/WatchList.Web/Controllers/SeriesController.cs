using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchList.Interfaces;

namespace WatchList.Web.Controllers
{
    [Route("[controller]")]
    public class SeriesController : Controller
    {
        private readonly IRepository<Series> _seriesRepository;
        public SeriesController(IRepository<Series> seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }
        [HttpGet("")]
        public IActionResult List()
        {
            return Ok(_seriesRepository.List().Select(s => new SeriesModel(s)));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SeriesModel model)
        {
            _seriesRepository.Update(id, model.ToSeries());
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _seriesRepository.Remove(id);
            return NoContent(); ;
        }


        [HttpPost("")] 
        public IActionResult Insert([FromBody] SeriesModel model)
        {
            model.Id = _seriesRepository.nextId();

            Series series = model.ToSeries();

            _seriesRepository.Insert(series);
            return Created("", series);
        }


        [HttpGet("{id}")] 
        public IActionResult Consulta(int id)
        {
            return Ok(new SeriesModel(_seriesRepository.List().FirstOrDefault(s => s.Id == id)));
        }

    }
}
