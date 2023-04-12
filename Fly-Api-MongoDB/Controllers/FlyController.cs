using fly_API.Models;
using fly_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace fly_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlyController : ControllerBase
    {
        public FlyService _flyService;

        public FlyController(FlyService flyService)
        {
            _flyService = flyService;
        }

        [HttpGet]
        public ActionResult<List<Fly>> Get()
        {
            return _flyService.Get();

        }

        [HttpGet("{id}")]
        public ActionResult<List<Fly>> GetId(string id)
        {
            var vuelo = _flyService.GetId(id)!;

            return Ok(vuelo)!;

        }

        [HttpPost]

        public ActionResult<Fly> Create(Fly vuelo)
        {

            _flyService.Create(vuelo);
            return Ok(vuelo);
        }

        [HttpPut("{id}")]

        public ActionResult Edit(Fly vuelo)
        {
            _flyService.Edit(vuelo.Id!, vuelo!);
            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(string id)
        {
            _flyService.Delete(id);
            return Ok();
        }
    }

}

