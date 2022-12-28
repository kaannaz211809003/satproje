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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //giriş yapan kullanıcı kontrol edilir, yetkisine göre ilgili sayfalara yönlendirilir
            PersonelContext ctx = new PersonelContext();
            Personel per = ctx.Personels.FirstOrDefault(x => x.Username == textBox1.Text && x.Password == textBox2.Text);
            if (per!=null)
            {
                var role=ctx.UserRoles.FirstOrDefault(x => x.UserId == per.Id);
                if (role != null&& role.RoleId==1)
                {
                    FrmMain main = new FrmMain();
                    main.Show();
                }else if (role != null && role.RoleId == 2)
                {
                    frmUserScreen main = new frmUserScreen();
                    main.Tag = per.Id;
                    main.Show();
                }
            }
        }
    }
}
