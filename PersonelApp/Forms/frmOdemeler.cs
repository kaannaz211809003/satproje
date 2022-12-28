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
    public partial class frmOdemeler : Form
    {
        public frmOdemeler()
        {
            InitializeComponent();
        }

        private void frmOdemeler_Load(object sender, EventArgs e)
        {
            PersonelContext ctx = new PersonelContext();
            dataGridView1.DataSource = ctx.Payments.Select(x=>new PaymentDTO 
            
                {
                    UserId=x.UserId,
                    Id=x.Id,
                    Name=x.User.Name+" "+x.User.Surname,
                    PaymentAmount=x.PaymentAmount,
                    PaymentDescription=x.PaymentDescription
                    
                }).ToList();
            dataGridView1.Columns.Remove("UserId");
        }
    }
}
