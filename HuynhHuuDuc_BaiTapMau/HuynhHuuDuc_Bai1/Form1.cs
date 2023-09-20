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

namespace HuynhHuuDuc_Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        public bool IsNumber(string pText)
        {
            Regex regex = null;
            try
            {
                regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$"); return regex.IsMatch(pText);
            }
            catch (Exception ex)
            {
                return regex.IsMatch(pText);
            }
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            //if (ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 11]))
            if (IsNumber(txtA.Text) == false)
            {
                this.errorProvider1.SetError(ctr, "This is not avalid number");
                MessageBox.Show("Đây không phải số !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                this.errorProvider1.Clear();
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            //if (ctr.Text.Length > 0 && !Char.IsDigit(ctr.Text[ctr.Text.Length - 11]))
            if (IsNumber(txtB.Text) == false)
            {
                this.errorProvider1.SetError(ctr, "This is not avalid number");
                MessageBox.Show("Đây không phải số !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                this.errorProvider1.Clear();
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            int Cong = Convert.ToInt32(txtA.Text) + Convert.ToInt32(txtB.Text);
            txtKetQua.Text = Convert.ToString(Cong);
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            int Tru = Convert.ToInt32(txtA.Text) - Convert.ToInt32(txtB.Text);
            txtKetQua.Text = Convert.ToString(Tru);
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            int Nhan = Convert.ToInt32(txtA.Text) * Convert.ToInt32(txtB.Text);
            txtKetQua.Text = Convert.ToString(Nhan);
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            double Chia = Convert.ToDouble(txtA.Text) / Convert.ToDouble(txtB.Text);
            txtKetQua.Text = Convert.ToString(Chia);
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }




    }
}
