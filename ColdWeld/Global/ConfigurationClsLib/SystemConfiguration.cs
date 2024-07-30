using GlobalDataDefineClsLib;
using GlobalToolClsLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WestDragon.Framework.BaseLoggerClsLib;
using WestDragon.Framework.UtilityHelper;

namespace ConfigurationClsLib
{
    [Serializable]
    [XmlRoot("SystemConfiguration")]
    public class SystemConfiguration
    {
        private static string _configPath = Path.Combine($@"{System.Environment.CurrentDirectory}\Config", "SystemConfiguration.xml");
        private static readonly object _lockObj = new object();
        private static volatile SystemConfiguration _instance = LoadConfig();
        public static SystemConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SystemConfiguration();
                        }
                    }
                }
                return _instance;
            }
        }
        private SystemConfiguration()
        {
            SystemGUIType = new SystemGUIType();
            JobConfig = new JobConfig();
            PositioningConfig = new PositioningConfig();
            CalibrationConfig = new CalibrationConfig();
            PPToolSettings = new List<PPToolSettings>();
            ESToolSettings = new List<ESToolSettings>();
        }
        private static SystemConfiguration LoadConfig()
        {
            SystemConfiguration ret = new SystemConfiguration();
            try
            {
                ret= XmlSerializeHelper.XmlDeserializeFromFile<SystemConfiguration>(_configPath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                LogRecorder.RecordLog(EnumLogContentType.Error, "Load  SystemConfiguration Error.", ex);
            }
            return ret;

        }
        public void SaveConfig()
        {
            XmlSerializeHelper.XmlSerializeToFile(this, _configPath, Encoding.UTF8);
        }
        [XmlIgnore]
        public string RawDataSavePath
        {
            get
            {
                var ret = @"D:\GWData\JobResult\";
                if (!string.IsNullOrEmpty(JobConfig.RawDataSavingPath))
                {
                    ret = JobConfig.RawDataSavingPath;
                }
                return ret;
            }
        }
        #region XMLConfig
        [XmlElement("MachineID")]
        public string MachineID { get; set; }


        [XmlElement("SystemDefaultDirectory")]
        public string SystemDefaultDirectory { get; set; }

        [XmlElement("SystemGUIType")]
        public SystemGUIType SystemGUIType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("SystemRunningType")]
        public EnumRunningType SystemRunningType { get; set; }
        [XmlElement("JobConfig")]
        public JobConfig JobConfig { get; set; }
        [XmlElement("PositioningConfig")]
        public PositioningConfig PositioningConfig { get; set; }
        [XmlElement("SystemCalibrationConfig")]
        public SystemCalibrationConfig SystemCalibrationConfig { get; set; }
        [XmlElement("CalibrationConfig")]
        public CalibrationConfig CalibrationConfig { get; set; }
        [XmlElement("ESUpPosition")]
        public float ESUpPosition { get; set; }
        [XmlElement("ESDownPosition")]
        public float ESDownPosition { get; set; }
        [XmlArray("PPToolSettings"), XmlArrayItem(typeof(PPToolSettings))]
        public List<PPToolSettings> PPToolSettings { get; set; }
        [XmlArray("ESToolSettings"), XmlArrayItem(typeof(ESToolSettings))]
        public List<ESToolSettings> ESToolSettings { get; set; }

        [XmlElement("OvenBoxConfig")]
        public OvenBoxConfig OvenBoxConfig { get; set; }
        


        #endregion

    }

    [Serializable]
    public class SystemGUIType
    {
        [XmlElement("CameraWindowHeight")]
        public int CameraWindowHeight { get; set; }

        [XmlElement("CameraWindowWidth")]
        public int CameraWindowWidth { get; set; }

    }

    [Serializable]
    public class JobConfig
    {
        [XmlElement("RunningType")]
        public EnumRunningType RunningType { get; set; }

        [XmlElement("RawDataSavingPath")]
        public string RawDataSavingPath { get; set; }

        [XmlElement("EnableMarathon")]
        public bool EnableMarathon { get; set; }
        [XmlElement("RecogniseResulSaveOption")]
        public EnumRecogniseResulSaveOption RecogniseResulSaveOption { get; set; }


    }
    /// <summary>
    /// 坐标系原点配置
    /// </summary>
    [Serializable]
    public class PositioningConfig
    {
        public PositioningConfig()
        {

            BondOrigion = new XYZTCoordinateConfig();
        }


        /// <summary>
        /// 榜头相机对焦系统原点坐标
        /// </summary>
        [XmlElement("BondOrigion")]
        public XYZTCoordinateConfig BondOrigion { get; set; }

    }

    /// <summary>
    /// 系统校准配置文件
    /// </summary>
    [Serializable]
    public class SystemCalibrationConfig
    {
        public SystemCalibrationConfig()
        {
            BondIdentifyBondOrigionMatch = new MatchIdentificationParam();
        }

        /// <summary>
        /// 榜头相机识别轨道原点 移动阵列个数 行数
        /// </summary>
        [XmlElement("BondIdentifyTrackOrigionArrayRowNum")]
        public int BondIdentifyTrackOrigionArrayRowNum { get; set; }
        /// <summary>
        /// 榜头相机识别轨道原点 移动阵列个数 列数
        /// </summary>
        [XmlElement("BondIdentifyTrackOrigionArrayColNum")]
        public int BondIdentifyTrackOrigionArrayColNum { get; set; }
        /// <summary>
        /// 榜头相机识别轨道原点 移动范围 宽
        /// </summary>
        [XmlElement("BondIdentifyTrackOrigionArrayWidthRange")]
        public double BondIdentifyTrackOrigionArrayWidthRange { get; set; }
        /// <summary>
        /// 榜头相机识别轨道原点 移动范围 高
        /// </summary>
        [XmlElement("BondIdentifyTrackOrigionArrayHeightRange")]
        public double BondIdentifyTrackOrigionArrayHeightRange { get; set; }


        /// <summary>
        /// 榜头相机识别系统原点识别方式 0轮廓 1边缘 2圆
        /// </summary>
        [XmlElement("BondIdentifyBondOrigionNum")]
        public int BondIdentifyBondOrigionNum { get; set; }
        /// <summary>
        /// 榜头相机识别系统原点
        /// </summary>
        [XmlElement("BondIdentifyBondOrigionMatch")]
        public MatchIdentificationParam BondIdentifyBondOrigionMatch { get; set; }

        

    }

    /// <summary>
    /// 烘箱手套箱参数
    /// </summary>
    [Serializable]
    public class OvenBoxConfig
    {
        public OvenBoxConfig()
        {
        }

        /// <summary>
        /// 烘箱1抽充次数
        /// </summary>
        [XmlElement("OvenPurgeTime")]
        public int OvenPurgeTime { get; set; }
        /// <summary>
        /// 烘箱1抽充压力上限
        /// </summary>
        [XmlElement("OvenPurgePressureUpperLimit")]
        public int OvenPurgePressureUpperLimit { get; set; }
        /// <summary>
        /// 烘箱1抽充压力下限
        /// </summary>
        [XmlElement("OvenPurgePressureLowerLimit")]
        public int OvenPurgePressureLowerLimit { get; set; }
        /// <summary>
        /// 烘箱1抽充间隔秒
        /// </summary>
        [XmlElement("OvenPurgeInterval")]
        public int OvenPurgeInterval { get; set; }
        /// <summary>
        /// 烘箱1超压上限
        /// </summary>
        [XmlElement("OvenOverPressureThreshold")]
        public int OvenOverPressureThreshold { get; set; }


        /// <summary>
        /// 烘箱1目标温度
        /// </summary>
        [XmlElement("HeatTargetTemperature")]
        public int HeatTargetTemperature { get; set; }
        /// <summary>
        /// 烘箱1保温时间分钟
        /// </summary>
        [XmlElement("HeatPreservationMinute")]
        public int HeatPreservationMinute { get; set; }
        /// <summary>
        /// 烘箱1超温上限
        /// </summary>
        [XmlElement("OverTemperatureThreshold")]
        public int OverTemperatureThreshold { get; set; }


        /// <summary>
        /// 烘箱2抽充次数
        /// </summary>
        [XmlElement("Oven2PurgeTime")]
        public int Oven2PurgeTime { get; set; }
        /// <summary>
        /// 烘箱2抽充压力上限
        /// </summary>
        [XmlElement("Oven2PurgePressureUpperLimit")]
        public int Oven2PurgePressureUpperLimit { get; set; }
        /// <summary>
        /// 烘箱2抽充压力下限
        /// </summary>
        [XmlElement("Oven2PurgePressureLowerLimit")]
        public int Oven2PurgePressureLowerLimit { get; set; }
        /// <summary>
        /// 烘箱2抽充间隔秒
        /// </summary>
        [XmlElement("Oven2PurgeInterval")]
        public int Oven2PurgeInterval { get; set; }
        /// <summary>
        /// 烘箱2超压上限
        /// </summary>
        [XmlElement("Oven2OverPressureThreshold")]
        public int Oven2OverPressureThreshold { get; set; }


        /// <summary>
        /// 烘箱2目标温度
        /// </summary>
        [XmlElement("HeatTargetTemperature2")]
        public int HeatTargetTemperature2 { get; set; }
        /// <summary>
        /// 烘箱2保温时间分钟
        /// </summary>
        [XmlElement("HeatPreservationMinute2")]
        public int HeatPreservationMinute2 { get; set; }
        /// <summary>
        /// 烘箱2超温上限
        /// </summary>
        [XmlElement("OverTemperatureThreshold2")]
        public int OverTemperatureThreshold2 { get; set; }



        /// <summary>
        /// 工作箱抽充次数
        /// </summary>
        [XmlElement("BoxPurgeTime")]
        public int BoxPurgeTime { get; set; }
        /// <summary>
        /// 工作箱抽充压力上限
        /// </summary>
        [XmlElement("BoxPurgePressureUpperLimit")]
        public int BoxPurgePressureUpperLimit { get; set; }
        /// <summary>
        /// 工作箱抽充压力下限
        /// </summary>
        [XmlElement("BoxPurgePressureLowerLimit")]
        public int BoxPurgePressureLowerLimit { get; set; }
        /// <summary>
        /// 工作箱抽充间隔秒
        /// </summary>
        [XmlElement("BoxPurgeInterval")]
        public int BoxPurgeInterval { get; set; }
        /// <summary>
        /// 工作箱超压上限
        /// </summary>
        [XmlElement("BoxOverPressureThreshold")]
        public int BoxOverPressureThreshold { get; set; }


    }



    [Serializable]
    public class CalibrationConfig
    {
        public CalibrationConfig()
        {
            ChipPPPosCompensateCoordinate1 = new XYZTCoordinateConfig();
        }
        /// <summary>
        /// 计算芯片吸嘴旋转补偿XY公式的坐标1，一般在T0度纪录
        /// </summary>
        [XmlElement("ChipPPPosCompensateCoordinate1")]
        public XYZTCoordinateConfig ChipPPPosCompensateCoordinate1 { get; set; }
        
    }
}