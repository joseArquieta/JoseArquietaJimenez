using JoseArquietaJimenez.ApiConf;
using JoseArquietaJimenez.Models;
using JoseArquietaJimenez.Models.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JoseArquietaJimenez.Controllers
{
    public class TipoProveedorController : Controller
    {
        Model1 db = new Model1();
        private ConexionApi ConsultaAPI = new ConexionApi();

        public ActionResult Index()
        {

            var lista = db.Lista_Canciones.ToList();

            return View(lista);
        }

        public async Task<JsonResult> CrearProductos(DatosCanciones datos)
        {

            try
            {

                if (datos.Titulo is null)
                {
                    return Json(new { success = true, responseText = "El campo Titulo es obligatorio" });
                }
                else if (datos.Grupo is null)
                {
                    return Json(new { success = true, responseText = "El campo Unidad Producto es obligatorio" });
                }
                else if (datos.Ano is null)
                {
                    return Json(new { success = true, responseText = "El campo Tipo Proveedor es obligatorio" });
                }


                DatosCanciones datProduct = new DatosCanciones()
                {
                    Titulo = datos.Titulo,
                    Grupo = datos.Grupo,
                    Ano = datos.Ano,
                    Genero = datos.Genero
                };


                var result = await ConexionApi.InsertarProductosApi(datProduct);


                return Json(new { success = true, responseText = result.responseText });
            }
            catch (Exception exp)
            {

                return Json(new { success = false, responseText = exp.Message });
            }
        }

        public ActionResult CrearProductosModel(DatosCanciones datos)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }


                return Json(new { success = true, responseText = "Datos creados Correctamente" });
            }
            catch (Exception exp)
            {

                return Json(new { success = false, responseText = exp.Message });
            }
        }


        [HttpGet]
        public async Task<ActionResult> EditarGetProductos(int idCancion)
        {

            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                
                    var product = await db.Lista_Canciones.FirstOrDefaultAsync(f => f.id_Cancion == idCancion);

                    return Json(new { success = true, idCancion= idCancion, Titulo = product.Titulo, Grupo = product.Grupo, Ano = product.Ano, Genero = product.Genero }, JsonRequestBehavior.AllowGet);
                }
                catch (SqlException ex)
                {
                    return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

      
        public async Task<ActionResult> EditarPostProductos(DatosCanciones datos)
        {

            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
           
                    var result = await ConexionApi.ActualizaProductosApi(datos);
                    return Json(new { success = true, responseText  = result.responseText }, JsonRequestBehavior.AllowGet);
                }
                catch (SqlException ex)
                {
                    return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
                }

            }

        }

        public ActionResult Delete(int id)
        {
            var exist = db.Lista_Canciones.Find(id);

            var eliminar = db.Lista_Canciones.Remove(exist);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

       

    }
}
