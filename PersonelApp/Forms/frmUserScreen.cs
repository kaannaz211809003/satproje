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
    public partial class frmUserScreen : Form
    {
        public frmUserScreen()
        {
            InitializeComponent();
        }

        private void frmUserScreen_Load(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Tag);
            PersonelContext ctx = new PersonelContext();
            dataGridView1.DataSource = ctx.Seizures.Select(x => new VardiyaDetailDTO
            {

                SeizuresDate = x.SeizuresDate,
                SeizuresStartDate = x.SeizuresStartDate,
                Name = x.User.Name + " " + x.User.Surname,
                SeizuresEndDate = x.SeizuresEndDate,
                Id = x.Id,
                UserId=x.UserId,
                Location=x.Location

            }).Where(x => x.UserId == userId&&x.SeizuresDate.Value.Date>=DateTime.Now.Date).ToList();
        }
    }
}
