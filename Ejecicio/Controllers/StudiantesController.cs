using Ejecicio.Service;
using Ejecicio.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Ejecicio.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [RoutePrefix("app/usuario")]
    public class StudiantesController : ApiController
    {
        EstudianteService service = new EstudianteService();
        [HttpGet]
        [Route("get")]
        public List<EstudianteVM> Index()
        {
            return service.PersonasList();
        }
        [Route("getById/{id}")]
        public  EstudianteVM GetStudent(int id)
        {
            return service.getById(id);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult CreatePersona(EstudianteVM estudianteVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            service.Add(estudianteVM);
            return Ok(estudianteVM);

        }
        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(EstudianteVM estudianteVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            service.Update(estudianteVM);
            return Ok(estudianteVM);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (!service.Delete(id))
            {
                return BadRequest();
            }
            return Ok(id);


        }
    }
}
