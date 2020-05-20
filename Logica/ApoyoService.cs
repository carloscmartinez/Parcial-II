using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ApoyoService
    {
      private readonly PersonaContext _context;
      public ApoyoService(PersonaContext context)
      {
          _context = context;
      } 
      
      public GuardarApoyoResponse Guardar(Apoyo apoyo)
      {
          try
          {
              var apoyoAux = _context.Apoyos.Find(apoyo.ApoyoId);
              if (apoyoAux != null)
              {
                  return new GuardarApoyoResponse($"Error de la aplicacion: El Apoyo ya se encuentra registrada!");
              }
              _context.Apoyos.Add(apoyo);
              _context.SaveChanges();
              return new GuardarApoyoResponse(apoyo);
          }
          catch (Exception e)
          {
              return new GuardarApoyoResponse($"Error de la aplicacion: {e.Message}");
          }
      }

      public List<Apoyo> ConsultarTodos()
      {
          List<Apoyo> apoyos = _context.Apoyos.ToList();
          return apoyos;
      } 

      public class GuardarApoyoResponse 
    {
        public GuardarApoyoResponse(Apoyo apoyo)
        {
            Error = false;
            Apoyo = apoyo;
        }
        public GuardarApoyoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Apoyo Apoyo { get; set; }
    }
    
    }
}