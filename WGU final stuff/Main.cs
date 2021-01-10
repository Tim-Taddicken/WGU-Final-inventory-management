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
        public BindingList<Product> filteredBindingList { get; set; }
        public BindingList<Part> partsBindingList { get; set; }
        public Main()
        {
            Inventory = new Inventory { Products = new BindingList<Product>(), AllParts = new BindingList<Part>() };
            filteredBindingList = new BindingList<Product>();
            partsBindingList = new BindingList<Part>();
            InitializeComponent();


        }
        //public BindingList<Product> GetProducts()
        //{
        //    BindingList<Product> list = new BindingList<Product>();
        //    list.Add(new Product()
        //    {
        //        ProductID = 1,
        //        Name = "can",
        //        Price = 1,
        //        InStock = 5,
        //        Min = 3,
        //        Max = 4,
        //        AssociatedParts = new BindingList<Part>()
        //    });
        //    list.Add(new Product()
        //    {
        //        ProductID = 2,
        //        Name = "sample",
        //        Price = 2,
        //        InStock = 5,
        //        Min = 3,
        //        Max = 4,
        //        AssociatedParts = new BindingList<Part>()
        //    });
        //    list.Add(new Product()
        //    {
        //        ProductID = 3,
        //        Name = "timesucker",
        //        Price = 5,
        //        InStock = 5,
        //        Min = 3,
        //        Max = 4,
        //        AssociatedParts = new BindingList<Part>()
        //    });
        //    list.Add(new Product()
        //    {
        //        ProductID = 4,
        //        Name = "uselessgoo",
        //        Price = 3,
        //        InStock = 5,
        //        Min = 3,
        //        Max = 4,
        //        AssociatedParts = new BindingList<Part>()
        //    });
        //    return list;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new AddPart();
            form2.Inventory = Inventory;
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parts_bindings.DataSource = Inventory.AllParts;
            partsBindingList = Inventory.AllParts;
            filteredBindingList = Inventory.Products;
            partsGridView.DataSource = partsBindingList;
            productsGridView1.DataSource = filteredBindingList;
        }

        private void modifyPartButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0)
            {

                var tempCheck = partsGridView.SelectedRows[0].DataBoundItem as Part;
                var original = Inventory.lookUpPart(tempCheck.PartID);
                if (original is InHouse)
                {
                    var selectedRow = partsGridView.SelectedRows[0].DataBoundItem as InHouse;
                    var modify = new ModifyPart(selectedRow);
                    modify.Inventory = Inventory;
                    partsBindingList = Inventory.AllParts;
                    partsGridView.Update();
                    partsGridView.Refresh();
                    modify.ShowDialog();
                }
                else
                {
                    var selectedRow = partsGridView.SelectedRows[0].DataBoundItem as Outsourced;
                    var modify = new ModifyPart(selectedRow);
                    modify.Inventory = Inventory;
                    partsBindingList = Inventory.AllParts;
                    partsGridView.Update();
                    partsGridView.Refresh();
                    modify.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Please Select Part first, then select modify");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addProductButton_Click(object sender, EventArgs e)
        {

            var form2 = new Form1();
            form2.Inventory = Inventory;
            form2.filteredBindingList = filteredBindingList;
            form2.SetViewParts();
            form2.ShowDialog();
            filteredBindingList = Inventory.Products;
            productsGridView1.Update();
            productsGridView1.Refresh();
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
            if (productsGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this product?",
                   "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var selectedRow = productsGridView1.SelectedRows[0].DataBoundItem as Product;

                    Inventory.removeProduct(selectedRow.ProductID);
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("no product selected for deletion");
            }
        }

        private void deletePartButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this part?",
                   "", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var selectedRow = partsGridView.SelectedRows[0].DataBoundItem as Part;
                    Inventory.deletePart(selectedRow);
                }
                else
                {
                }
                
            }
            else
            {
                MessageBox.Show("Please select a part and try again or select add for new");
            }
        }

        private void modifyProductButton_Click(object sender, EventArgs e)
        {
            if (productsGridView1.SelectedRows.Count > 0)
            {

                var form2 = new Form1();
                form2.Inventory = Inventory;
                form2.SetViewParts();
                form2.ModifyProduct(productsGridView1.SelectedRows[0].DataBoundItem as Product);
                form2.ShowDialog();
                return;
            }
            MessageBox.Show("Please select a product and try again or select add for new");

        }

        public void productSearchBox_TextChanged(object sender, EventArgs e)
        {

            var filteredanswers = Inventory.Products.Where(x => x.Name.Contains(productSearchBox.Text)).ToList();
            filteredBindingList = new BindingList<Product> { };
            foreach (var Product in filteredanswers)
            {
                filteredBindingList.Add(Product);

            }
            productsGridView1.DataSource = filteredBindingList;
        }

        private void partSearchBox_TextChanged(object sender, EventArgs e)
        {
            var filteredanswers = Inventory.AllParts.Where(x => x.Name.Contains(partSearchBox.Text)).ToList();
            partsBindingList = new BindingList<Part> { };
            foreach (var part in filteredanswers)
            {
                partsBindingList.Add(part);

            }
            partsGridView.DataSource = partsBindingList;
        }
    }

}
