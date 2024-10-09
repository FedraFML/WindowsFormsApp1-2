using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.algoritmo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Paso 0: Verificar si los campos están vacíos
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingrese valores válidos en todos los campos.");
                return;
            }

            // Paso 1: Inicializar los parámetros mínimo, máximo y valor muestra
            int valorMinimo = Convert.ToInt32(textBox1.Text); // Mínimo
            int valorMaximo = Convert.ToInt32(textBox2.Text); // Máximo
            int valorMuestra = Convert.ToInt32(textBox3.Text); // Valor Muestra

            // Verificar que el valor máximo sea mayor que el mínimo
            if (valorMaximo <= valorMinimo)
            {
                MessageBox.Show("El valor máximo debe ser mayor que el valor mínimo.");
                return;
            }

            // Paso 2: Crear instancia de la clase AlgoritmoSimulacion
            AlgoritmoSimulacion algoritmo = new AlgoritmoSimulacion();

            // Paso 3: Llamar al método principal del algoritmo para generar valores dentro del rango
            List<int> listaEnteros = algoritmo.GenerarValores(valorMinimo, valorMaximo, valorMuestra);

            // Paso 4: Llenar el grid con los valores generados
            llenarGrid(listaEnteros);
        }

        public void llenarGrid(List<int> lista)
        {
            // Paso 0: Limpiar columnas previas
            dataGridView1.Columns.Clear();

            // Paso 1: Añadir columnas de Id y Valor
            dataGridView1.Columns.Add("1", "Id");
            dataGridView1.Columns.Add("2", "Valor");

            // Paso 2: Rellenar el DataGridView con los valores generados
            dataGridView1.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString(); // Id
                dataGridView1.Rows[i].Cells[1].Value = lista[i].ToString(); // Valor
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar el DataGridView cuando se carga el formulario (opcional)
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("1", "Id");
            dataGridView1.Columns.Add("2", "Valor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Esta sección la puedes usar para exportar a Excel si lo necesitas
            DescargaExcel(dataGridView1);
        }

        public void DescargaExcel(DataGridView data)
        {
            // Paso 0: Instalar componente de Excel
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;

            // Paso 1: Añadir las cabeceras de las columnas
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }

            // Paso 2: Añadir los datos
            int indiceFila = 0;
            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFila + 1, indiceColumna] = fila.Cells[columna.Index].Value;
                }
            }

            // Paso 3: Hacer visible el archivo de Excel
            exportarExcel.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Puedes agregar algún evento en caso de usar etiquetas
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Puedes manejar eventos para cambios en el texto si es necesario
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
