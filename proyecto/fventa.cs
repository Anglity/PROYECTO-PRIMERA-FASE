
using DocumentFormat.OpenXml.Vml;
using entidad;
using negocio;
using proyecto.modales;
using proyecto.utlidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace proyecto
{

    public partial class fventa : Form
    {
        private usuario _usuario;
        public fdetalle_venta formVenta;
        public fventa(usuario oUsuario = null)
        {
            _usuario = oUsuario;
            InitializeComponent();
            InicializarComboBoxUnidadesMedida();
            this.txtproducto.TextChanged += new System.EventHandler(this.txtproducto_TextChanged);
            formVenta = new fdetalle_venta();


        }

        private void fventa_Load(object sender, EventArgs e)
        {


            tipodocumento2.Items.Add(new opcionescombo() { valor = "Efectivo", texto = "Efectivo" });
            tipodocumento2.Items.Add(new opcionescombo() { valor = "Facturaa", texto = "Factura" });
            tipodocumento2.Items.Add(new opcionescombo() { valor = "Transferencia", texto = "Transferencia" });
            tipodocumento2.DisplayMember = "Texto";
            tipodocumento2.ValueMember = "Valor";
            tipodocumento2.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";

            txtpagacon.Text = string.Empty;
            txtcambio.Text = string.Empty;
            txttotalpagar.Text = "0";
            this.dgdata.CellDoubleClick += new DataGridViewCellEventHandler(this.dgdata_CellContentDoubleClick);








        }
        private void InicializarComboBoxUnidadesMedida()
        {
            cbUnidadesMedida.Items.Add(new UnidadMedida() { Valor = "Galones", Texto = "Galones" });
            cbUnidadesMedida.Items.Add(new UnidadMedida() { Valor = "Litros", Texto = "Litros" });
            cbUnidadesMedida.Items.Add(new UnidadMedida() { Valor = "Bloques de Queso", Texto = "Bloques de Queso" });
            cbUnidadesMedida.Items.Add(new UnidadMedida() { Valor = "Libra", Texto = "Libra" });

            cbUnidadesMedida.DisplayMember = "Texto";
            cbUnidadesMedida.ValueMember = "Valor";

            if (cbUnidadesMedida.Items.Count > 0)
            {
                cbUnidadesMedida.SelectedIndex = 0;
            }


        }


        private void btnbusqueda_Click(object sender, EventArgs e)
        {

            using (var modal = new md_cliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtdocumentocliente.Text = modal._cliente.Documento;
                    txtnombrecliente.Text = modal._cliente.NombreCompleto;
                    txtcodproducto.Select();
                }
                else
                {
                    txtdocumentocliente.Select();
                }

            }
        }

        private void busquedaproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new md_productos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproducto.Text = modal._producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._producto.Codigo;
                    txtproducto.Text = modal._producto.Nombre;
                    txtprecio.Text = modal._producto.PrecioVenta.ToString("0.00");
                    txtstock.Text = modal._producto.Stock.ToString();
                    txtcantidad.Select();
                }
                else
                {
                    txtcodproducto.Select();
                }
                txtprecio.Text = modal._producto.PrecioVenta.ToString("N0");

            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                producto oProducto = new cn_producto().listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtcodproducto.BackColor = System.Drawing.Color.Honeydew;
                    txtidproducto.Text = oProducto.IdProducto.ToString();
                    txtproducto.Text = oProducto.Nombre;
                    txtprecio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtstock.Text = oProducto.Stock.ToString();
                    txtcantidad.Select();
                }
                else
                {
                    txtcodproducto.BackColor = System.Drawing.Color.MistyRose;
                    txtidproducto.Text = "0";
                    txtproducto.Text = string.Empty;
                    txtprecio.Text = string.Empty;
                    txtstock.Text = string.Empty;
                    txtcantidad.Value = 1;
                }
            }
        }






        private void btnagregarproductos_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool producto_existe = false;
            decimal porcentajeITBIS = 18;
            const decimal LITROS_POR_GALON = 3.78541M;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtprecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecio.Select();
                return;
            }

            if (cbUnidadesMedida.Text == "Bloques de Queso")
            {
                const decimal FACTOR_BLOQUES_QUESO = 5M;
                precio = precio * FACTOR_BLOQUES_QUESO;
            }
            else if (cbUnidadesMedida.Text == "Galones")
            {
                precio = precio * LITROS_POR_GALON;
            }

            decimal cantidad = Convert.ToDecimal(txtcantidad.Value);
            decimal cantidadEnStock = Convert.ToDecimal(txtstock.Text);
            decimal cantidadAComparar = cantidad;



            if (cantidadEnStock < cantidadAComparar)
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dgdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {
                string cantidadEnLibras = "0";
                string cantidadEnLitros = "0";

                if (cbUnidadesMedida.Text == "Bloques de Queso")
                {
                    cantidadEnLibras = (cantidad * 5).ToString();
                }
                else if (cbUnidadesMedida.Text == "Galones")
                {
                    cantidadEnLitros = (cantidad * LITROS_POR_GALON).ToString("0.00");
                }

                decimal subtotal = cantidad * precio;
                decimal itbis = subtotal * (porcentajeITBIS / 100);
                decimal total = subtotal + itbis;

                dgdata.Rows.Add(new object[] {
            txtidproducto.Text,
            txtproducto.Text,
            txtcodproducto.Text,
            txtstock.Text,
            precio.ToString("0.00"),
            cantidad.ToString(),
            cbUnidadesMedida.Text,
            subtotal.ToString("0.00"),
            itbis.ToString("0.00"),
            total.ToString("0.00"),
            cantidadEnLitros,
            cantidadEnLibras,
            txtLitros.Text,
            txtLibras.Text,



        });

                calcularTotal();
                limpiarProducto();
                txtcodproducto.Select();

            }



        }


        private void NuevaVenta()
        {
            dgdata.Rows.Clear();
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());

            }
            txttotalpagar.Text = total.ToString("N0");

            decimal porcentajeITBIS = 18;

            // Calcular el monto del ITBIS y agregarlo al total
            decimal itbis = total * (porcentajeITBIS / 100);
            total += itbis;

            txtitbis.Text = total.ToString("N0");

            txtitbis2.Text = itbis.ToString("N0");





        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = string.Empty;
            txtproducto.Text = string.Empty;
            txtprecio.Text = string.Empty;
            txtstock.Text = string.Empty;
            txtcantidad.Value = 1;
        }

        private void dgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 12)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.borrar.Width;
                var h = Properties.Resources.borrar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.borrar, new System.Drawing.Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private bool seHizoClickEliminar = false; // Bandera para rastrear si se hizo clic en el botón "Eliminar"

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    // Aquí estás convirtiendo los valores pero no los estás asignando a ninguna variable
                    // Puedes asignarlos a variables si los necesitas usar más adelante
                    // int idProducto = Convert.ToInt32(dgdata.Rows[index].Cells["IdProducto"].Value.ToString());
                    // int cantidad = Convert.ToInt32(dgdata.Rows[index].Cells["Cantidad"].Value.ToString());

                    dgdata.Rows.RemoveAt(index);
                    calcularTotal();


                }
            }


        }
        private bool seHizoClickRegistrar = false; // Bandera para rastrear si se hizo clic en el botón "Registrar"

        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verificar si se hizo clic en el botón "Registrar"
            if (!seHizoClickRegistrar)
            {
                // Si no se hizo clic en el botón "Registrar", realizar la operación inversa para sumar el stock nuevamente
                // Puedes obtener los datos necesarios del DataGridView para sumar el stock adecuadamente
                // ...

                // Ejemplo de cómo obtener los datos de la última fila del DataGridView (ajusta esto según tu DataGridView)
                int idProducto = Convert.ToInt32(dgdata.Rows[dgdata.Rows.Count - 1].Cells["IdProducto"].Value);
                int cantidad = Convert.ToInt32(dgdata.Rows[dgdata.Rows.Count - 1].Cells["Cantidad"].Value);

                // Sumar el stock nuevamente (esto es solo un ejemplo, debes ajustar la lógica según tus necesidades)
                new cn_venta().SumarStock(idProducto, cantidad);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Tu código para registrar la venta
            // ...

            // Si no se hizo clic en el botón "Eliminar", restar el stock
            if (!seHizoClickEliminar)
            {
                bool respuesta = new cn_venta().RestarStock(
                    Convert.ToInt32(txtidproducto.Text),
                    Convert.ToInt32(txtcantidad.Value.ToString())
                );

                if (respuesta)
                {
                    // Resto de tu código para agregar la venta a la DataGridView
                    // ...
                }
            }

            // Reiniciar la bandera después de realizar las operaciones
            seHizoClickEliminar = false;

        }


        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }
        }



        private void txtpagacon_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagacon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }
        }

        private void calcularcambio()
        {

            if (txttotalpagar.Text.Trim() == string.Empty)
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(txtitbis.Text);

            if (txtpagacon.Text.Trim() == string.Empty)
            {
                txtpagacon.Text = "0";
            }

            if (decimal.TryParse(txtpagacon.Text.Trim(), out pagacon))
            {

                if (pagacon < total)
                {



                    MessageBox.Show("El monto a pagar debe ser mayor o igual al Valor total", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

#pragma warning disable CS0162 // Se detectó código inaccesible
                    txtcambio.Text = "0.00";
#pragma warning restore CS0162 // Se detectó código inaccesible

                }
                else
                {
                    decimal cambio = pagacon - total;
                    txtcambio.Text = cambio.ToString("0.00");

                }



            }



        }

        private void txtpagacon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularcambio();
            }
        }

        public void btncrearventa_Click(object sender, EventArgs e)
        {

            // Validar los campos de cliente y productos antes de continuar
            if (txtdocumentocliente.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el documento del cliente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtnombrecliente.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el nombre del cliente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string tipoDocumentoSeleccionado = ((opcionescombo)tipodocumento2.SelectedItem).texto;

            // Validar txtpagacon solo si no es Factura o Transferencia
            if (tipoDocumentoSeleccionado != "Factura" && tipoDocumentoSeleccionado != "Transferencia")
            {
                if (txtpagacon.Text == string.Empty)
                {
                    MessageBox.Show("Debe ingresar el pagar con.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (dgdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la venta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }




            // Crear y llenar la tabla detalle_venta con los datos de la DataGridView
            DataTable detalle_venta = new DataTable();
            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));
            detalle_venta.Columns.Add("itbis", typeof(decimal));
            detalle_venta.Columns.Add("Valortotal", typeof(decimal));
            detalle_venta.Columns.Add("UnidadesMedida", typeof(string));
            detalle_venta.Columns.Add("Galones_a_Litro", typeof(decimal));
            detalle_venta.Columns.Add("Bloque_a_Libra", typeof(decimal));

            foreach (DataGridViewRow row in dgdata.Rows)
            {
                int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value ?? 0);
                decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value ?? 0);
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value ?? 0);
                decimal subTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value ?? 0);
                decimal itbis = Convert.ToDecimal(row.Cells["itbis"].Value ?? 0);
                decimal valorTotal = Convert.ToDecimal(row.Cells["Valortotal"].Value ?? 0);
                string unidadesMedida = Convert.ToString(row.Cells["UnidadesMedida"].Value ?? string.Empty);

                // Si Galones_a_Litro está vacío, asignamos 0, si no, convertimos su valor a decimal.
                decimal galonesALitro = string.IsNullOrEmpty(Convert.ToString(row.Cells["Galones_a_Litro"].Value))
                    ? 0
                    : Convert.ToDecimal(row.Cells["Galones_a_Litro"].Value);

                // Si Bloque_a_Libra está vacío, asignamos 0, si no, convertimos su valor a decimal.
                decimal bloqueALibra = string.IsNullOrEmpty(Convert.ToString(row.Cells["Bloque_a_Libra"].Value))
                    ? 0
                    : Convert.ToDecimal(row.Cells["Bloque_a_Libra"].Value);

                detalle_venta.Rows.Add(new object[] { idProducto, precio, cantidad, subTotal, itbis, valorTotal, unidadesMedida, galonesALitro, bloqueALibra });
            }

            // Obtener el número de venta correlativo
            int idcorrelativo = new cn_venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);

            // Crear el objeto de venta
            venta oVenta = new venta()
            {
                ousuario = new usuario() { IdUsuario = _usuario.IdUsuario },
                TipoDocumento = ((opcionescombo)tipodocumento2.SelectedItem).texto,
                NumeroDocumento = numeroDocumento,
                DocumentoCliente = txtdocumentocliente.Text,
                NombreCliente = txtnombrecliente.Text,
                MontoPago = Convert.ToDecimal(txtpagacon.Text),
                MontoCambio = Convert.ToDecimal(txtcambio.Text),
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text),

            };

            string mensaje = string.Empty;
            bool respuesta = new cn_venta().Registrar(oVenta, detalle_venta, out mensaje);

            if (respuesta)
            {
                // Restar el stock de cada producto vendido
                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                    int cantidadVendida = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    string unidadDeMedida = Convert.ToString(row.Cells["UnidadesMedida"].Value ?? string.Empty);
                    decimal factorDeConversión = 1;  // Para otros tipos de productos

                    // Si el producto es un "Bloque de Queso", ajustar la cantidad a libras
                    if (unidadDeMedida == "Bloques de Queso")
                    {
                        factorDeConversión = 5; // 1 Bloque de Queso = 5 Libras
                    }
                    // Si el producto es un "Galón", ajustar la cantidad a litros
                    else if (unidadDeMedida == "Galones")
                    {
                        factorDeConversión = 3.78541M; // 1 Galón = 3.78541 Litros
                    }

                    // Aplicar el factor de conversión
                    decimal cantidadARestar = cantidadVendida * factorDeConversión;

                    bool restarStockExitoso = new cn_venta().RestarStock(idProducto, (int)Math.Floor(cantidadARestar));

                    if (!restarStockExitoso)
                    {
                        MessageBox.Show("Error al restar el stock del producto: " + idProducto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Aquí puedes agregar lógica adicional si ocurre un error al restar el stock.
                    }


                }


                var result = MessageBox.Show("Número de venta generada:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Clipboard.SetText(numeroDocumento);

                // Limpiar los campos y la DataGridView después de registrar la venta exitosamente
                txtdocumentocliente.Text = string.Empty;
                txtnombrecliente.Text = string.Empty;
                dgdata.Rows.Clear();
                calcularTotal();
                txtpagacon.Text = string.Empty;
                txtcambio.Text = string.Empty;
                txtitbis.Text = string.Empty;
                txtitbis2.Text = string.Empty;
                txttotalpagar.Text = string.Empty;
                cbUnidadesMedida.Text = string.Empty;


            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            formVenta.excel_Click(null, EventArgs.Empty);

        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {
            string productoSeleccionado = txtproducto.Text.ToLower();
            cbUnidadesMedida.Items.Clear();

            if (productoSeleccionado.Contains("queso"))
            {
                cbUnidadesMedida.Items.Add("Libras");
                cbUnidadesMedida.Items.Add("Bloques de Queso");
            }
            else if (productoSeleccionado.Contains("leche"))
            {
                cbUnidadesMedida.Items.Add("Litros");
                cbUnidadesMedida.Items.Add("Galones");
            }
            else
            {
                // Aquí puedes añadir las otras unidades de medida que quieras que aparezcan
                cbUnidadesMedida.Items.Add("Saco");
                cbUnidadesMedida.Items.Add("Litro");
                cbUnidadesMedida.Items.Add("Cubeta");
                cbUnidadesMedida.Items.Add("Galones");
                // ... (añade aquí más unidades de medida si es necesario)
            }

            // Asegurarse de que el primer ítem esté seleccionado
            if (cbUnidadesMedida.Items.Count > 0)
            {
                cbUnidadesMedida.SelectedIndex = 0;
            }
        }


        private bool conversionRealizada = false;
        private decimal stockOriginalEnLibras;
        private decimal stockOriginalEnLitros;

        private void cbUnidadesMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el producto seleccionado contiene la palabra "queso"
            if (txtproducto.Text.ToLower().Contains("queso"))
            {
                if (cbUnidadesMedida.SelectedItem.ToString() == "Bloques de Queso" && !conversionRealizada)
                {
                    if (decimal.TryParse(txtstock.Text, out decimal stockEnLibras))
                    {
                        // Almacena el valor original en libras antes de la conversión
                        stockOriginalEnLibras = stockEnLibras;

                        decimal stockEnBloques = stockEnLibras / 5M; // Convierte libras a bloques de queso
                        txtstock.Text = stockEnBloques.ToString("0.00"); // Actualiza el textbox con el resultado
                        conversionRealizada = true; // Marca la conversión como realizada
                    }
                    else
                    {
                        MessageBox.Show("El valor del stock no es un número válido.");
                    }
                }
                else if (cbUnidadesMedida.SelectedItem.ToString() == "Libras" && conversionRealizada)
                {
                    // Restablece el valor del stock al original en libras
                    txtstock.Text = stockOriginalEnLibras.ToString();
                    conversionRealizada = false; // Permite nuevas conversiones si se vuelve a seleccionar "Bloques de Queso"
                }
            }
            else if (txtproducto.Text.ToLower().Contains("leche"))
            {
                if (cbUnidadesMedida.SelectedItem.ToString() == "Galones" && !conversionRealizada)
                {
                    if (decimal.TryParse(txtstock.Text, out decimal stockEnLitros))
                    {
                        stockOriginalEnLitros = stockEnLitros;
                        decimal stockEnGalones = stockEnLitros * 0.264172M; // Convierte litros a galones
                        txtstock.Text = stockEnGalones.ToString("0.00");
                        conversionRealizada = true;
                    }
                    else
                    {
                        MessageBox.Show("El valor del stock no es un número válido.");
                    }
                }
                else if (cbUnidadesMedida.SelectedItem.ToString() == "Litros" && conversionRealizada)
                {
                    txtstock.Text = stockOriginalEnLitros.ToString();
                    conversionRealizada = false;
                }
            }
            // Puedes agregar más condicionales para otros productos aquí si es necesario
        }




        private void dgdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya hecho clic en una fila válida
            {


                // Opción 2: Cargar los datos en los TextBox y luego eliminar la fila
                // Comentar o eliminar esta sección si solo quieres eliminar la fila sin cargar los datos
                DataGridViewRow row = dgdata.Rows[e.RowIndex];
                txtidproducto.Text = row.Cells["IdProducto"].Value.ToString();
                txtcodproducto.Text = row.Cells["Codigo"].Value.ToString();
                txtproducto.Text = row.Cells["Producto"].Value.ToString();
                txtprecio.Text = Convert.ToDecimal(row.Cells["Precio"].Value).ToString("0.00");
                txtstock.Text = row.Cells["Stock"].Value.ToString();
                txtcantidad.Value = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                cbUnidadesMedida.SelectedValue = row.Cells["UnidadesMedida"].Value.ToString();
                txtcantidad.Select();

                // Eliminar la fila después de cargar los datos
                dgdata.Rows.RemoveAt(e.RowIndex);


            }
        }

        private void txtpagacon_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void tipodocumento2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var tipoDocumentoSeleccionado = ((opcionescombo)tipodocumento2.SelectedItem).texto;

            if (tipoDocumentoSeleccionado == "Factura" || tipoDocumentoSeleccionado == "Transferencia")
            {
                // Establece el campo txtpagacon a 0, y lo oculta y deshabilita
                txtpagacon.Text = "0";
                txtcambio.Text = "0";
                txtpagacon.Visible = false;
                txtpagacon.Enabled = false;
            }
            else
            {
                // Muestra y habilita el campo txtpagacon para otros tipos de documentos
                txtpagacon.Visible = true;
                txtpagacon.Enabled = true;

            }
        }
    }

}

