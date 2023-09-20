using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Tên đăng nhập là bắt buộc");
            else
                this.errorProvider1.Clear();
        }

        private void txtDiaChiEmail_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Địa chỉ email là bắt buộc");
            else if (IsEmail(txtDiaChiEmail.Text) == false)
                this.errorProvider1.SetError(ctr, "Địa chỉ email không đúng định dạng");
            else
                this.errorProvider1.Clear();
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Mật khẩu là bắt buộc");
            else
                this.errorProvider1.Clear();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                MessageBox.Show("Tên đăng nhập không được để trống");
            else if(string.IsNullOrWhiteSpace(txtDiaChiEmail.Text))
                MessageBox.Show("Địa chỉ email không được để trống");
            else if (IsEmail(txtDiaChiEmail.Text) == false)
                MessageBox.Show("Địa chỉ email không đúng định dạng");
            else if(string.IsNullOrWhiteSpace(txtMatKhau.Text))
                MessageBox.Show("Mật khẩu không được để trống");
            else if(String.Compare(txtMatKhau.Text, txtXacNhan.Text, false) != 0)
                MessageBox.Show("Xác nhận mật khẩu không đúng");
            else
            {
                string s;
                s = "Tên đăng nhập: " + txtTenDangNhap.Text + "\n";
                s = s + "Địa chỉ email: " + txtDiaChiEmail.Text + "\n";
                s = s + "Mật khẩu: " + txtMatKhau.Text + "\n";
                MessageBox.Show(s);
            }
                
        }

        private void txtXacNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                    MessageBox.Show("Tên đăng nhập không được để trống");
                else if (string.IsNullOrWhiteSpace(txtDiaChiEmail.Text))
                    MessageBox.Show("Địa chỉ email không được để trống");
                else if (IsEmail(txtDiaChiEmail.Text) == false)
                    MessageBox.Show("Địa chỉ email không đúng định dạng");
                else if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    MessageBox.Show("Mật khẩu không được để trống");
                else if (String.Compare(txtMatKhau.Text, txtXacNhan.Text, false) != 0)
                    MessageBox.Show("Xác nhận mật khẩu không đúng");
                else
                {
                    string s;
                    s = "Tên đăng nhập: " + txtTenDangNhap.Text + "\n";
                    s = s + "Địa chỉ email: " + txtDiaChiEmail.Text + "\n";
                    s = s + "Mật khẩu: " + txtMatKhau.Text + "\n";
                    MessageBox.Show(s);
                }
            }
        }
    }
}
