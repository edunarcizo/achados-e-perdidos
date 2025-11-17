using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Achados_e_perdidos
{
    public partial class FrmAdicionar : Form
    {
        public FrmAdicionar()
        {
            InitializeComponent();
        }

        private string caminhoImagem = null;

        private byte[] ConverterImagem(string caminho)
        {
            if (!string.IsNullOrEmpty(caminho))
            {
                return File.ReadAllBytes(caminho);
            }
            return null;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            string quemEncontrou = txtQuemEncontrou.Text;
            string data = dtpDataEncontro.Value.ToString("yyyy-MM-dd");

            byte[] imageBytes = ConverterImagem(caminhoImagem);

            string databasePath = "achados_perdidos.db";
            string connString = $"Data Source={databasePath};Version=3;";

            string query = "INSERT INTO achados_perdidos (descricao_item, quem_encontrou, data_encontro, foto_item) " +
                           "VALUES (@desc, @quem, @data, @foto)";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@desc", descricao);
                    cmd.Parameters.AddWithValue("@quem", quemEncontrou);
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@foto", (object)imageBytes ?? DBNull.Value);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item cadastrado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao cadastrar: " + ex.Message);
                    }
                }
            }
        }

        private void btnAdicionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = ofd.FileName;
                pictureBox1.ImageLocation = caminhoImagem;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
