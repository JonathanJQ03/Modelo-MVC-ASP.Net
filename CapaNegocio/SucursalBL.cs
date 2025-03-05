using CapaDatos;
using CapaEntidad;
using System.Reflection.Metadata.Ecma335;

namespace CapaNegocio
{
    public class SucursalBL
    {
        public List<SucursalCLS> ListarSucursal()
        {
            SucursalDAL sucursalDAL = new SucursalDAL();
            return sucursalDAL.listarSucursales();
        }
        public List<SucursalCLS> FiltrarSucursal(SucursalCLS objSuc)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursal(objSuc);
        }
        //Comente la funcion de filtrar que teniamos antes ya que esta se basaba unicamente en un nombre
        //public List<SucursalCLS> FiltrarSucursal(string nombre)
        //{
        //    SucursalDAL sucursalDAL = new SucursalDAL();
        //    return sucursalDAL.filtrarSucursal(nombre);
        //}
        public int GuardarSucursal(SucursalCLS oSucursalCLS)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.GuardarSucursal(oSucursalCLS);
        }

    }
}