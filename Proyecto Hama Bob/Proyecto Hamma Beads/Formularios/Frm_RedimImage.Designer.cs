namespace Proyecto_Hamma_Beads.Formularios
{
    partial class Frm_RedimImage
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
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMantenerProporciones = new System.Windows.Forms.CheckBox();
            this.txtAlto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAncho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbRedimensionar = new System.Windows.Forms.RadioButton();
            this.rdbMantener = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAltoOriginal = new System.Windows.Forms.TextBox();
            this.txtAnchoOriginal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImagen
            // 
            this.pbImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImagen.Location = new System.Drawing.Point(201, 10);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(181, 226);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagen.TabIndex = 0;
            this.pbImagen.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pbImagen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(392, 246);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAltoOriginal);
            this.panel1.Controls.Add(this.txtAnchoOriginal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 240);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 199);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(166, 34);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.Location = new System.Drawing.Point(86, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 28);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAceptar.Location = new System.Drawing.Point(3, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 28);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkMantenerProporciones);
            this.groupBox1.Controls.Add(this.txtAlto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAncho);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdbRedimensionar);
            this.groupBox1.Controls.Add(this.rdbMantener);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 144);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "¿Qué opción elige?";
            // 
            // chkMantenerProporciones
            // 
            this.chkMantenerProporciones.AutoSize = true;
            this.chkMantenerProporciones.Checked = true;
            this.chkMantenerProporciones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMantenerProporciones.Enabled = false;
            this.chkMantenerProporciones.Location = new System.Drawing.Point(6, 117);
            this.chkMantenerProporciones.Name = "chkMantenerProporciones";
            this.chkMantenerProporciones.Size = new System.Drawing.Size(136, 17);
            this.chkMantenerProporciones.TabIndex = 6;
            this.chkMantenerProporciones.Text = "Mantener Proporciones";
            this.chkMantenerProporciones.UseVisualStyleBackColor = true;
            // 
            // txtAlto
            // 
            this.txtAlto.Enabled = false;
            this.txtAlto.Location = new System.Drawing.Point(54, 91);
            this.txtAlto.MaxLength = 5;
            this.txtAlto.Name = "txtAlto";
            this.txtAlto.Size = new System.Drawing.Size(100, 20);
            this.txtAlto.TabIndex = 5;
            this.txtAlto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoloNumerico_KeyPress);
            this.txtAlto.Leave += new System.EventHandler(this.txtAlto_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Alto:";
            // 
            // txtAncho
            // 
            this.txtAncho.Enabled = false;
            this.txtAncho.Location = new System.Drawing.Point(54, 65);
            this.txtAncho.MaxLength = 5;
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(100, 20);
            this.txtAncho.TabIndex = 3;
            this.txtAncho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoloNumerico_KeyPress);
            this.txtAncho.Leave += new System.EventHandler(this.txtAncho_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ancho:";
            // 
            // rdbRedimensionar
            // 
            this.rdbRedimensionar.AutoSize = true;
            this.rdbRedimensionar.Location = new System.Drawing.Point(6, 42);
            this.rdbRedimensionar.Name = "rdbRedimensionar";
            this.rdbRedimensionar.Size = new System.Drawing.Size(145, 17);
            this.rdbRedimensionar.TabIndex = 1;
            this.rdbRedimensionar.TabStop = true;
            this.rdbRedimensionar.Text = "Redimensionar Imagen a:";
            this.rdbRedimensionar.UseVisualStyleBackColor = true;
            this.rdbRedimensionar.CheckedChanged += new System.EventHandler(this.rdbRedimensionar_CheckedChanged);
            // 
            // rdbMantener
            // 
            this.rdbMantener.AutoSize = true;
            this.rdbMantener.Checked = true;
            this.rdbMantener.Location = new System.Drawing.Point(6, 19);
            this.rdbMantener.Name = "rdbMantener";
            this.rdbMantener.Size = new System.Drawing.Size(150, 17);
            this.rdbMantener.TabIndex = 0;
            this.rdbMantener.TabStop = true;
            this.rdbMantener.Text = "Mantener Tamaño Original";
            this.rdbMantener.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "x";
            // 
            // txtAltoOriginal
            // 
            this.txtAltoOriginal.BackColor = System.Drawing.Color.White;
            this.txtAltoOriginal.Location = new System.Drawing.Point(91, 23);
            this.txtAltoOriginal.MinimumSize = new System.Drawing.Size(30, 20);
            this.txtAltoOriginal.Name = "txtAltoOriginal";
            this.txtAltoOriginal.ReadOnly = true;
            this.txtAltoOriginal.Size = new System.Drawing.Size(30, 20);
            this.txtAltoOriginal.TabIndex = 3;
            // 
            // txtAnchoOriginal
            // 
            this.txtAnchoOriginal.BackColor = System.Drawing.Color.White;
            this.txtAnchoOriginal.Location = new System.Drawing.Point(37, 23);
            this.txtAnchoOriginal.MinimumSize = new System.Drawing.Size(30, 20);
            this.txtAnchoOriginal.Name = "txtAnchoOriginal";
            this.txtAnchoOriginal.ReadOnly = true;
            this.txtAnchoOriginal.Size = new System.Drawing.Size(30, 20);
            this.txtAnchoOriginal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "de:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "La Imagen tiene un tamaño";
            // 
            // Frm_RedimImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 246);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_RedimImage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Información de Imagen";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkMantenerProporciones;
        private System.Windows.Forms.TextBox txtAlto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAncho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbRedimensionar;
        private System.Windows.Forms.RadioButton rdbMantener;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAltoOriginal;
        private System.Windows.Forms.TextBox txtAnchoOriginal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}