//using CapaDatos;
//using CapaEntidad;
//using CapaNegocio;
//using Microsoft.AspNetCore.Mvc;

//namespace MiPrimeraAPPAspNetCore.Controllers
//{
//    public class LaboratorioController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public List<MedicamentoCLS> ListarLaboratorios()
//        {
//            MedicamentoDAL lab = new MedicamentoDAL();
//            return lab.listarLaboratorios();
//        }
//        public List<MedicamentoCLS> filtrarLaboratorios(MedicamentoCLS objLaboratorio)
//        {
//            MedicamentoBL obj = new MedicamentoBL();
//            return obj.filtrarLaboratorio(objLaboratorio);
//        }
//        public int GuardarLaboratorio(MedicamentoCLS oLaboratorioCLS)
//        {
//            MedicamentoBL obj = new MedicamentoBL();
//            return obj.GuardarLaboratorio(oLaboratorioCLS);

//        }
//        public int ActualizarLaboratorio(MedicamentoCLS oLaboratorioCLS)
//        {
//            MedicamentoBL obj = new MedicamentoBL();
//            return obj.ActualizarLaboratorio(oLaboratorioCLS);
//        }

//        public int ELiminarLaboratorio(MedicamentoCLS oLaboratorioCLS)
//        {
//            MedicamentoBL obj = new MedicamentoBL();
//            return obj.ELiminarLaboratorio(oLaboratorioCLS);
//        }
//        public MedicamentoCLS RecuperarLaboratorio(int iidlaboratorio)
//        {
//            MedicamentoBL obj = new MedicamentoBL();
//            return obj.RecuperarLaboratorio(iidlaboratorio);
//        }
//    }
//}
