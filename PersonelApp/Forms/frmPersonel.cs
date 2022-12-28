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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            PersonelContext ctx = new PersonelContext();
           
           
            dataGridView1.DataSource = ctx.Personels.Select(x => new PersonelDTO
            {
                Id = x.Id,
                Email = x.Email,
                Gsm = x.Gsm,
                Name = x.Name,
                Surname = x.Surname,
                Tckn = x.Tckn,
                Title =x.Title,
                PermissionDays = x.PermissionDays,


            }).ToList();


        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmIzınGunDegis degis = new frmIzınGunDegis();
            degis.Tag = dataGridView1.CurrentRow.Cells["Id"].Value;
            degis.Show();

        }
    }
}
