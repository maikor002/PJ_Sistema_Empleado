using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Empleado
{
    public partial class Form1 : Form
    {
        /* TODO Lista de empleados con enlace de datos automático para que el DataGridView 
        se actualice automáticamente cuando se agregan o eliminan empleados*/
        private BindingList<Empleado> empleados = new BindingList<Empleado>();

        public Form1()
        {
            InitializeComponent();

            //TODO Esto es para Asignar la lista de empleados al DataGridView
            dgv_Empleados.DataSource = empleados;

            //TODO Esto es para Manejar errores en el DataGridView
            dgv_Empleados.DataError += dgv_Empleados_DataError;
        }
        private void dgv_Empleados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Se ha producido un error de formato en la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false; //TODO Esto Evita que el programa se cierre por el error
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ActualizarDataGrid()
        {
            dgv_Empleados.DataSource = null;  //TODO Esto es para Limpiar la fuente de datos
            dgv_Empleados.DataSource = empleados;  //TODO Esto Vuelve a asignar la lista actualizada
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string nombre = txt_Nombre.Text.Trim();
            string apellido = txt_Apellido.Text.Trim();
            int edad;
            decimal salario;

            //TODO Para Validar que los campos de texto no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //TODO Para Validar que el usuario haya seleccionado un cargo
            if (cmb_Cargo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cargo = cmb_Cargo.SelectedItem.ToString();

            //TODO para Validar que la edad sea un número válido
            if (!int.TryParse(txt_Edad.Text, out edad) || edad <= 0)
            {
                MessageBox.Show("Ingrese una edad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //TODO Para Validar que el salario sea un número válido
            if (!decimal.TryParse(txt_Salario.Text, out salario) || salario <= 0)
            {
                MessageBox.Show("Ingrese un salario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }//TODO Para Validar que la edad sea un número válido
            if (!int.TryParse(txt_Edad.Text, out edad) || edad <= 0)
            {
                MessageBox.Show("Ingrese una edad válida (solo números enteros positivos).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //TODO Para Validar que el salario sea un número válido
            if (!decimal.TryParse(txt_Salario.Text, out salario) || salario <= 0)
            {
                MessageBox.Show("Ingrese un salario válido (solo números positivos).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //TODO Para Crear un nuevo empleado según el tipo seleccionado en el ComboBox
            Empleado nuevoEmpleado;
            if (cargo == "Administrativo")
                nuevoEmpleado = new Administrativo(nombre, apellido, edad, salario);
            else
                nuevoEmpleado = new Tecnico(nombre, apellido, edad, salario);

            //TODO Para Agregar a la lista y actualizar el DataGridView
            empleados.Add(nuevoEmpleado);
            ActualizarDataGrid();

            //TODO Para Limpiar los campos después de registrar
            txt_Nombre.Clear();
            txt_Apellido.Clear();
            txt_Edad.Clear();
            txt_Salario.Clear();
            cmb_Cargo.SelectedIndex = -1;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            //TODO Para Verificar si la lista está vacía
            if (empleados.Count == 0)
            {
                MessageBox.Show("No hay empleados para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //TODO Para Verificar si hay un empleado seleccionado
            if (dgv_Empleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //TODO Para Obtener el índice del empleado seleccionado
            int indice = dgv_Empleados.SelectedRows[0].Index;

            //TODO Para Eliminar el empleado de la lista
            empleados.RemoveAt(indice);

            //TODO Para Actualizar el DataGridView
            ActualizarDataGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO Para Agregar opciones al ComboBox al iniciar el formulario
            cmb_Cargo.Items.Clear(); // Limpiar para evitar duplicados
            cmb_Cargo.Items.Add("Administrativo");
            cmb_Cargo.Items.Add("Técnico");

            //TODO Para Evitar que el usuario escriba en el ComboBox
            cmb_Cargo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

       
    }
}
