using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace MiPrimeraAPPAspNetCore.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<MedicamentoCLS> ListarMedicamentos()
        {
            MedicamentoBL obj = new MedicamentoBL();
            return obj.listarMedicamento();
        }
        //public List<MedicamentoCLS> filtrar(LaboratorioCLS objLaboratorio)
        //{
        //    LaboratorioBL obj = new LaboratorioBL();
        //    return obj.filtrarLaboratorio(objLaboratorio);
        //}
        public int GuardarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            MedicamentoBL obj = new MedicamentoBL();
            return obj.GuardarMedicamento(oMedicamentoCLS);

        }
        public int ActualizarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            MedicamentoBL obj = new MedicamentoBL();
            return obj.ActualizarMedicamento(oMedicamentoCLS);
        }

        public int EliminarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            MedicamentoBL obj = new MedicamentoBL();
            return obj.EliminarMedicamento(oMedicamentoCLS);
        }
        public MedicamentoCLS RecuperarMedicamento(int iidlaboratorio)
        {
            MedicamentoBL obj = new MedicamentoBL();
            return obj.RecuperarMedicamento(iidlaboratorio);
        }
    }
}

