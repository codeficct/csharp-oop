using System;
using System.Windows.Forms;
/*
 *  Author: Luis Gabriel Janco
 *  description: This example is a basic intro of c#
*/
namespace csharp_learn{
    public partial class ManageUsers : Form {
        // Global variable
        double salary = 0.0;

        public ManageUsers() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            labelDate.Text = DateTime.Today.ToString("d");
        }

        private void buttonRegistrar_Click(object sender, EventArgs e) {
            string employee = textEmployee.Text;
            string category = comboCategory.Text;

            try {
                if (employee == "") throw new ArgumentException("Ingrese el nombre del empleado.");
                if (category == "(Seleccione)") throw new ArgumentException("Por favor seleccione una categoria.");

                double discount = 0.0;

                if (salary > 2000) discount = salary * (12.5 / 100);
                double netIncome = salary - discount;
                ListViewItem row = new ListViewItem(employee);
                row.SubItems.Add(category);
                row.SubItems.Add(salary.ToString("c"));
                row.SubItems.Add(discount.ToString("c"));
                row.SubItems.Add(netIncome.ToString("c"));
                listViewPayments.Items.Add(row);
                // Reset inputs
                buttonCancel_Click(sender, e);
            }
            catch (Exception error) {
                MessageBox.Show(
                    error.Message,
                    "Datos incorrectos o faltantes.",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                );
            }
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e) {
            string category = comboCategory.Text;

            if (category == "Jefe") salary = 3500;
            if (category == "Administrativo") salary = 2500;
            if (category == "Tecnico") salary = 1700;
            if (category == "Operario") salary = 1000;

            labelSalary.Text = salary.ToString("c");
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            comboCategory.Text = "(Seleccione)";
            labelSalary.Text = "Bs. 0.00";
            textEmployee.Clear();
            textEmployee.Focus();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            DialogResult r = MessageBox.Show(
                "¿Esta seguro que quiere salir?", "Pago",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation
            );
            if (r == DialogResult.Yes) this.Close();
        }
    }
}
