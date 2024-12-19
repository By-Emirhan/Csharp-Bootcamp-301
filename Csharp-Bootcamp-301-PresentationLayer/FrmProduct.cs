using Csharp_Bootcamp_301_BusinessLayer.Abstract;
using Csharp_Bootcamp_301_BusinessLayer.Concrete;
using Csharp_Bootcamp_301_DataAccessLayer.EntityFramework;
using Csharp_Bootcamp_301_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Bootcamp_301_PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            cmbCategory.DataSource = values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember= "CategoryID";
            cmbCategory.SelectedIndex = -1;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }
        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName = txtProductName.Text;
            product.ProductStock = int.Parse(txtProductStock.Text);
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.CategoryID = int.Parse(cmbCategory.SelectedIndex.ToString());
            product.ProductDescription = txtDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Ekleme İşlemi Başarılı...");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtID.Text);
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            MessageBox.Show("Silme İşlemi Başarılı...");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtID.Text);
            var values = _productService.TGetById(id);
            values.ProductName = txtProductName.Text;
            values.ProductStock = int.Parse(txtProductStock.Text);
            values.ProductPrice = decimal.Parse(txtProductPrice.Text);
            values.CategoryID = int.Parse(cmbCategory.SelectedIndex.ToString());
            values.ProductDescription = txtDescription.Text;
            _productService.TUpdate(values);
            MessageBox.Show("Güncelleme İşlemi Başarılı...");
        }
    }
}
