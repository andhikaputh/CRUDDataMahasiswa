using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mission3
{
    public partial class Form1 : Form
    {
        public List<Mahasiswa> mahasiswaList = new List<Mahasiswa>();
        public Form1()
        {
            InitializeComponent();

        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputDataMahasiswa inputdataMahasiswa = new InputDataMahasiswa(this);
            inputdataMahasiswa.Show();
        }

        private void outputDataMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputDataMahasiswa outputDataMahasiswa = new OutputDataMahasiswa(mahasiswaList);
            outputDataMahasiswa.Show();
        }

        private void pencarianDataMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchMahasiswa searchMahasiswa = new SearchMahasiswa(mahasiswaList);
            searchMahasiswa.Show();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
