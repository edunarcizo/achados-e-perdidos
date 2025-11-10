using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(!string.IsNullOrEmpty(caminho)) 
            {
                FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] ImageBytes = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                return ImageBytes;

            }
            return null;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            string QuemEncontrou = txtQuemEncontrou.Text;
            string data = dtpDataEncontro.Value.ToString("yyyy-MM-dd");

            byte[] imageBytes = ConverterImagem(caminhoImagem);

            string connString = "Server=localhost;Database=achados_perdidos;Uid=root;Pwd=''";
            string query = "INSERT INTO achados_perdidos (descricao_item,quem_encontrou,data_encontro,foto_item) VALUES (@desc,@quem,@data,@foto";

            using(MySqlConnection conn = new MySqlConnection(connString))
            { 
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Parameters.AddWithValue("@desc", descricao);
                    cmd.Parameters.AddWithValue("@quem", QuemEncontrou);
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@foto", MySqlDbType.LongBlob).Value = imageBytes;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Item cadastrado com sucesso");

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
            ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = ofd.FileName;
                pictureBox1.ImageLocation = caminhoImagem;
            }
        }
    }
}
