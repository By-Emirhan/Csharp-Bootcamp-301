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
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            if (rdbAktif.Checked == true && rdbPasif.Checked == false)
            {
                category.CategoryStatus = true;
            }
            else
            {
                category.CategoryStatus = false;
            }
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme Başarılı...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme İşlemi Başarılı...");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var value = _categoryService.TGetAll().Where(w => w.CategoryID == id).ToList();
            dataGridView1.DataSource = value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var updatedValue = _categoryService.TGetById(id);
            updatedValue.CategoryName = txtCategoryName.Text;
            if (rdbAktif.Checked == true && rdbPasif.Checked == false)
            {
                updatedValue.CategoryStatus = true;
            }
            else
            {
                updatedValue.CategoryStatus = false;
            }
            _categoryService.TUpdate(updatedValue);
            MessageBox.Show("Güncellendi...");
        }
    }
}
