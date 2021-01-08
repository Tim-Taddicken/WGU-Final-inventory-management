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

        private bool validated;
        public bool GetValidated()
        {
            return validated;
        }
        public void SetValidated(bool value)
        {
            validated = value;
        }
        public AddPart()
        {
            InitializeComponent();
            //Hide arrows
            add_Part_Max_Field.Controls[0].Visible = false;
            add_Part_Min_Field.Controls[0].Visible = false;
            add_Part_Price_Field.Controls[0].Visible = false;
            add_Part_Inventory_Field.Controls[0].Visible = false;
            add_Part_Inhouse_Field.Controls[0].Visible = false;
            //end/hide arrows

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
                if (validated == true)
                {                
                    Inventory.addPart(new InHouse
                    {
                        Name = add_Part_Name_Field.Text,
                        Min = (int)add_Part_Min_Field.Value,
                        Max = (int)add_Part_Max_Field.Value,
                        InStock = (int)add_Part_Inventory_Field.Value,
                        Price = add_Part_Price_Field.Value,
                        MachineID = (int)add_Part_Inhouse_Field.Value
                    });
                    Close();
                }
            }
            else {
                if (validated == true)
                {
                    Inventory.addPart(new Outsourced
                    {
                        Name = add_Part_Name_Field.Text,
                        Min = (int)add_Part_Min_Field.Value,
                        Max = (int)add_Part_Max_Field.Value,
                        InStock = (int)add_Part_Inventory_Field.Value,
                        Price = add_Part_Price_Field.Value,
                        CompanyName = add_Part_Outsourced_Field.Text
                    });
                    Close();
                }
            }
            
        }

        private void add_Part_Inventory_Field_ValueChanged(object sender, EventArgs e)
        {
            var inven = add_Part_Inventory_Field.Value;
            var min = add_Part_Min_Field.Value;
            var max = add_Part_Max_Field.Value;
            if (inven < min || inven > max)
            {
                Inventory_Validation_label.Show();
                validated = false;

            }
            if (inven >= min && inven <= max)
            {
                Inventory_Validation_label.Hide();
                validated = true;
            }
        }

        private void add_Part_Max_Field_ValueChanged(object sender, EventArgs e)
        {
            var inven = add_Part_Inventory_Field.Value;
            var min = add_Part_Min_Field.Value;
            var max = add_Part_Max_Field.Value;
            if (inven < min || inven > max)
            {
                Inventory_Validation_label.Show();
                validated = false;

            }
            if (inven >= min && inven <= max)
            {
                Inventory_Validation_label.Hide();
                validated = true;
            }
        }

        private void add_Part_Min_Field_ValueChanged(object sender, EventArgs e)
        {
            var inven = add_Part_Inventory_Field.Value;
            var min = add_Part_Min_Field.Value;
            var max = add_Part_Max_Field.Value;
            if (inven < min || inven > max)
            {
                Inventory_Validation_label.Show();
                validated = false;

            }
            if (inven >= min && inven <= max)
            {
                Inventory_Validation_label.Hide();
                validated = true;
            }
        }
    }
}
