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
    public partial class OutputDataMahasiswa : Form
    {
        private List<Mahasiswa> mahasiswaList;
        public OutputDataMahasiswa(List<Mahasiswa> mahasiswaList)
        {
            InitializeComponent();
            this.mahasiswaList = mahasiswaList;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ColumnName1", "Nama");
            dataGridView1.Columns.Add("ColumnName2", "NIM");
            dataGridView1.Columns.Add("ColumnName3", "Jurusan");
            dataGridView1.Columns.Add("ColumnName4", "Photo Path");
            dataGridView1.Rows.Clear();

            foreach (var mahasiswa in mahasiswaList)
            {
                dataGridView1.Rows.Add(mahasiswa.namaMhs, mahasiswa.nim, mahasiswa.jurusan, mahasiswa.photo);
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3) {
                string photoPath = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (System.IO.File.Exists(photoPath))
                {
                    pictureBox1.Image = Image.FromFile(photoPath);
                }
                else {
                    MessageBox.Show("File foto tidak ditemukan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBox1.Image = null;
                }
            }
        }
    }
}
