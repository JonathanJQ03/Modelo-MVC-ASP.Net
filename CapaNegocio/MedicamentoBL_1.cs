using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MedicamentoBL
    {
        public List<MedicamentoCLS> ListarLaboratorio()
        {
            MedicamentoDAL lab = new MedicamentoDAL();
            return lab.listarLaboratorios();
        }

        public List<MedicamentoCLS> filtrarLaboratorio(MedicamentoCLS objLab)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.filtrarLaboratorios(objLab);
        }
        public int GuardarLaboratorio(MedicamentoCLS oLaboratorioCLS)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.GuardarLaboratorio(oLaboratorioCLS);

        }
        public int ActualizarLaboratorio(MedicamentoCLS oLaboratorioCLS)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.ActualizarLaboratorio(oLaboratorioCLS);
        }

        public int ELiminarLaboratorio(MedicamentoCLS oLaboratorioCLS)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.ELiminarLaboratorio(oLaboratorioCLS);
        }
        public MedicamentoCLS RecuperarLaboratorio(int iidlaboratorio)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.RecuperarLaboratorio(iidlaboratorio);
        }
    }
}
