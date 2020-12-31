using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WGU_final_stuff
{
    public partial class AddPart : Form
    {
        public Inventory Inventory { get; set; }
        public AddPart()
        {
            InitializeComponent();
            
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void inhouse_radio_CheckedChanged(object sender, EventArgs e)
        {
            inhouse_label.Show();
            outsourced_label.Hide();
            add_Part_Inhouse_Field.Show();
            add_Part_Outsourced_Field.Hide();
           
        }

        private void outsourced_radio_CheckedChanged(object sender, EventArgs e)
        {
            inhouse_label.Hide();
            add_Part_Inhouse_Field.Hide();
            outsourced_label.Show();
            add_Part_Outsourced_Field.Show();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (inhouse_radio.Checked) { 
            Inventory.addPart(new InHouse { 
                Name = add_Part_Name_Field.Text, Min = (int)add_Part_Min_Field.Value, Max = (int)add_Part_Max_Field.Value, 
                InStock = (int)add_Part_Inventory_Field.Value, Price = add_Product_Price_Field.Value, MachineID = (int)add_Part_Inhouse_Field.Value});
            }
            else { 
            Inventory.addPart(new Outsourced { Name = add_Part_Name_Field.Text, Min = (int)add_Part_Min_Field.Value, 
                Max = (int)add_Part_Max_Field.Value, InStock = (int)add_Part_Inventory_Field.Value, Price = add_Product_Price_Field.Value, 
                CompanyName = add_Part_Outsourced_Field.Text });
            }
            this.Close();
        }
    }
}
