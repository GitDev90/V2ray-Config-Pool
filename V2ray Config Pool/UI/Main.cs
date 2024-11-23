using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using vcruntime110;

namespace V2ray_Config_Pool.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


            this.AutoScroll = false;


            CheckForIllegalCrossThreadCalls = false;

            
        }



        #region MoveForm

        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        #endregion


        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            BtnClose.BackColor = Color.Red;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.BackColor = SystemColors.Control;
        }

        private void BtnMini_MouseEnter(object sender, EventArgs e)
        {
            BtnMini.BackColor = Color.Red;
        }

        private void BtnMini_MouseLeave(object sender, EventArgs e)
        {
            BtnMini.BackColor = SystemColors.Control;
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void Main_Shown(object sender, EventArgs e)
        {
            PanelRow1.Enabled = false;
            PanelRow2.Enabled = false;
            PanelRow3.Enabled = false;
            PanelRow4.Enabled = false;
            PanelRow5.Enabled = false;
            PanelRow6.Enabled = false;


            PanelSearch.Size = new Size(377, 325);

            PanelSearch.Location = new Point((this.Location.X / 2) + (PanelSearch.Width/3), (this.Location.Y / 2) + (PanelSearch.Height/2));

            TimerShow.Start();
        }

        private void PicAE_Click(object sender, EventArgs e)
        {
            string _Tag = ((PictureBox)sender).Tag.ToString().ToLower();

            string _UrlPic = _Tag;

            QrForm _QrForm = new QrForm(_UrlPic,_Tag.ToUpper());
            _QrForm.ShowDialog();
        }



        int _CountR1 = 0, _CountR2 = 0, _CountR3 = 0, _CountR4 = 0, _CountR5 = 0, _CountR6 = 0;

        int _CountTotal = 0;

        int _RemainTime = 0;


        int _TotalTime = 2;

        private void TimerShow_Tick(object sender, EventArgs e)
        {

            TimerShow.Interval = 400;
            Control.ControlCollection _Con = PanelRow1.Controls;
            Control.ControlCollection _Con2 = PanelRow2.Controls;
            Control.ControlCollection _Con3 = PanelRow3.Controls;
            Control.ControlCollection _Con4 = PanelRow4.Controls;
            Control.ControlCollection _Con5 = PanelRow5.Controls;
            Control.ControlCollection _Con6 = PanelRow6.Controls;

            if (_RemainTime == 0)
            {
                _CountR1 = _Con.Count - 1;
                _CountR2 = _Con2.Count - 1;
                _CountR3 = _Con3.Count - 1;
                _CountR4 = _Con4.Count - 1;
                _CountR5 = _Con5.Count - 1;
                _CountR6 = _Con6.Count - 1;
            }

            _RemainTime++;



    

            if (_CountR1 > -1)
            {
                _Con[_CountR1].Visible = true;

                if (_Con[_CountR1].Controls.Count > 0)
                {

                    _CountTotal++;

                    lblLocations.Text = _CountTotal + " location found!";
                }
            }
            else
            {
                if (_CountR2 > -1)
                {
                    _Con2[_CountR2].Visible = true;
                    if (_Con[_CountR2].Controls.Count > 0)
                    {

                        _CountTotal++;

                        lblLocations.Text = _CountTotal + " location found!";
                    }
                }
                else
                {
                    if (_CountR3 > -1)
                    {
                        _Con3[_CountR3].Visible = true;
                        if (_Con[_CountR3].Controls.Count > 0)
                        {

                            _CountTotal++;

                            lblLocations.Text = _CountTotal + " location found!";
                        }
                    }
                    else
                    {
                        if (_CountR4 > -1)
                        {
                            _Con4[_CountR4].Visible = true;
                            if (_Con[_CountR4].Controls.Count > 0)
                            {

                                _CountTotal++;

                                lblLocations.Text = _CountTotal + " location found!";
                            }
                        }
                        else
                        {
                            if (_CountR5 > -1)
                            {
                                _Con5[_CountR5].Visible = true;
                                if (_Con[_CountR5].Controls.Count > 0)
                                {

                                    _CountTotal++;

                                    lblLocations.Text = _CountTotal + " location found!";
                                }
                            }
                            else
                            {
                                if (_CountR6 > -1)
                                {
                                    _Con6[_CountR6].Visible = true;
                                    if (_Con[_CountR6].Controls.Count > 0)
                                    {

                                        _CountTotal++;

                                        lblLocations.Text = _CountTotal + " location found!";
                                    }
                                }
                                else
                                {
                                    PanelSearch.Visible = false;

                                    PanelRow1.Enabled = true;
                                    PanelRow2.Enabled = true;
                                    PanelRow3.Enabled = true;
                                    PanelRow4.Enabled = true;
                                    PanelRow5.Enabled = true;
                                    PanelRow6.Enabled = true;

                                    TimerShow.Stop();
                                }

                                _CountR6--;
                            }

                            _CountR5--;
                        }

                        _CountR4--;
                    }

                    _CountR3--;
                }

                _CountR2--;
            }

            _CountR1--;


            if (((_TotalTime) - Convert.ToInt32(((_RemainTime * 1600) / 60000))) >= 0)
            {
                lblTime.Text = "Estimated time: " + ((_TotalTime) - Convert.ToInt32(((_RemainTime * 1600) / 60000))).ToString() + " Minutes";
            }

    

        }
    }
}
