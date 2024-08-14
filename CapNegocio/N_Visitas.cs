using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapDato;
using CapEntidad;
using System.Data;


namespace CapNegocio
{
    public class N_Visitas
    {
        D_registro accesoDatos = new D_registro();


        
        public bool VerificarLogin(E_Visitas registro)
        {
            return accesoDatos.Login(registro);
        }

        public bool RegistrarVisita(E_Visitas visita)
        {
            return accesoDatos.InsertarVisita(visita);
        }
        public bool ModificarVisita(E_Visitas visita)
        {
            return accesoDatos.ModificarVisita(visita);
        }
        public E_Visitas ObtenerVisitaPorID(int id)
        {
            return accesoDatos.ObtenerVisitaPorID(id);
        }
        public DataTable ObtenerTodasLasVisitas()
        {
            return accesoDatos.ObtenerTodasLasVisitas();
        }
        public bool EliminarVisita(int id)
        {
            return accesoDatos.EliminarVisita(id);
        }
        public DataTable ObtenerVisitasPorEdificioAula(string edificio, string aula)
        {
            return accesoDatos.ObtenerVisitasPorEdificioAula(edificio, aula);
        }
        public void InsertarUsuario(string usuario, string nombre, string apellido, DateTime fechaNacimiento)
        {
            accesoDatos.InsertarUsuario(usuario, nombre, apellido, fechaNacimiento);
        }
        public DataTable ConsultarUsuarios()
        {
            return accesoDatos.ConsultarUsuarios();
        }
        public bool ActualizarCuentaUsuario(E_Visitas usuario)
        {
            return accesoDatos.ActualizarCuentaUsuario(usuario);
        }
    }
}
