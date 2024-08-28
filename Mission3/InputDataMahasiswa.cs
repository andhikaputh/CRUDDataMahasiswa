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
    public partial class InputDataMahasiswa : Form
    {
        Form1 form1;
        public InputDataMahasiswa(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == DialogResult.OK) {
                textBoxPhoto.Text = openfiledialog.FileName;
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNama.Text) || string.IsNullOrWhiteSpace(textBoxJurusan.Text) || string.IsNullOrWhiteSpace(textBoxNim.Text) || string.IsNullOrWhiteSpace(textBoxPhoto.Text)) {
                MessageBox.Show("Semua field harus diisi", "Error", MessageBoxButtons.OK);
                return;
            }
            Mahasiswa mahasiswa = new Mahasiswa
            {
                namaMhs = textBoxNama.Text,
                nim = textBoxNim.Text,
                jurusan = textBoxJurusan.Text,
                photo = textBoxPhoto.Text
            };
            form1.mahasiswaList.Add(mahasiswa);
            MessageBox.Show("Data berhasil dimasukkan !", "Informasi", MessageBoxButtons.OK);

            textBoxNama.Clear();
            textBoxNim.Clear();
            textBoxJurusan.Clear();
            textBoxPhoto.Clear();
        }
    }

    public class Mahasiswa {
        public string namaMhs { get; set; }
        public string nim { get; set; }
        public string jurusan { get; set; }

        public string photo { get; set; }
    }
}
