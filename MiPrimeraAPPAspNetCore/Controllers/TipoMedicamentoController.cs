using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAPPAspNetCore.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TipoMedicamentoCLS> ListartipoMedicamento()
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.listarTipoMedicamento();
        }

        public List<TipoMedicamentoCLS> FiltrartipoMedicamento(string nombre)
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.filtrarTipoMedicamento(nombre);
        }
        //OJO COMO ENVIO UN TIO INT SE ENVIA ACORDE UN FORMATO TEXTO Y NO JSON PQ NO TIENE EL VALOR DE LISTA
        //public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS) {
        //    return 0;
        //}
        public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.GuardarTipoMedicamento(oTipoMedicamentoCLS);
        }
        public TipoMedicamentoCLS RecuperarTipoMedicamento(int idtipomedicamento)
        {
            TipoMedicamentoBL tipoMedicamentoDAL = new TipoMedicamentoBL();
            return tipoMedicamentoDAL.RecuperarTipoMedicamento(idtipomedicamento);
        }

        public int ActualizarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.ActualizarTipoMedicamento(oTipoMedicamentoCLS);
        }
        public int EliminarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            TipoMedicamentoBL obj = new TipoMedicamentoBL();
            return obj.EliminarTipoMedicamentos(oTipoMedicamentoCLS);
        }
       

    }
}
