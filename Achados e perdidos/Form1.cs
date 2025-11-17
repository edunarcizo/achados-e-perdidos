using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Achados_e_perdidos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriarBancoCasoNaoExista();
        }

        private void CriarBancoCasoNaoExista()
        {
            string databasePath = "achados_perdidos.db";

            if (!File.Exists(databasePath))
            {
                
                SQLiteConnection.CreateFile(databasePath);

                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    conn.Open();

                    string createTableQuery = @"
                        CREATE TABLE achados_perdidos (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            descricao_item TEXT NOT NULL,
                            quem_encontrou TEXT NOT NULL,
                            data_encontro DATE NOT NULL,
                            foto_item BLOB
                        );
                    ";

                    using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            FrmAdicionar frmAdicionar = new FrmAdicionar();
            this.Hide();
            frmAdicionar.ShowDialog();
            this.Show();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            FrmVisualizar frmVisualizar = new FrmVisualizar();
            this.Hide();
            frmVisualizar.ShowDialog();
            this.Show();
        }
    }
}