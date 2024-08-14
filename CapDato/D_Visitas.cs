using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapEntidad;
using System.Data.SqlClient;
using System.Data;


namespace CapDato
{
    public class D_registro
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cone"].ConnectionString);

        public bool Login(E_Visitas Registro)
        {
            SqlCommand cmd = new SqlCommand("LoginUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@p_usuario", Registro.usuario);
            cmd.Parameters.AddWithValue("@p_password", Registro.pass);

            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               
                if (reader.HasRows)
                {
                    reader.Close();
                    cn.Close();
                    return true;
                }
                reader.Close();
                cn.Close();
                return false;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Error en la conexión: " + ex.Message);
                return false;
            }
        }

        public bool InsertarVisita(E_Visitas visita)
        {
            SqlCommand cmd = new SqlCommand("spInsertarVisita", cn);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@Nombre", visita.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", visita.Apellido);
            cmd.Parameters.AddWithValue("@Carrera", visita.Carrera);
            cmd.Parameters.AddWithValue("@Correo", visita.Correo);
            cmd.Parameters.AddWithValue("@Motivo", visita.Motivo);
            cmd.Parameters.AddWithValue("@Tiempo", visita.Tiempo);
            cmd.Parameters.AddWithValue("@Edificio", visita.Edificio);
            cmd.Parameters.AddWithValue("@Aula", visita.Aula);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la conexión: " + ex.Message);
                return false;
            }
        }
        public bool ModificarVisita(E_Visitas visita)
        {
            SqlCommand cmd = new SqlCommand("sp_ModificarVisita", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", visita.ID);
            cmd.Parameters.AddWithValue("@Nombre", visita.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", visita.Apellido);
            cmd.Parameters.AddWithValue("@Carrera", visita.Carrera);
            cmd.Parameters.AddWithValue("@Correo", visita.Correo);
            cmd.Parameters.AddWithValue("@Motivo", visita.Motivo);
            cmd.Parameters.AddWithValue("@Tiempo", visita.Tiempo);
            cmd.Parameters.AddWithValue("@Edificio", visita.Edificio);
            cmd.Parameters.AddWithValue("@Aula", visita.Aula);

            try
            {
                cn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la visita", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public E_Visitas ObtenerVisitaPorID(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_ObtenerVisitaPorID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            E_Visitas visita = null;

            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    visita = new E_Visitas()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Carrera = reader["Carrera"].ToString(),
                        Correo = reader["Correo"].ToString(),
                        Motivo = reader["Motivo"].ToString(),
                        Tiempo = Convert.ToDateTime(reader["Tiempo"]),
                        Edificio = reader["Edificio"].ToString(),
                        Aula = reader["Aula"].ToString()
                    };
                }
                reader.Close();
                return visita;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la visita", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public DataTable ObtenerTodasLasVisitas()
        {
            SqlCommand cmd = new SqlCommand("sp_ObtenerTodasLasVisitas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool EliminarVisita(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarVisita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
        public DataTable ObtenerVisitasPorEdificioAula(string edificio, string aula)
        {
            SqlCommand cmd = new SqlCommand("sp_VisitasPorEdificioAula", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Edificio", edificio);
            cmd.Parameters.AddWithValue("@Aula", aula);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void InsertarUsuario(string usuario, string nombre, string apellido, DateTime fechaNacimiento)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Apellido", apellido);
            cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public DataTable ConsultarUsuarios()
        {
            SqlCommand cmd = new SqlCommand("sp_ConsultarUsuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool ActualizarCuentaUsuario(E_Visitas usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarCuentaUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                cn.Close();

                return i > 0;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }

    }
}
