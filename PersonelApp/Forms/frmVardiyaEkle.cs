using PersonelApp.DTO;
using PersonelApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelApp.Forms
{
    public partial class frmVardiyaEkle : Form
    {
        public frmVardiyaEkle()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        PersonelContext ctx = new PersonelContext();
        private void frmVardiyaEkle_Load(object sender, EventArgs e)
        {
           
            comboBox1.DataSource = ctx.Personels.Select(x=>new PersonelDTO { 
                Email=x.Email,
                Gsm=x.Gsm,
                Id=x.Id,
                Name=x.Name +" "+x.Surname,
                
            }).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
        List<AddSeizure> vardiyalar = new List<AddSeizure>();
        private void button1_Click(object sender, EventArgs e)
        {
            //Startdate ve enddate, nöbetin başlama ve bitiş saatini alır
            var startDate = Convert.ToDateTime(comboBox2.SelectedItem).TimeOfDay;
            var endDate = Convert.ToDateTime(comboBox3.SelectedItem).TimeOfDay;
            var date = dateTimePicker1.Value;
           
            var userId =Convert.ToInt32( comboBox1.SelectedValue);
            //Eğer nöbet süresi 1 saatten küçükse değerlerin doğru girilmesi istenir
             var totalHour =(endDate.Hours - startDate.Hours); 
            if (totalHour <1)
            {
                MessageBox.Show("Mesai bitiş süresi başlama süresinden büyük olmalıdır", "uyarı");
                return;
            }
            //Personel işçi kategorisindeyse ve mevcut nöbeti 9 saatten fazlaysa,memur 8 saattein fazlaysa uyarı verdirilir
            if (ctx.PersonelCategories.FirstOrDefault(x=>x.UserId==userId&&x.Id==2)!=null&& totalHour > 9)
            {
                MessageBox.Show("İşçiler 9 saatten daha fazla çalışamaz", "uyarı");
                return;
            }
            else if (ctx.UserRoles.FirstOrDefault(x => x.UserId == userId && x.Id == 1) != null &&  totalHour > 8)
            {
                MessageBox.Show("Memurlar 8 saatten daha fazla çalışamaz", "uyarı");
                return;
            }
            //personelin nöbet girilen tarih ve sonrasında başka bir nöbeti var mı diye bakılır
           bool isExist =ctx.Seizures.Any(x => x.SeizuresDate.Value.Date == date.Date && (x.SeizuresStartDate >= startDate && x.SeizuresEndDate <= x.SeizuresEndDate));
            if (!isExist)
            {
                //Eğer personel nöbet girilen gün izinliyse kontrol edilir ve izinli olduğu uyarı verdirilir
                var culture = new System.Globalization.CultureInfo("tr-TR");
                var trDay =culture.DateTimeFormat.GetDayName(date.Date.DayOfWeek);
                
                bool permissionDay = ctx.Personels.Any(x => x.Id == userId && x.PermissionDays.Contains(trDay));
                bool isExistPermission = ctx.Seizures.Any(x => x.SeizuresDate.Value.Date == date.Date && (x.SeizuresStartDate >= startDate && x.SeizuresEndDate <= x.SeizuresEndDate));
                if (permissionDay || isExistPermission)
                {
                    //izinli olduğu halde nöbet girilmek isteniyor, nöbet saati kadar ücret ödenir ya da izin verilir
                    var isOk = MessageBox.Show("Personel bu gün, bu saatler arasında izinli. Vardiya eklemek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (isOk == DialogResult.Yes)
                    {
                        var isPay = MessageBox.Show("Personel bu tarihte izinli olduğu için ek mesai ücreti uygulanacaktır  Eğer Onaylamazsanız personel başka bir gün için izinli sayılacaktır! Onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo);
                        bool giveMoney = false;
                        if (isPay == DialogResult.Yes)
                        {
                            //ücret ödemek istiyor musunuz sorusuna evet denirse ücret ödenir, hayır denirse personele izin yazılır
                            giveMoney = true;
                        }

                        AddSeizure vardiya = new AddSeizure
                        {
                            SeizuresDate = date,
                            SeizuresEndDate = endDate,
                            SeizuresStartDate = startDate,
                            UserId = Convert.ToInt32(comboBox1.SelectedValue),
                            PayMoney = giveMoney,
                            Location = comboBox4.SelectedItem.ToString()
                        };
                        vardiyalar.Add(vardiya);
                        dataGridView1.DataSource = vardiyalar.ToList();
                        dataGridView1.Columns.Remove("PayMoney");

                    }
                }
                else
                {
                    AddSeizure vardiya = new AddSeizure
                    {
                        SeizuresDate = date,
                        SeizuresEndDate = endDate,
                        SeizuresStartDate = startDate,
                        UserId = Convert.ToInt32(comboBox1.SelectedValue),
                        Location = comboBox4.SelectedItem.ToString()
                    };
                    vardiyalar.Add(vardiya);
                    dataGridView1.DataSource = vardiyalar.ToList();
                    dataGridView1.Columns.Remove("PayMoney");
                }
                

            }
            else
            {
                MessageBox.Show("Bu tarihte başka bir kayıt ekli !");
                return;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in vardiyalar)
                {
                    var totalHour = (item.SeizuresEndDate.Value.Hours - item.SeizuresStartDate.Value.Hours);
                    if (item.PayMoney==true)
                    {
                        
                        Payment pay = new Payment
                        {
                            //saatlik ek mesai ücreti 20 tl
                            PaymentAmount = (totalHour * 20),
                            PaymentDescription = "Fazla Mesai",
                            UserId = item.UserId
                        };
                        ctx.Payments.Add(pay);
                    }
                    else if (item.PayMoney == false)
                    {


                        ctx.PersonelPermissions.Add(
                             new PersonelPermission
                             {
                                 UserId = item.UserId,
                                 PermissionHour = totalHour,
                                 Description="Fazla Mesai"
                             }
                            ); ;
                    }
                    ctx.Seizures.Add(new Seizure
                    {
                        SeizuresDate = item.SeizuresDate,
                        UserId = item.UserId,
                        SeizuresEndDate = item.SeizuresEndDate,
                        SeizuresStartDate = item.SeizuresStartDate,
                        Location=item.Location
                    });
                   
                }
                ctx.SaveChanges();
                dataGridView1.DataSource = new List<Seizure>().ToList();
                MessageBox.Show("Vardiyalar Başarıyla Eklendi", "Uyarı");
            }
            catch (Exception)
            {

                MessageBox.Show("Vardiya Eklenirken Bir Hata Oluştu", "Uyarı");
            }
            
        }
    }
}
