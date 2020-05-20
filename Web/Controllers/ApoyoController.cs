using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApoyoController: ControllerBase
    {
        private readonly ApoyoService _apoyoService;
        public ApoyoController(PersonaContext context)
        {
            _apoyoService = new ApoyoService(context);
        }
        // GET: api/Apoyo
        [HttpGet]
        public IEnumerable<ApoyoViewModel> Gets()
        {
            var apoyos = _apoyoService.ConsultarTodos().Select(p=> new ApoyoViewModel(p));
            return apoyos;
        }

        // POST: api/Apoyo
        [HttpPost]
        public ActionResult<ApoyoViewModel> Post(ApoyoInputModel apoyoInput)
        {
            Apoyo apoyo = MapearApoyo(apoyoInput);
            var response = _apoyoService.Guardar(apoyo);
            if (response.Error) 
            {  
                //------------------------------------------------------------------------------------
                //Retornar los mensajes de validación adicionales en el mismo fomato que el ModalState
                ModelState.AddModelError("Guardar Persona", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
                //------------------------------------------------------------------------------------
                //return BadRequest(response.Mensaje);
            }
            return Ok(response.Apoyo);
        }

        private Apoyo MapearApoyo(ApoyoInputModel apoyoInput)
        {
            var apoyo = new Apoyo
            {
                ApoyoId = apoyoInput.ApoyoId,
                PersonaId = apoyoInput.PersonaId,
                Valor = apoyoInput.Valor,
                Modalidad = apoyoInput.Modalidad,
                Fecha = apoyoInput.Fecha,
                
            };
            return apoyo;
        
    }
        
    }
}