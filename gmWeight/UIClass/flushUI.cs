using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace gmWeight
{
	class flushUI
	{
        //声明一个更新主线程的委托
        public delegate void UpdateUI(int step);
        public UpdateUI UpdateUIDelegate;

        //声明一个在完成任务时通知主线程的委托
        public delegate void AccomplishTask();
        public AccomplishTask TaskCallBack;

        /// <summary>
        /// 一个写入数据的方法
        /// </summary>
        /// <param name="lineCount"></param>
        public void Write(object lineCount)
        {
            for (int i = 0; i < (int)lineCount; i++)
            {
                Thread.Sleep(100);
                UpdateUIDelegate(i);
            }
            TaskCallBack();
        }

	}
}
