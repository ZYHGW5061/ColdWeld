using CommonPanelClsLib;
using DevExpress.XtraEditors;
using GlobalDataDefineClsLib;
using PositioningSystemClsLib;
using RecipeClsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControlPanelClsLib
{
    public partial class FrmEditTransportRecipe : BaseForm
    {
        /// <summary>
        /// 数据库
        /// </summary>
        //private DBManager _dataBaseManager
        //{
        //    get { return DBManager.DBManagerHandler; }
        //}
        /// <summary>
        /// RightsData数据操作
        /// </summary>
        //private UserRightsManager _rightsDataManage = UserRightsManager.GetHandler();

        //private DataRow _dataRow = null;
        private TransportRecipe _selRecipe = null;
        private TransportRecipe _newRecipe = null;
        private string _operation = "Edit";
        /// <summary>
        /// 定位系统
        /// </summary>
        private PositioningSystem _positionSystem
        {
            get { return PositioningSystem.Instance; }
        }

        public FrmEditTransportRecipe(string operation, TransportRecipe recipe)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            if (recipe != null)
            {
                _selRecipe = recipe;
            }
            _operation = operation;           
            BindingData();
        }

        private void BindingData()
        {
            if (_operation == "Add")
            {
                //this.txtID.Text = (LoginHelper.GetHandler.GetUserMaxID() + 1).ToString();
                this.teName.Text = "";
                this.tableLayoutPanel2.Controls.Add(this.btn_Add, 0, 0);
                this.btn_Add.Visible = true;
                this.btn_Edit.Visible = false;
                this.Text = "新增传送配方";
            }
            else if (_operation == "Edit" && _selRecipe != null)
            {
                this.tableLayoutPanel2.Controls.Add(this.btn_Edit, 0, 0);
                this.btn_Add.Visible = false;
                this.btn_Edit.Visible = true;
                this.teName.Text = _selRecipe.RecipeName;
                //this.seTargetTemp.Value = _selRecipe.TargetTemperature;
                //this.seHeatPreservationMinute.Value = _selRecipe.HeatPreservationMinute;
                //this.seOverTemperatureThreshold.Value = _selRecipe.OverTemperatureThreshold;
                this.Text = "编辑传送配方";
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string name = this.teName.Text.Trim();
            //int targetTemp = (int)this.seTargetTemp.Value;
            //int heatPreservationMinute = (int)this.seHeatPreservationMinute.Value;
            //int overTemperatureThreshold = (int)this.seOverTemperatureThreshold.Value;
            if (Name == "")
            {
                WarningBox.FormShow("错误", "参数不符合要求!", "提示");
                return;
            }
            var newRecipe = TransportRecipe.CreateRecipe(name, EnumRecipeType.Transport);
            newRecipe.RecipeName = name;
            SetParameters(newRecipe);
            //newRecipe.TargetTemperature = targetTemp;
            //newRecipe.HeatPreservationMinute = heatPreservationMinute;
            //newRecipe.OverTemperatureThreshold = overTemperatureThreshold;
            newRecipe.SaveRecipe();
            WarningBox.FormShow("成功!", "添加配方完成!", "提示");
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string name = this.teName.Text.Trim();
            //int targetTemp = (int)this.seTargetTemp.Value;
            //int heatPreservationMinute = (int)this.seHeatPreservationMinute.Value;
            //int overTemperatureThreshold = (int)this.seOverTemperatureThreshold.Value;
            if (Name == "")
            {
                WarningBox.FormShow("错误", "参数不符合要求!", "提示");
                return;
            }
            if (_selRecipe != null)
            {
                //_selRecipe.RecipeName = name;
                //_selRecipe.TargetTemperature = targetTemp;
                //_selRecipe.HeatPreservationMinute = heatPreservationMinute;
                //_selRecipe.OverTemperatureThreshold = overTemperatureThreshold;
                SetParameters();
                _selRecipe.SaveRecipe();
                WarningBox.FormShow("成功!", "编辑配方完成!", "提示");
            }
            else
            {
                WarningBox.FormShow("错误", "编辑的配方异常!", "提示");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void btnSetHookZPreparePosForPullMB_Click(object sender, EventArgs e)
        {
            //if (ckbManualSet.Checked)
            //{
            //    var setValue = 0f;
            //    if (float.TryParse(this.teHookZPreparePosForPullMB.Text.Trim(), out setValue))
            //    {
            //        _selRecipe.HookAxisZPreparePosForPullMaterialBox = setValue;
                    

            //        WarningFormCL.WarningBox.FormShow("成功", "设置完成。", "提示");
            //    }
            //    else
            //    {
            //        WarningFormCL.WarningBox.FormShow("错误", "设置值无效", "提示");
            //    }
            //}
            //else
            //{
            //    _selRecipe.HookAxisZPreparePosForPullMaterialBox = (float)_positionSystem.ReadCurrentStagePosition(EnumStageAxis.HookZForMaterialbox);
                
            //    LoadParameters();
            //    WarningFormCL.WarningBox.FormShow("成功", "设置完成。", "提示");
            //}
        }



        private void LoadParameters()
        {
            //this.teHookZPreparePosForPullMB.Text = _selRecipe.HookAxisZPreparePosForPullMaterialBox.ToString();
            //this.teHookXPreparePosForPullMBStep1.Text = _selRecipe.HookAxisXPreparePosForPullMBStep1.ToString();
            //this.teHookZPosForPullMB.Text = _selRecipe.HookAxisZPosForPullMaterialBox.ToString();
            //this.teHookXPullHalfPosForMBStep1.Text = _selRecipe.HookAxisXPosForPullMBStep1.ToString();
            //this.teHookXPreparePosForPullMBStep2.Text = _selRecipe.HookAxisXPreparePosForPullMBStep2.ToString();
            //this.teHookXPosForPullMBStep2.Text = _selRecipe.HookAxisXPosForPullMBStep2.ToString();
            //this.teHookZPosForPushMB.Text = _selRecipe.HookAxisZPosForPushMaterialbox.ToString();
            //this.teHookXPreparePosForPushMBStep1.Text = _selRecipe.HookAxisXPreparePosForPushMBStep1.ToString();
            //this.teHookXPosForPushMBStep1.Text = _selRecipe.HookAxisXPosForPushMBStep1.ToString();
            //this.teHookZPreparePushWholePosForMB.Text = _selRecipe.HookAxisZPreparePosForPushMaterialbox.ToString();
            //this.teHookXPreparePosForPushMBStep2.Text = _selRecipe.HookAxisXPreparePosForPushMBStep2.ToString();
            //this.teHookXPosForPushMBStep2.Text = _selRecipe.HookAxisXPosForPushMBStep2.ToString();
            //this.teTrackXPosForPullMaterialBox.Text = _selRecipe.TrackXPosForPullMaterialBox.ToString();
            //this.teTrackXPosForPushMaterialBox.Text = _selRecipe.TrackXPosForPushMaterialBox.ToString();
            //this.teHookXIdlePosForMB.Text = _selRecipe.HookAxisXIdlePosForMaterialbox.ToString();
            //this.teHookZIdlePosForMB.Text = _selRecipe.HookAxisZIdlePosForMaterialbox.ToString();
            //this.teTrackXIdlePosForMB.Text = _selRecipe.TrackXIdlePosForMaterialBox.ToString();
            //this.teLifterPosForLoadMB.Text = _selRecipe.BufferLifterPosForLoadMaterialbox.ToString();
            //this.teLifterPosForUnloadMB.Text = _selRecipe.BufferLifterPosForUnloadMaterialbox.ToString();
            //this.teHookZPreparePosForPullStripFormMB.Text = _selRecipe.HookZPreparePosForPullStripFromMB.ToString();
            //this.teHookXPreparePosForPullStripFormMBStep1.Text = _selRecipe.HookXPreparePosForPullStripFromMBStep1.ToString();
            //this.teHookZPosForPullStripFormMB.Text = _selRecipe.HookZPosForPullStripFromMB.ToString();
            //this.teHookXPosForPullStripFormMBStep1.Text = _selRecipe.HookXPosForPullStripFromMBStep1.ToString();
            //this.teHookXPreparePosForPullStripFormMBStep2.Text = _selRecipe.HookXPreparePosForPullStripFromMBStep2.ToString();
            //this.teHookXPosForPullStripFormMBStep2.Text = _selRecipe.HookXPosForPullStripFromMBStep2.ToString();
            //this.teHookZPosForPushStripToChuck.Text = _selRecipe.HookAxisZPosForPushStripToChuck.ToString();
            //this.teHookXPreparePosForPushStripToChuckStep1.Text = _selRecipe.HookAxisXPreparePosForPushStripToChuckStep1.ToString();
            //this.teHookXPosForPushStripToChuckStep1.Text = _selRecipe.HookAxisXPosForPushStripToChuckStep1.ToString();
            //this.teHookZPreparePosForPushStripToChuck.Text = _selRecipe.HookAxisZPreparePosForPushStripToChuck.ToString();
            //this.teHookXPreparePosForPushStripToChuckStep2.Text = _selRecipe.HookAxisXPreparePosForPushStripToChuckStep2.ToString();
            //this.teHookXPosForPushStripToChuckStep2.Text = _selRecipe.HookAxisXPosForPushStripToChuckStep2.ToString();
            //this.teTrackXPosForPullStripFromMB.Text = _selRecipe.TrackXPosForPickStripFromMaterialbox.ToString();
            //this.teTrackXPosForPushStripToChuck.Text = _selRecipe.TrackXPosForPlaceStripToChuck.ToString();
            //this.teHookXIdlePosForStrip.Text = _selRecipe.HookAxisXIdlePosForStrip.ToString();
            //this.teHookZIdlePosForStrip.Text = _selRecipe.HookAxisZIdlePosForStrip.ToString();
            //this.teTrackXIdlePosForStrip.Text = _selRecipe.TrackXIdlePosForStrip.ToString();
            //this.teChuckLoadLidPosX.Text = _selRecipe.LidChuckLoadPosition.X.ToString();
            //this.teChuckLoadLidPosY.Text = _selRecipe.LidChuckLoadPosition.Y.ToString();
            //this.teChuckLoadShellPosX.Text = _selRecipe.ShellChuckLoadPosition.X.ToString();
            //this.teChuckLoadShellPosY.Text = _selRecipe.ShellChuckLoadPosition.Y.ToString();

        }
        private void SetParameters(TransportRecipe recipe=null)
        {
            //if (recipe == null)
            //{
            //    _selRecipe.HookAxisZPreparePosForPullMaterialBox = float.Parse(this.teHookZPreparePosForPullMB.Text);
            //    _selRecipe.HookAxisXPreparePosForPullMBStep1 = float.Parse(this.teHookXPreparePosForPullMBStep1.Text);
            //    _selRecipe.HookAxisZPosForPullMaterialBox = float.Parse(this.teHookZPosForPullMB.Text);
            //    _selRecipe.HookAxisXPosForPullMBStep1 = float.Parse(this.teHookXPullHalfPosForMBStep1.Text);
            //    _selRecipe.HookAxisXPreparePosForPullMBStep2 = float.Parse(this.teHookXPreparePosForPullMBStep2.Text);


            //    _selRecipe.HookAxisXPosForPullMBStep2 = float.Parse(this.teHookXPosForPullMBStep2.Text);
            //    _selRecipe.HookAxisZPosForPushMaterialbox = float.Parse(this.teHookZPosForPushMB.Text);
            //    _selRecipe.HookAxisXPreparePosForPushMBStep1 = float.Parse(this.teHookXPreparePosForPushMBStep1.Text);
            //    _selRecipe.HookAxisXPosForPushMBStep1 = float.Parse(this.teHookXPosForPushMBStep1.Text);
            //    _selRecipe.HookAxisZPreparePosForPushMaterialbox = float.Parse(this.teHookZPreparePushWholePosForMB.Text);
            //    _selRecipe.HookAxisXPreparePosForPushMBStep2 = float.Parse(this.teHookXPreparePosForPushMBStep2.Text);
            //    _selRecipe.HookAxisXPosForPushMBStep2 = float.Parse(this.teHookXPosForPushMBStep2.Text);
            //    _selRecipe.TrackXPosForPullMaterialBox = float.Parse(this.teTrackXPosForPullMaterialBox.Text);
            //    _selRecipe.TrackXPosForPushMaterialBox = float.Parse(this.teTrackXPosForPushMaterialBox.Text);
            //    _selRecipe.HookAxisXIdlePosForMaterialbox = float.Parse(this.teHookXIdlePosForMB.Text);
            //    _selRecipe.HookAxisZIdlePosForMaterialbox = float.Parse(this.teHookZIdlePosForMB.Text);
            //    _selRecipe.TrackXIdlePosForMaterialBox = float.Parse(this.teTrackXIdlePosForMB.Text);
            //    _selRecipe.BufferLifterPosForLoadMaterialbox = float.Parse(this.teLifterPosForLoadMB.Text);
            //    _selRecipe.BufferLifterPosForUnloadMaterialbox = float.Parse(this.teLifterPosForUnloadMB.Text);


            //    _selRecipe.HookZPreparePosForPullStripFromMB = float.Parse(this.teHookZPreparePosForPullStripFormMB.Text);
            //    _selRecipe.HookXPreparePosForPullStripFromMBStep1 = float.Parse(this.teHookXPreparePosForPullStripFormMBStep1.Text);
            //    _selRecipe.HookZPosForPullStripFromMB = float.Parse(this.teHookZPosForPullStripFormMB.Text);
            //    _selRecipe.HookXPosForPullStripFromMBStep1 = float.Parse(this.teHookXPosForPullStripFormMBStep1.Text);
            //    _selRecipe.HookXPreparePosForPullStripFromMBStep2 = float.Parse(this.teHookXPreparePosForPullStripFormMBStep2.Text);
            //    _selRecipe.HookXPosForPullStripFromMBStep2 = float.Parse(this.teHookXPosForPullStripFormMBStep2.Text);
            //    _selRecipe.HookAxisZPosForPushStripToChuck = float.Parse(this.teHookZPosForPushStripToChuck.Text);
            //    _selRecipe.HookAxisXPreparePosForPushStripToChuckStep1 = float.Parse(this.teHookXPreparePosForPushStripToChuckStep1.Text);
            //    _selRecipe.HookAxisXPosForPushStripToChuckStep1 = float.Parse(this.teHookXPosForPushStripToChuckStep1.Text);
            //    _selRecipe.HookAxisZPreparePosForPushStripToChuck = float.Parse(this.teHookZPreparePosForPushStripToChuck.Text);
            //    _selRecipe.HookAxisXPreparePosForPushStripToChuckStep2 = float.Parse(this.teHookXPreparePosForPushStripToChuckStep2.Text);
            //    _selRecipe.HookAxisXPosForPushStripToChuckStep2 = float.Parse(this.teHookXPosForPushStripToChuckStep2.Text);
            //    _selRecipe.TrackXPosForPickStripFromMaterialbox = float.Parse(this.teTrackXPosForPullStripFromMB.Text);
            //    _selRecipe.TrackXPosForPlaceStripToChuck = float.Parse(this.teTrackXPosForPushStripToChuck.Text);
            //    _selRecipe.HookAxisXIdlePosForStrip = float.Parse(this.teHookXIdlePosForStrip.Text);
            //    _selRecipe.HookAxisZIdlePosForStrip = float.Parse(this.teHookZIdlePosForStrip.Text);
            //    _selRecipe.TrackXIdlePosForStrip = float.Parse(this.teTrackXIdlePosForStrip.Text);
            //    _selRecipe.LidChuckLoadPosition.X = float.Parse(this.teChuckLoadLidPosX.Text);
            //    _selRecipe.LidChuckLoadPosition.Y = float.Parse(this.teChuckLoadLidPosY.Text);
            //    _selRecipe.ShellChuckLoadPosition.X = float.Parse(this.teChuckLoadShellPosX.Text);
            //    _selRecipe.ShellChuckLoadPosition.Y = float.Parse(this.teChuckLoadShellPosY.Text);
            //}
            //else
            //{
            //    recipe.HookAxisZPreparePosForPullMaterialBox = float.Parse(this.teHookZPreparePosForPullMB.Text);
            //    recipe.HookAxisXPreparePosForPullMBStep1 = float.Parse(this.teHookXPreparePosForPullMBStep1.Text);
            //    recipe.HookAxisZPosForPullMaterialBox = float.Parse(this.teHookZPosForPullMB.Text);
            //    recipe.HookAxisXPosForPullMBStep1 = float.Parse(this.teHookXPullHalfPosForMBStep1.Text);
            //    recipe.HookAxisXPreparePosForPullMBStep2 = float.Parse(this.teHookXPreparePosForPullMBStep2.Text);


            //    recipe.HookAxisXPosForPullMBStep2 = float.Parse(this.teHookXPosForPullMBStep2.Text);
            //    recipe.HookAxisZPosForPushMaterialbox = float.Parse(this.teHookZPosForPushMB.Text);
            //    recipe.HookAxisXPreparePosForPushMBStep1 = float.Parse(this.teHookXPreparePosForPushMBStep1.Text);
            //    recipe.HookAxisXPosForPushMBStep1 = float.Parse(this.teHookXPosForPushMBStep1.Text);
            //    recipe.HookAxisZPreparePosForPushMaterialbox = float.Parse(this.teHookZPreparePushWholePosForMB.Text);
            //    recipe.HookAxisXPreparePosForPushMBStep2 = float.Parse(this.teHookXPreparePosForPushMBStep2.Text);
            //    recipe.HookAxisXPosForPushMBStep2 = float.Parse(this.teHookXPosForPushMBStep2.Text);
            //    recipe.TrackXPosForPullMaterialBox = float.Parse(this.teTrackXPosForPullMaterialBox.Text);
            //    recipe.TrackXPosForPushMaterialBox = float.Parse(this.teTrackXPosForPushMaterialBox.Text);
            //    recipe.HookAxisXIdlePosForMaterialbox = float.Parse(this.teHookXIdlePosForMB.Text);
            //    recipe.HookAxisZIdlePosForMaterialbox = float.Parse(this.teHookZIdlePosForMB.Text);
            //    recipe.TrackXIdlePosForMaterialBox = float.Parse(this.teTrackXIdlePosForMB.Text);
            //    recipe.BufferLifterPosForLoadMaterialbox = float.Parse(this.teLifterPosForLoadMB.Text);
            //    recipe.BufferLifterPosForUnloadMaterialbox = float.Parse(this.teLifterPosForUnloadMB.Text);


            //    recipe.HookZPreparePosForPullStripFromMB = float.Parse(this.teHookZPreparePosForPullStripFormMB.Text);
            //    recipe.HookXPreparePosForPullStripFromMBStep1 = float.Parse(this.teHookXPreparePosForPullStripFormMBStep1.Text);
            //    recipe.HookZPosForPullStripFromMB = float.Parse(this.teHookZPosForPullStripFormMB.Text);
            //    recipe.HookXPosForPullStripFromMBStep1 = float.Parse(this.teHookXPosForPullStripFormMBStep1.Text);
            //    recipe.HookXPreparePosForPullStripFromMBStep2 = float.Parse(this.teHookXPreparePosForPullStripFormMBStep2.Text);
            //    recipe.HookXPosForPullStripFromMBStep2 = float.Parse(this.teHookXPosForPullStripFormMBStep2.Text);
            //    recipe.HookAxisZPosForPushStripToChuck = float.Parse(this.teHookZPosForPushStripToChuck.Text);
            //    recipe.HookAxisXPreparePosForPushStripToChuckStep1 = float.Parse(this.teHookXPreparePosForPushStripToChuckStep1.Text);
            //    recipe.HookAxisXPosForPushStripToChuckStep1 = float.Parse(this.teHookXPosForPushStripToChuckStep1.Text);
            //    recipe.HookAxisZPreparePosForPushStripToChuck = float.Parse(this.teHookZPreparePosForPushStripToChuck.Text);
            //    recipe.HookAxisXPreparePosForPushStripToChuckStep2 = float.Parse(this.teHookXPreparePosForPushStripToChuckStep2.Text);
            //    recipe.HookAxisXPosForPushStripToChuckStep2 = float.Parse(this.teHookXPosForPushStripToChuckStep2.Text);
            //    recipe.TrackXPosForPickStripFromMaterialbox = float.Parse(this.teTrackXPosForPullStripFromMB.Text);
            //    recipe.TrackXPosForPlaceStripToChuck = float.Parse(this.teTrackXPosForPushStripToChuck.Text);
            //    recipe.HookAxisXIdlePosForStrip = float.Parse(this.teHookXIdlePosForStrip.Text);
            //    recipe.HookAxisZIdlePosForStrip = float.Parse(this.teHookZIdlePosForStrip.Text);
            //    recipe.TrackXIdlePosForStrip = float.Parse(this.teTrackXIdlePosForStrip.Text);
            //    recipe.LidChuckLoadPosition.X = float.Parse(this.teChuckLoadLidPosX.Text);
            //    recipe.LidChuckLoadPosition.Y = float.Parse(this.teChuckLoadLidPosY.Text);
            //    recipe.ShellChuckLoadPosition.X = float.Parse(this.teChuckLoadShellPosX.Text);
            //    recipe.ShellChuckLoadPosition.Y = float.Parse(this.teChuckLoadShellPosY.Text);
            //}
        }

        private void btnAutoCal_Click(object sender, EventArgs e)
        {

        }
    }

}
