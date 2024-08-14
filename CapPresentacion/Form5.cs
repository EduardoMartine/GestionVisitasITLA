using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapNegocio;
using CapEntidad;
using Bunifu.Framework.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapPresentacion
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                
                bunifuMetroTextbox3.Text = row.Cells["Usuario"].Value?.ToString(); 
                bunifuMetroTextbox1.Text = row.Cells["Nombre"].Value?.ToString();  
                bunifuMetroTextbox2.Text = row.Cells["Apellido"].Value?.ToString(); 
                bunifuDatepicker1.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value); 
            }
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            N_Visitas users = new N_Visitas();
            string usuario = bunifuMetroTextbox3.Text;
            string nombre = bunifuMetroTextbox1.Text;
            string apellido = bunifuMetroTextbox2.Text;
            DateTime fechaNacimiento = bunifuDatepicker1.Value; 

            
            users.InsertarUsuario(usuario, nombre, apellido, fechaNacimiento);

            MessageBox.Show("Usuario insertado correctamente");
        }
        

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            N_Visitas negocio = new N_Visitas();
            dataGridView1.DataSource = negocio.ConsultarUsuarios();
            AjustarColumnas();

        }
        private void AjustarColumnas()
        {
           
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            E_Visitas usuario = new E_Visitas
            {
                Usuario = bunifuMetroTextbox3.Text,
                Nombre = bunifuMetroTextbox1.Text,
                Apellido = bunifuMetroTextbox2.Text,
                FechaNacimiento = bunifuDatepicker1.Value
            };

            N_Visitas negocio = new N_Visitas();
            if (negocio.ActualizarCuentaUsuario(usuario))
            {
                MessageBox.Show("Datos actualizados correctamente.");
            }
            else
            {
                MessageBox.Show("Error al actualizar datos.");
            }
        }
    }
}
