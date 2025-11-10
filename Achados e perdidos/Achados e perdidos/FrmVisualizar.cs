using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Achados_e_perdidos
{
    public partial class FrmVisualizar : Form
    {
        public FrmVisualizar()
        {
            InitializeComponent();
        }

        private void CarregarDados()
        {
            string connString = "Server=localhost;Database=achados_perdidos;Uid=root;Pwd=''";
            string query = "SELECT id, descricao_item, quem_encontrou, data_encontro FROM achados_perdidos ORDER BY data_encontro DESC";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["descricao_item"].HeaderText = "Descrição do item";
                    dataGridView1.Columns["quem_encontrou"].HeaderText = "Encontrado por";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }

        }

        private void FrmVisualizar_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string termo = txtPesquisar.Text.Trim();
            string connString = "Server=localhost;Database=achados_perdidos;Uid=root;Pwd=''";
            string query = "SELECt id , descricao_item, quem_encontrou, data_encontro FROM achados_perdidos WHERE descricao_item LIKE @termo OR quem_encontrou LIKE ORDER BY data_encontro DESC";

            using (MySqlConnection conn = new MySqlConnection(connString)) 
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@termo", $"%{termo}%");
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
    }
}
