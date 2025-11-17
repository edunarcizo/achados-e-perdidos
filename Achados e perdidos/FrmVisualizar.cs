using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Achados_e_perdidos
{
    public partial class FrmVisualizar : Form
    {
        public FrmVisualizar()
        {
            InitializeComponent();
        }

        private string connString = "Data Source=achados_perdidos.db;Version=3;";

        private void CarregarDados()
        {
            string query = "SELECT id, descricao_item, quem_encontrou, data_encontro FROM achados_perdidos ORDER BY data_encontro DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["id"].HeaderText = "ID";
                    dataGridView1.Columns["descricao_item"].HeaderText = "Descrição";
                    dataGridView1.Columns["quem_encontrou"].HeaderText = "Encontrado por";
                    dataGridView1.Columns["data_encontro"].HeaderText = "Data";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void FrmVisualizar_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termo = txtPesquisar.Text.Trim();

            string query = "SELECT id, descricao_item, quem_encontrou, data_encontro " +
                           "FROM achados_perdidos " +
                           "WHERE descricao_item LIKE @termo OR quem_encontrou LIKE @termo " +
                           "ORDER BY data_encontro DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@termo", "%" + termo + "%");

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na pesquisa: " + ex.Message);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIDExcluir.Text, out int id))
            {
                MessageBox.Show("ID inválido.");
                return;
            }

            string query = "DELETE FROM achados_perdidos WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Registro excluído com sucesso.");
                        CarregarDados();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado com esse ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
