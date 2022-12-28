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
    public partial class frmIzinler : Form
    {
        public frmIzinler()
        {
            InitializeComponent();
        }

        private void frmIzinler_Load(object sender, EventArgs e)
        {
            PersonelContext ctx = new PersonelContext();
            dataGridView1.DataSource= ctx.PersonelPermissions.Select(x=>new PermissionDTO { 
                Description=x.Description,
                FullName=x.User.Name+" "+x.User.Surname,
                PermissionHour=x.PermissionHour.Value
            
            }).ToList();
        }
    }
}
