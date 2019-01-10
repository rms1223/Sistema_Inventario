namespace InventarioFod
{
    partial class OpcionesEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcionesEdicion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.l_estado = new System.Windows.Forms.Label();
            this.txt_danos = new System.Windows.Forms.TextBox();
            this.l_danos = new System.Windows.Forms.Label();
            this.txt_fecha = new System.Windows.Forms.MaskedTextBox();
            this.txt_tecnicoInventario = new System.Windows.Forms.TextBox();
            this.txt_ubicacion = new System.Windows.Forms.TextBox();
            this.txt_tecnico = new System.Windows.Forms.TextBox();
            this.txt_serie = new System.Windows.Forms.TextBox();
            this.txt_placa = new System.Windows.Forms.TextBox();
            this.txt_accion = new System.Windows.Forms.TextBox();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.l_tecnicoinventario = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(250)))), ((int)(((byte)(236)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt_estado);
            this.panel1.Controls.Add(this.l_estado);
            this.panel1.Controls.Add(this.txt_danos);
            this.panel1.Controls.Add(this.l_danos);
            this.panel1.Controls.Add(this.txt_fecha);
            this.panel1.Controls.Add(this.txt_tecnicoInventario);
            this.panel1.Controls.Add(this.txt_ubicacion);
            this.panel1.Controls.Add(this.txt_tecnico);
            this.panel1.Controls.Add(this.txt_serie);
            this.panel1.Controls.Add(this.txt_placa);
            this.panel1.Controls.Add(this.txt_accion);
            this.panel1.Controls.Add(this.txt_descripcion);
            this.panel1.Controls.Add(this.l_tecnicoinventario);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 461);
            this.panel1.TabIndex = 0;
            // 
            // txt_estado
            // 
            this.txt_estado.Location = new System.Drawing.Point(567, 335);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(134, 20);
            this.txt_estado.TabIndex = 24;
            this.txt_estado.TextChanged += new System.EventHandler(this.txt_estado_TextChanged);
            // 
            // l_estado
            // 
            this.l_estado.AutoSize = true;
            this.l_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.l_estado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_estado.Location = new System.Drawing.Point(433, 335);
            this.l_estado.Name = "l_estado";
            this.l_estado.Size = new System.Drawing.Size(113, 17);
            this.l_estado.TabIndex = 23;
            this.l_estado.Text = "Estado Equipo";
            // 
            // txt_danos
            // 
            this.txt_danos.Location = new System.Drawing.Point(189, 375);
            this.txt_danos.Multiline = true;
            this.txt_danos.Name = "txt_danos";
            this.txt_danos.Size = new System.Drawing.Size(221, 81);
            this.txt_danos.TabIndex = 20;
            // 
            // l_danos
            // 
            this.l_danos.AutoSize = true;
            this.l_danos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.l_danos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_danos.Location = new System.Drawing.Point(90, 375);
            this.l_danos.Name = "l_danos";
            this.l_danos.Size = new System.Drawing.Size(54, 17);
            this.l_danos.TabIndex = 19;
            this.l_danos.Text = "Daños";
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(571, 26);
            this.txt_fecha.Mask = "00/00/0000";
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(130, 20);
            this.txt_fecha.TabIndex = 18;
            this.txt_fecha.ValidatingType = typeof(System.DateTime);
            // 
            // txt_tecnicoInventario
            // 
            this.txt_tecnicoInventario.Location = new System.Drawing.Point(575, 249);
            this.txt_tecnicoInventario.Name = "txt_tecnicoInventario";
            this.txt_tecnicoInventario.Size = new System.Drawing.Size(130, 20);
            this.txt_tecnicoInventario.TabIndex = 17;
            // 
            // txt_ubicacion
            // 
            this.txt_ubicacion.Location = new System.Drawing.Point(571, 169);
            this.txt_ubicacion.Name = "txt_ubicacion";
            this.txt_ubicacion.Size = new System.Drawing.Size(130, 20);
            this.txt_ubicacion.TabIndex = 16;
            // 
            // txt_tecnico
            // 
            this.txt_tecnico.Location = new System.Drawing.Point(571, 92);
            this.txt_tecnico.Name = "txt_tecnico";
            this.txt_tecnico.Size = new System.Drawing.Size(130, 20);
            this.txt_tecnico.TabIndex = 15;
            // 
            // txt_serie
            // 
            this.txt_serie.Enabled = false;
            this.txt_serie.Location = new System.Drawing.Point(189, 26);
            this.txt_serie.Name = "txt_serie";
            this.txt_serie.Size = new System.Drawing.Size(100, 20);
            this.txt_serie.TabIndex = 13;
            // 
            // txt_placa
            // 
            this.txt_placa.Enabled = false;
            this.txt_placa.Location = new System.Drawing.Point(189, 96);
            this.txt_placa.Name = "txt_placa";
            this.txt_placa.Size = new System.Drawing.Size(101, 20);
            this.txt_placa.TabIndex = 12;
            // 
            // txt_accion
            // 
            this.txt_accion.Location = new System.Drawing.Point(189, 173);
            this.txt_accion.Name = "txt_accion";
            this.txt_accion.Size = new System.Drawing.Size(101, 20);
            this.txt_accion.TabIndex = 11;
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(189, 256);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(221, 99);
            this.txt_descripcion.TabIndex = 10;
            // 
            // l_tecnicoinventario
            // 
            this.l_tecnicoinventario.AutoSize = true;
            this.l_tecnicoinventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.l_tecnicoinventario.Location = new System.Drawing.Point(427, 252);
            this.l_tecnicoinventario.Name = "l_tecnicoinventario";
            this.l_tecnicoinventario.Size = new System.Drawing.Size(142, 17);
            this.l_tecnicoinventario.TabIndex = 7;
            this.l_tecnicoinventario.Text = "Tecnico Inventario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(440, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ubicacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(440, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tecnico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(437, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(90, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(120, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Accion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(120, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Placa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(120, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serie";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(698, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 36);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(647, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 36);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OpcionesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(757, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OpcionesEdicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Registros";
            this.Load += new System.EventHandler(this.OpcionesEdicion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_tecnicoInventario;
        private System.Windows.Forms.TextBox txt_ubicacion;
        private System.Windows.Forms.TextBox txt_tecnico;
        private System.Windows.Forms.TextBox txt_serie;
        private System.Windows.Forms.TextBox txt_placa;
        private System.Windows.Forms.TextBox txt_accion;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label l_tecnicoinventario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txt_fecha;
        private System.Windows.Forms.TextBox txt_danos;
        private System.Windows.Forms.Label l_danos;
        private System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.Label l_estado;
    }
}