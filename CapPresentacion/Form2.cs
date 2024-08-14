using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapPresentacion
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Form consulta = new Form4();
            consulta.Show();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Form Agregarvisita = new Form3();
            Agregarvisita.Show();

        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Form Usuarios = new Form5();
            Usuarios.Show();
        }
    }
}
