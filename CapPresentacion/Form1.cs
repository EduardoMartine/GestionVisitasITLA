using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapEntidad;
using CapNegocio;
namespace CapPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            E_Visitas registro = new E_Visitas
            {
                usuario = bunifuMaterialTextbox1.Text,
                pass = bunifuMaterialTextbox2.Text
            };

            
            N_Visitas negocio = new N_Visitas();

           
            if (negocio.VerificarLogin(registro))
            {
                MessageBox.Show("Login exitoso!");
                Form Opcones = new Form2(); 
                Opcones.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
