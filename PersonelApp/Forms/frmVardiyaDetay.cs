using PersonelApp.DTO;
using PersonelApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelApp.Forms
{
    public partial class frmVardiyaDetay : Form
    {
        public frmVardiyaDetay()
        {
            InitializeComponent();
        }

        private void frmVardiyaDetay_Load(object sender, EventArgs e)
        {
            PersonelContext ctx = new PersonelContext();
            DateTime date = Convert.ToDateTime(this.Tag);
            dataGridView1.DataSource = ctx.Seizures.Where(x => x.SeizuresDate.Value.Date == date.Date).ToList();
            dataGridView1.DataSource = ctx.Seizures.Select(x => new VardiyaDetailDTO
            {

                SeizuresDate = x.SeizuresDate,
                SeizuresStartDate =x.SeizuresStartDate,
                Name=x.User.Name+" "+x.User.Surname,
                SeizuresEndDate=x.SeizuresEndDate,
                Id=x.Id,
                Location=x.Location

            }).ToList();
            dataGridView1.Columns.Remove("UserId");
        }
    }
}
