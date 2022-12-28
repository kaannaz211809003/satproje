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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            frmPersonel personel = new frmPersonel();
            personel.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            frmVardiya var = new frmVardiya();
            var.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            frmVardiyaEkle ekle = new frmVardiyaEkle();
            ekle.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            frmOdemeler ode = new frmOdemeler();
            ode.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            PersonelContext ctx = new PersonelContext();
            dataGridView1.DataSource = ctx.Seizures.Select(x => new VardiyaDetailDTO
            {

                SeizuresDate = x.SeizuresDate,
                SeizuresStartDate = x.SeizuresStartDate,
                Name = x.User.Name + " " + x.User.Surname,
                SeizuresEndDate = x.SeizuresEndDate,
                Id = x.Id,
                Location=x.Location

            }).Where(x=>x.SeizuresDate.Value.Date==DateTime.Now.Date).ToList();
       
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            frmIzinler izin = new frmIzinler();
            izin.Show();
        }
    }
}
