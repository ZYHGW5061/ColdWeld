
using DevExpress.XtraEditors;
using GlobalDataDefineClsLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VisionClsLib;
using VisionControlAppClsLib;

namespace VisionGUI
{
    public partial class VisualMatchControlGUI : XtraUserControl
    {
        #region Private File

        //private static readonly object _lockObj = new object();
        //private static volatile VisualMatchControlGUI _instance = null;
        //public static VisualMatchControlGUI Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            lock (_lockObj)
        //            {
        //                if (_instance == null)
        //                {
        //                    _instance = new VisualMatchControlGUI();
        //                }
        //            }
        //        }
        //        return _instance;
        //    }
        //}

        VisualControlApplications VisualApp;

        CameraWindowGUI CameraWindow;

        public bool ImageShow = false;


        #endregion

        #region 算法参数

        private int _RingLightintensity = 0;
        private int _DirectLightintensity = 0;
        private float _Score = 0.5f;
        private int _MinAngle = -15;
        private int _MaxAngle = 15;

        private PointF Benchmark = new PointF(-1, -1);

        private RectangleF _TemplateRoi;
        private RectangleF _SearchRoi;

        bool TemplateRoiMove = false;
        bool TemplateRoiResize = false;
        bool SearchRoiMove = false;
        bool SearchRoiResize = false;
        bool OutlineMove = false;
        bool OutlineRotate = false;

        public int RoiMoveInterval = 16;
        public int RoiResizeInterval = 16;
        public float OutlineRotateInterval = 0.5f;

        private string _MatchTemplatefilepath;
        private string _MatchRunfilepath;

        private MatchTemplateResult _Templateresult = new MatchTemplateResult();
        private PointF _OutlineDeviation = new PointF();
        private float _OutlineAngle = 0.0f;

        public bool Inited = false;

        private MatchResult matchresult = null;

        #endregion

        #region 轮廓识别属性

        /// <summary>
        /// 环光强度
        /// </summary>
        public int RingLightintensity 
        { 
            get
            {
                return _RingLightintensity;
            }
            set
            {

                RingLightBar.Value = value;
                RingLightNumlabel.Text = value.ToString();
                _RingLightintensity = value;
                if (VisualApp != null)
                {
                    if (value > -1 && value < 256)
                    {
                        VisualApp.SetRingLightintensity(value);
                    }
                }
            }
        }

        /// <summary>
        /// 直光强度
        /// </summary>
        public int DirectLightintensity
        {
            get
            {
                return _DirectLightintensity;
            }
            set
            {

                DirectLightBar.Value = value;
                DirectLightNumlabel.Text = value.ToString();
                _DirectLightintensity = value;
                if (VisualApp != null)
                {
                    if (value > -1 && value < 256)
                    {
                        VisualApp.SetDirectLightintensity(value);
                    }
                }
            }
        }

        /// <summary>
        /// 识别分数
        /// </summary>
        public float Score
        {
            get
            {
                return _Score;
            }
            set
            {
                QualityBar.Value = (int)(value * 100);
                MinimunqualityNumlabel.Text = value.ToString();
                _Score = value;
            }
        }

        /// <summary>
        /// 角度范围
        /// </summary>
        public int AngleRange
        {
            get
            {
                return _MaxAngle;
            }
            set
            {
                AngleBar.Value = value;
                _MinAngle = -value;
                _MaxAngle = +value;
                AngleDeviationNumlabel.Text = value.ToString();
            }
        }

        /// <summary>
        /// 训练区域
        /// </summary>
        public RectangleFV TemplateRoi
        {
            get
            {
                RectangleFV rectangle = new RectangleFV();
                rectangle.X = _TemplateRoi.X;
                rectangle.Y = _TemplateRoi.Y;
                rectangle.Width = _TemplateRoi.Width;
                rectangle.Height = _TemplateRoi.Height;

                return rectangle;
            }
            set
            {
                RectangleF rectangle = new RectangleF(value.X, value.Y, value.Width, value.Height);
                _TemplateRoi = rectangle;
            }
        }

        /// <summary>
        /// 识别区域
        /// </summary>
        public RectangleFV SearchRoi
        {
            get
            {
                RectangleFV rectangle = new RectangleFV();
                rectangle.X = _SearchRoi.X;
                rectangle.Y = _SearchRoi.Y;
                rectangle.Width = _SearchRoi.Width;
                rectangle.Height = _SearchRoi.Height;

                return rectangle;
            }
            set
            {
                RectangleF rectangle = new RectangleF(value.X, value.Y, value.Width, value.Height);
                _SearchRoi = rectangle;
            }
        }

        /// <summary>
        /// 训练结果
        /// </summary>
        public MatchTemplateResult Templateresult
        {
            get
            {
                return _Templateresult;
            }
            set
            {
                _Templateresult = value;
            }
        }

        /// <summary>
        /// 轮廓偏移
        /// </summary>
        public PointF OutlineDeviation
        {
            get
            {
                return _OutlineDeviation;
            }
            set
            {
                _OutlineDeviation = value;
            }
        }

        /// <summary>
        /// 轮廓角度
        /// </summary>
        public float OutlineAngle
        {
            get
            {
                return _OutlineAngle;
            }
            set
            {
                _OutlineAngle = value;
            }
        }

        /// <summary>
        /// 训练模板路径
        /// </summary>
        public string MatchTemplatefilepath
        {
            get
            {
                if (string.IsNullOrEmpty(_MatchTemplatefilepath))
                    return _MatchTemplatefilepath;

                Uri basePath = new Uri(AppDomain.CurrentDomain.BaseDirectory);
                Uri filePath = new Uri(_MatchTemplatefilepath);
                return basePath.MakeRelativeUri(filePath).ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _MatchTemplatefilepath = value;
                }
                else
                {
                    _MatchTemplatefilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, value);
                }
            }
        }

        /// <summary>
        /// 识别参数路径
        /// </summary>
        public string MatchRunfilepath
        {
            get
            {
                if (string.IsNullOrEmpty(_MatchRunfilepath))
                    return _MatchRunfilepath;

                Uri basePath = new Uri(AppDomain.CurrentDomain.BaseDirectory);
                Uri filePath = new Uri(_MatchRunfilepath);
                return basePath.MakeRelativeUri(filePath).ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _MatchRunfilepath = value;
                }
                else
                {
                    _MatchRunfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, value);
                }
            }
        }

        /// <summary>
        /// 识别结果
        /// </summary>
        public MatchResult Matchresult
        {
            get
            { 
                return matchresult;
            }
            set
            {
                matchresult = value;
            }
        }

        #endregion

        #region 相机视窗控制

        public void CameraWindowShow(Graphic graphic, bool Show)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.GraphicDraw(graphic, Show);
        }

        public void RoiResize(ImageDirection Direct, int interval)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.ROIReSize(Direct, interval);
        }

        public void RoiMove(ImageDirection Direct, int interval)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.ROIMove(Direct, interval);
        }
        public void MatchMove(float DeviationX, float DeviationY, float Angle)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.MatchMove(DeviationX, DeviationY, Angle);
        }

        public void CameraWindowShowInit(RectangleF rect)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.GraphicDrawInit(rect);
        }

        public RectangleF GetROI()
        {
            if (ImageShow && CameraWindow != null)
                return CameraWindow.GetROI();
            else
                return RectangleF.Empty;
        }

        public void CircleRoiResize(int interval)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.CircleROIReSize(interval);
        }

        public void CircleRoiMove(ImageDirection Direct, int interval)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.CircleROIMove(Direct, interval);
        }

        public void CameraWindowShowInit(PointF Center, float Radius)
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.GraphicDrawInit(Center, Radius);
        }

        public (PointF Center, float Radius) GetCircleROI()
        {
            if (ImageShow && CameraWindow != null)
                return CameraWindow.GetCircleROI();
            else
                return (PointF.Empty, -1);
        }

        public void CameraWindowClear()
        {
            if (ImageShow && CameraWindow != null)
                CameraWindow.ClearGraphicDraw();
        }

        #endregion


        public VisualMatchControlGUI()
        {
            InitializeComponent();

            _TemplateRoi = new RectangleF();
            _SearchRoi = new RectangleF();

            string currentDirectory = Directory.GetCurrentDirectory();
            string newFilePath = Path.Combine(currentDirectory, "MatchTemplate.contourmxml");
            _MatchTemplatefilepath = newFilePath;

            newFilePath = Path.Combine(currentDirectory, "MatchRun.contourmxml");
            _MatchRunfilepath = newFilePath;

            
        }

        public void InitVisualControl(CameraWindowGUI CameraWindow, VisualControlApplications VisualApp)
        {
            if (CameraWindow == null || VisualApp == null)
            {
                Inited = false;
                return;
            }
            this.VisualApp = VisualApp;
            this.CameraWindow = CameraWindow;

            ImageShow = true;

            _TemplateRoi = GetROI();
            _SearchRoi = GetROI();

            Inited = true;
            
        }

        public bool InitForm()
        {
            try
            {
                if(VisualApp != null)
                {
                    int RingInt = VisualApp.GetRingLightintensity();

                    int DirectInt = VisualApp.GetDirectLightintensity();

                    RingLightBar.Value = RingInt;
                    RingLightNumlabel.Text = RingInt.ToString();
                    _RingLightintensity = RingInt;

                    DirectLightBar.Value = DirectInt;
                    DirectLightNumlabel.Text = DirectInt.ToString();
                    _DirectLightintensity = DirectInt;

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetVisualParam(GlobalDataDefineClsLib.MatchIdentificationParam param)
        {
            this.RingLightintensity = param.RingLightintensity;
            this.DirectLightintensity = param.DirectLightintensity;
            this.Score = param.Score;
            this.AngleRange = param.MaxAngle;
            this.TemplateRoi = param.TemplateRoi;
            this.SearchRoi = param.SearchRoi;
            //this.Templateresult = param.Templateresult;
            this.MatchTemplatefilepath = param.Templatexml;
            this.MatchRunfilepath = param.Runxml;
        }

        public GlobalDataDefineClsLib.MatchIdentificationParam GetVisualParam()
        {
            GlobalDataDefineClsLib.MatchIdentificationParam param1 = new GlobalDataDefineClsLib.MatchIdentificationParam();

            param1.RingLightintensity = this.RingLightintensity;
            param1.DirectLightintensity = this.DirectLightintensity;
            param1.Score = this.Score;
            param1.MaxAngle = this.AngleRange;
            param1.TemplateRoi = this.TemplateRoi;
            param1.SearchRoi = this.SearchRoi;
            //param1.Templateresult = this.Templateresult;
            param1.Templatexml = this.MatchTemplatefilepath;
            param1.Runxml = this.MatchRunfilepath;

            return param1;
        }


        private void RingLightBar_Scroll(object sender, EventArgs e)
        {
            int value = RingLightBar.Value;
            if(VisualApp != null)
            {
                if (value > -1 && value < 256)
                {
                    VisualApp.SetRingLightintensity(value);
                    RingLightNumlabel.Text = value.ToString();
                    _RingLightintensity = value;
                }
            }
            
        }

        private void DirectLightBar_Scroll(object sender, EventArgs e)
        {
            int value = DirectLightBar.Value;
            if (VisualApp != null)
            {
                if (value > -1 && value < 256)
                {
                    VisualApp.SetDirectLightintensity(value);
                    DirectLightNumlabel.Text = value.ToString();
                    _DirectLightintensity = value;
                }
            }
        }

        private void QualityBar_Scroll(object sender, EventArgs e)
        {
            int value = QualityBar.Value;

            _Score = (float)(value) / 100.0f;

            MinimunqualityNumlabel.Text = _Score.ToString();
        }

        private void AngleBar_Scroll(object sender, EventArgs e)
        {
            _MinAngle = -(AngleBar.Value);
            _MaxAngle = +(AngleBar.Value);

            AngleDeviationNumlabel.Text = _MaxAngle.ToString();
        }

        private void TemplateRoiShowBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (VisualApp != null)
            {
                CameraWindowShowInit(_TemplateRoi);
                CameraWindowShow(Graphic.rectRoi, TemplateRoiShowBtn.Checked);
            }
                
        }

        private void SearchAreaRoiShowBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (VisualApp != null)
            {
                CameraWindowShowInit(_SearchRoi);
                CameraWindowShow(Graphic.rectRoi, SearchAreaRoiShowBtn.Checked);
            }
        }
        private void OutlineShowBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (VisualApp != null)
            {
                if (_Templateresult != null)
                {
                    CameraWindow.GraphicDrawInit(_Templateresult.Points, _Templateresult.Center);

                    CameraWindow.GraphicDraw(Graphic.train, OutlineShowBtn.Checked);
                }
            }
        }

        private void TemplateMoveBtn_CheckedChanged(object sender, EventArgs e)
        {
            TemplateRoiMove = TemplateMoveBtn.Checked;
            if(TemplateRoiMove)
            {
                if(TemplateResizeBtn.Checked)
                {
                    TemplateResizeBtn.Checked = false;
                    TemplateRoiResize = false;
                }
                if (SearchAreaMoveBtn.Checked)
                {
                    SearchAreaMoveBtn.Checked = false;
                    SearchRoiMove = false;
                }
                if (SearchAreaResizeBtn.Checked)
                {
                    SearchAreaResizeBtn.Checked = false;
                    SearchRoiResize = false;
                }
            }
        }

        private void TemplateResizeBtn_CheckedChanged(object sender, EventArgs e)
        {
            TemplateRoiResize = TemplateResizeBtn.Checked;
            if (TemplateRoiResize)
            {
                if (TemplateMoveBtn.Checked)
                {
                    TemplateMoveBtn.Checked = false;
                    TemplateRoiMove = false;
                }
                if (SearchAreaMoveBtn.Checked)
                {
                    SearchAreaMoveBtn.Checked = false;
                    SearchRoiMove = false;
                }
                if (SearchAreaResizeBtn.Checked)
                {
                    SearchAreaResizeBtn.Checked = false;
                    SearchRoiResize = false;
                }
            }
        }

        private void SearchAreaMoveBtn_CheckedChanged(object sender, EventArgs e)
        {
            SearchRoiMove = SearchAreaMoveBtn.Checked;
            if (SearchRoiMove)
            {
                if (TemplateMoveBtn.Checked)
                {
                    TemplateMoveBtn.Checked = false;
                    TemplateRoiMove = false;
                }
                if (TemplateResizeBtn.Checked)
                {
                    TemplateResizeBtn.Checked = false;
                    TemplateRoiResize = false;
                }
                if (SearchAreaResizeBtn.Checked)
                {
                    SearchAreaResizeBtn.Checked = false;
                    SearchRoiResize = false;
                }
            }
        }

        private void SearchAreaResizeBtn_CheckedChanged(object sender, EventArgs e)
        {
            SearchRoiResize = SearchAreaResizeBtn.Checked;
            if (SearchRoiResize)
            {
                if (TemplateMoveBtn.Checked)
                {
                    TemplateMoveBtn.Checked = false;
                    TemplateRoiMove = false;
                }
                if (TemplateResizeBtn.Checked)
                {
                    TemplateResizeBtn.Checked = false;
                    TemplateRoiResize = false;
                }
                if (SearchAreaMoveBtn.Checked)
                {
                    SearchAreaMoveBtn.Checked = false;
                    SearchRoiMove = false;
                }
            }
        }

        private void VisualRoiTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage currentTab = VisualRoiTab.SelectedTab;

            if(currentTab.Text == "Template")
            {
                if (VisualApp != null)
                {
                    TemplateRoiShowBtn.Checked = true;

                    SearchAreaRoiShowBtn.Checked = false;
                }

                if (SearchAreaMoveBtn.Checked)
                {
                    SearchAreaMoveBtn.Checked = false;
                    SearchRoiMove = false;
                }
                if (SearchAreaResizeBtn.Checked)
                {
                    SearchAreaResizeBtn.Checked = false;
                    SearchRoiResize = false;
                }
                if (OutlineMoveBtn.Checked)
                {
                    OutlineMoveBtn.Checked = false;
                    OutlineMove = false;
                }
                if (OutlineRotateBtn.Checked)
                {
                    OutlineRotateBtn.Checked = false;
                    OutlineRotate = false;
                }

            }
            if (currentTab.Text == "SearchArea")
            {
                if (VisualApp != null)
                {
                    TemplateRoiShowBtn.Checked = false;

                    SearchAreaRoiShowBtn.Checked = true;
                }

                if (TemplateMoveBtn.Checked)
                {
                    TemplateMoveBtn.Checked = false;
                    TemplateRoiMove = false;
                }
                if (TemplateResizeBtn.Checked)
                {
                    TemplateResizeBtn.Checked = false;
                    TemplateRoiResize = false;
                }
                if (OutlineMoveBtn.Checked)
                {
                    OutlineMoveBtn.Checked = false;
                    OutlineMove = false;
                }
                if (OutlineRotateBtn.Checked)
                {
                    OutlineRotateBtn.Checked = false;
                    OutlineRotate = false;
                }

            }
            if (currentTab.Text == "Match")
            {
                if (VisualApp != null)
                {
                    OutlineShowBtn.Checked = true;
                }

                if (TemplateMoveBtn.Checked)
                {
                    TemplateMoveBtn.Checked = false;
                    TemplateRoiMove = false;
                }
                if (TemplateResizeBtn.Checked)
                {
                    TemplateResizeBtn.Checked = false;
                    TemplateRoiResize = false;
                }
                if (SearchAreaMoveBtn.Checked)
                {
                    SearchAreaMoveBtn.Checked = false;
                    SearchRoiMove = false;
                }
                if (SearchAreaResizeBtn.Checked)
                {
                    SearchAreaResizeBtn.Checked = false;
                    SearchRoiResize = false;
                }
            }
        }

        private void VisualRoiTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (VisualApp != null)
            {
                if (e.Modifiers == Keys.Control && TemplateMoveBtn.Checked)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RoiMove(ImageDirection.Y, -RoiMoveInterval);
                            break;
                        case Keys.Down:
                            RoiMove(ImageDirection.Y, +RoiMoveInterval);
                            break;
                        case Keys.Left:
                            RoiMove(ImageDirection.X, -RoiMoveInterval);
                            break;
                        case Keys.Right:
                            RoiMove(ImageDirection.X, +RoiMoveInterval);
                            break;
                    }
                    _TemplateRoi = GetROI();
                }

                if (e.Modifiers == Keys.Control && TemplateResizeBtn.Checked)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RoiResize(ImageDirection.Y, +RoiResizeInterval);
                            break;
                        case Keys.Down:
                            RoiResize(ImageDirection.Y, -RoiResizeInterval);
                            break;
                        case Keys.Left:
                            RoiResize(ImageDirection.X, -RoiResizeInterval);
                            break;
                        case Keys.Right:
                            RoiResize(ImageDirection.X, +RoiResizeInterval);
                            break;
                    }
                    _TemplateRoi = GetROI();
                }


                if (e.Modifiers == Keys.Control && SearchAreaMoveBtn.Checked)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RoiMove(ImageDirection.Y, -RoiMoveInterval);
                            break;
                        case Keys.Down:
                            RoiMove(ImageDirection.Y, +RoiMoveInterval);
                            break;
                        case Keys.Left:
                            RoiMove(ImageDirection.X, -RoiMoveInterval);
                            break;
                        case Keys.Right:
                            RoiMove(ImageDirection.X, +RoiMoveInterval);
                            break;
                    }
                    _SearchRoi = GetROI();
                }

                if (e.Modifiers == Keys.Control && SearchAreaResizeBtn.Checked)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RoiResize(ImageDirection.Y, +RoiResizeInterval);
                            break;
                        case Keys.Down:
                            RoiResize(ImageDirection.Y, -RoiResizeInterval);
                            break;
                        case Keys.Left:
                            RoiResize(ImageDirection.X, -RoiResizeInterval);
                            break;
                        case Keys.Right:
                            RoiResize(ImageDirection.X, +RoiResizeInterval);
                            break;
                    }
                    _SearchRoi = GetROI();
                }

                if (e.Modifiers == Keys.Control && OutlineMoveBtn.Checked)
                {
                    float X = _OutlineDeviation.X;
                    float Y = _OutlineDeviation.Y;
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            MatchMove(_OutlineDeviation.X, _OutlineDeviation.Y - RoiMoveInterval, _OutlineAngle);
                            Y = _OutlineDeviation.Y - RoiMoveInterval;
                            break;
                        case Keys.Down:
                            MatchMove(_OutlineDeviation.X, _OutlineDeviation.Y + RoiMoveInterval, _OutlineAngle);
                            Y = _OutlineDeviation.Y + RoiMoveInterval;
                            break;
                        case Keys.Left:
                            MatchMove(_OutlineDeviation.X - RoiMoveInterval,_OutlineDeviation.Y, _OutlineAngle);
                            X = _OutlineDeviation.X - RoiMoveInterval;
                            break;
                        case Keys.Right:
                            MatchMove(_OutlineDeviation.X + RoiMoveInterval, _OutlineDeviation.Y, _OutlineAngle);
                            X = _OutlineDeviation.X + RoiMoveInterval;
                            break;
                    }
                    _OutlineDeviation = new PointF(X, Y);
                    _Templateresult.Deviation = new PointF(_OutlineDeviation.X, _OutlineDeviation.Y);
                }
                if (e.Modifiers == Keys.Control && OutlineRotateBtn.Checked)
                {
                    float A = _OutlineAngle;
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            MatchMove(_OutlineDeviation.X, _OutlineDeviation.Y, _OutlineAngle + OutlineRotateInterval);
                            A = _OutlineAngle + OutlineRotateInterval;
                            break;
                        case Keys.Down:
                            MatchMove(_OutlineDeviation.X, _OutlineDeviation.Y, _OutlineAngle - OutlineRotateInterval);
                            A = _OutlineAngle - OutlineRotateInterval;
                            break;
                        case Keys.Left:
                            MatchMove(_OutlineDeviation.X, _OutlineDeviation.Y, _OutlineAngle + OutlineRotateInterval);
                            A = _OutlineAngle + OutlineRotateInterval;
                            break;
                        case Keys.Right:
                            MatchMove(_OutlineDeviation.X, _OutlineDeviation.Y, _OutlineAngle - OutlineRotateInterval);
                            A = _OutlineAngle - OutlineRotateInterval;
                            break;
                    }
                    _OutlineAngle = A;
                    _Templateresult.Angle = _OutlineAngle;
                }

            }
            
        }

        private void TemplateBtn_ClickAsync(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(new Action(() =>
            //{

                if (VisualApp != null)
                {
                    VisualApp.ContinuousGetImage(false);

                    MatchTemplateResult result = new MatchTemplateResult();

                    if (Benchmark != null && Benchmark.X > 0 && Benchmark.Y > 0)
                    {
                        result = VisualApp.MatchTemplateAsync(_MatchTemplatefilepath, Benchmark, _TemplateRoi);
                    }
                    else
                    {
                        result = VisualApp.MatchTemplateAsync(_MatchTemplatefilepath, PointF.Empty, _TemplateRoi);

                        if (result != null)
                        {
                            Benchmark = result.Center;
                            BenchmarkXtextBox.Text = ((int)Benchmark.X).ToString();
                            BenchmarkYtextBox.Text = ((int)Benchmark.Y).ToString();
                        }
                    }



                    //result = await VisualApp.MatchTemplateAsync(_MatchTemplatefilepath, PointF.Empty, _TemplateRoi);



                    if (result != null && CameraWindow != null)
                    {
                        _Templateresult = result;

                        _OutlineDeviation = result.Deviation;
                        _OutlineAngle = result.Angle;

                        CameraWindow.ClearGraphicDraw();

                        CameraWindow.GraphicDrawInit(result.Points, result.Center);



                        CameraWindow.GraphicDraw(Graphic.train, true);
                    }

                    VisualApp.ContinuousGetImage(true);
                }
            //}));

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(new Action(() =>
            //{
                if (VisualApp != null)
            {
                List<MatchResult> results = new List<MatchResult>();

                VisualApp.ContinuousGetImage(false);

                bool Done = VisualApp.MatchFindInit(_MatchTemplatefilepath);

                Done = VisualApp.LoadMatchRunXml(_MatchRunfilepath);

                results = VisualApp.MatchFindAsync(_Score, _MinAngle, _MaxAngle, _SearchRoi);

                Done = VisualApp.SaveMatchRunXml(_MatchRunfilepath);

                if (results != null && CameraWindow != null && results.Count > 0)
                {
                    matchresult = results[0];

                    CameraWindow.ClearGraphicDraw();

                    CameraWindow.GraphicDrawInit(results);

                    CameraWindow.GraphicDraw(Graphic.match, true);
                }

                VisualApp.ContinuousGetImage(true);

            }
            //}));
        }

        private void CameraWindowClearBtn_Click(object sender, EventArgs e)
        {
            if (VisualApp != null)
            {
                CameraWindowClear();
            }
        }

        private void SetBenchmarkBtn_Click(object sender, EventArgs e)
        {
            //BenchmarkXtextBox.Text = ((int)Benchmark.X).ToString();
            //BenchmarkYtextBox.Text = ((int)Benchmark.Y).ToString();

            if(BenchmarkXtextBox.Text != null && BenchmarkYtextBox.Text != null)
            {
                float xValue = float.Parse(BenchmarkXtextBox.Text);
                float yValue = float.Parse(BenchmarkYtextBox.Text);
                if ((xValue > 0 && xValue < CameraWindow.ImageWidth) && (yValue > 0 && yValue < CameraWindow.ImageWidth))
                {
                    Benchmark.X = xValue;
                    Benchmark.Y = yValue;
                }


            }

            
        }
    }
}
