using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideotekaAPI.Models;

namespace VideotekaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozajmicaController : ControllerBase
    {
        readonly IRepository _repository;
        public PozajmicaController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Pozajmica>> Get()
        {
            return Ok(_repository.GetPozajmice());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Pozajmica> GetPozajmicaById(int id)
        {
            return Ok(_repository.GetPozajmicaById(id));
        }

        [HttpPost]
        public ActionResult PostPozajmica(Pozajmica pozajmica)
        {
            return Ok(_repository.CreatePozajmica(pozajmica));
        }

        [HttpPost("{id:int}")]
        public ActionResult DeletePozajmica(int id)
        {
            return Ok(_repository.DeletePozajmica(id));
        }

        [HttpPut]
        public ActionResult EditPozajmica(Pozajmica pozajmica)
        {
            return Ok(_repository.UpdatePozajmica(pozajmica));
        }


    }
}
