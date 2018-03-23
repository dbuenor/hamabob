namespace HammaBob.Controles
{
    partial class colorCheckBox
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkColor = new System.Windows.Forms.CheckBox();
            this.pnlRecuadroColor = new System.Windows.Forms.Panel();
            this.lblNumPiezas = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.chkColor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlRecuadroColor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNumPiezas, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(160, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkColor
            // 
            this.chkColor.AutoSize = true;
            this.chkColor.Location = new System.Drawing.Point(23, 3);
            this.chkColor.Name = "chkColor";
            this.chkColor.Size = new System.Drawing.Size(80, 17);
            this.chkColor.TabIndex = 0;
            this.chkColor.Text = "checkBox1";
            this.chkColor.UseVisualStyleBackColor = true;
            // 
            // pnlRecuadroColor
            // 
            this.pnlRecuadroColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecuadroColor.Location = new System.Drawing.Point(3, 3);
            this.pnlRecuadroColor.Name = "pnlRecuadroColor";
            this.pnlRecuadroColor.Size = new System.Drawing.Size(14, 20);
            this.pnlRecuadroColor.TabIndex = 1;
            this.pnlRecuadroColor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRecuadroColor_Paint);
            // 
            // lblNumPiezas
            // 
            this.lblNumPiezas.AutoSize = true;
            this.lblNumPiezas.Location = new System.Drawing.Point(109, 3);
            this.lblNumPiezas.Margin = new System.Windows.Forms.Padding(3);
            this.lblNumPiezas.Name = "lblNumPiezas";
            this.lblNumPiezas.Size = new System.Drawing.Size(0, 13);
            this.lblNumPiezas.TabIndex = 2;
            // 
            // colorCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "colorCheckBox";
            this.Size = new System.Drawing.Size(160, 26);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkColor;
        private System.Windows.Forms.Panel pnlRecuadroColor;
        private System.Windows.Forms.Label lblNumPiezas;
    }
}
