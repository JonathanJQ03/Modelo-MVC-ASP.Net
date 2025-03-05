using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MedicamentoDAL : CadenaDAL
    {
        public List<MedicamentoCLS> listarMedicamentos()
        {
            List<MedicamentoCLS> listaMedicamento = null;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarMedicamento", cn))
                    {
                        //Ojo el StoredProcedure es el nombre del procedimiento almacenado
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            MedicamentoCLS oMedicamentoCLS;
                            listaMedicamento = new List<MedicamentoCLS>();
                            while (dr.Read())
                            {
                                oMedicamentoCLS = new MedicamentoCLS();
                                oMedicamentoCLS.iidmedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oMedicamentoCLS.nombremedicamento = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                oMedicamentoCLS.nombrelaboratorio = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oMedicamentoCLS.nombretipomedicamento = dr.IsDBNull(3) ? "" : dr.GetString(3);
                                listaMedicamento.Add(oMedicamentoCLS);

                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    //Mi lista se quedara como nulo si no logra recibir ningun parametro
                    listaMedicamento = null;

                }
            }
            return listaMedicamento;
        }
        public int EliminarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {

            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UspEliminarMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidmedicamento", oMedicamentoCLS.iidmedicamento);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    cn.Close();

                }
            }
            return rpta;
        }
        public int ActualizarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    // Actualización de Medicamento
                    using (SqlCommand cmd = new SqlCommand("UPDATE Medicamento SET NOMBREMEDICAMENTO = @nombre, IIDLABORATORIO = @iidlaboratorio, IIDTIPOMEDICAMENTO = @idTipoMedicamento WHERE IIDMEDICAMENTO = @idMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        // Asignar los valores a los parámetros
                        cmd.Parameters.AddWithValue("@nombre", oMedicamentoCLS.nombremedicamento);
                        cmd.Parameters.AddWithValue("@iidlaboratorio", oMedicamentoCLS.nombrelaboratorio);
                        cmd.Parameters.AddWithValue("@idTipoMedicamento", oMedicamentoCLS.nombretipomedicamento);
                        cmd.Parameters.AddWithValue("@idMedicamento", oMedicamentoCLS.iidmedicamento);
                        rpta = cmd.ExecuteNonQuery(); // Ejecuta la consulta
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        cn.Close();
                    }
                }
            }
            return rpta;
        }

        public MedicamentoCLS RecuperarMedicamento(int iidmedicamento)
        {
            MedicamentoCLS oMedicamentoCLS = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT m.IIDMEDICAMENTO, m.NOMBREMEDICAMENTO, l.NOMBRE AS NOMBRELABORATORIO, t.NOMBRE AS NOMBRETIPOMEDICAMENTO " +
                    "FROM Medicamento m " +
                    "INNER JOIN Laboratorio l ON m.IIDLABORATORIO = l.IIDLABORATORIO " +
                    "INNER JOIN TipoMedicamento t ON m.IIDTIPOMEDICAMENTO = t.IIDTIPOMEDICAMENTO " +
                    "WHERE m.BHABILITADO = 1 AND m.IIDMEDICAMENTO = @iidmedicamento", cn))

                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@iidmedicamento", iidmedicamento);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            int posId = dr.GetOrdinal("IIDMEDICAMENTO");
                            int posNombre = dr.GetOrdinal("NOMBREMEDICAMENTO");
                            int posNombreLaboratorio = dr.GetOrdinal("NOMBRELABORATORIO");
                            //int posNombreLaboratorio = dr.GetOrdinal("NOMBRETIPOMEDICAMENTO");


                            while (dr.Read())
                            {
                                oMedicamentoCLS = new MedicamentoCLS();
                                oMedicamentoCLS.iidmedicamento = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                oMedicamentoCLS.nombremedicamento = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                oMedicamentoCLS.nombrelaboratorio = dr.IsDBNull(posNombreLaboratorio) ? "" : dr.GetString(posNombreLaboratorio);
                                oMedicamentoCLS.nombretipomedicamento = dr.IsDBNull(posNombreLaboratorio) ? "" : dr.GetString(posNombreLaboratorio);

                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();

                }
            }
            return oMedicamentoCLS;

        }

        public int GuardarMedicamento(MedicamentoCLS oMedicamentoCLS)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Medicamento(NOMBREMEDICAMENTO, IIDLABORATORIO, IIDTIPOMEDICAMENTO, BHABILITADO) VALUES (@nombre, @iidlaboratorio, @iidtipomedicamento, 1)", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombremedicamento", oMedicamentoCLS.nombremedicamento);
                        cmd.Parameters.AddWithValue("@nombrelaboratorio", oMedicamentoCLS.nombrelaboratorio);
                        cmd.Parameters.AddWithValue("@nombretipomedicamento", oMedicamentoCLS.nombretipomedicamento);
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return rpta;
        }
        }
    //por insertar el de filtrar medicamento
}

