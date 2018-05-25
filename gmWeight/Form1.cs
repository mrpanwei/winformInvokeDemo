using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace gmWeight
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 声明一个异步更新的委托
        /// </summary>
        /// <param name="step"></param>
        delegate void AsynUpdateUI(int step);

        public Form1()
        {
            InitializeComponent();
            pageInit();
        }

        #region 初始化页面操作
        void pageInit()
        {
            flushUI fu = new flushUI();
            //绑定更新任务状态的委托
            fu.UpdateUIDelegate += UpdataUIStatus;
            //绑定完成任务要调用的委托
            fu.TaskCallBack += Accomplish;

            Thread thread = new Thread(new ParameterizedThreadStart(fu.Write));
            thread.IsBackground = true;
            thread.Start(100);
        }
        #endregion

        private void UpdataUIStatus(int step)
        {
            if (InvokeRequired)
            {
                this.Invoke(new AsynUpdateUI(delegate(int s)
                {
                    this.orderID.Text = s.ToString();
                    this.goodsName.Text = s.ToString();
                    this.goodsBarCode.Text = s.ToString();
                    this.goodsCode.Text = s.ToString();
                    this.goodsUint.Text = s.ToString();
                    this.shopName.Text = s.ToString();
                    this.remark.Text = s.ToString();
                    this.prevWeight.Text = s.ToString();
                }), step);
            }
            else
            {
                this.orderID.Text = step.ToString();
                this.goodsName.Text = step.ToString();
                this.goodsBarCode.Text = step.ToString();
                this.goodsCode.Text = step.ToString();
                this.goodsUint.Text = step.ToString();
                this.shopName.Text = step.ToString();
                this.remark.Text = step.ToString();
                this.prevWeight.Text = step.ToString();
            }
        }

        private void Accomplish()
        {
            MessageBox.Show("任务完成");
        }

        #region 电子秤操作

        private void zero_Click(object sender, EventArgs e)
        {

        }

        private void toZero_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 网络订单操作

        /// <summary>
        /// 1次称重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void level1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 2次称重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void level2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 3次称重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void level3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 撤销已打包订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelPrev_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 暂时不处理改订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderDelay_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 历史订单打印【上1次订单】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyPrint_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
