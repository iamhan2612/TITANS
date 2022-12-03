using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using DAL;
using System.Net;
using System.Net.Mail;

namespace TITANS
{
    public partial class Dangky : Form
    {
        public Dangky()
        {
            InitializeComponent();
        }

        Users_BUS nvBUS = new Users_BUS();

        private void sendemail(string email)
        {
            string from, to, pass, content;
            from = "quynhngo030502@gmail.com";
            to = txtemail.Text.Trim();
            pass = "ngoquynh020503";
            content = "Mật khẩu của bạn là 123. Hãy đổi mật khẩu sau khi đăng nhập lần đầu";

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = "UPDATE PASSWORD";
            mail.Body = content;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.Credentials = new System.Net.NetworkCredential("quynhngo030502@gmail.com", "cxsnpvrgqikrodia");
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Email sent successfully.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            if (txtemail.Text.Trim().Length == 0)// kiem tra phai nhap email
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemail.Focus();
                return;
            }
            else if (txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đúng định dang email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemail.Focus();
                return;
            }
            
            else
            {
                // Tạo DTO
                Users_DTO nv = new Users_DTO(txtemail.Text, "123", cbchucvu.Text); 
                if (nvBUS.InsertNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    //ResetValues();
                    //LoadGridview_NhanVien(); // refresh datagridview
                    sendemail(txtemail.Text);

                }

                else
                {
                    MessageBox.Show("Thêm ko thành công");
                }
            }
        }

        private void btndk_Load(object sender, EventArgs e)
        {

        }
    }
}
