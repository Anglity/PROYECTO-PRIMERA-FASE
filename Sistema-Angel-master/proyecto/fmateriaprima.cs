using entidad;
using negocio;
using proyecto.utlidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace proyecto
{
    public partial class fmateriaprima : Form
    {
        public fmateriaprima()
        {
            InitializeComponent();
        }

        private void fmateriaprima_Load(object sender, EventArgs e)
        {
            estado2.Items.Add(new opcionescombo() { valor = 1, texto = "Disponible" });
            estado2.Items.Add(new opcionescombo() { valor = 0, texto = "No disponible" });
            estado2.DisplayMember = "Texto";
            estado2.ValueMember = "Valor";
            estado2.SelectedIndex = 0;

            unidadMedida2.Items.Add(new opcionescombo() { valor = "Libra", texto = "Libra" });
            unidadMedida2.Items.Add(new opcionescombo() { valor = "Litro", texto = "Litro" });
            unidadMedida2.Items.Add(new opcionescombo() { valor = "Saco", texto = "Saco" });
            unidadMedida2.Items.Add(new opcionescombo() { valor = "Cubeta", texto = "Cubeta" });
            unidadMedida2.DisplayMember = "Texto";
            unidadMedida2.ValueMember = "Valor";
            unidadMedida2.SelectedIndex = 0;



            List<categoria> listacategoria = new cn_categoria().listar();

            foreach (categoria item in listacategoria)
            {
                categoria2.Items.Add(new opcionescombo() { valor = item.IdCategoria, texto = item.Descripcion });
            }
            categoria2.DisplayMember = "Texto";
            categoria2.ValueMember = "Valor";
            categoria2.SelectedIndex = 0;

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

            CargarMateriaPrima(); // Agregamos una llamada para cargar los usuarios en el DataGridView
        }

        private void CargarMateriaPrima()
        {
            dgdata.Rows.Clear();  // Limpiamos las filas existentes en el DataGridView

            // MOSTRAR TODAS LAS MATERIAS PRIMAS
            List<materiaprima> lista = new cn_materiaprima().listar(); // Asumiendo que tienes una clase similar a cn_producto pero para materiaprima

            foreach (materiaprima item in lista)
            {

                dgdata.Rows.Add(new object[] {
            item.IdMateriaPrima,
            item.Codigo,
            item.Nombre,
            item.Proveedor,
            item.CantidadEnStock,
            item.UnidadDeMedida,
            item.CostoPorUnidad,
            item.FechaRegistro
        });
            }
        }
    }
}
