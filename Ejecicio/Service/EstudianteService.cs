using Ejecicio.Models;
using Ejecicio.VModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ejecicio.Service
{
    public class EstudianteService
    {
        public List<EstudianteVM> PersonasList()
        {
            List<EstudianteVM> list = new List<EstudianteVM>();
            EstudianteVM estudiante;
            try
            {
                using (dbContextd contexto = new dbContextd())
                {
                    var p1 = contexto.Estudiante;
                    foreach (var p in p1)
                    {
                        var estudianteVm = new EstudianteVM
                        {
                            Id = p.Id,
                            strNombre = p.strNombre,
                            strApellidoP = p.strApellidoP,
                            strApelidoM = p.strApelidoM,
                            strEmail = p.strEmail,
                            strGrupo = p.strGrupo,
                        };
                        list.Add(estudianteVm);
                    }
                }
            }
            catch (Exception e)
            {
                
            }
            
            return list;
        }
        public EstudianteVM getById(int id){
            EstudianteVM estudiante = new EstudianteVM();
            try
            {
                using (dbContextd context = new dbContextd())
                {
                    var estudianteDb = context.Estudiante.FirstOrDefault(p => p.Id == id);
                    if (estudianteDb != null)
                    {
                        estudiante.Id = estudianteDb.Id;
                        estudiante.strNombre = estudianteDb.strNombre;
                        estudiante.strApellidoP = estudianteDb.strApellidoP;
                        estudiante.strApelidoM = estudianteDb.strApelidoM;
                        estudiante.strEmail = estudianteDb.strEmail;
                        estudiante.strGrupo = estudianteDb.strGrupo;

                    }
                }
            }catch(Exception e)
            {
                return null;
            }

            return estudiante;
        }

        public bool Add(EstudianteVM estudianteVM)
        {
            bool respuesta = false;
            try
            {
                using (dbContextd contexto = new dbContextd())
                {
                    Estudiante estudianteDB = new Estudiante()
                    {
                        strNombre = estudianteVM.strNombre,
                        strApellidoP = estudianteVM.strApellidoP,
                        strApelidoM = estudianteVM.strApelidoM,
                        strEmail = estudianteVM.strEmail,
                        strGrupo = estudianteVM.strGrupo,
                    };
                    contexto.Estudiante.Add(estudianteDB);
                    contexto.Estudiante.Add(estudianteDB);
                    contexto.SaveChanges();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {

            }
            return respuesta;
        }
        public bool Update(EstudianteVM estudianteVM)
        {
            bool respuesta = false;
            try
            {
                using (dbContextd contexto = new dbContextd())
                {
                    Estudiante estudianteDB = new Estudiante()
                    {
                        Id = estudianteVM.Id,
                        strNombre = estudianteVM.strNombre,
                        strApellidoP = estudianteVM.strApellidoP,
                        strApelidoM = estudianteVM.strApelidoM,
                        strEmail = estudianteVM.strEmail,
                        strGrupo = estudianteVM.strGrupo,
                    };
                    contexto.Entry(estudianteDB).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {

            }
            return respuesta;
        }
        public bool Delete(int id)
        {
            var respuesta = false;
            try
            {
                using (dbContextd contexto = new dbContextd())
                {

                    var estudiante = contexto.Estudiante.FirstOrDefault(p => p.Id == id);
                    contexto.Estudiante.Remove(estudiante);
                    contexto.SaveChanges();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {

            }
            return respuesta;
        }


    }
}