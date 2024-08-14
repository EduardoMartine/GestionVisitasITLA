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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string edificio = comboBox1.Text;
            string aula = comboBox2.Text;
            N_Visitas negocio = new N_Visitas();
            dataGridView1.DataSource = negocio.ObtenerVisitasPorEdificioAula(edificio, aula);
            AjustarColumnas();
        }
        private void AjustarColumnas()
        {
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
