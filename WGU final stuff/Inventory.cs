using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WGU_final_stuff
{
    public class Inventory
    {
        public BindingList<Product> Products { get; set; }
        public BindingList<Part> AllParts { get; set; }

        public void addProduct(Product product) {
            if (product.ProductID == 0 && Products.Count() > 0)
            {
                int tempid = Products.OrderBy(x => x.ProductID).Last().ProductID;
                product.ProductID = ++tempid;
                Products.Add(product);
            } else if (Products.Count() > 0 || product.ProductID != 0) {
                Products.Add(product);
            } else if (Products.Count() == 0)
            {
                product.ProductID = 1;
                Products.Add(product);
            }
            
        }
        public bool removeProduct(int id) {
            var productToDelete = Products.SingleOrDefault(x => x.ProductID == id);
            if (productToDelete != null && productToDelete.AssociatedParts.Count() == 0)
            {
                    Products.Remove(productToDelete);
                    return true;
            } else
              {
                 MessageBox.Show(" Please remove associated parts from the selected product prior to deletion." +
                     " These parts can be found and removed on the Modify page");
                return false;
                    
              }
            
        }
        public Product lookupProduct(int id) {
            return Products.Single(x => x.ProductID == id);
        }
        public void updateProduct(int id, Product product) {
            Products.Remove(Products.FirstOrDefault(x => x.ProductID == id));
            
            addProduct(product);
        }
        public void addPart(Part part) {
            var id = AllParts.Any()? AllParts.OrderBy(x => x.PartID).Last().PartID : 0;
            part.PartID = ++id;
            AllParts.Add(part);
        }
        public bool deletePart(Part part) {
            if (part != null)
            {
                AllParts.Remove(part);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Part lookUpPart(int id) {
            return AllParts.Single(x => x.PartID == id);
        }
        public void updatePart(int id, Part part) {
            deletePart(lookUpPart(id));
            AllParts.Add(part);
        }

    }
}
