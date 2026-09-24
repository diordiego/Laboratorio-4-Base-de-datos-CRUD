namespace Laboratorio_4___Diego_Sanjur
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            txtBusqueda = new TextBox();
            dgvProductos = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Imagen = new DataGridViewImageColumn();
            btnGuardar = new Button();
            imageList1 = new ImageList(components);
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblFolio = new Label();
            lblNombre = new Label();
            lblPrecio = new Label();
            label2 = new Label();
            txtFolio = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            panel2 = new Panel();
            lblCrud = new Label();
            pictureBox2 = new PictureBox();
            lblImagen = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtBusqueda);
            panel1.Location = new Point(17, 228);
            panel1.Name = "panel1";
            panel1.Size = new Size(853, 50);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 2;
            label1.Text = "Busqueda";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.buscar;
            pictureBox1.Location = new Point(600, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(133, 14);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(448, 27);
            txtBusqueda.TabIndex = 0;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { id, Nombre, Precio, Cantidad, Imagen });
            dgvProductos.Location = new Point(17, 284);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(853, 292);
            dgvProductos.TabIndex = 1;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 125;
            // 
            // Imagen
            // 
            Imagen.HeaderText = "Imagen";
            Imagen.MinimumWidth = 6;
            Imagen.Name = "Imagen";
            Imagen.Width = 125;
            // 
            // btnGuardar
            // 
            btnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            btnGuardar.ImageIndex = 2;
            btnGuardar.ImageList = imageList1;
            btnGuardar.Location = new Point(37, 592);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(178, 49);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "eliminar.png");
            imageList1.Images.SetKeyName(1, "boton-editar.png");
            imageList1.Images.SetKeyName(2, "salvar.png");
            imageList1.Images.SetKeyName(3, "escoba.png");
            imageList1.Images.SetKeyName(4, "buscar.png");
            // 
            // btnModificar
            // 
            btnModificar.ImageAlign = ContentAlignment.MiddleRight;
            btnModificar.ImageIndex = 1;
            btnModificar.ImageList = imageList1;
            btnModificar.Location = new Point(239, 592);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(178, 49);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.ImageAlign = ContentAlignment.MiddleRight;
            btnEliminar.ImageIndex = 0;
            btnEliminar.ImageList = imageList1;
            btnEliminar.Location = new Point(440, 592);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(178, 49);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.ImageAlign = ContentAlignment.MiddleRight;
            btnLimpiar.ImageIndex = 3;
            btnLimpiar.ImageList = imageList1;
            btnLimpiar.Location = new Point(645, 592);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(178, 49);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFolio.Location = new Point(37, 60);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(58, 28);
            lblFolio.TabIndex = 6;
            lblFolio.Text = "Folio";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNombre.Location = new Point(37, 100);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(89, 28);
            lblNombre.TabIndex = 7;
            lblNombre.Text = "Nombre";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPrecio.Location = new Point(37, 142);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(71, 28);
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "Precio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(37, 185);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 9;
            label2.Text = "Cantidad";
            // 
            // txtFolio
            // 
            txtFolio.Location = new Point(159, 61);
            txtFolio.Name = "txtFolio";
            txtFolio.ReadOnly = true;
            txtFolio.Size = new Size(424, 27);
            txtFolio.TabIndex = 10;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(159, 104);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(424, 27);
            txtNombre.TabIndex = 11;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(159, 146);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(424, 27);
            txtPrecio.TabIndex = 12;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(159, 186);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(424, 27);
            txtCantidad.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(lblCrud);
            panel2.Location = new Point(12, 9);
            panel2.Name = "panel2";
            panel2.Size = new Size(858, 43);
            panel2.TabIndex = 14;
            // 
            // lblCrud
            // 
            lblCrud.AutoSize = true;
            lblCrud.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCrud.Location = new Point(5, 7);
            lblCrud.Name = "lblCrud";
            lblCrud.Size = new Size(196, 28);
            lblCrud.TabIndex = 0;
            lblCrud.Text = "CRUD de productos";
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(628, 91);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(242, 131);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // lblImagen
            // 
            lblImagen.AutoSize = true;
            lblImagen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblImagen.Location = new Point(628, 60);
            lblImagen.Name = "lblImagen";
            lblImagen.Size = new Size(82, 28);
            lblImagen.TabIndex = 16;
            lblImagen.Text = "Imágen";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 653);
            Controls.Add(lblImagen);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtFolio);
            Controls.Add(label2);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(lblFolio);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvProductos);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "CRUD de productos";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox txtBusqueda;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewImageColumn Imagen;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private ImageList imageList1;
        private Label lblFolio;
        private Label lblNombre;
        private Label lblPrecio;
        private Label label2;
        private TextBox txtFolio;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private Panel panel2;
        private Label lblCrud;
        private PictureBox pictureBox2;
        private Label lblImagen;
    }
}
