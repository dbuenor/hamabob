namespace Proyecto_Hamma_Beads.Controles
{
    partial class PictureBoxZoom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureBoxZoom));
            this.tbPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tbTexto = new System.Windows.Forms.TableLayoutPanel();
            this.lblRutaTitulo = new System.Windows.Forms.Label();
            this.lblMedidasTitulo = new System.Windows.Forms.Label();
            this.lblMedidas = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.pnlImagen = new System.Windows.Forms.Panel();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.pbZoom = new System.Windows.Forms.PictureBox();
            this.tbarZoom = new System.Windows.Forms.TrackBar();
            this.btnMostrarOcultar = new System.Windows.Forms.Button();
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.toolTipPB = new System.Windows.Forms.ToolTip(this.components);
            this.lblZoom = new System.Windows.Forms.Label();
            this.tbPrincipal.SuspendLayout();
            this.tbTexto.SuspendLayout();
            this.pnlImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.ColumnCount = 3;
            this.tbPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tbPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.38095F));
            this.tbPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPrincipal.Controls.Add(this.tbTexto, 0, 3);
            this.tbPrincipal.Controls.Add(this.pnlImagen, 0, 0);
            this.tbPrincipal.Controls.Add(this.pbZoom, 1, 0);
            this.tbPrincipal.Controls.Add(this.tbarZoom, 1, 1);
            this.tbPrincipal.Controls.Add(this.btnMostrarOcultar, 2, 0);
            this.tbPrincipal.Controls.Add(this.lblZoom, 1, 2);
            this.tbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tbPrincipal.Name = "tbPrincipal";
            this.tbPrincipal.RowCount = 4;
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPrincipal.Size = new System.Drawing.Size(515, 358);
            this.tbPrincipal.TabIndex = 3;
            this.tbPrincipal.SizeChanged += new System.EventHandler(this.tbPrincipal_SizeChanged);
            // 
            // tbTexto
            // 
            this.tbTexto.ColumnCount = 4;
            this.tbTexto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tbTexto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tbTexto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tbTexto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbTexto.Controls.Add(this.lblRutaTitulo, 2, 0);
            this.tbTexto.Controls.Add(this.lblMedidasTitulo, 0, 0);
            this.tbTexto.Controls.Add(this.lblMedidas, 1, 0);
            this.tbTexto.Controls.Add(this.lblRuta, 3, 0);
            this.tbTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTexto.Location = new System.Drawing.Point(3, 333);
            this.tbTexto.Name = "tbTexto";
            this.tbTexto.RowCount = 1;
            this.tbTexto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbTexto.Size = new System.Drawing.Size(224, 22);
            this.tbTexto.TabIndex = 3;
            // 
            // lblRutaTitulo
            // 
            this.lblRutaTitulo.AutoSize = true;
            this.lblRutaTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaTitulo.Location = new System.Drawing.Point(178, 0);
            this.lblRutaTitulo.Name = "lblRutaTitulo";
            this.lblRutaTitulo.Size = new System.Drawing.Size(45, 13);
            this.lblRutaTitulo.TabIndex = 2;
            this.lblRutaTitulo.Text = "RUTA:";
            this.lblRutaTitulo.Visible = false;
            // 
            // lblMedidasTitulo
            // 
            this.lblMedidasTitulo.AutoSize = true;
            this.lblMedidasTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedidasTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblMedidasTitulo.Name = "lblMedidasTitulo";
            this.lblMedidasTitulo.Size = new System.Drawing.Size(67, 13);
            this.lblMedidasTitulo.TabIndex = 0;
            this.lblMedidasTitulo.Text = "MEDIDAS:";
            // 
            // lblMedidas
            // 
            this.lblMedidas.AutoSize = true;
            this.lblMedidas.Location = new System.Drawing.Point(78, 0);
            this.lblMedidas.Name = "lblMedidas";
            this.lblMedidas.Size = new System.Drawing.Size(0, 13);
            this.lblMedidas.TabIndex = 1;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(233, 0);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(0, 13);
            this.lblRuta.TabIndex = 3;
            this.lblRuta.Visible = false;
            // 
            // pnlImagen
            // 
            this.pnlImagen.AutoScroll = true;
            this.pnlImagen.Controls.Add(this.pbImagen);
            this.pnlImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagen.Location = new System.Drawing.Point(3, 3);
            this.pnlImagen.Name = "pnlImagen";
            this.tbPrincipal.SetRowSpan(this.pnlImagen, 3);
            this.pnlImagen.Size = new System.Drawing.Size(224, 324);
            this.pnlImagen.TabIndex = 3;
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImagen.Location = new System.Drawing.Point(0, 0);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(224, 324);
            this.pbImagen.TabIndex = 2;
            this.pbImagen.TabStop = false;
            this.pbImagen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_MouseClick);
            // 
            // pbZoom
            // 
            this.pbZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbZoom.Location = new System.Drawing.Point(240, 10);
            this.pbZoom.Margin = new System.Windows.Forms.Padding(10);
            this.pbZoom.Name = "pbZoom";
            this.pbZoom.Size = new System.Drawing.Size(232, 83);
            this.pbZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbZoom.TabIndex = 0;
            this.pbZoom.TabStop = false;
            this.pbZoom.Visible = false;
            // 
            // tbarZoom
            // 
            this.tbarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbarZoom.Location = new System.Drawing.Point(233, 106);
            this.tbarZoom.Maximum = 20;
            this.tbarZoom.Minimum = 2;
            this.tbarZoom.Name = "tbarZoom";
            this.tbarZoom.Size = new System.Drawing.Size(246, 45);
            this.tbarZoom.TabIndex = 2;
            this.tbarZoom.TickFrequency = 2;
            this.tbarZoom.Value = 2;
            this.tbarZoom.Visible = false;
            // 
            // btnMostrarOcultar
            // 
            this.btnMostrarOcultar.ImageIndex = 0;
            this.btnMostrarOcultar.ImageList = this.imgLista;
            this.btnMostrarOcultar.Location = new System.Drawing.Point(485, 3);
            this.btnMostrarOcultar.Name = "btnMostrarOcultar";
            this.tbPrincipal.SetRowSpan(this.btnMostrarOcultar, 2);
            this.btnMostrarOcultar.Size = new System.Drawing.Size(26, 26);
            this.btnMostrarOcultar.TabIndex = 4;
            this.btnMostrarOcultar.UseVisualStyleBackColor = true;
            this.btnMostrarOcultar.Click += new System.EventHandler(this.btnMostrarOcultar_Click);
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "1388423143_icon-arrow-left-b.png");
            this.imgLista.Images.SetKeyName(1, "1388423149_icon-arrow-right-b.png");
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZoom.Location = new System.Drawing.Point(233, 154);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(246, 13);
            this.lblZoom.TabIndex = 5;
            this.lblZoom.Text = "1X";
            this.lblZoom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBoxZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbPrincipal);
            this.Name = "PictureBoxZoom";
            this.Size = new System.Drawing.Size(515, 358);
            this.tbPrincipal.ResumeLayout(false);
            this.tbPrincipal.PerformLayout();
            this.tbTexto.ResumeLayout(false);
            this.tbTexto.PerformLayout();
            this.pnlImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbPrincipal;
        private System.Windows.Forms.PictureBox pbZoom;
        private System.Windows.Forms.TrackBar tbarZoom;
        private System.Windows.Forms.Panel pnlImagen;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Button btnMostrarOcultar;
        private System.Windows.Forms.ImageList imgLista;
        private System.Windows.Forms.TableLayoutPanel tbTexto;
        private System.Windows.Forms.Label lblMedidasTitulo;
        private System.Windows.Forms.Label lblMedidas;
        private System.Windows.Forms.Label lblRutaTitulo;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.ToolTip toolTipPB;
        private System.Windows.Forms.Label lblZoom;


    }
}
