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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        Csharp_Bootcamp_EF_TravelDBEntities db = new Csharp_Bootcamp_EF_TravelDBEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName=x.GuideName+ " " + x.GuideSurname,
                x.GuideID
            }).ToList();
            CmbGuide.DisplayMember = "FullName";
            CmbGuide.ValueMember= "GuideID";
            CmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(NudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideID = int.Parse(CmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deleteValues = db.Location.Find(id);
            db.Location.Remove(deleteValues);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı...");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var updateValue=db.Location.Find(id);
            updateValue.DayNight = txtDayNight.Text;
            updateValue.Price = decimal.Parse(txtPrice.Text);
            updateValue.Capacity=byte.Parse(NudCapacity.Value.ToString());
            updateValue.City = txtCity.Text;
            updateValue.Country = txtCountry.Text;
            updateValue.GuideID = int.Parse(CmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarılı...");
        }
    }
}
