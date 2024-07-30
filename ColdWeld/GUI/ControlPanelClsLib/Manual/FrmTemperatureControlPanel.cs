using GlobalDataDefineClsLib;
using HardwareManagerClsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureControllerClsLib;

namespace ControlPanelClsLib
{
    public partial class FrmTemperatureControlPanel : Form
    {
        private TemperatureControllerManager _TemperatureControllerManager
        {
            get { return TemperatureControllerManager.Instance; }
        }

        public FrmTemperatureControlPanel()
        {
            InitializeComponent();

            comboBox2.SelectedIndex = 0;

            comboBox1.Items.Clear();

            comboBox1.Items.Add(TemperatureRtuAdd.PV);
            comboBox1.Items.Add(TemperatureRtuAdd.SV);
            comboBox1.Items.Add(TemperatureRtuAdd.OUT1);
            comboBox1.Items.Add(TemperatureRtuAdd.OUT2);
            comboBox1.Items.Add(TemperatureRtuAdd.EXE_FLG);
            comboBox1.Items.Add(TemperatureRtuAdd.EV_FLG);
            comboBox1.Items.Add(TemperatureRtuAdd.SV_No);
            comboBox1.Items.Add(TemperatureRtuAdd.EXE_PID);
            comboBox1.Items.Add(TemperatureRtuAdd.HC1);
            comboBox1.Items.Add(TemperatureRtuAdd.HC2);
            comboBox1.Items.Add(TemperatureRtuAdd.DI_FLG);
            comboBox1.Items.Add(TemperatureRtuAdd.EV_LAC);
            comboBox1.Items.Add(TemperatureRtuAdd.EV_ACT);
            comboBox1.Items.Add(TemperatureRtuAdd.E_PRG);
            comboBox1.Items.Add(TemperatureRtuAdd.E_PTN);
            comboBox1.Items.Add(TemperatureRtuAdd.E_PRG_Num);
            comboBox1.Items.Add(TemperatureRtuAdd.E_PTN_Num);
            comboBox1.Items.Add(TemperatureRtuAdd.E_TIM);
            comboBox1.Items.Add(TemperatureRtuAdd.E_PID);
            comboBox1.Items.Add(TemperatureRtuAdd.SV_NO);
            comboBox1.Items.Add(TemperatureRtuAdd.OUT1_Set);
            comboBox1.Items.Add(TemperatureRtuAdd.OUT2_Set);
            comboBox1.Items.Add(TemperatureRtuAdd.AT);
            comboBox1.Items.Add(TemperatureRtuAdd.MAN);
            comboBox1.Items.Add(TemperatureRtuAdd.RUN);
            comboBox1.Items.Add(TemperatureRtuAdd.HLD);
            comboBox1.Items.Add(TemperatureRtuAdd.ADV);
            comboBox1.Items.Add(TemperatureRtuAdd.RST_LACH);
            comboBox1.Items.Add(TemperatureRtuAdd.FIX_SV1);
            comboBox1.Items.Add(TemperatureRtuAdd.FIX_SV2);
            comboBox1.Items.Add(TemperatureRtuAdd.FIX_SV3);
            comboBox1.Items.Add(TemperatureRtuAdd.SV_L);
            comboBox1.Items.Add(TemperatureRtuAdd.SV_H);

            comboBox1.SelectedIndex = 0;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Write((TemperatureRtuAdd)comboBox1.SelectedItem,(int)spinEdit1.Value);
                }

            }
            catch
            {

            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(_TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).IsConnect)
                {
                    int Value = _TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Read((TemperatureRtuAdd)comboBox1.SelectedItem);
                    spinEdit1.Value = Value;
                }

            }
            catch
            {

            }
        }

        private void btnHeat_Click(object sender, EventArgs e)
        {
            try
            {
                if (_TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Write(TemperatureRtuAdd.FIX_SV1, (int)seTargetTemp.Value);

                    //_TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Write(TemperatureRtuAdd., (int)seTargetTemp.Value);

                    _TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Write(TemperatureRtuAdd.RUN, 1);

                }

            }
            catch
            {

            }
        }

        private void btnStopHeat_Click(object sender, EventArgs e)
        {
            try
            {
                if (_TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Write(TemperatureRtuAdd.RUN, 0);

                }

            }
            catch
            {

            }
        }

        private void btnSelfTuning_Click(object sender, EventArgs e)
        {
            try
            {
                if (_TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Write(TemperatureRtuAdd.FIX_SV1, (int)seTargetTemp.Value);

                    _TemperatureControllerManager.GetTemperatureController((EnumTemperatureType)comboBox2.SelectedIndex).Write(TemperatureRtuAdd.AT, 1);

                }

            }
            catch
            {

            }
        }
    }
}
