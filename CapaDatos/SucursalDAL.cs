using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class SucursalDAL : CadenaDAL
    {
        public List<SucursalCLS> listarSucursales()
        {
            List<SucursalCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarSucursal", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            SucursalCLS sucursal;
                            lista = new List<SucursalCLS>();
                            while (dr.Read())
                            {
                                sucursal = new SucursalCLS();
                                sucursal.idSucursal = dr.GetInt32(0);
                                sucursal.nombre = dr.GetString(1);
                                sucursal.direccion = dr.GetString(2);

                                lista.Add(sucursal);
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

        public List<SucursalCLS> filtrarSucursal(SucursalCLS objSuc)
        {
            List<SucursalCLS> lista = null;

            

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    //El uspFiltrarSucursalFormulario no existe dentro de la base de datos por lo cual yo mismo copie el del laboratorio, cree un query
                    //Y eso lo use aqui para hacerlo como un tipo formulario
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursalFormularios", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //Aqui cambiamos el null por 0 ya que el null no era un valor permitido para tipos de datos int
                        cmd.Parameters.AddWithValue("@idSucursal", objSuc.idSucursal == 0 ? 0 : objSuc.idSucursal);
                        cmd.Parameters.AddWithValue("@nombresucursal", objSuc.nombre == null ? "" : objSuc.nombre);
                        cmd.Parameters.AddWithValue("@direccion", objSuc.direccion == null ? "" : objSuc.direccion);

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            SucursalCLS otipoMedicamentoCLS;
                            lista = new List<SucursalCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new SucursalCLS();
                                otipoMedicamentoCLS.idSucursal = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                otipoMedicamentoCLS.direccion = dr.IsDBNull(2) ? "" : dr.GetString(2);

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

    }
}
