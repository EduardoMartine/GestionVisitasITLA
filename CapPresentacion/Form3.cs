using CapEntidad;
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
using Bunifu.Framework.UI;

namespace CapPresentacion
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            E_Visitas visita = new E_Visitas()
            {
                Nombre = bunifuMetroTextbox1.Text,
                Apellido = bunifuMetroTextbox2.Text,
                Carrera = bunifuMetroTextbox3.Text,
                Correo = bunifuMetroTextbox4.Text,
                Motivo = bunifuMetroTextbox5.Text,
                Tiempo = bunifuDatepicker1.Value,
                Edificio = comboBox1.Text,
                Aula = comboBox2.Text
            };

            N_Visitas negocio = new N_Visitas();
            if (negocio.RegistrarVisita(visita))
            {
                MessageBox.Show("Visita registrada con éxito");
            }
            else
            {
                MessageBox.Show("Error al registrar la visita");
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            E_Visitas visita = new E_Visitas()
            {
                ID = int.Parse(bunifuMetroTextbox6.Text), 
                Nombre = bunifuMetroTextbox1.Text,
                Apellido = bunifuMetroTextbox2.Text,
                Carrera = bunifuMetroTextbox3.Text,
                Correo = bunifuMetroTextbox4.Text,
                Motivo = bunifuMetroTextbox5.Text,
                Tiempo = bunifuDatepicker1.Value,
                Edificio = comboBox1.Text,
                Aula = comboBox2.Text
            };

            N_Visitas negocio = new N_Visitas();
            if (negocio.ModificarVisita(visita))
            {
                MessageBox.Show("Visita modificada con éxito");
            }
            else
            {
                MessageBox.Show("Error al modificar la visita");
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(bunifuMetroTextbox6.Text, out id))  
            {
                N_Visitas negocio = new N_Visitas();
                E_Visitas visita = negocio.ObtenerVisitaPorID(id);
                if (visita != null)
                {
                    bunifuMetroTextbox1.Text = visita.Nombre;
                    bunifuMetroTextbox2.Text = visita.Apellido;
                    bunifuMetroTextbox3.Text = visita.Carrera;
                    bunifuMetroTextbox4.Text = visita.Correo;
                    bunifuMetroTextbox5.Text = visita.Motivo;
                    bunifuDatepicker1.Value = visita.Tiempo;
                    comboBox1.Text = visita.Edificio;
                    comboBox2.Text = visita.Aula;
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna visita con el ID proporcionado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            N_Visitas negocio = new N_Visitas();
            DataTable dt = negocio.ObtenerTodasLasVisitas();
            dataGridView1.DataSource = dt;
            AjustarColumnas();
        }
        private void AjustarColumnas()
        {
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(bunifuMetroTextbox6.Text))
            {
                int id = Convert.ToInt32(bunifuMetroTextbox6.Text);
                N_Visitas negocio = new N_Visitas();
                if (negocio.EliminarVisita(id))
                {
                    MessageBox.Show("Visita eliminada correctamente");
                    
                }
                else
                {
                    MessageBox.Show("Error al eliminar visita");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido para eliminar la visita");
            }
        }
    }
}
