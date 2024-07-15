using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;
using RecipeClsLib;
using WestDragon.Framework.UtilityHelper;
using GlobalDataDefineClsLib;
using System.Diagnostics;
using ConfigurationClsLib;
using CameraControllerClsLib;
using WestDragon.Framework.BaseLoggerClsLib;
using PowerControllerManagerClsLib;
using VisionDesigner;
using GlobalToolClsLib;
using CommonPanelClsLib;
using CameraControllerWrapperClsLib;

namespace JobClsLib
{
    /// <summary>
    /// 
    /// </summary>
    internal class AutoBondJob : ABondJob
    {

        private int _processedLidCounter = 0;
        private int _processedShellCounter = 0;
        private bool _pointWeldFinish = false;
        private int _currentShellRow = 0;
        private int _currentShellColumn = 0;
        private int _currentLidRow = 0;
        private int _currentLidColumn = 0;


        /// <summary>
        /// Recipe存放系统默认路径
        /// </summary>
        public static string SystemDefaultDirectory = GlobalParamSetting.CONFIG_FILE_DEFAULT_DIR;
        public JobResult JobResult { get; set; }
        private GWPowerControl _powerController
        {
            get
            {
                var controller = PowerControllerManager.Instance.GetCurrentHardware();
                if (controller != null)
                {
                    return controller as GWPowerControl;
                }
                return null;
            }
        }
        private CameraConfig _cameraConfig
        {
            get { return CameraManager.Instance.CurrentCameraConfig; }
        }
        /// <summary>
        /// 传片流程规划器
        /// </summary>
        private MaterialTranferPlanner _transferPlanner = null;
        /// <summary>
        /// 
        /// </summary>
        public AutoBondJob()
        {
            _statusChecker = new RunStatusController();
            _transferPlanner = new MaterialTranferPlanner();
            try
            {
                //var lidShapeMatcher = new GWShapeMatch();
                //_lidPositionDetector = new PositionDetectProcesser(lidShapeMatcher);
                //var ShellShapeMatcher = new GWShapeMatch();
                //_shellPositionDetector = new PositionDetectProcesser(ShellShapeMatcher);
            }
            catch (MvdException ex)
            {
                WarningBox.FormShow("运行环境异常。", ex.Message, "提示");
            }
            catch (Exception ex)
            {
                LogRecorder.RecordLog(EnumLogContentType.Error, "Contruct WeldProcessJob Fail.", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void RunBeforeJob()
        {
            _processedLidCounter = 0;
            _processedShellCounter = 0;
            _pointWeldFinish = false;
            RawDataSavingPath = GenerateDataSavingPath();
            JobResult = new JobResult();
            Queue<MaterialMapInformation> components = new Queue<MaterialMapInformation>();
            foreach (var item in _currentRecipe.CurrentComponent.ComponentMapInfos)
            {
                components.Enqueue(item);
            }
            _actionForComponentQueue = _transferPlanner.PlanComponentTransferActionQueue(components);
            Queue<MaterialMapInformation> submounts = new Queue<MaterialMapInformation>();
            foreach (var item in _currentRecipe.SubmonutInfos.SubmountMapInfos)
            {
                submounts.Enqueue(item);
            }
            _actionForSubmountQueue = _transferPlanner.PlanSubmountTransferActionQueue(submounts);
            //if (_lidPositionDetector == null)
            //{
            //    var lidShapeMatcher = new GWShapeMatch();
            //    _lidPositionDetector = new PositionDetectProcesser(lidShapeMatcher);
            //}
            //if (_shellPositionDetector == null)
            //{
            //    var ShellShapeMatcher = new GWShapeMatch();
            //    _shellPositionDetector = new PositionDetectProcesser(ShellShapeMatcher);
            //}
            SetRumParameters();
        }
        public override void PrepareJob(BondRecipe recipe, bool isFirst)
        {

        }

        private float CorrectRecogniseAngle(float rawAngle)
        {

            var correctAngle = rawAngle % 90;

            // If the actual angle is greater than 45 or less than -45, 
            // map it to the equivalent angle in the range -45 to 45
            if (correctAngle > 45)
            {
                correctAngle = correctAngle - 90;
            }
            else if (correctAngle < -45)
            {
                correctAngle = correctAngle + 90;
            }
            LogRecorder.RecordLog(EnumLogContentType.Debug, $"CorrectRecogniseAngle.<rawAngle:{rawAngle},correctAngle:{correctAngle}.>");
            return correctAngle;
        }
        

        private void TurnOffLights()
        {
            try
            {
                //if (!_statusChecker.IsRunning) { return; }
                //_hardWareManager.ShellDarkField.SetIntensity(0);
                //_hardWareManager.ShellBrightField.SetIntensity(0);
                //_hardWareManager.LidDarkField.SetIntensity(0);
                //_hardWareManager.LidBrightField.SetIntensity(0);
            }
            catch (Exception ex)
            {
                //应用检测照明参数异常，退出检测流程
                //this.Abort();
                LogRecorder.RecordLog(EnumLogContentType.Error, "Errors occured While TurnOff Lights.",ex);
            }

        }
        /// <summary>
        /// 生成数据存储目录
        /// </summary>
        /// <returns></returns>
        protected override string GenerateDataSavingPath()
        {
            try
            {
                string dateString = System.DateTime.Now.ToString("yyyyMMdd");
                string timeString = System.DateTime.Now.ToString("HHmmss");
                string path = _systemConfig.RawDataSavePath;
                string lotId = JobInfosManager.Instance.CurrentJobMaterialStripSourceInfo.LotId;
                string materialStripId = JobInfosManager.Instance.CurrentJobMaterialStripSourceInfo.MaterialStripId;
                string slotId = JobInfosManager.Instance.CurrentJobMaterialStripSourceInfo.SourceSlotIndex;
                path = Path.Combine(path, _currentRecipe.RecipeName, lotId);
                string parentPath = Path.Combine(path, dateString, "L" + slotId + "-" + materialStripId + "-" + timeString);
                var rawDataSavingPath = Path.Combine(parentPath, @"Data");
                CommonProcess.EnsureFolderExist(rawDataSavingPath);
                return rawDataSavingPath;
            }
            catch (Exception ex)
            {
                LogRecorder.RecordLog(EnumLogContentType.Error, "Create Saving FilePath failed.", ex);
                throw (ex);
            }
        }




        /// <summary>
        /// 初始化WaferJob
        /// </summary>
        public override void InitialJob()
        {
            try
            {
                _actionForSubmountQueue = new Queue<SubmountTransferInfo>();
                _actionForSubmountQueue = new Queue<SubmountTransferInfo>();
                //初始化完成
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                IsInitialized = false;
                LogRecorder.RecordLog(EnumLogContentType.Error, "Initial Job failed.", ex);
            }
        }
        /// <summary>
        /// 流程动作队列
        /// </summary>
        private Queue<ComponentTransferInfo> _actionForComponentQueue;
        /// <summary>
        /// 流程动作队列
        /// </summary>
        private Queue<SubmountTransferInfo> _actionForSubmountQueue;
        /// <summary>
        /// 运行WaferJob
        /// </summary>
        /// <param name="recipe"></param>
        public override void RunProcessJob(BondRecipe recipe, int index = 0, bool isTestRecipe = false)
        {
            ReportJobRunningStatus(EnumBondJobStatus.Running, "准备开始...");
            //------流程开始---------------
            this._statusChecker.Start();
            this._isCompleted = false;
            List<Tuple<int, int, PointF, float>> shellPositionInfo = new List<Tuple<int, int, PointF, float>>();
            this._currentRecipe = recipe;
            RunBeforeJob();

            Task.Factory.StartNew(new Action(() =>
            {
                this._currentRecipe = recipe;
                try
                {
                    if (UIOperation != null)
                    {
                        UIOperation();
                    }
                    //循环执行流程队列
                    while (_actionForSubmountQueue.Count>0 && _statusChecker.IsRunning)
                    {
                        var actionForSubmount = _actionForSubmountQueue.Dequeue();
                        ExecuteTransferAction(actionForSubmount.TransferAction);
                        if (actionForSubmount.TransferAction == EnumTransferAction.PlaceSubmounttoChuck)
                        {
                            while (_actionForComponentQueue.Count > 0 && _statusChecker.IsRunning)
                            {
                                var actionForComponent = _actionForComponentQueue.Dequeue();
                                ExecuteTransferAction(actionForComponent.TransferAction);
                                if (actionForComponent.TransferAction == EnumTransferAction.PlaceComponent)
                                {
                                    break;
                                }
                                //如果芯片取完，且基板还有未处理的，则人工干预重新选择芯片区域
                                if (false)
                                {
                                    ManualSelectComponent();
                                }
                            }
                        }

                        if(_actionForSubmountQueue.Count==0)
                        {
                            break;
                        }
                    }
                    MarkJobCompleted();
                    ReportJobRunningStatus(EnumBondJobStatus.ProcessCompleted, "流程完成.");
                    if (NotifyProcessCompleted != null)
                    {
                        NotifyProcessCompleted(JobResult);
                    }


                }
                catch (Exception ex)
                {
                    this.Abort();
                    LogRecorder.RecordLog(EnumLogContentType.Error, "Exception occured during job.", ex);
                    ReportJobRunningStatus(EnumBondJobStatus.ProcessError, "启动流程异常！");
                }
            }));
        }
        private void ManualSelectComponent()
        {

        }
        private void PlanComponentPath()
        {

        }
        public override void Abort()
        {
            base.Abort();

            TurnOffLights();
        }

        private void SetRumParameters()
        {
            
        }

        private void DoWeld()
        {

        }



        /// <summary>
        /// 等待下位发出的识别盖板的请求
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>



        private void PickLid()
        {
        }
        private void PlaceLid()
        {
        }
        private void SetPointWeldPowerParameter()
        {
            if(_powerController!=null)
            {
            }
            else
            {
                LogRecorder.RecordLog(EnumLogContentType.Error, "Power Controller is NULL!");
            }
        }

        private object _visionSafeObj = new object();
        private AutoResetEvent _visionSafeEvent = new AutoResetEvent(true);
        public void ChangeCurrentCamera(EnumCameraType type)
        {
            if(BeforeCameraChangeAct!=null)
            {
                BeforeCameraChangeAct();
            }
            CameraManager.Instance.CurrentCameraType = type;
            if (AfterCameraChangeAct != null)
            {
                AfterCameraChangeAct();
            }
        }

        /// <returns></returns>
        private bool ExecuteTransferAction(EnumTransferAction cmd)
        {
            switch (cmd)
            {
                case EnumTransferAction.PositionSubmountBeforePickFromSubstrate:
                    break;
                case EnumTransferAction.PickSubmountFromSubstrate:
                    break;
                case EnumTransferAction.AccuracySubmountPosition:
                    break;
                case EnumTransferAction.PlaceSubmounttoChuck:
                    break;
                case EnumTransferAction.PositionBeforeBond:
                    break;
                case EnumTransferAction.PositionSubmountBeforePickFromChuck:
                    break;
                case EnumTransferAction.PickSubmountFromChuck:
                    break;
                case EnumTransferAction.PlaceSubmounttoSubstrate:
                    break;
                case EnumTransferAction.PositionComponent:
                    break;
                case EnumTransferAction.PickComponent:
                    break;
                case EnumTransferAction.AccuracyComponentPosition:
                    break;
                case EnumTransferAction.PlaceComponent:
                    break;
                default:
                    break;
            }

            return true;
        }
    }

}
