using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Bootcamp_301_EFProject
{
    public partial class FrmStatistic : Form
    {
        public FrmStatistic()
        {
            InitializeComponent();
        }

        Csharp_Bootcamp_EF_TravelDBEntities db = new Csharp_Bootcamp_EF_TravelDBEntities();
        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(s => s.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(a => a.Capacity).ToString();
            lblAvgPrice.Text = db.Location.Average(a=>a.Price).ToString();
            int lastCountryName = db.Location.Max(m => m.LocationID);
            lblLastCountryName.Text = db.Location.Where(w => w.LocationID == lastCountryName).Select(s => s.Country).FirstOrDefault();
            lblVenedicTravelCapacity.Text = db.Location.Where(w => w.City == "Venedik").Select(s => s.Capacity).FirstOrDefault().ToString();
            lblAvgTurkiyeTravelCapacity.Text = db.Location.Where(w => w.Country == "Türkiye").Average(a => a.Capacity).ToString();

            var venedicGuideId = db.Location.Where(w=>w.City=="Venedik").Select(s=>s.GuideID).FirstOrDefault();
            lblVenedicTravelGuideName.Text = db.Guide.Where(w => w.GuideID == venedicGuideId).Select(s => s.GuideName + " " + s.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(m => m.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(w => w.Capacity == maxCapacity).Select(s => s.Country + " " + s.Capacity).FirstOrDefault().ToString();

            var maxPriceTravel = db.Location.Max(m => m.Price);
            lblMaxPriceTravel.Text = db.Location.Where(w => w.Price == maxPriceTravel).Select(s => s.City + " " + s.Price).FirstOrDefault().ToString();

            var travelCountAylinBaharlioglu = db.Guide.Where(w => w.GuideName == "Aylin" && w.GuideSurname == "Baharlıoğlu").Select(s => s.GuideID).FirstOrDefault();
            lblAylinBaharliogluTravelCount.Text = db.Location.Where(w => w.GuideID == travelCountAylinBaharlioglu).Count().ToString();
        }
    }
}
