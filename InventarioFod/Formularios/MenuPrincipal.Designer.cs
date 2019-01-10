namespace InventarioFod
{
    partial class MenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Agregar Lista", 1, 10);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Imprimir Lista", 13, 10);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Listas", 17, 10, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Reequipamiento", 16, 10);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Acciones");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Inventarios", 15, 10, new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Agregar Accion", 1, 10);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Acciones", 14, 10, new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Reequipamiento", 16, 10);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Acciones", 3, 10);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Listados");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Consultas", 18, 10, new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 676);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(3, 650);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(-1, 133);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "add_lista";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode1.SelectedImageIndex = 10;
            treeNode1.Text = "Agregar Lista";
            treeNode2.ImageIndex = 13;
            treeNode2.Name = "print_list";
            treeNode2.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode2.SelectedImageIndex = 10;
            treeNode2.Text = "Imprimir Lista";
            treeNode3.ImageIndex = 17;
            treeNode3.Name = "Listas";
            treeNode3.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.SelectedImageIndex = 10;
            treeNode3.Text = "Listas";
            treeNode3.ToolTipText = "Reequipamiento de equipos";
            treeNode4.ImageIndex = 16;
            treeNode4.Name = "inven_reeequi";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode4.SelectedImageIndex = 10;
            treeNode4.Text = "Reequipamiento";
            treeNode5.Name = "inven_acciones";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode5.SelectedImageIndex = 10;
            treeNode5.Text = "Acciones";
            treeNode6.ImageIndex = 15;
            treeNode6.Name = "Nodo1";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.SelectedImageIndex = 10;
            treeNode6.Text = "Inventarios";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "addAccion";
            treeNode7.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode7.SelectedImageIndex = 10;
            treeNode7.Text = "Agregar Accion";
            treeNode8.ImageIndex = 14;
            treeNode8.Name = "Nodo2";
            treeNode8.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode8.SelectedImageIndex = 10;
            treeNode8.Text = "Acciones";
            treeNode9.ImageIndex = 16;
            treeNode9.Name = "list_reequi";
            treeNode9.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode9.SelectedImageIndex = 10;
            treeNode9.Text = "Reequipamiento";
            treeNode10.ImageIndex = 3;
            treeNode10.Name = "list_accion";
            treeNode10.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode10.SelectedImageIndex = 10;
            treeNode10.Text = "Acciones";
            treeNode11.Name = "consul_List";
            treeNode11.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            treeNode11.SelectedImageIndex = 10;
            treeNode11.Text = "Listados";
            treeNode12.ImageIndex = 18;
            treeNode12.Name = "Nodo0";
            treeNode12.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            treeNode12.SelectedImageIndex = 10;
            treeNode12.Text = "Consultas";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode8,
            treeNode12});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(202, 330);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Purchase Order_32px.png");
            this.imageList1.Images.SetKeyName(1, "Add File_32px.png");
            this.imageList1.Images.SetKeyName(2, "Check Book_32px.png");
            this.imageList1.Images.SetKeyName(3, "Compare_26px.png");
            this.imageList1.Images.SetKeyName(4, "Edit Property_26px.png");
            this.imageList1.Images.SetKeyName(5, "File_32px.png");
            this.imageList1.Images.SetKeyName(6, "Checked_32px.png");
            this.imageList1.Images.SetKeyName(7, "Checked Checkbox 2_32px.png");
            this.imageList1.Images.SetKeyName(8, "Checked_32px_1.png");
            this.imageList1.Images.SetKeyName(9, "Checked Checkbox_16px.png");
            this.imageList1.Images.SetKeyName(10, "Checked Checkbox_16px_1.png");
            this.imageList1.Images.SetKeyName(11, "Add Database_16px.png");
            this.imageList1.Images.SetKeyName(12, "Microsoft Excel_16px.png");
            this.imageList1.Images.SetKeyName(13, "Print_32px.png");
            this.imageList1.Images.SetKeyName(14, "Edit Property_16px.png");
            this.imageList1.Images.SetKeyName(15, "Folder_16px.png");
            this.imageList1.Images.SetKeyName(16, "Laptop_16px.png");
            this.imageList1.Images.SetKeyName(17, "Todo List_16px.png");
            this.imageList1.Images.SetKeyName(18, "View File_16px.png");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(202, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 35);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1046, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "-";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1076, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(202, 35);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1112, 641);
            this.panelPrincipal.TabIndex = 2;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1314, 676);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}