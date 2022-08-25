using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 *  Author: Luis Gabriel Janco
 *  Object Oriented Programming
 */

namespace csharp_learn {
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            ManageUsers windowUsers = new ManageUsers();
            windowUsers.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) {
            FormTicket windowTicket = new FormTicket();
            windowTicket.ShowDialog();
        }
    }
}
