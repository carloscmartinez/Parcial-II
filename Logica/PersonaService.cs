using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Logica
{
    public class PersonaService
    {
        private readonly PersonaContext _context;
      public PersonaService(PersonaContext context)
      {
          _context = context;
      } 
      
      public GuardarPersonaResponse Guardar(Persona persona)
      {
          try
          {
              var personaAux = _context.Personas.Find(persona.PersonaId);
              if (personaAux != null)
              {
                  return new GuardarPersonaResponse($"Error de la aplicacion: La Persona ya se encuentra registrada!");
              }
              _context.Personas.Add(persona);
              _context.SaveChanges();
              return new GuardarPersonaResponse(persona);
          }
          catch (Exception e)
          {
              return new GuardarPersonaResponse($"Error de la aplicacion: {e.Message}");
          }
      }

      public List<Persona> ConsultarTodos()
      {
          List<Persona> personas = _context.Personas.Include(c => c.Apoyos).ToList();
          return personas;
      } 

      public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
    }
}