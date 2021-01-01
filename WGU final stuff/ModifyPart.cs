﻿using System;
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
        public ModifyPart(Part part)
        {
            InitializeComponent();
            modify_Part_Name_Field.Text = part.Name;
            modify_Part_ID_Field.Text = part.PartID.ToString();
            modify_Part_Inventory_Field.Value = part.InStock;
            modify_Part_Price_Field.Value = part.Price;
            modify_Part_Max_Field.Value = part.Max;
            modify_Part_Min_Field.Value = part.Min;

            if (modify_Part_Outsourced_Radio.Checked)
            {
                var temp = part as Outsourced;
                modify_Part_Companyname_Field.Text = temp.CompanyName;

            }
            else if (modify_Part_Inhouse_Radio.Checked)
            {
                var temp2 = part as InHouse; 
                modify_Part_MachineID_Field.Value = temp2.MachineID;
            }
            
        }

        private void modify_Part_Save_Button_Click(object sender, EventArgs e)
        {
            var part = new Outsourced
            {
                Name = modify_Part_Name_Field.Text, PartID = Convert.ToInt32(modify_Part_ID_Field.Text),
            };
            Inventory.updatePart(part.PartID, part);
            this.Close();
        }

        private void modify_Part_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
