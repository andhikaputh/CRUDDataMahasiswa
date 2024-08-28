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
    public partial class SearchMahasiswa : Form
    {
        private List<Mahasiswa> mahasiswaList;
        public SearchMahasiswa(List<Mahasiswa> mahasiswaList)
        {
            InitializeComponent();
            this.mahasiswaList = mahasiswaList;
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

        private void buttonCari_Click(object sender, EventArgs e)
        {
            string cari = textBox1.Text.ToLower();
            var hasil = mahasiswaList.Where(m => m.namaMhs.ToLower().Contains(cari) || m.nim.ToLower().Contains(cari)).ToList();
            dataGridView1.Rows.Clear();
            foreach (var mhs in hasil)
            {
                dataGridView1.Rows.Add(mhs.namaMhs, mhs.nim, mhs.jurusan, mhs.photo);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                string photoPath = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (System.IO.File.Exists(photoPath))
                {
                    pictureBox1.Image = Image.FromFile(photoPath);
                }
                else {
                    MessageBox.Show("File foto tidak ditemukan", "Error", MessageBoxButtons.OK);
                    pictureBox1.Image = null;
                }
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.ToLower();
            var itemsToRemove = mahasiswaList.Where(m => m.namaMhs.ToLower().Contains(keyword) || m.nim.ToLower().Contains(keyword)).ToList();

            foreach (var item in itemsToRemove)
            {
                mahasiswaList.Remove(item);
            }

            dataGridView1.Rows.Clear();
            foreach (var mahasiswa in mahasiswaList)
            {
                dataGridView1.Rows.Add(mahasiswa.namaMhs, mahasiswa.nim, mahasiswa.jurusan, mahasiswa.photo);
            }

            pictureBox1.Image = null;
            MessageBox.Show("Mahasiswa Berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
