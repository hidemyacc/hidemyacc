using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HidemyaccSample
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitConnection();
        }

        private void InitConnection()
        {
            var me = HmaApi.GetUser();

			if (me == null)
			{
				MessageBox.Show("Kết nối với Hidemyacc không thành công!");
				Close();
				return;
			}

			if (me.ExpireDate < DateTime.Now)
			{
				MessageBox.Show("Tài khoản của bạn đã hết hạn. Vui lòng nâng cấp tài khoản để tiếp tục sử dụng.");
				Close();
				return;
			}

            lblEmail.Text = me.Email;
            lblExpire.Text = me.ExpireDate.ToString("dd/MM/yyyy");
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            if (!workerRun.IsBusy)
            {
                workerRun.RunWorkerAsync();
            }
        }

        private void workerRun_DoWork(object sender, DoWorkEventArgs e)
        {
            ChromeService chromeService = new ChromeService();
            if (chromeService.StartProfile("xxx"))
            {
                chromeService.TestChromeDrive();
            }
            Invoke(new Action(() => btnRun.Enabled = true));
            MessageBox.Show("Test Done");
        }
    }
}
