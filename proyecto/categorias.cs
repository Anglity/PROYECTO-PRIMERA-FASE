using entidad;
using negocio;
using proyecto.utlidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace proyecto
{
    public partial class categorias : Form
    {
        public categorias()
        {
            InitializeComponent();
        }



        private void categorias_Load(object sender, EventArgs e)
        {
            estado2.Items.Add(new opcionescombo() { valor = 1, texto = "Activo" });
            estado2.Items.Add(new opcionescombo() { valor = 0, texto = "No Activo" });
            estado2.DisplayMember = "Texto";
            estado2.ValueMember = "Valor";
            estado2.SelectedIndex = 0;





            foreach (DataGridViewColumn columna in dgdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    busquedacombo.Items.Add(new opcionescombo() { valor = columna.Name, texto = columna.HeaderText });
                }
            }
            busquedacombo.DisplayMember = "Texto";
            busquedacombo.ValueMember = "Valor";
            busquedacombo.SelectedIndex = 0;

            CargarUsuarios(); // Agregamos una llamada para cargar los usuarios en el DataGridView
        }

        private void CargarUsuarios()
        {
            dgdata.Rows.Clear(); // Limpiamos las filas existentes en el DataGridView

            //MOSTRAR TODOS LOS USUARIOS
            List<categoria> lista = new cn_categoria().listar();

            foreach (categoria item in lista)
            {
                string estadoTexto = item.Estado ? "Activo" : "No Activo";
                dgdata.Rows.Add(new object[] {"",item.IdCategoria,
                item.Descripcion,
                estadoTexto // Asignamos directamente el texto "Activo" o "No Activo"
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            categoria obj = new categoria()
            {
                IdCategoria = Convert.ToInt32(txtid.Text),
                Descripcion = xtxdescripcion.Text,
                Estado = Convert.ToInt32(((opcionescombo)estado2.SelectedItem).valor) == 1 ? true : false
            };

            if (obj.IdCategoria == 0)
            {
                int idgenerado = new cn_categoria().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    string estadoTexto = obj.Estado ? "Activo" : "No Activo";
                    dgdata.Rows.Add(new object[] {"",idgenerado,xtxdescripcion.Text,
                        estadoTexto
                    });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }


            }
            else
            {
                bool resultado = new cn_categoria().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Descripcion"].Value = xtxdescripcion.Text;
                    row.Cells["EstadoValor"].Value = ((opcionescombo)estado2.SelectedItem).valor.ToString();
                    row.Cells["Estado"].Value = ((opcionescombo)estado2.SelectedItem).texto.ToString();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }


        }


        private void Limpiar()
        {

            txtindice.Text = "-1";
            txtid.Text = "0";
            xtxdescripcion.Text = "";
            estado2.SelectedIndex = 0;

        }

        private void limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            xtxdescripcion.Text = "";

            estado2.SelectedIndex = 0;
            xtxdescripcion.Select();

        }

        private void dgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.comprobado.Width;
                var h = Properties.Resources.comprobado.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.comprobado, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgdata.Rows[indice].Cells["Id"].Value?.ToString();
                    xtxdescripcion.Text = dgdata.Rows[indice].Cells["Descripcion"].Value?.ToString();

                    string estadoTexto = dgdata.Rows[indice].Cells["Estado"].Value?.ToString();

                    foreach (opcionescombo oc in estado2.Items)
                    {
                        if (Convert.ToInt32(oc.valor) == Convert.ToInt32(dgdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = estado2.Items.IndexOf(oc);
                            estado2.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar la Categoria", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    categoria obj = new categoria()
                    {
                        IdCategoria = Convert.ToInt32(txtid.Text),
                    };
                    bool respuesta = new cn_categoria().Eliminar(obj, out Mensaje);
                    if (respuesta)
                    {
                        dgdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiar();
                    }
                }
            }
        }
        private bool filtrandoEnTiempoReal = false;
        private void btnbusqueda_Click(object sender, EventArgs e)
        {
            // Verificar si ya se está realizando un filtrado en tiempo real
            if (!filtrandoEnTiempoReal)
            {
                filtrandoEnTiempoReal = true;

                string ColumnaFiltro = ((opcionescombo)busquedacombo.SelectedItem).valor.ToString();
                string textoBusqueda = busqueda.Text.Trim().ToUpper();

                if (dgdata.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgdata.Rows)
                    {
                        string valorCelda = row.Cells[ColumnaFiltro].Value.ToString().Trim().ToUpper();

                        // Mostrar la fila si el valor de la celda contiene el texto de búsqueda
                        row.Visible = valorCelda.Contains(textoBusqueda);
                    }
                }

                filtrandoEnTiempoReal = false;
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnlimpiarbuscador_Click_1(object sender, EventArgs e)
        {
            busqueda.Text = "";
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                row.Visible = true;
            }
        }
    }

}

