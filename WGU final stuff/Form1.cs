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
    public partial class Form1 : Form
    {
        public Inventory Inventory { get; set; }
 //       public DataGridView DataGridView1 = new DataGridView();
        
        public Form1()
        {
            Inventory = new Inventory { Products = GetProducts(),AllParts= new List<Part>()};
            InitializeComponent();
            

        }
        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();
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
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = Inventory.Products;
        }

        private void modifyPartButton_Click(object sender, EventArgs e)
        {
            if (Inventory.Products != null) { 
            StringBuilder sb = new StringBuilder();

            foreach (var item in Inventory.Products)
            {
                sb.AppendLine(item.Name.ToString());
            }
            MessageBox.Show(sb.ToString());
            }
            else
            {
                MessageBox.Show("You Lost your List");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }

}
