using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class TipoMedicamentoDAL : CadenaDAL
    {
        public int EliminarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {

            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidtipomedicamento", oTipoMedicamentoCLS.idTipoMedicamento);

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
        public int ActualizarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {
            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    // Actualización solo de los campos que se modifican, usando el ID del input.
                    using (SqlCommand cmd = new SqlCommand("UPDATE TipoMedicamento SET NOMBRE = @nombre, DESCRIPCION = @descripcion WHERE IIDTIPOMEDICAMENTO = @idTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        // Asignar los valores a los parámetros
                        cmd.Parameters.AddWithValue("@nombre", oTipoMedicamentoCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoMedicamentoCLS.descripcion);
                        cmd.Parameters.AddWithValue("@idTipoMedicamento", oTipoMedicamentoCLS.idTipoMedicamento);

                        rpta = cmd.ExecuteNonQuery(); // Ejecuta la consulta
                    }
                }
                catch (Exception)
                {
                    // Manejo de errores
                    cn.Close();
                    throw; // O manejar el error de otra forma
                }
            }
            return rpta;
        }



        public int GuardarTipoMedicamento(TipoMedicamentoCLS oTipoMedicamentoCLS)
        {

            int rpta = 0;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("insert into TipoMedicamento(NOMBRE,DESCRIPCION,BHABILITADO)\r\nvalues(@nombre, @descripcion, 1)", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", oTipoMedicamentoCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoMedicamentoCLS.descripcion);

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

        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            TipoMedicamentoCLS otipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new TipoMedicamentoCLS();
                                otipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                otipoMedicamentoCLS.descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2);

                                lista.Add(otipoMedicamentoCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    lista = null;
                    throw;

                }
            }
            return lista;



            /*
            List<TipoMedicamentoCLS> lista = new List<TipoMedicamentoCLS>();

            lista.Add(new TipoMedicamentoCLS
            {
                idTipoMedicamento = 1,
                nombre = "Analgésicos",
                descripcion = "Desc1",
                stock = 5
            });

            lista.Add(new TipoMedicamentoCLS
            {
                idTipoMedicamento = 2,
                nombre = "Antialérgicos",
                descripcion = "Desc2",
                stock = 6
            });

            lista.Add(new TipoMedicamentoCLS
            {
                idTipoMedicamento = 3,
                nombre = "Anticonceptivo",
                descripcion = "Desc3",
                stock = 1
            });

            return lista;
            */
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            List<TipoMedicamentoCLS> lista = null;



            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombretipomedicamento", nombre == null ? "" : nombre);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            TipoMedicamentoCLS otipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new TipoMedicamentoCLS();
                                otipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                otipoMedicamentoCLS.descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2);

                                lista.Add(otipoMedicamentoCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    lista = null;
                    throw;

                }
            }
            return lista;

        }


        public TipoMedicamentoCLS RecuperarTipoMedicamento(int idTipoMedicamento)
        {
            TipoMedicamentoCLS otipoMedicamentoCLS = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("select IIDTIPOMEDICAMENTO, NOMBRE, DESCRIPCION\r\nfrom TipoMedicamento" +
                        " where BHABILITADO = 1 and IIDTIPOMEDICAMENTO = @iidtipomedicamento ", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@iidtipomedicamento", idTipoMedicamento);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            int posId = dr.GetOrdinal("IIDTIPOMEDICAMENTO");
                            int posNombre = dr.GetOrdinal("NOMBRE");
                            int posDescripcion = dr.GetOrdinal("DESCRIPCION");

                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new TipoMedicamentoCLS();
                                otipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(posId) ? 0 : dr.GetInt32(posId);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(posNombre) ? "" : dr.GetString(posNombre);
                                otipoMedicamentoCLS.descripcion = dr.IsDBNull(posDescripcion) ? "" : dr.GetString(posDescripcion);

                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();

                }
            }
            return otipoMedicamentoCLS;

        }
    }
}

