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

namespace PersonelApp
{
    public partial class frmIzınGunDegis : Form
    {
        public frmIzınGunDegis()
        {
            InitializeComponent();
        }
        PersonelContext ctx = new PersonelContext();
        private void button1_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(this.Tag);
            var user = ctx.Personels.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.PermissionDays = comboBox1.SelectedItem + "," + comboBox2.SelectedItem;
                ctx.Personels.Update(user);
                ctx.SaveChanges();
                MessageBox.Show("İzin Günleri Güncellendi");
            }
        }
        private void frmIzınGunDegis_Load(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(this.Tag);
            var user = ctx.Personels.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                textBox1.Text = user.Name;
                textBox2.Text = user.Surname;
                textBox3.Text = user.Tckn;
            }
        }
    }
}
