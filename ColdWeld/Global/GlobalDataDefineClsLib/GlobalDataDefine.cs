using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VisionClsLib;
using WestDragon.Framework.UtilityHelper;

namespace GlobalDataDefineClsLib
{
    [Serializable]
    public enum EnumRunningType { Actual, Simulated }

    [Serializable]
    public enum EnumStageAxis
    {
        [Description("无")]
        None = -1,

        [Description("料盒钩爪Y轴")]
        MaterialboxY = 1,

        [Description("料盒钩爪X轴")]
        MaterialboxX = 2,

        [Description("料盒钩爪Z轴")]
        MaterialboxZ = 3,

        [Description("料盒钩爪Theta轴")]
        MaterialboxT = 4,

        [Description("料盒钩爪开合轴")]
        MaterialboxHook = 5,

        [Description("物料钩子Y轴")]
        MaterialY = 6,

        [Description("物料钩子X轴")]
        MaterialX = 7,

        [Description("物料钩子Z轴")]
        MaterialZ = 8,

        [Description("物料钩子开合轴")]
        MaterialHook = 9,

        [Description("烘箱1轨道")]
        OverTrack1 = 10,

        [Description("烘箱2轨道")]
        OverTrack2 = 11,

        
    }

    [Serializable]
    public enum EnumStageSystem
    {
        MaterialboxHook,
        MaterialHook,
        OverTrack1,
        OverTrack2
    }
    [Serializable]
    public enum EnumSystemAxis
    {
        XY,
        Z,
        Hook,
        Track,
        Focus,
        Theta
    }
    [Serializable]
    public enum EnumFindBondPositionMethod
    {
        NoAccuracy,
        Accuracy,
    }
    [Serializable]
    public enum EnumCameraProducer { HIK, DaHeng }
    [Serializable]
    public enum EnumCameraType
    {
        None = 0,
        TrackCamera = 1,
        WeldCamera = 2,
    }
    [Serializable]
    public enum EnumImageData
    {
        Grey, RGB
    }
    [Serializable]
    public enum EnumLightProducer { HIK, OPT }
    [Serializable]
    public enum EnumLightSourceType
    {
        TrackRingField, WeldRingField
    }
    [Serializable]
    public enum EnumCommunicationType { SerialPort, Ethernet }
    public enum EnumRecogniseResulSaveOption
    {
        NotSave = 0, SaveOK = 1, SaveNG = 2, AllSave = 3
    }
    /// <summary>
    /// Recipe根节点步骤
    /// </summary>
    public enum EnumRecipeRootStep 
    { 
        None,
        Submount,
        Dispenser, 
        BondPosition, 
        Component 
    }
    /// <summary>
    /// Recipe步骤
    /// </summary>
    [Serializable]
    public enum EnumRecipeStep
    {
        Create,
        Configuration,

        Submount_InformationSettings,
        Submount_PositionSettings,
        Submount_MaterialMap,
        Submount_PPSettings,
        Submount_Accuracy,

        BondPosition,

        Component_InformationSettings,
        Component_PositionSettings,
        Component_MaterialMap,
        Component_PPSettings,
        Component_Accuracy,

        EutecticSettings,

        ProcessList,
        BlankingSetting,

        None
    }
    /// <summary>
    /// Recipe步骤
    /// </summary>
    [Serializable]
    public enum EnumDefinedSingleStep
    {
        CHipPPPick,
        ChipPPPlace,
        SubmountPPPick,
        SubmountPPPlace,

        ComponentVisionPosition,
        ComponentUplookingAccuracy,

        SubmountVisionPosition,
        SubmountUplookingAccuracy,

        SubmountVisionPositionBeforeBond,

        Bond,
        Eutectic,

        SubmountVisionPositionBeforeBlanking,

        None
    }
    [Serializable]
    public enum EnumDefineSetupRecipeComponentPositionStep
    {
        None,
        SetWorkHeight,
        SetComponentLeftUpperCorner,
        SetComponentRightUpperCorner,
        SetComponentRightLowerCorner,
        SetComponentLeftLowerCorner,
        VisionPosition
    }



    [Serializable]
    public enum EnumDefineSetupRecipeComponentMapStep
    {
        None,
        SetFirstComponentPos,
        SetColumnMap,   //包括列数和列间距
        SetRowMap,    //包括行数和行间距
        SetDeterminWaferRangeFirstPoint,
        SetDeterminWaferRangeSecondPoint,
        SetDeterminWaferRangeThirdPoint
    }
    [Serializable]
    public enum EnumDefineSetupRecipeComponentAccuracyStep
    {
        None,
        SetComponentLeftUpperCorner,
        SetComponentRightUpperCorner,
        SetComponentRightLowerCorner,
        SetComponentLeftLowerCorner,
        EdgeSearch,
        LeftUpperEdgeSearch,
        RighLowerEdgeSearch
    }

    [Serializable]
    public enum EnumDefineSetupRecipeSubmountPositionStep
    {
        None,
        SetWorkHeight,
        SetSubmountLeftUpperCorner,
        SetSubmountRightUpperCorner,
        SetSubmountRightLowerCorner,
        SetSubmountLeftLowerCorner,
        VisionPosition
    }


    [Serializable]
    public enum EnumDefineSetupRecipeSubmountMapStep
    {
        None,
        SetFirstSubmountPos,
        SetColumnMap,   //包括列数和列间距
        SetRowMap,    //包括行数和行间距
        SetDeterminWaferRangeFirstPoint,
        SetDeterminWaferRangeSecondPoint,
        SetDeterminWaferRangeThirdPoint
    }
    [Serializable]
    public enum EnumDefineSetupRecipeSubmountAccuracyStep
    {
        None,
        SetSubmountLeftUpperCorner,
        SetSubmountRightUpperCorner,
        SetSubmountRightLowerCorner,
        SetSubmountLeftLowerCorner,
        EdgeSearch,
        LeftUpperEdgeSearch,
        RighLowerEdgeSearch
    }

    [Serializable]
    public enum EnumDefineSetupRecipeBondPositionStep
    {
        None,
        SetPPHeight,
        SetSubmountLeftUpperCorner,
        SetSubmountRightUpperCorner,
        SetSubmountRightLowerCorner,
        SetSubmountLeftLowerCorner,
        VisionPosition,
        SetBondPosition
    }
    [Serializable]
    public enum EnumDefineSetupRecipeBlankingSettingsStep
    {
        None,
        SetPickParameters,
        BlankingMethod
    }
    [Serializable]
    public enum EnumDefinePPAlignStep
    {
        None,
        PositionCenterFirst,
        PositionCenterSecond
    }
    [Serializable]
    public enum EnumHardwareType
    {
        Stage,
        Camera,
        Light,
        ControlBoard,
        PowerController,
        LaserSensor,
        Dynamometer,
    }
    [Serializable]
    public enum EnumCarrierType
    {
        [Description("蓝膜")]
        Wafer,
        [Description("华夫盒")]
        WafflePack,
        [Description("蓝膜华夫盒")]
        WaferWafflePack
    }
    [Serializable]
    public enum EnumBlankingMethod
    {
        OriginalRoad,
        BlankingArea
    }
    /// <summary>
    /// 加热段参数
    /// </summary>
    [Serializable]
    public class HeatSegmentParam
    {
        public int segmentNo { get; set; }

        public double TimespanMinite { get; set; }

        public double TargetTemprerature { get; set; }

    }
    [Serializable]
    public enum EnumUsedPP
    {
        ChipPP,
        SubmountPP
    }
    [Serializable]
    public enum EnumVisionPositioningMethod
    {
        PatternSearch,
        CircleSearch,
        EdgeSearch
    }
    [Serializable]
    public enum EnumAccuracyMethod
    {
        None,
        UplookingCamera,
        CalibrationTable
    }
    [Serializable]
    public class ShapeMatchParameters
    {
        public ShapeMatchParameters()
        {
            MaskSetting = new List<RecogniseMaskSetting>();
            BondTablePositionOfCreatePattern = new XYZTCoordinateConfig();
            WaferTablePositionOfCreatePattern = new XYZTCoordinateConfig();
            PositionOfMaterialCenter = new XYZTCoordinateConfig();
            RingLightSetting = new OpticalSettings();
            DirectLightSetting = new OpticalSettings();
            ROILeftUpperPoint = new PointF();
        }
        [XmlElement("Name")]
        public string Name { get; set; }


        [XmlElement("CameraZWorkPosition")]
        public float CameraZWorkPosition { get; set; }
        [XmlElement("OrigionAngle")]
        public float OrigionAngle { get; set; }
        /// <summary>
        /// 创建模板时BondTable的位置
        /// </summary>
        [XmlElement("BondTablePositionOfCreatePattern")]
        public XYZTCoordinateConfig BondTablePositionOfCreatePattern { get; set; }
        /// <summary>
        /// 创建模板时物料中心的系统坐标位
        /// </summary>
        [XmlIgnore]
        public XYZTCoordinateConfig PositionOfMaterialCenter { get; set; }
        /// <summary>
        /// 创建模板时WaferTable的位置
        /// </summary>
        [XmlElement("WaferTablePositionOfCreatePattern")]
        public XYZTCoordinateConfig WaferTablePositionOfCreatePattern { get; set; }

        [XmlElement("RingLightSetting")]
        public OpticalSettings RingLightSetting { get; set; }
        [XmlElement("DirectLightSetting")]
        public OpticalSettings DirectLightSetting { get; set; }
        [XmlElement("ScoreThreshold")]
        public double ScoreThreshold { get; set; }
        [XmlElement("AcceptAngleThreshold")]
        public double AcceptAngleThreshold { get; set; }




        /// <summary>
        /// 
        /// </summary>
        [XmlElement("TrainFileFullName")]
        public string TrainFileFullName { get; set; }
        [XmlElement("TemplateFileFullName")]
        public string TemplateFileFullName { get; set; }
        [XmlElement("TemplateRegionLeftUpperPoint")]
        public PointF TemplateRegionLeftUpperPoint { get; set; }
        [XmlElement("TemplateRegionWidth")]
        public float TemplateRegionWidth { get; set; }
        [XmlElement("TemplateRegionHeight")]
        public float TemplateRegionHeight { get; set; }

        [XmlElement("ROILeftUpperPoint")]
        public PointF ROILeftUpperPoint { get; set; }
        [XmlElement("ROIWidth")]
        public float ROIWidth { get; set; }
        [XmlElement("ROIHeight")]
        public float ROIHeight { get; set; }
        [XmlArray("MaskSetting"), XmlArrayItem(typeof(RecogniseMaskSetting))]
        public List<RecogniseMaskSetting> MaskSetting { get; set; }

    }
    [Serializable]
    public enum EnumMaskType
    {
        None = 0,
        BondOrigion = 1,
        TrackOrigion = 2,
        WaferCameraOrigion = 3,
        LookupCameraOrigion = 4,
        WaferOrigion = 5,
        LookupChipPPOrigion = 6,
        LookupSubmountPPOrigion = 7,
        LookupLaserSensorOrigion = 8,
        EutecticWeldingOrigion = 9,
    }
    [Serializable]
    [XmlType("Mask")]
    public class RecogniseMaskSetting
    {
        [XmlElement("MaskRegionLeftUpperPoint")]
        public PointF MaskRegionLeftUpperPoint { get; set; }
        [XmlElement("MaskRegionWidth")]
        public float MaskRegionWidth { get; set; }
        [XmlElement("MaskRegionHeight")]
        public float MaskRegionHeight { get; set; }
        public RecogniseMaskSetting()
        {
            MaskRegionLeftUpperPoint = new PointF();
        }
    }

    [Serializable]
    public class CircleSearchParameters
    {
        public CircleSearchParameters()
        {
            MaskSetting = new List<RecogniseMaskSetting>();
            BondTablePosition = new XYZTCoordinateConfig();
            WaferTablePosition = new XYZTCoordinateConfig();
        }
        [XmlElement("Name")]
        public string Name { get; set; }

        //[XmlElement("UsedCamera")]
        //public EnumCameraType UsedCamera { get; set; }
        [XmlElement("BondTablePosition")]
        public XYZTCoordinateConfig BondTablePosition { get; set; }
        [XmlElement("WaferTablePosition")]
        public XYZTCoordinateConfig WaferTablePosition { get; set; }
        [XmlElement("CameraZWorkPosition")]
        public float CameraZWorkPosition { get; set; }
        [XmlElement("RingLightSetting")]
        public OpticalSettings RingLightSetting { get; set; }
        [XmlElement("DirectLightSetting")]
        public OpticalSettings DirectLightSetting { get; set; }
        [XmlElement("ScoreThreshold")]
        public double ScoreThreshold { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("TrainFileFullName")]
        public string TrainFileFullName { get; set; }
        [XmlElement("TemplateFileFullName")]
        public string TemplateFileFullName { get; set; }
        [XmlElement("TemplateRegionLeftUpperPoint")]
        public PointF TemplateRegionLeftUpperPoint { get; set; }
        [XmlElement("TemplateRegionWidth")]
        public float TemplateRegionWidth { get; set; }
        [XmlElement("TemplateRegionHeight")]
        public float TemplateRegionHeight { get; set; }

        [XmlElement("ROILeftUpperPoint")]
        public PointF ROILeftUpperPoint { get; set; }
        [XmlElement("ROIWidth")]
        public float ROIWidth { get; set; }
        [XmlElement("ROIHeight")]
        public float ROIHeight { get; set; }
        [XmlArray("MaskSetting"), XmlArrayItem(typeof(RecogniseMaskSetting))]
        public List<RecogniseMaskSetting> MaskSetting { get; set; }
    }
    [Serializable]
    public class EdgeSearchParameters
    {
        public EdgeSearchParameters()
        {
            MaskSetting = new List<RecogniseMaskSetting>();
            BondTablePosition = new XYZTCoordinateConfig();
            WaferTablePosition = new XYZTCoordinateConfig();
            RingLightSetting = new OpticalSettings();
            DirectLightSetting = new OpticalSettings();
        }
        [XmlElement("Name")]
        public string Name { get; set; }

        //[XmlElement("UsedCamera")]
        //public EnumCameraType UsedCamera { get; set; }
        [XmlElement("BondTablePosition")]
        public XYZTCoordinateConfig BondTablePosition { get; set; }
        [XmlElement("WaferTablePosition")]
        public XYZTCoordinateConfig WaferTablePosition { get; set; }
        [XmlElement("CameraZWorkPosition")]
        public float CameraZWorkPosition { get; set; }
        [XmlElement("OrigionAngle")]
        public float OrigionAngle { get; set; }
        [XmlElement("RingLightSetting")]
        public OpticalSettings RingLightSetting { get; set; }
        [XmlElement("DirectLightSetting")]
        public OpticalSettings DirectLightSetting { get; set; }
        [XmlElement("ScoreThreshold")]
        public double ScoreThreshold { get; set; }
        [XmlElement("AcceptAngleThreshold")]
        public double AcceptAngleThreshold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("TrainFileFullName")]
        public string TrainFileFullName { get; set; }
        [XmlElement("TemplateFileFullName")]
        public string TemplateFileFullName { get; set; }
        [XmlElement("UpEdgeSearchTemplateFileFullName")]
        public string UpEdgeSearchTemplateFileFullName { get; set; }
        [XmlElement("RightEdgeSearchTemplateFileFullName")]
        public string RightEdgeSearchTemplateFileFullName { get; set; }
        [XmlElement("DownEdgeSearchTemplateFileFullName")]
        public string DownEdgeSearchTemplateFileFullName { get; set; }
        [XmlElement("LeftEdgeSearchTemplateFileFullName")]
        public string LeftEdgeSearchTemplateFileFullName { get; set; }
        [XmlElement("TemplateRegionLeftUpperPoint")]
        public PointF TemplateRegionLeftUpperPoint { get; set; }
        [XmlElement("TemplateRegionWidth")]
        public float TemplateRegionWidth { get; set; }
        [XmlElement("TemplateRegionHeight")]
        public float TemplateRegionHeight { get; set; }

        [XmlElement("ROILeftUpperPoint")]
        public PointF ROILeftUpperPoint { get; set; }
        [XmlElement("ROIWidth")]
        public float ROIWidth { get; set; }
        [XmlElement("ROIHeight")]
        public float ROIHeight { get; set; }
        [XmlArray("MaskSetting"), XmlArrayItem(typeof(RecogniseMaskSetting))]
        public List<RecogniseMaskSetting> MaskSetting { get; set; }
    }
    [Serializable]
    public class OpticalSettings
    {
        [XmlAttribute("Active")]
        public bool Active { get; set; }
        [XmlAttribute("LightColor")]
        public EnumLightColor LightColor { get; set; }

        [XmlAttribute("Brightness")]
        public float Brightness { get; set; }


    }
    /// <summary>
    /// 自定义回调动作抽象基类
    /// 用于向特定的过程返回数据并进行自定义操作。
    /// </summary>
    public abstract class ACustomActionBaseClass { }

    [Serializable]
    public enum EnumRecipeType { INVALID = 0, Bonder = 1, Heat = 2, Transport = 3 }
    /// <summary>
    /// 用于保存Job分析结果的类
    /// </summary>
    [Serializable]
    public sealed class JobResult
    {
        /// <summary>
        /// 最终结果
        /// </summary>
        //public List<ProcessResult> LidFinalResults { get; set; }
        //public List<ProcessResult> ShellFinalResults { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProcessJobName { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public JobResult()
        {
            //LidFinalResults = new List<ProcessResult>();
            //ShellFinalResults = new List<ProcessResult>();
        }
    }
    [Serializable]
    public enum EnumTransferAction
    {
        PositionSubmountBeforePickFromSubstrate,                   //打开烘箱内门
        PickSubmountFromSubstrate,                //传送轴移动到烘箱前
        AccuracySubmountPosition,             //把料盒从烘箱拉出来
        PlaceSubmounttoChuck,                 //把料盒移动到buffer前
        PositionBeforeBond,
        PositionSubmountBeforePickFromChuck,
        PickSubmountFromChuck,                //传送轴移动到烘箱前
        PlaceSubmounttoSubstrate,                 //把料盒移动到buffer前

        PositionComponent,                   //打开烘箱内门
        PickComponent,                //传送轴移动到烘箱前
        AccuracyComponentPosition,             //把料盒从烘箱拉出来
        PlaceComponent,                 //把料盒移动到buffer前
    }
    [Serializable]
    public enum EnumTransferStatus
    {
        TransferCompleted, //整盒传输完成
        StripTransferCompleted, //整盒传输完成
        Transfering,       //正在传输
        ExceptionAborted,  //传输异常停止
        UserAbort,         //用户停止传输
        StripCleared,      //清片完成
        StripLoaded,        //一键上片完成
        /// <summary>
        /// 料盒在buffer
        /// </summary>
        MaterialboxinBuffer,
        /// <summary>
        /// 料盒在交换箱
        /// </summary>
        MaterialboxinExchangebox,
        /// <summary>
        /// 料盒在料盒轨道
        /// </summary>
        MaterialboxinMaterialboxTrack,
        /// <summary>
        /// 料盒在烘箱
        /// </summary>
        MaterialboxinOven,
        /// <summary>
        /// 料条在料条轨道
        /// </summary>
        MaterialstripinMaterialstripTrack,
        /// <summary>
        /// 料条在焊台
        /// </summary>
        MaterialstripinWeld,
        /// <summary>
        /// 无料盒无料条
        /// </summary>
        NoMateralboxNoMateralstrip
    }
    [Serializable]
    public enum EnumProcessingState
    {
        INIT = 0,
        IDLE = 2,
        SETUP = 3,
        READY = 4,
        EXECUTING = 5,
        PAUSE = 6
    }
    [Serializable]
    public enum EnumProcessJobState
    {
        Created = 255,
        Queued = 0,
        SettingUp = 1,
        WaitingForStart = 2,
        Processing = 3,
        ProcessComplete = 4,
        Pausing = 6,
        Paused = 7,
        Stopping = 8,
        Aborting = 9,
        Stopped = 10,
        Aborted = 11
    }
    [Serializable]
    public enum EnumBondJobStatus
    {
        Idle = 0,
        Running = 1,
        UserAbort = 2,
        ProcessCompleted = 3,
        ProcessError = 4,
        TransferError = 5,
        TransferCompleted = 6,
        VisionFailed = 7,
        NeedManualLoadSubstrate,
        NeedManualFindComponent
    }
    /// <summary>
    /// 支持权重对象的随机对象接口
    /// </summary>
    public interface IRandomObject
    {
        /// <summary>
        /// 权重
        /// </summary>
        int Weight
        {
            set;
            get;
        }
    }
    [Serializable]
    public class MaterialMapInformation : ACloneable<MaterialMapInformation>, IComparable, IEqualityComparer<MaterialMapInformation>, IRandomObject
    {
        #region IRandomObject
        /// <summary>
        /// 权重
        /// </summary>
        [XmlAttribute("Weight")]
        public int Weight { set; get; }
        #endregion

        /// <summary>
        /// Wafer坐标系的坐标值
        /// </summary>
        public PointF MaterialLocation;
        /// <summary>
        /// 索引坐标。
        /// </summary>
        public Point MaterialCoordIndex;

        /// <summary>
        /// 编号
        /// </summary>
        [XmlAttribute("MaterialNumber")]
        public int MaterialNumber;

        /// <summary>
        /// material是否存在
        /// </summary>
        [XmlAttribute("IsMaterialExist")]
        public bool IsMaterialExist;

        /// <summary>
        /// 是否是Mark
        /// </summary>
        [XmlAttribute("IsMark")]
        public bool IsMark;

        /// <summary>
        /// 属性
        /// </summary>
        [XmlAttribute("Properties")]
        public MaterialProperties Properties { get; set; }
        [XmlIgnore]
        MaterialProcessResult ProcessResult { get; set; }

        /// <summary>
        /// 是否需要检测
        /// </summary>
        [XmlAttribute("IsProcess")]
        public bool IsProcess;

        /// <summary>
        /// 构造函数。
        /// </summary>
        public MaterialMapInformation()
        {
            IsMaterialExist = true;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="coordIndex"></param>
        /// <param name="location"></param>
        /// <param name="patternAngle"></param>
        /// <param name="toBePorcessed"></param>
        public MaterialMapInformation(int number, Point coordIndex, PointF location, double patternAngle, bool toBePorcessed)
        {
            IsMaterialExist = true;
            MaterialNumber = number;
            MaterialCoordIndex = coordIndex;
            MaterialLocation = location;
        }

        /// <summary>
        /// 对象比较
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            try
            {
                int positive = 0;
                if (obj is MaterialMapInformation)
                {
                    MaterialMapInformation compareObject = obj as MaterialMapInformation;
                    if (this.MaterialCoordIndex.X < compareObject.MaterialCoordIndex.X)
                    {
                        positive = this.MaterialCoordIndex.Y <= compareObject.MaterialCoordIndex.Y ? -1 : 1;
                    }
                    else if (this.MaterialCoordIndex.X > compareObject.MaterialCoordIndex.X)
                    {
                        positive = this.MaterialCoordIndex.Y < compareObject.MaterialCoordIndex.Y ? -1 : 1;
                    }
                    else
                    {
                        positive = this.MaterialCoordIndex.Y.CompareTo(compareObject.MaterialCoordIndex.Y);
                    }
                }
                return -positive;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + " <- " + ex.TargetSite.Name);
                return 0;
            }
        }

        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(MaterialMapInformation obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public bool Equals(MaterialMapInformation obj1, MaterialMapInformation obj2)
        {
            return obj1.MaterialCoordIndex.Equals(obj2.MaterialCoordIndex);
        }
    }
    /// <summary>
    /// 机台工艺检测状态
    /// </summary>
    [Serializable]
    public enum EnumProcessStatus
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        UnknownError,
        /// <summary>
        /// 空闲状态
        /// </summary>
        Idle,
        /// <summary>
        /// 运行中
        /// </summary>
        Running,
        /// <summary>
        /// 用户停止
        /// </summary>
        Aborted,
        /// <summary>
        ///
        /// </summary>
        Completed,
        /// <summary>
        /// 暂停
        /// </summary>
        Paused,
        /// <summary>
        /// 
        /// </summary>
        WaferInspectError,
        /// <summary>
        /// Wafer传送异常
        /// </summary>
        WaferTransferError,
        /// <summary>
        /// 这里指一盒扫描完成，指一次循环跑片
        /// </summary>
        TransferCompleted
    }
    [Serializable]
    public enum EnumLightColor
    {
        Red,
        Green,
        Blue,
        White
    }
    [Serializable]
    public class ESToolSettings
    {
        public ESToolSettings()
        {
            NeedleCenter = new XYZTCoordinateConfig();
        }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("NeedleName")]
        public string NeedleName { get; set; }
        [XmlElement("ESBasePosition")]
        public float ESBasePosition { get; set; }

        [XmlElement("NeedleZeorPosition")]
        public float NeedleZeorPosition { get; set; }
        [XmlElement("NeedleCenter")]
        public XYZTCoordinateConfig NeedleCenter { get; set; }

    }
    [Serializable]
    public class PPToolSettings
    {
        public PPToolSettings()
        {
            ChipPPPosCompensateCoordinate1 = new XYZTCoordinateConfig();
            ChipPPPosCompensateCoordinate2 = new XYZTCoordinateConfig();
            PPESAltimetryParameter = new PPESAltimetryParameters();

        }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("PPName")]
        public string PPName { get; set; }
        /// <summary>
        /// 在Mark处的测高值
        /// </summary>
        [XmlElement("AltimetryOnMark")]
        public float AltimetryOnMark { get; set; }

        /// <summary>
        /// 计算吸嘴旋转补偿XY公式的坐标1，一般在T0度纪录
        /// </summary>
        [XmlElement("PPosCompensateCoordinate1")]
        public XYZTCoordinateConfig ChipPPPosCompensateCoordinate1 { get; set; }
        /// <summary>
        /// 计算吸嘴旋转补偿XY公式的坐标2，一般在T180度纪录
        /// </summary>
        [XmlElement("PPosCompensateCoordinate2")]
        public XYZTCoordinateConfig ChipPPPosCompensateCoordinate2 { get; set; }
        /// <summary>
        /// 吸嘴和ES测高时的参数
        /// </summary>
        [XmlElement("PPESAltimetryParameter")]
        public PPESAltimetryParameters PPESAltimetryParameter { get; set; }
    }
    [Serializable]
    public class PPESAltimetryParameters
    {
        public PPESAltimetryParameters()
        {
        }
        [XmlElement("PPName")]
        public string PPName { get; set; }

        [XmlElement("PPPosition")]
        public float PPPosition { get; set; }
        [XmlElement("ESPosition")]
        public float ESPosition { get; set; }
    }
    [Serializable]
    public class BaseCoordinateConfig
    {
        [XmlAttribute("X"), DataMember(Order = 1)]
        public double X { get; set; }

        [XmlAttribute("Y"), DataMember(Order = 2)]
        public double Y { get; set; }
    }

    [Serializable]
    public class XYThetaCoordinateConfig : BaseCoordinateConfig
    {
        [XmlAttribute("Theta")]
        public float Theta { get; set; }
    }

    [Serializable]
    public class XYZCoordinateConfig : BaseCoordinateConfig
    {
        [XmlAttribute("Z")]
        public double Z { get; set; }
    }

    [Serializable]
    public class XYZTCoordinateConfig : BaseCoordinateConfig
    {
        [XmlAttribute("Z")]
        public double Z { get; set; }

        [XmlAttribute("Theta")]
        public double Theta { get; set; }
    }

    [Serializable]
    public class XYZTOffsetConfig : BaseCoordinateConfig
    {
        [XmlAttribute("Z")]
        public double Z { get; set; }

        [XmlAttribute("Theta")]
        public double Theta { get; set; }
    }

    [Serializable]
    public class MatchIdentificationParam
    {
        public MatchIdentificationParam()
        {
            //Templatexml = "";
            //Runxml = "";
            TemplateRoi = new RectangleFV();
            SearchRoi = new RectangleFV();
            MaskSetting = new List<RecogniseMaskSetting>();
            BondTablePositionOfCreatePattern = new XYZTCoordinateConfig();
            PositionOfMaterialCenter = new XYZTCoordinateConfig();
            WaferTablePositionOfCreatePattern = new XYZTCoordinateConfig();
            //Templateresult = new MatchTemplateResult();
        }

        [XmlElement("RingLightintensity")]
        public int RingLightintensity { get; set; }
        [XmlElement("DirectLightintensity")]
        public int DirectLightintensity { get; set; }
        [XmlElement("Templatexml")]
        public string Templatexml { get; set; }
        [XmlElement("Runxml")]
        public string Runxml { get; set; }

        [XmlElement("Score")]
        public float Score { get; set; }

        [XmlElement("MinAngle")]
        public int MinAngle { get; set; }

        [XmlElement("MaxAngle")]
        public int MaxAngle { get; set; }

        [XmlElement("TemplateRoi")]
        public RectangleFV TemplateRoi { get; set; }

        [XmlElement("SearchRoi")]
        public RectangleFV SearchRoi { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }


        [XmlElement("CameraZWorkPosition")]
        public float CameraZWorkPosition { get; set; }
        [XmlElement("OrigionAngle")]
        public float OrigionAngle { get; set; }
        /// <summary>
        /// 创建模板时BondTable的位置
        /// </summary>
        [XmlElement("BondTablePositionOfCreatePattern")]
        public XYZTCoordinateConfig BondTablePositionOfCreatePattern { get; set; }
        /// <summary>
        /// 创建模板时物料中心的系统坐标位
        /// </summary>
        [XmlIgnore]
        public XYZTCoordinateConfig PositionOfMaterialCenter { get; set; }
        /// <summary>
        /// 创建模板时WaferTable的位置
        /// </summary>
        [XmlElement("WaferTablePositionOfCreatePattern")]
        public XYZTCoordinateConfig WaferTablePositionOfCreatePattern { get; set; }

        [XmlArray("MaskSetting"), XmlArrayItem(typeof(RecogniseMaskSetting))]
        public List<RecogniseMaskSetting> MaskSetting { get; set; }
        //[XmlElement("Templateresult")]
        //public MatchTemplateResult Templateresult { get; set; }
    }

    [Serializable]
    public class LineFindIdentificationParam
    {
        public LineFindIdentificationParam()
        {
            //UpEdgefilepath = "";
            //DownEdgefilepath = "";
            //LeftEdgefilepath = "";
            //RightEdgefilepath = "";
            UpEdgeRoi = new RectangleFV();
            DownEdgeRoi = new RectangleFV();
            LeftEdgeRoi = new RectangleFV();
            RightEdgeRoi = new RectangleFV();
            MaskSetting = new List<RecogniseMaskSetting>();
            BondTablePosition = new XYZTCoordinateConfig();
            WaferTablePosition = new XYZTCoordinateConfig();
        }
        [XmlElement("RingLightintensity")]
        public int RingLightintensity { get; set; }
        [XmlElement("DirectLightintensity")]
        public int DirectLightintensity { get; set; }

        [XmlElement("UpEdgefilepath")]
        public string UpEdgefilepath { get; set; }
        [XmlElement("DownEdgefilepath")]
        public string DownEdgefilepath { get; set; }
        [XmlElement("LeftEdgefilepath")]
        public string LeftEdgefilepath { get; set; }
        [XmlElement("RightEdgefilepath")]
        public string RightEdgefilepath { get; set; }


        [XmlElement("UpEdgeScore")]
        public int UpEdgeScore { get; set; }
        [XmlElement("DownEdgeScore")]
        public int DownEdgeScore { get; set; }
        [XmlElement("LeftEdgeScore")]
        public int LeftEdgeScore { get; set; }
        [XmlElement("RightEdgeScore")]
        public int RightEdgeScore { get; set; }


        [XmlElement("UpEdgeRoi")]
        public RectangleFV UpEdgeRoi { get; set; }
        [XmlElement("DownEdgeRoi")]
        public RectangleFV DownEdgeRoi { get; set; }
        [XmlElement("LeftEdgeRoi")]
        public RectangleFV LeftEdgeRoi { get; set; }

        [XmlElement("RightEdgeRoi")]
        public RectangleFV RightEdgeRoi { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        //[XmlElement("UsedCamera")]
        //public EnumCameraType UsedCamera { get; set; }
        [XmlElement("BondTablePosition")]
        public XYZTCoordinateConfig BondTablePosition { get; set; }
        [XmlElement("WaferTablePosition")]
        public XYZTCoordinateConfig WaferTablePosition { get; set; }
        [XmlElement("CameraZWorkPosition")]
        public float CameraZWorkPosition { get; set; }
        [XmlElement("OrigionAngle")]
        public float OrigionAngle { get; set; }
        [XmlArray("MaskSetting"), XmlArrayItem(typeof(RecogniseMaskSetting))]
        public List<RecogniseMaskSetting> MaskSetting { get; set; }
    }

    [Serializable]
    public class CircleFindIdentificationParam
    {
        public CircleFindIdentificationParam()
        {
            //CircleFindTemplatefilepath = "";
            TemplateRoiCenter = new PointF();
            SearchRoi = new RectangleFV();
            MaskSetting = new List<RecogniseMaskSetting>();
            BondTablePosition = new XYZTCoordinateConfig();
            WaferTablePosition = new XYZTCoordinateConfig();
        }
        [XmlElement("RingLightintensity")]
        public int RingLightintensity { get; set; }
        [XmlElement("DirectLightintensity")]
        public int DirectLightintensity { get; set; }
        [XmlElement("CircleFindTemplatefilepath")]
        public string CircleFindTemplatefilepath { get; set; }

        [XmlElement("Score")]
        public int Score { get; set; }

        [XmlElement("MinR")]
        public int MinR { get; set; }

        [XmlElement("MaxR")]
        public int MaxR { get; set; }

        [XmlElement("TemplateRoiCenter")]
        public PointF TemplateRoiCenter { get; set; }
        [XmlElement("TemplateRoiR")]
        public float TemplateRoiR { get; set; }

        [XmlElement("SearchRoi")]
        public RectangleFV SearchRoi { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        //[XmlElement("UsedCamera")]
        //public EnumCameraType UsedCamera { get; set; }
        [XmlElement("BondTablePosition")]
        public XYZTCoordinateConfig BondTablePosition { get; set; }
        [XmlElement("WaferTablePosition")]
        public XYZTCoordinateConfig WaferTablePosition { get; set; }
        [XmlElement("CameraZWorkPosition")]
        public float CameraZWorkPosition { get; set; }
        [XmlElement("OrigionAngle")]
        public float OrigionAngle { get; set; }
        [XmlArray("MaskSetting"), XmlArrayItem(typeof(RecogniseMaskSetting))]
        public List<RecogniseMaskSetting> MaskSetting { get; set; }
    }
    [Serializable]
    public enum EnumBoardcardDefineOutputIO
    {
        Undefine = 0,


        TowerYellowLight = 1,
        TowerGreenLight = 2,
        TowerRedLight = 3,




        ChipPPVaccumSwitch = 4,
        SubmountPPVaccumSwitch = 5,

        ChipPPBlowSwitch = 7,
        SubmountPPBlowSwitch = 6,

        EjectionSystemVaccumSwitch = 13,
        EutecticPlatformVaccumSwitch = 8,
        WaferTableVaccumSwitch = 14,
        MaterialPlatformVaccumSwitch = 9,



        NitrogenValve = 12,
        StartEctectic = 10,
        ResetEutectic = 11,

        //BondXLeftLimit = 5,
        //BondXRightLimit = 6,
        //BondYLeftLimit = 7,
        //BondYRightLimit = 8,
        //BondZLeftLimit = 7,
        //BondZRightLimit = 8,
        //WaferTableXLeftLimit = 7,
        //WaferTableXRightLimit = 8,
        //WaferTableYLeftLimit = 7,
        //WaferTableYRightLimit = 8

    }
    [Serializable]
    public enum EnumBoardcardDefineInputIO
    {
        ChipPPVaccumNormally = 8,
        SubmountPPVaccumNormally = 9,
        EjectionSystemVaccumNormally = 6,
        EutecticPlatformVaccumNormally = 7,

        EutecticError =2,
        EutecticComplete=1,
        
    }


    public enum EnumProductStepType
    {
        [Description("无")]
        None,

        [Description("传输")]
        Translate,

        [Description("共晶")]
        Eutectic
    }

    public enum EnumTransSrc
    {
        [Description("无")]
        None,

        [Description("物料")]
        Component,

        [Description("校准平台")]
        CalibrationTable,

        [Description("共晶平台")]
        EutecticTable
    }

    public enum EnumTransDest
    {
        [Description("无")]
        None,

        [Description("校准平台")]
        CalibrationTable,

        [Description("共晶平台")]
        EutecticTable,

        [Description("成品区")]
        FinishedProduct
    }


    [Serializable]
    public class PowerParam
    {
        [XmlAttribute("T1")]
        public int T1 { get; set; }
        [XmlAttribute("T2")]
        public int T2 { get; set; }
        [XmlAttribute("T3")]
        public int T3 { get; set; }
        [XmlAttribute("T4")]
        public int T4 { get; set; }
        [XmlAttribute("T5")]
        public int T5 { get; set; }
        [XmlAttribute("t1")]
        public int t1 { get; set; }
        [XmlAttribute("t2")]
        public int t2 { get; set; }
        [XmlAttribute("t3")]
        public int t3 { get; set; }
        [XmlAttribute("t4")]
        public int t4 { get; set; }
        [XmlAttribute("t5")]
        public int t5 { get; set; }
        [XmlAttribute("t6")]
        public int t6 { get; set; }

        [XmlAttribute("H1")]
        public int H1 { get; set; }
        [XmlAttribute("H2")]
        public int H2 { get; set; }
        [XmlAttribute("H3")]
        public int H3 { get; set; }
        [XmlAttribute("H4")]
        public int H4 { get; set; }

        [XmlAttribute("L1")]
        public int L1 { get; set; }
        [XmlAttribute("L2")]
        public int L2 { get; set; }
        [XmlAttribute("L3")]
        public int L3 { get; set; }
        [XmlAttribute("L4")]
        public int L4 { get; set; }



        [XmlAttribute("G1")]
        public int G1 { get; set; }
        [XmlAttribute("G2")]
        public int G2 { get; set; }
        [XmlAttribute("G3")]
        public int G3 { get; set; }
        [XmlAttribute("G4")]
        public int G4 { get; set; }



        [XmlAttribute("t0")]
        public int t0 { get; set; }

        [XmlAttribute("T0")]
        public int T0 { get; set; }



        [XmlAttribute("MH")]
        public int MH { get; set; }
        [XmlAttribute("ML")]
        public int ML { get; set; }

        [XmlAttribute("HD")]
        public int HD { get; set; }

        [XmlAttribute("CNTLLimit")]
        public int CNTLLimit { get; set; }

        [XmlAttribute("MP")]
        public int MP { get; set; }

        [XmlAttribute("TC")]
        public int TC { get; set; }

        [XmlAttribute("IOUT")]
        public int IOUT { get; set; }

        [XmlAttribute("OPMD")]
        public int OPMD { get; set; }

        [XmlAttribute("DM")]
        public int DM { get; set; }

        [XmlAttribute("GP")]
        public int GP { get; set; }

        [XmlAttribute("DN")]
        public int DN { get; set; }

        [XmlAttribute("ERRC")]
        public int ERRC { get; set; }


        [XmlAttribute("CNTH")]
        public int CNTH { get; set; }
        [XmlAttribute("CNTL")]
        public int CNTL { get; set; }

        [XmlAttribute("TM1")]
        public int TM1 { get; set; }
        [XmlAttribute("TM2")]
        public int TM2 { get; set; }
        [XmlAttribute("TM3")]
        public int TM3 { get; set; }
        [XmlAttribute("TM4")]
        public int TM4 { get; set; }
        [XmlAttribute("TMC")]
        public int TMC { get; set; }
        [XmlAttribute("DataTime")]
        public int DataTime { get; set; }
        [XmlAttribute("tcys")]
        public int tcys { get; set; }
        [XmlAttribute("IM1")]
        public int IM1 { get; set; }
        [XmlAttribute("IM2")]
        public int IM2 { get; set; }
        [XmlAttribute("IM3")]
        public int IM3 { get; set; }
        [XmlAttribute("IM4")]
        public int IM4 { get; set; }
        [XmlAttribute("UM1")]
        public int UM1 { get; set; }
        [XmlAttribute("UM2")]
        public int UM2 { get; set; }
        [XmlAttribute("UM3")]
        public int UM3 { get; set; }
        [XmlAttribute("UM4")]
        public int UM4 { get; set; }

        [XmlAttribute("TData1")]
        public int TData1 { get; set; }



    }

    [Serializable]
    public class RectangleFV
    {
        [XmlAttribute("X")]
        public float X { get; set; }
        [XmlAttribute("Y")]
        public float Y { get; set; }
        [XmlAttribute("Width")]
        public float Width { get; set; }
        [XmlAttribute("Height")]
        public float Height { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PPWorkParameters
    {
        /// <summary>
        /// 使用的吸嘴
        /// </summary>
        [XmlElement("UsedPP")]
        public EnumUsedPP UsedPP;
        /// <summary>
        /// 工作高度，不包括压力偏移和其他偏移
        /// </summary>
        [XmlElement("WorkHeight")]
        public float WorkHeight { get; set; }
        /// <summary>
        /// 压力偏移
        /// </summary>

        [XmlElement("PickupStress")]
        public float PickupStress { get; set; }
        /// <summary>
        /// 是否需要顶针
        /// </summary>
        [XmlElement("IsUseNeedle")]
        public bool IsUseNeedle { get; set; }
        /// <summary>
        /// 顶针上升高度
        /// </summary>
        [XmlElement("NeedleUpHeight")]
        public float NeedleUpHeight { get; set; }
        /// <summary>
        /// 顶针上升速度
        /// </summary>
        [XmlElement("NeedleSpeed")]
        public float NeedleSpeed { get; set; }

        //[XmlElement("PickedDelayMS")]
        //public float DelayMSAfterPicked { get; set; }
        /// <summary>
        /// 开真空后等待的延时，延时过后才开始上升
        /// </summary>

        [XmlElement("DelayMSForVaccum")]
        public float DelayMSForVaccum { get; set; }
        /// <summary>
        /// 拾取前慢速移动的距离
        /// </summary>

        [XmlElement("SlowTravelBeforePickupMM")]
        public float SlowTravelBeforePickupMM { get; set; }
        /// <summary>
        /// 拾取前慢速移动的速度
        /// </summary>

        [XmlElement("SlowSpeedBeforePickup")]
        public float SlowSpeedBeforePickup { get; set; }
        /// <summary>
        /// 拾取后慢速移动的距离
        /// </summary>

        [XmlElement("SlowTravelAfterPickupMM")]
        public float SlowTravelAfterPickupMM { get; set; }
        /// <summary>
        /// 拾取前慢速移动的速度
        /// </summary>

        [XmlElement("SlowSpeedAfterPickup")]
        public float SlowSpeedAfterPickup { get; set; }
        /// <summary>
        /// 拾取后上升的高度
        /// </summary>

        [XmlElement("UpDistanceMMAfterPicked")]
        public float UpDistanceMMAfterPicked { get; set; }
        public PPWorkParameters()
        {

        }
    }

}
