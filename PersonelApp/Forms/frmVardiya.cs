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
    public partial class frmVardiya : Form
    {
        public frmVardiya()
        {
            InitializeComponent();
        }

        private void frmVardiya_Load(object sender, EventArgs e)
        {
            PersonelContext ctx = new PersonelContext();
            dataGridView1.DataSource = ctx.Seizures.OrderByDescending(x=>x.SeizuresDate).AsEnumerable().GroupBy(x => x.SeizuresDate).Select(x => new VardiyaDTO
            {
              
                SeizuresDate = x.Max(y => y.SeizuresDate) ,
            SeizuresStartDate = x.Max(y => y.SeizuresStartDate),
      

            }).ToList();
          
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmVardiyaDetay detay = new frmVardiyaDetay();
               detay.Tag = dataGridView1.CurrentRow.Cells["SeizuresDate"].Value;
            detay.Show();
        }
    }
}
