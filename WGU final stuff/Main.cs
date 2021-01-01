using Microsoft.Build.Framework;
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
    public partial class Main : Form
    {
        
        public Inventory Inventory { get; set; }
         
        public Main()
        {
            Inventory = new Inventory { Products = GetProducts(),AllParts= new BindingList<Part>()};
            InitializeComponent();
            

        }
        public BindingList<Product> GetProducts()
        {
            BindingList<Product> list = new BindingList<Product>();
            list.Add(new Product()
            {
                ProductID = 1,
                Name = "canogoo",
                Price = 1,
                InStock = 5,
                Min = 3,
                Max = 4
            });
            list.Add(new Product()
            {
                ProductID = 2,
                Name = "sample",
                Price = 2,
                InStock = 5,
                Min = 3,
                Max = 4
            });
            list.Add(new Product()
            {
                ProductID = 3,
                Name = "timesucker",
                Price = 5,
                InStock = 5,
                Min = 3,
                Max = 4
            });
            list.Add(new Product()
            {
                ProductID = 4,
                Name = "uselessgoo",
                Price = 3,
                InStock = 5,
                Min = 3,
                Max = 4
            });
            return list;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new AddPart();
            form2.Inventory = Inventory;
  
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parts_bindings.DataSource = Inventory.AllParts;
            productsGridView1.DataSource = Inventory.Products;
            partsGridView.DataSource = parts_bindings;
            
        }

        private void modifyPartButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0) {
            var selectedRow = partsGridView.SelectedRows[0].DataBoundItem as Part;
            var modify = new ModifyPart(selectedRow);
         //   var selectedRows = partsGridView.SelectedRows[0];
            modify.Inventory = Inventory;

            modify.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            var selectedRow = productsGridView1.SelectedRows[0].DataBoundItem as Product;
            try
            {
                Inventory.removeProduct(selectedRow.ProductID);
            }
            catch (InvalidCastException f)
            {

                throw new Exception("this is what i got ", f);
            }
            
        }

        private void deletePartButton_Click(object sender, EventArgs e)
        {
            var selectedRow = partsGridView.SelectedRows[0].DataBoundItem as Part;
            Inventory.deletePart(selectedRow);
        }
    }

}
