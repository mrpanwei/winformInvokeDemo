using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gmWeight
{
    public partial class login : Form
    {
        private static int WHERE = 1;

        public login()
        {
            InitializeComponent();
            WHERE = 1;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //测试账户
            if (userName.Text.Trim().Equals("1111"))
            {
                UserInfo.setUserName("admin");
                UserInfo.setTerminalID(1111);
                this.DialogResult = DialogResult.OK;
                return;
            }
            DataTable dt = Dao.tryLogin(userName.Text.Trim(), userPassword.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                UserInfo.setUserName(dt.Rows[0]["name"].ToString());
                UserInfo.setTerminalID(Convert.ToInt32(dt.Rows[0]["tid"]));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (WHERE.Equals(1))
                {
                    userName.Focus();
                    userName.SelectionStart = userName.Text.Trim().Length;
                }
                else if (WHERE.Equals(2))
                {
                    userPassword.Focus();
                    userPassword.SelectionStart = userPassword.Text.Trim().Length;
                }
                MessageBox.Show("账户或密码错误！");
            }
        }

        #region 键盘操作

        private void Key_R_Click(object sender, EventArgs e)
        {
            dealInput("R");
        }

        private void Key_F_Click(object sender, EventArgs e)
        {
            dealInput("F");
        }

        private void Key_W_Click(object sender, EventArgs e)
        {
            dealInput("W");
        }

        private void Key_1_Click(object sender, EventArgs e)
        {
            dealInput("1");
        }

        private void Key_2_Click(object sender, EventArgs e)
        {
            dealInput("2");
        }

        private void Key_3_Click(object sender, EventArgs e)
        {
            dealInput("3");
        }

        private void Key_4_Click(object sender, EventArgs e)
        {
            dealInput("4");
        }

        private void Key_5_Click(object sender, EventArgs e)
        {
            dealInput("5");
        }

        private void Key_6_Click(object sender, EventArgs e)
        {
            dealInput("6");
        }

        private void Key_7_Click(object sender, EventArgs e)
        {
            dealInput("7");
        }

        private void Key_8_Click(object sender, EventArgs e)
        {
            dealInput("8");
        }

        private void Key_9_Click(object sender, EventArgs e)
        {
            dealInput("9");
        }

        private void Key_0_Click(object sender, EventArgs e)
        {
            dealInput("0");
        }

        private void Key_Del_Click(object sender, EventArgs e)
        {
            if (WHERE.Equals(1))
            {
                if (!userName.Text.Trim().Equals(""))
                {
                    userName.Text = userName.Text.Trim().Substring(0, userName.Text.Trim().Length - 1);
                }
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else if (WHERE.Equals(2))
            {
                if (!userPassword.Text.Trim().Equals(""))
                {
                    userPassword.Text = userPassword.Text.Trim().Substring(0, userPassword.Text.Trim().Length - 1);
                }
                userPassword.Focus();
                userPassword.SelectionStart = userPassword.Text.Trim().Length;
            }
        }

        #endregion

        private void dealInput(string key)
        {
            string xx = WHERE.ToString();
            if (WHERE.Equals(1))
            {
                userName.Text = userName.Text.Trim() + key;
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;

            }
            else if (WHERE.Equals(2))
            {
                userPassword.Text = userPassword.Text.Trim() + key;
                userPassword.Focus();
                userPassword.SelectionStart = userPassword.Text.Trim().Length;
            }
        }


        private void userName_MouseClick(object sender, MouseEventArgs e)
        {
            WHERE = 1;
            userName.SelectionStart = userName.Text.Trim().Length;
        }

        private void userPassword_MouseClick(object sender, MouseEventArgs e)
        {
            WHERE = 2;
            userPassword.SelectionStart = userPassword.Text.Trim().Length;
        }


     

        
    }
}
