namespace Achados_e_perdidos
{
    partial class FrmAdicionar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuemEncontrou = new System.Windows.Forms.TextBox();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.dtpDataEncontro = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdicionarFoto = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(127, 36);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(100, 22);
            this.txtDescricao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descrição:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quem encontrou:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data:";
            // 
            // txtQuemEncontrou
            // 
            this.txtQuemEncontrou.Location = new System.Drawing.Point(127, 85);
            this.txtQuemEncontrou.Name = "txtQuemEncontrou";
            this.txtQuemEncontrou.Size = new System.Drawing.Size(100, 22);
            this.txtQuemEncontrou.TabIndex = 4;
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // dtpDataEncontro
            // 
            this.dtpDataEncontro.Location = new System.Drawing.Point(127, 129);
            this.dtpDataEncontro.Name = "dtpDataEncontro";
            this.dtpDataEncontro.Size = new System.Drawing.Size(200, 22);
            this.dtpDataEncontro.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(426, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 254);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdicionarFoto
            // 
            this.btnAdicionarFoto.Location = new System.Drawing.Point(554, 267);
            this.btnAdicionarFoto.Name = "btnAdicionarFoto";
            this.btnAdicionarFoto.Size = new System.Drawing.Size(101, 23);
            this.btnAdicionarFoto.TabIndex = 7;
            this.btnAdicionarFoto.Text = "Adiconar foto";
            this.btnAdicionarFoto.UseVisualStyleBackColor = true;
            this.btnAdicionarFoto.Click += new System.EventHandler(this.btnAdicionarFoto_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(16, 407);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // FrmAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnAdicionarFoto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtpDataEncontro);
            this.Controls.Add(this.txtQuemEncontrou);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescricao);
            this.Name = "FrmAdicionar";
            this.Text = "FrmAdicionar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuemEncontrou;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.DateTimePicker dtpDataEncontro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAdicionarFoto;
        private System.Windows.Forms.Button btnCadastrar;
    }
}