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
        public PersonaController(PersonaContext context)
        {
            _personaService = new ApoyoService(context)
        }
        // GET: api/Apoyo
        [HttpGet]
        public IEnumerable<ApoyoViewModel> Gets()
        {
            var personas = _personaService.ConsultarTodos().Select(p=> new ApoyoViewModel(p));
            return personas;
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
               /*  ModelState.AddModelError("Guardar Cliente", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails); */
                //------------------------------------------------------------------------------------
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Apoyo);
        }

        private Apoyo MapearApoyo(ApoyoInputModel apoyoInput)
        {
            var apoyo = new Apoyo
            {
                apoyoId = apoyoInput.ApoyoId,
                valor = apoyoInput.Valor,
                modalidad = apoyoInput.Modalidad,
                fecha = apoyoInput.Fecha,
                
            };
            return apoyo;
        
    }
        
    }
}