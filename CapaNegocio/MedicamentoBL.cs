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
        public List<MedicamentoCLS> listarMedicamento()
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.listarMedicamentos();
        }
        //public List<LaboratorioCLS> filtrarLaboratorio(LaboratorioCLS objLab)
        //{
        //    LaboratorioDAL obj = new LaboratorioDAL();
        //    return obj.filtrarLaboratorios(objLab);
        //}
        public int GuardarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.GuardarMedicamento(oMedicamentoCLS);

        }
        public int ActualizarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.ActualizarMedicamento(oMedicamentoCLS);
        }

        public int EliminarMedicamento (MedicamentoCLS oMedicamentoCLS)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.EliminarMedicamento(oMedicamentoCLS);
        }
        public MedicamentoCLS RecuperarMedicamento(int iidmedicamento)
        {
            MedicamentoDAL obj = new MedicamentoDAL();
            return obj.RecuperarMedicamento(iidmedicamento);
        }
    }
}
