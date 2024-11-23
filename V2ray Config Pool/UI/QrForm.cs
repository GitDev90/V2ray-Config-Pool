using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V2ray_Config_Pool.UI
{
    public partial class QrForm : Form
    {
        public QrForm(string _QrDataT,string _CounT)
        {
            InitializeComponent();

            _QrData=_QrDataT;
            _Coun = _CounT;
        }

        string _QrData,_Coun;

        private void QrForm_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "   QrCode (" + _Coun + ")";

            QrCodeReader _Qr = new QrCodeReader();

            QrPic.Image = _Qr.Read_QrCode(_QrData);


        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            BtnClose.BackColor = Color.Red;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(_QrData);


            BtnAdd.Text = "Copied !";
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.BackColor = Color.DimGray;
        }


    }
}
