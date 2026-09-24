using System.Drawing.Imaging;

namespace Laboratorio_4___Diego_Sanjur
{
    public partial class Form1 : Form
    {
        private List<Producto> listaProductos;
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();
        private bool imagenSeleccionada = false;   // ¿hay una imagen real en pictureBox2?
        private int idSeleccionado = 0;            // 0 = ningún producto seleccionado

        public Form1()
        {
            InitializeComponent();

            // Filas altas e imagen completa en el grid
            dgvProductos.RowTemplate.Height = 80;
            if (dgvProductos.Columns["Imagen"] is DataGridViewImageColumn colImagen)
                colImagen.ImageLayout = DataGridViewImageCellLayout.Zoom;

            listaProductos = new List<Producto>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        // ---------- LEER: llena el grid ----------
        private void cargarProductos(string filtro = "")
        {
            dgvProductos.Rows.Clear();
            listaProductos = Conexion.GetProductos(filtro);

            foreach (var prod in listaProductos)
            {
                Image? img = null;

                if (prod.Imagen != null && prod.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(prod.Imagen))
                    using (Bitmap bmp = new Bitmap(ms))
                    {
                        img = new Bitmap(bmp);   // copia independiente del stream
                    }
                }

                dgvProductos.Rows.Add(prod.Id, prod.Nombre, prod.Precio, prod.Cantidad, img);
            }

            dgvProductos.ClearSelection();
        }

        // ---------- BUSCAR ----------
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarProductos(txtBusqueda.Text.Trim());
        }

        // pictureBox1 = lupa
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cargarProductos(txtBusqueda.Text.Trim());
        }

        // ---------- ELEGIR IMAGEN (pictureBox2 = imagen del producto) ----------
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen del producto";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    imagenSeleccionada = true;
                }
            }
        }

        // ---------- SELECCIONAR FILA DEL GRID ----------
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // clic en el encabezado

            int id = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value);
            Producto? prod = listaProductos.Find(p => p.Id == id);
            if (prod == null) return;

            idSeleccionado = prod.Id;
            txtFolio.Text = prod.Id.ToString();
            txtNombre.Text = prod.Nombre;
            txtPrecio.Text = prod.Precio.ToString();
            txtCantidad.Text = prod.Cantidad.ToString();

            pictureBox2.Image = null;
            imagenSeleccionada = false;

            if (prod.Imagen != null && prod.Imagen.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(prod.Imagen))
                using (Bitmap bmp = new Bitmap(ms))
                {
                    pictureBox2.Image = new Bitmap(bmp);
                }
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                imagenSeleccionada = true;
            }
        }

        // ---------- GUARDAR (INSERT) ----------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0)
            {
                MessageBox.Show("Hay un producto seleccionado. Use Modificar, o presione Limpiar para agregar uno nuevo.");
                return;
            }

            if (!datosCorrectos())
                return;

            CargarDatosProductos();

            if (Conexion.InsertSeguro("productos", myProducto))
            {
                MessageBox.Show("Se ha guardado satisfactoriamente el registro");
                limpiarCampos();
                cargarProductos();
            }
            else
            {
                MessageBox.Show("No se pudo guardar. Revisa la conexión a MySQL.");
            }
        }

        // ---------- MODIFICAR (UPDATE) ----------
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto del grid para modificar");
                return;
            }

            if (!datosCorrectos())
                return;

            CargarDatosProductos();

            if (Conexion.UpdateSeguro("productos", myProducto, "id", idSeleccionado))
            {
                MessageBox.Show("Producto modificado correctamente");
                limpiarCampos();
                cargarProductos();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el producto");
            }
        }

        // ---------- VALIDACIONES ----------
        private bool datosCorrectos()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre del Producto");
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio))
            {
                MessageBox.Show("Ingrese un Precio correcto");
                return false;
            }
            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad))
            {
                MessageBox.Show("Ingrese una Cantidad correcta");
                return false;
            }
            if (!imagenSeleccionada)
            {
                MessageBox.Show("Seleccione una imagen para el producto");
                return false;
            }
            return true;
        }

        // ---------- PASAR DATOS AL DICCIONARIO ----------
        private void CargarDatosProductos()
        {
            myProducto["nombre"] = txtNombre.Text.Trim();
            myProducto["precio"] = decimal.Parse(txtPrecio.Text.Trim());
            myProducto["cantidad"] = int.Parse(txtCantidad.Text.Trim());
            myProducto["imagen"] = ImageToByteArray(pictureBox2.Image)!;
        }

        private byte[]? ImageToByteArray(Image? image)
        {
            if (image == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // ---------- LIMPIAR ----------
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtFolio.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            pictureBox2.Image = null;
            imagenSeleccionada = false;
            idSeleccionado = 0;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto del grid para eliminar");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de eliminar el producto \"{txtNombre.Text}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            if (Conexion.DeleteSeguro("productos", "id", idSeleccionado))
            {
                MessageBox.Show("Producto eliminado correctamente");
                limpiarCampos();
                cargarProductos();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el producto");
            }
        }
    }
}