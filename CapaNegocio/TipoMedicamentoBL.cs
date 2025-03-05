using CapaDatos;
using CapaEntidad;
using System.Reflection.Metadata.Ecma335;

namespace CapaNegocio
{
    public class TipoMedicamentoBL
    {
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
        public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.GuardarTipoMedicamento(oTipoMedicamentoCLS);
        }
        public TipoMedicamentoCLS RecuperarTipoMedicamento(int idtipomedicamento) {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.RecuperarTipoMedicamento(idtipomedicamento);
        }
        public int ActualizarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.ActualizarTipoMedicamento(oTipoMedicamentoCLS);
        }

        public int EliminarTipoMedicamentos(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            TipoMedicamentoDAL tipoMedicamentoDAL = new TipoMedicamentoDAL();
            return tipoMedicamentoDAL.EliminarTipoMedicamento(oTipoMedicamentoCLS);
        }
    }
}