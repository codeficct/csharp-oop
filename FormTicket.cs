using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 *  Author: Luis Gabriel Janco
 *  description: Object Oriented Programming - basic concepts
 */
namespace csharp_learn
{
    public partial class FormTicket : Form
    {
        // Global variables
        static int uuid;
        ListViewItem item;
        // Objeto de la clase Ticket
        Ticket objTicket = new Ticket();

        public FormTicket()
        {
            InitializeComponent();
        }

        private void FormTicket_Load(object sender, EventArgs e)
        {
            idTicket.Text = generateTicketId();
            currentDate.Text = DateTime.Now.ToShortDateString();
            cboProduct.Text = "(Seleccione)";
            cboProduct.Items.Add("PS4 + 1 MANDO DS4");
            cboProduct.Items.Add("PS4 + 2 MANDO DS4");
            cboProduct.Items.Add("PS3 (500GB)");
            cboProduct.Items.Add("MANDO PS4/DS4");
            cboProduct.Items.Add("MANDO PS3/DS4");
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            objTicket.product = cboProduct.Text;
            unitPrice.Text = objTicket.determinePrice().ToString("c");

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            try
            {
                captureData();
                validate();
                double price = objTicket.determinePrice();
                double totalPrice = objTicket.calculateTotalPrice();
                setDetails(price, totalPrice);
                labelTotalPrice.Text = totalPriceTicket().ToString("c");
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    error.Message, "Datos incorrectos o faltantes.",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                );
            }
        }

        private void registerTicket_Click(object sender, EventArgs e)
        {
            ListViewItem row = new ListViewItem(
                "2022-" + (int.Parse(idTicket.Text).ToString("00000"))
            );
            row.SubItems.Add(currentDate.Text);
            row.SubItems.Add(totalProductCount().ToString("0.00"));
            row.SubItems.Add(getTotalPriceAllTickets().ToString("C"));
            row.SubItems.Add(currentDate.Text);
            listStatistics.Items.Add(row);
            cleanControls();
        }

        // Methods
        Func<string> generateTicketId = () =>
        {
            uuid++;
            return uuid.ToString("00000");
        };

        void captureData()
        {
            objTicket.client = textClientName.Text;
            objTicket.dni = int.Parse(textDni.Text);
            objTicket.id = int.Parse(idTicket.Text);
            objTicket.phone = int.Parse(textPhone.Text);
            objTicket.product = cboProduct.Text;
            objTicket.productCount = Decimal.ToInt32(productCount.Value);
            objTicket.date = DateTime.Parse(currentDate.Text);
        }

        void validate()
        {
            Func<TextBox, bool> textBoxIsEmpty = (element) =>
            {
                return element.Text.Trim().Length == 0;
            };

            string clientError = "Datos del Cliente: ";
            string ProductError = "Datos del Producto: ";

            if (textBoxIsEmpty(textClientName))
                throw new ArgumentException(clientError + "Ingresa el nombre del cliente."); textClientName.Focus();
            if (textBoxIsEmpty(textPhone))
                throw new ArgumentException(clientError + "Ingresa el número de telefono.");
            if (textBoxIsEmpty(textDni))
                throw new ArgumentException(clientError + "Ingresa el DNI del cliente.");
            if (cboProduct.SelectedIndex == -1)
                throw new ArgumentException(ProductError + "Selecciona un producto.");
        }

        void setDetails(double price, double totalPrice)
        {
            ListViewItem row = new ListViewItem(objTicket.productCount.ToString());
            row.SubItems.Add(objTicket.product);
            row.SubItems.Add(price.ToString("0.00"));
            row.SubItems.Add(totalPrice.ToString("0.00"));
            listDetails.Items.Add(row);
        }

        double totalPriceTicket()
        {
            double total = 0;

            int detailItemsCount = listDetails.Items.Count;
            for (int i = 0; i < detailItemsCount; i++)
            {
                total += double.Parse(listDetails.Items[i].SubItems[3].Text);
            }
            return total;
        }

        int totalProductCount()
        {
            int total = 0;
            int detailItemsCount = listDetails.Items.Count;
            for (int i = 0; i < detailItemsCount; i++)
            {
                total += int.Parse(listDetails.Items[i].SubItems[0].Text);
            }
            return total;
        }

        double getTotalPriceAllTickets()
        {
            double accumulated = 0;
            int detailItemsCount = listDetails.Items.Count;
            for (int i = 0; i < detailItemsCount; i++)
            {
                accumulated += double.Parse(listDetails.Items[i].SubItems[3].Text);
            }
            return accumulated;
        }

        void cleanControls()
        {
            idTicket.Text = generateTicketId();
            textClientName.Clear();
            textDni.Clear();
            textPhone.Clear();
            cboProduct.Text = "(Seleccione)";
            productCount.Value = 1;
            unitPrice.Text = "Bs. 0.00";
            listDetails.Items.Clear();
        }
    }
}
