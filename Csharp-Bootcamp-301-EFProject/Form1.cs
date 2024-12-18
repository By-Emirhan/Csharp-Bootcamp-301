using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Bootcamp_301_EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Csharp_Bootcamp_EF_TravelDBEntities db = new Csharp_Bootcamp_EF_TravelDBEntities();

        #region Entity Framework Listeleme
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }
        #endregion

        #region Entity Framework Ekleme
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Eklendi...");
        }
        #endregion

        #region Entity Framework Silme
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var removeValue = db.Guide.Find(id);
            db.Guide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Silindi...");
        }
        #endregion

        #region Entity Framework Güncelleme
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var updateValue = db.Guide.Find(id);
            updateValue.GuideName= txtName.Text;
            updateValue.GuideSurname= txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi...","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        #endregion

        #region Entity Framework ID'ye Göre Listeleme
        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = db.Guide.Where(x => x.GuideID == id).ToList();
            dataGridView1.DataSource = values;
        }
        #endregion
    }
}
