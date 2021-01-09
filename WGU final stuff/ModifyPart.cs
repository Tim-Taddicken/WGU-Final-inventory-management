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
    public partial class ModifyPart : Form
    {
        public Inventory Inventory { get; set; }
        public BindingList<Part> partsBindingList { get; set; }

        private bool validated;

        public bool GetValidated()
        {
            return validated;
        }

        public void SetValidated(bool value)
        {
            validated = value;
        }

        public ModifyPart(Part part)
        {
            InitializeComponent();
            
            // set initital value of validated to force validation before saving
            validated = false;
            // end validated


            //Hide arrows
            modify_Part_Min_Field.Controls[0].Visible = false;
            modify_Part_Max_Field.Controls[0].Visible = false;
            modify_Part_Price_Field.Controls[0].Visible = false;
            modify_Part_Inventory_Field.Controls[0].Visible = false;
            modify_Part_MachineID_Field.Controls[0].Visible = false;
            //end hide arrows

            // begin inventory validation because we are modifing and there is an existing product
            var inven = modify_Part_Inventory_Field.Value;
            var min = modify_Part_Min_Field.Value;
            var max = modify_Part_Max_Field.Value;
            
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
            //end validation
            //set part fields
            
            if (part is InHouse)
            {
                var temp2 = part as InHouse;
                modify_Part_MachineID_Field.Value = temp2.MachineID;
                modify_Part_Inhouse_Radio.Checked = true;
            } else if (part is Outsourced) {
                var temp = part as Outsourced;
                modify_Part_Outsourced_Radio.Checked = true;
                modify_Part_Companyname_Field.Text = temp.CompanyName;
            }
            modify_Part_Name_Field.Text = part.Name;
            modify_Part_ID_Field.Text = part.PartID.ToString();
            modify_Part_Inventory_Field.Value = part.InStock;
            modify_Part_Price_Field.Value = part.Price;
            modify_Part_Max_Field.Value = part.Max;
            modify_Part_Min_Field.Value = part.Min;
        }

        private void modify_Part_Save_Button_Click(object sender, EventArgs e)
        {
            if (modify_Part_Outsourced_Radio.Checked)
            {
                var part = new Outsourced
                {
                    Name = modify_Part_Name_Field.Text,
                    PartID = Convert.ToInt32(modify_Part_ID_Field.Text),
                    Max = Decimal.ToInt32(modify_Part_Max_Field.Value),
                    Min = Decimal.ToInt32(modify_Part_Min_Field.Value),
                    InStock = Decimal.ToInt32(modify_Part_Inventory_Field.Value),
                    Price = modify_Part_Price_Field.Value,
                    CompanyName = modify_Part_Companyname_Field.Text

                };
               //validation begin
                var inven = modify_Part_Inventory_Field.Value;
                var min = modify_Part_Min_Field.Value;
                var max = modify_Part_Max_Field.Value;
                
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
                if (validated == true)
                {
                    Inventory.updatePart(part.PartID, part);
                    partsBindingList = Inventory.AllParts;
                    this.Close();
                }
                //end validation
            }
            else
            {
                var part = new InHouse
                {
                    Name = modify_Part_Name_Field.Text,
                    PartID = Convert.ToInt32(modify_Part_ID_Field.Text),
                    Max = Decimal.ToInt32(modify_Part_Max_Field.Value),
                    Min = Decimal.ToInt32(modify_Part_Min_Field.Value),
                    InStock = Decimal.ToInt32(modify_Part_Inventory_Field.Value),
                    Price = modify_Part_Price_Field.Value,
                    MachineID = Decimal.ToInt32(modify_Part_MachineID_Field.Value)
                };
                //validation begin
                var inven = modify_Part_Inventory_Field.Value;
                var min = modify_Part_Min_Field.Value;
                var max = modify_Part_Max_Field.Value;

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
                if (validated == true)
                {
                    Inventory.updatePart(part.PartID, part);
                    partsBindingList = Inventory.AllParts;
                    this.Close();
                }
                //end validation
            }
            
        }

            private void modify_Part_Cancel_Button_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void modify_Part_Outsourced_Radio_CheckedChanged(object sender, EventArgs e)
            {
                modify_Part_MachineID_Field.Hide();
                modify_Part_MachineID_Label.Hide();
                modify_Part_Companyname_Field.Show();
                modify_Part_CompanyName_Label.Show();
            }

            private void modify_Part_Inhouse_Radio_CheckedChanged(object sender, EventArgs e)
            {
                modify_Part_MachineID_Field.Show();
                modify_Part_MachineID_Label.Show();
                modify_Part_Companyname_Field.Hide();
                modify_Part_CompanyName_Label.Hide();

            }

        private void Inventory_Validation_label_Click(object sender, EventArgs e)
        {
           

        }

        private void modify_Part_Inventory_Field_ValueChanged(object sender, EventArgs e)
        {
            var inven = modify_Part_Inventory_Field.Value;
            var min = modify_Part_Min_Field.Value;
            var max = modify_Part_Max_Field.Value;
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

        private void modify_Part_Max_Field_ValueChanged(object sender, EventArgs e)
        {
            var inven = modify_Part_Inventory_Field.Value;
            var min = modify_Part_Min_Field.Value;
            var max = modify_Part_Max_Field.Value;
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

        private void modify_Part_Min_Field_ValueChanged(object sender, EventArgs e)
        {
            var inven = modify_Part_Inventory_Field.Value;
            var min = modify_Part_Min_Field.Value;
            var max = modify_Part_Max_Field.Value;
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
