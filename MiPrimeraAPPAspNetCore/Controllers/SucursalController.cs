using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAPPAspNetCore.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<SucursalCLS> ListarSucursal()
        {
            SucursalDAL sucursalDAL = new SucursalDAL();
            return sucursalDAL.listarSucursales();
        }

        public List<SucursalCLS> FiltrarSucursal(SucursalCLS objSucursal)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursal(objSucursal);
        }
    }
}
