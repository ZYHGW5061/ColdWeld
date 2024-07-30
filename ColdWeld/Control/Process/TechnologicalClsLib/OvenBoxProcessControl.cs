using BoardCardControllerClsLib;
using GlobalDataDefineClsLib;
using GlobalToolClsLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TemperatureControllerClsLib;

namespace TechnologicalClsLib
{
    public class OvenBoxProcessControl
    {
        #region Private File

        private static readonly object _lockObj = new object();
        private static volatile OvenBoxProcessControl _instance = null;

        IBoardCardController _boardCardController;

        public static OvenBoxProcessControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new OvenBoxProcessControl();
                        }
                    }
                }
                return _instance;
            }
        }

        

        private OvenBoxProcessControl()
        {
            _boardCardController = BoardCardManager.Instance.GetCurrentController();
        }


        private TemperatureControllerManager _TemperatureControllerManager
        {
            get { return TemperatureControllerManager.Instance; }
        }


        private Thread heatthd;


        //private StageCore stage = StageControllerClsLib.StageCore.Instance;
        ///// <summary>
        ///// 定位系统
        ///// </summary>
        //private PositioningSystem _positioningSystem
        //{
        //    get { return PositioningSystem.Instance; }
        //}

        //private CameraConfig _TrackCameraConfig
        //{
        //    get { return CameraManager.Instance.GetCameraConfigByID(EnumCameraType.TrackCamera); }
        //}
        //private CameraConfig _WeldCameraConfig
        //{
        //    get { return CameraManager.Instance.GetCameraConfigByID(EnumCameraType.WeldCamera); }
        //}

        //private SystemConfiguration _systemConfig
        //{
        //    get { return SystemConfiguration.Instance; }
        //}

        //private VisionControlAppClsLib.VisualControlManager _VisualManager
        //{
        //    get { return VisionControlAppClsLib.VisualControlManager.Instance; }
        //}
        //public VisualControlApplications TrackCameraVisual
        //{
        //    get { return _VisualManager.GetCameraByID(EnumCameraType.TrackCamera); }
        //}
        //public VisualControlApplications WeldCameraVisual
        //{
        //    get { return _VisualManager.GetCameraByID(EnumCameraType.WeldCamera); }
        //}


        //VisualControlForm VForm;

        #endregion

        #region Public File

        public EnumOvenBoxStates OvenBox1state { get; set; } = new EnumOvenBoxStates();
        public EnumOvenBoxStates OvenBox2state { get; set; } = new EnumOvenBoxStates();
        public bool IsConnected 
        {
            get 
            {
                return _boardCardController.IsConnect;
            }
        }


        private bool StopHeat = false;

        #endregion


        #region Private Mothed

        private EnumOvenBoxStates ReadAllOvenBoxStatesMothed(EnumOvenBoxNum num)
        {
            try
            {
                EnumOvenBoxStates OvenBoxstate = new EnumOvenBoxStates();
                if (num == EnumOvenBoxNum.Oven1)
                {
                    //OvenBoxstate
                }
                else if(num == EnumOvenBoxNum.Oven2)
                {

                }

                return OvenBoxstate;
            }
            catch(Exception ex)
            {
                return null;
            }
            

        }

        private bool ReadBoolOvenBoxStatesMothed(EnumBoardcardDefineInputIO name)
        {
            try
            {
                var ret = false;
                var status = 0;
                _boardCardController.IO_ReadOutput(11, (int)name, out status);
                ret = status == 1;
                return ret;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private float ReadfloatOvenBoxStatesMothed(EnumBoardcardDefineInputIO name)
        {
            try
            {
                

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }

        private short ReadshortOvenBoxStatesMothed(EnumBoardcardDefineInputIO name)
        {
            try
            {
                EnumOvenBoxStates OvenBoxstate = new EnumOvenBoxStates();

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }

        private bool ReadBoolOvenBoxStatesMothed(EnumBoardcardDefineOutputIO name)
        {
            try
            {
                var ret = false;
                var status = 0;
                _boardCardController.IO_ReadOutput(11, (int)name, out status);
                ret = status == 1;
                return ret;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private float ReadfloatOvenBoxStatesMothed(EnumBoardcardDefineOutputIO name)
        {
            try
            {


                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }

        private short ReadshortOvenBoxStatesMothed(EnumBoardcardDefineOutputIO name)
        {
            try
            {
                EnumOvenBoxStates OvenBoxstate = new EnumOvenBoxStates();

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }


        private int WriteBoolOvenBoxStatesMothed(EnumBoardcardDefineOutputIO name, bool value)
        {
            try
            {
                int V = 0;
                if(value == false)
                {
                    V = 0;
                }
                else
                {
                    V = 1;
                }

                _boardCardController.IO_WriteOutPut(11, (short)name, V);

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }

        private int WritefloatOvenBoxStatesMothed(EnumBoardcardDefineOutputIO name, float value)
        {
            try
            {

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }

        private int WriteshortOvenBoxStatesMothed(EnumBoardcardDefineOutputIO name, short value)
        {
            try
            {

                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }


        private void ManualHeatMothed(EnumOvenBoxNum num, int HeatTargetTemperature, int HeatPreservationMinute, int OverTemperatureThreshold)
        {
            IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", HeatPreservationMinute);

            if (num == EnumOvenBoxNum.Oven1)
            {
                if (_TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).IsConnect && _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.RUN, 1);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.RUN, 1);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, true);

                    Stopwatch stopwatch = new Stopwatch();

                    while (!StopHeat)
                    {
                        float temperatureLow = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Read(TemperatureRtuAdd.PV);
                        float temperatureUp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Read(TemperatureRtuAdd.PV);

                        if((temperatureLow > (HeatTargetTemperature - 1)) && (temperatureUp > (HeatTargetTemperature - 1)))
                        {
                            break;
                        }
                        Thread.Sleep(200);
                    }

                    if(StopHeat)
                    {
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.RUN, 0);
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.RUN, 0);

                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, false);

                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                        StopHeat = false;

                        return;
                    }


                    float temperatureLow1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Read(TemperatureRtuAdd.PV);
                    float temperatureUp1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Read(TemperatureRtuAdd.PV);
                    if ((temperatureLow1 > (HeatTargetTemperature - 1)) && (temperatureUp1 > (HeatTargetTemperature - 1)))
                    {
                        stopwatch.Start();
                    }

                    while (!StopHeat)
                    {
                        if ((stopwatch.Elapsed.TotalSeconds / 60) > HeatPreservationMinute)
                        {
                            stopwatch.Stop();

                            break;
                        }

                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", HeatPreservationMinute - (stopwatch.Elapsed.TotalSeconds / 60));

                        Thread.Sleep(500);

                    }

                    if(stopwatch.IsRunning)
                    {
                        stopwatch.Stop();
                    }

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.RUN, 0);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.RUN, 0);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, false);

                    IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                    StopHeat = false;
                }
            }
            else if (num == EnumOvenBoxNum.Oven2)
            {
                if (_TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).IsConnect && _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.RUN, 1);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.RUN, 1);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, true);

                    Stopwatch stopwatch = new Stopwatch();

                    while (!StopHeat)
                    {
                        float temperatureLow = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Read(TemperatureRtuAdd.PV);
                        float temperatureUp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Read(TemperatureRtuAdd.PV);

                        if ((temperatureLow > (HeatTargetTemperature - 1)) && (temperatureUp > (HeatTargetTemperature - 1)))
                        {
                            break;
                        }
                        Thread.Sleep(200);
                    }

                    if (StopHeat)
                    {
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.RUN, 0);
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.RUN, 0);

                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, false);

                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                        StopHeat = false;

                        return;
                    }


                    float temperatureLow1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Read(TemperatureRtuAdd.PV);
                    float temperatureUp1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Read(TemperatureRtuAdd.PV);
                    if ((temperatureLow1 > (HeatTargetTemperature - 1)) && (temperatureUp1 > (HeatTargetTemperature - 1)))
                    {
                        stopwatch.Start();
                    }

                    while (!StopHeat)
                    {
                        if ((stopwatch.Elapsed.TotalSeconds / 60) > HeatPreservationMinute)
                        {
                            stopwatch.Stop();

                            break;
                        }

                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", HeatPreservationMinute - (stopwatch.Elapsed.TotalSeconds / 60));

                        Thread.Sleep(500);

                    }

                    if (stopwatch.IsRunning)
                    {
                        stopwatch.Stop();
                    }

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.RUN, 0);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.RUN, 0);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, false);

                    IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                    StopHeat = false;
                }
            }

        }


        private void AutoHeatMothed(EnumOvenBoxNum num, int HeatTargetTemperature, int HeatPreservationMinute, int OverTemperatureThreshold, int BakeOvenPFUpPressure, int BakeOvenPFDownPressure, int BakeOvenPFnum, int BakeOvenPFinterval)
        {
            IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", HeatPreservationMinute);

            if (num == EnumOvenBoxNum.Oven1)
            {
                if (_TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).IsConnect && _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.RUN, 1);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.RUN, 1);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, true);


                    bool BakeOvenBleedstatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed);
                    bool BakeOvenAeratestatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate);
                    bool BakeOvenExhauststatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOvenExhaust);
                    if (BakeOvenBleedstatus == true)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);
                    }
                    if (BakeOvenAeratestatus == true)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, false);
                    }
                    if (BakeOvenExhauststatus == true)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenExhaust, false);
                    }

                    //抽气

                    if (Read<float>(EnumBoardcardDefineInputIO.BakeOvenVacuum) > BakeOvenPFDownPressure)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, true);

                        while (!StopHeat)
                        {
                            float BakeOvenVacuum = Read<float>(EnumBoardcardDefineInputIO.BakeOvenVacuum);

                            if (BakeOvenVacuum < BakeOvenPFDownPressure)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);
                                break;
                            }
                            Thread.Sleep(200);
                        }

                        if (StopHeat)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);

                            StopHeat = false;

                            IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                            IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                            return;
                        }
                    }


                    Stopwatch stopwatch = new Stopwatch();

                    while (!StopHeat)
                    {
                        float temperatureLow = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Read(TemperatureRtuAdd.PV);
                        float temperatureUp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Read(TemperatureRtuAdd.PV);

                        if ((temperatureLow > (HeatTargetTemperature - 1)) && (temperatureUp > (HeatTargetTemperature - 1)))
                        {
                            break;
                        }
                        Thread.Sleep(200);
                    }


                    if (StopHeat)
                    {
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.RUN, 0);
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.RUN, 0);

                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, false);

                        StopHeat = false;

                        IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                        return;
                    }


                    float temperatureLow1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Read(TemperatureRtuAdd.PV);
                    float temperatureUp1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Read(TemperatureRtuAdd.PV);
                    if ((temperatureLow1 > (HeatTargetTemperature - 1)) && (temperatureUp1 > (HeatTargetTemperature - 1)))
                    {
                        stopwatch.Start();
                    }

                    for (int i = 0; i < BakeOvenPFnum; i++)
                    {
                        //抽气

                        if (Read<float>(EnumBoardcardDefineInputIO.BakeOvenVacuum) > BakeOvenPFDownPressure)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, true);

                            while (!StopHeat)
                            {
                                float BakeOvenVacuum = Read<float>(EnumBoardcardDefineInputIO.BakeOvenVacuum);

                                if (BakeOvenVacuum < BakeOvenPFDownPressure)
                                {
                                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);
                                    break;
                                }
                                Thread.Sleep(200);
                            }

                            if (StopHeat)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);

                                IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                                IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                                StopHeat = false;

                                return;
                            }
                        }


                        //充气

                        if (Read<float>(EnumBoardcardDefineInputIO.BakeOvenPressure) < BakeOvenPFUpPressure)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, true);

                            while (!StopHeat)
                            {
                                float BakeOvenPressure = Read<float>(EnumBoardcardDefineInputIO.BakeOvenPressure);

                                if (BakeOvenPressure > BakeOvenPFUpPressure)
                                {
                                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, false);
                                    break;
                                }
                                Thread.Sleep(200);
                            }

                            if (StopHeat)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, false);

                                _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.RUN, 0);
                                _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.RUN, 0);

                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, false);

                                StopHeat = false;

                                IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                                IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                                return;
                            }
                        }

                        IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", i);

                        //间隔时间
                        Thread.Sleep(BakeOvenPFinterval * 1000);

                    }


                    while (!StopHeat)
                    {
                        if ((stopwatch.Elapsed.TotalSeconds / 60) > HeatPreservationMinute)
                        {
                            stopwatch.Stop();

                            break;
                        }

                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", HeatPreservationMinute - (stopwatch.Elapsed.TotalSeconds / 60));

                        Thread.Sleep(500);

                    }

                    if (stopwatch.IsRunning)
                    {
                        stopwatch.Stop();
                    }

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Write(TemperatureRtuAdd.RUN, 0);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Write(TemperatureRtuAdd.RUN, 0);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, false);

                    IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                    IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                    StopHeat = false;
                }
            }
            else if (num == EnumOvenBoxNum.Oven2)
            {
                if (_TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).IsConnect && _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).IsConnect)
                {
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.FIX_SV1, (int)HeatTargetTemperature);

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.RUN, 1);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.RUN, 1);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, true);


                    bool BakeOvenBleedstatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed);
                    bool BakeOvenAeratestatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate);
                    bool BakeOvenExhauststatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOven2Exhaust);
                    if (BakeOvenBleedstatus == true)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);
                    }
                    if (BakeOvenAeratestatus == true)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, false);
                    }
                    if (BakeOvenExhauststatus == true)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Exhaust, false);
                    }

                    //抽气

                    if (Read<float>(EnumBoardcardDefineInputIO.BakeOven2Vacuum) > BakeOvenPFDownPressure)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, true);

                        while (!StopHeat)
                        {
                            float BakeOvenVacuum = Read<float>(EnumBoardcardDefineInputIO.BakeOven2Vacuum);

                            if (BakeOvenVacuum < BakeOvenPFDownPressure)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);
                                break;
                            }
                            Thread.Sleep(200);
                        }

                        if (StopHeat)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);

                            IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                            IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                            StopHeat = false;

                            return;
                        }
                    }


                    Stopwatch stopwatch = new Stopwatch();

                    while (!StopHeat)
                    {
                        float temperatureLow = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Read(TemperatureRtuAdd.PV);
                        float temperatureUp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Read(TemperatureRtuAdd.PV);

                        if ((temperatureLow > (HeatTargetTemperature - 1)) && (temperatureUp > (HeatTargetTemperature - 1)))
                        {
                            break;
                        }
                        Thread.Sleep(200);
                    }


                    if (StopHeat)
                    {
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.RUN, 0);
                        _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.RUN, 0);

                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, false);

                        IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                        StopHeat = false;

                        return;
                    }


                    float temperatureLow1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Read(TemperatureRtuAdd.PV);
                    float temperatureUp1 = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Read(TemperatureRtuAdd.PV);
                    if ((temperatureLow1 > (HeatTargetTemperature - 1)) && (temperatureUp1 > (HeatTargetTemperature - 1)))
                    {
                        stopwatch.Start();
                    }

                    for (int i = 0; i < BakeOvenPFnum; i++)
                    {
                        //抽气

                        if (Read<float>(EnumBoardcardDefineInputIO.BakeOven2Vacuum) > BakeOvenPFDownPressure)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, true);

                            while (!StopHeat)
                            {
                                float BakeOvenVacuum = Read<float>(EnumBoardcardDefineInputIO.BakeOven2Vacuum);

                                if (BakeOvenVacuum < BakeOvenPFDownPressure)
                                {
                                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);
                                    break;
                                }
                                Thread.Sleep(200);
                            }

                            if (StopHeat)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);

                                IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                                IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                                StopHeat = false;

                                return;
                            }
                        }


                        //充气

                        if (Read<float>(EnumBoardcardDefineInputIO.BakeOven2Pressure) < BakeOvenPFUpPressure)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, true);

                            while (!StopHeat)
                            {
                                float BakeOvenPressure = Read<float>(EnumBoardcardDefineInputIO.BakeOven2Pressure);

                                if (BakeOvenPressure > BakeOvenPFUpPressure)
                                {
                                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, false);
                                    break;
                                }
                                Thread.Sleep(200);
                            }

                            if (StopHeat)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, false);

                                _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.RUN, 0);
                                _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.RUN, 0);

                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, false);

                                IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                                IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                                StopHeat = false;

                                return;
                            }
                        }

                        IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", i);

                        //间隔时间
                        Thread.Sleep(BakeOvenPFinterval * 1000);

                    }


                    while (!StopHeat)
                    {
                        if ((stopwatch.Elapsed.TotalSeconds / 60) > HeatPreservationMinute)
                        {
                            stopwatch.Stop();

                            break;
                        }

                        IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", HeatPreservationMinute - (stopwatch.Elapsed.TotalSeconds / 60));

                        Thread.Sleep(500);

                    }

                    if (stopwatch.IsRunning)
                    {
                        stopwatch.Stop();
                    }

                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Write(TemperatureRtuAdd.RUN, 0);
                    _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Write(TemperatureRtuAdd.RUN, 0);

                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, false);

                    IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
                    IOManager.Instance.ChangeIOValue("HeatPreservationResidueMinute", 0);

                    StopHeat = false;
                }
            }


        }


        private void PurgeMothed(EnumOvenBoxNum num, int BakeOvenPFUpPressure, int BakeOvenPFDownPressure,int BakeOvenPFnum, int BakeOvenPFinterval)
        {
            if(num == EnumOvenBoxNum.Oven1)
            {
                IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);

                bool BakeOvenBleedstatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed);
                bool BakeOvenAeratestatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate);
                bool BakeOvenExhauststatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOvenExhaust);
                if (BakeOvenBleedstatus == true)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);
                }
                if (BakeOvenAeratestatus == true)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, false);
                }
                if (BakeOvenExhauststatus == true)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenExhaust, false);
                }

                for(int i = 0; i < BakeOvenPFnum; i++)
                {
                    //抽气

                    if(Read<float>(EnumBoardcardDefineInputIO.BakeOvenVacuum) > BakeOvenPFDownPressure)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, true);

                        while (!StopHeat)
                        {
                            float BakeOvenVacuum = Read<float>(EnumBoardcardDefineInputIO.BakeOvenVacuum);

                            if (BakeOvenVacuum < BakeOvenPFDownPressure)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);
                                break;
                            }
                            Thread.Sleep(200);
                        }

                        if (StopHeat)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenBleed, false);

                            IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);

                            StopHeat = false;

                            return;
                        }
                    }

                    
                    //充气

                    if(Read<float>(EnumBoardcardDefineInputIO.BakeOvenPressure) < BakeOvenPFUpPressure)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, true);

                        while (!StopHeat)
                        {
                            float BakeOvenPressure = Read<float>(EnumBoardcardDefineInputIO.BakeOvenPressure);

                            if (BakeOvenPressure > BakeOvenPFUpPressure)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, false);
                                break;
                            }
                            Thread.Sleep(200);
                        }

                        if (StopHeat)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOvenAerate, false);

                            IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);

                            StopHeat = false;

                            return;
                        }
                    }

                    IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", i);

                    //间隔时间
                    Thread.Sleep(BakeOvenPFinterval * 1000);

                }

            }
            else if(num == EnumOvenBoxNum.Oven2)
            {
                IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);

                bool BakeOvenBleedstatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed);
                bool BakeOvenAeratestatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate);
                bool BakeOvenExhauststatus = Read<bool>(EnumBoardcardDefineOutputIO.BakeOven2Exhaust);
                if (BakeOvenBleedstatus == true)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);
                }
                if (BakeOvenAeratestatus == true)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, false);
                }
                if (BakeOvenExhauststatus == true)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Exhaust, false);
                }

                for (int i = 0; i < BakeOvenPFnum; i++)
                {
                    //抽气

                    if (Read<float>(EnumBoardcardDefineInputIO.BakeOven2Vacuum) > BakeOvenPFDownPressure)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, true);

                        while (!StopHeat)
                        {
                            float BakeOvenVacuum = Read<float>(EnumBoardcardDefineInputIO.BakeOven2Vacuum);

                            if (BakeOvenVacuum < BakeOvenPFDownPressure)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);
                                break;
                            }
                            Thread.Sleep(200);
                        }

                        if (StopHeat)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Bleed, false);

                            IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);

                            StopHeat = false;

                            return;
                        }
                    }


                    //充气

                    if (Read<float>(EnumBoardcardDefineInputIO.BakeOven2Pressure) < BakeOvenPFUpPressure)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, true);

                        while (!StopHeat)
                        {
                            float BakeOvenPressure = Read<float>(EnumBoardcardDefineInputIO.BakeOven2Pressure);

                            if (BakeOvenPressure > BakeOvenPFUpPressure)
                            {
                                Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, false);
                                break;
                            }
                            Thread.Sleep(200);
                        }

                        if (StopHeat)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BakeOven2Aerate, false);

                            IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);

                            StopHeat = false;

                            return;
                        }
                    }

                    IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", i);

                    //间隔时间
                    Thread.Sleep(BakeOvenPFinterval * 1000);

                }
                
            }
            IOManager.Instance.ChangeIOValue("OvenPurgeResidueTime", 0);
        }

        private void BoxPurgeMothed(int BoxPFUpPressure, int BoxPFDownPressure, int BoxPFnum, int BoxPFinterval)
        {
            IOManager.Instance.ChangeIOValue("BoxPurgeResidueTime", 0);

            bool BoxBleedstatus = Read<bool>(EnumBoardcardDefineOutputIO.BoxBleed);
            bool BoxAeratestatus = Read<bool>(EnumBoardcardDefineOutputIO.BoxAerate);
            bool BoxExhauststatus = Read<bool>(EnumBoardcardDefineOutputIO.BoxExhaust);
            if (BoxBleedstatus == true)
            {
                Write<bool>(EnumBoardcardDefineOutputIO.BoxBleed, false);
            }
            if (BoxAeratestatus == true)
            {
                Write<bool>(EnumBoardcardDefineOutputIO.BoxAerate, false);
            }
            if (BoxExhauststatus == true)
            {
                Write<bool>(EnumBoardcardDefineOutputIO.BoxExhaust, false);
            }

            for (int i = 0; i < BoxPFnum; i++)
            {
                //抽气

                if (Read<float>(EnumBoardcardDefineInputIO.BoxVacuum) > BoxPFDownPressure)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BoxBleed, true);

                    while (!StopHeat)
                    {
                        float BoxVacuum = Read<float>(EnumBoardcardDefineInputIO.BoxVacuum);

                        if (BoxVacuum < BoxPFDownPressure)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BoxBleed, false);
                            break;
                        }
                        Thread.Sleep(200);
                    }

                    if (StopHeat)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BoxBleed, false);

                        IOManager.Instance.ChangeIOValue("BoxPurgeResidueTime", 0);

                        StopHeat = false;

                        return;
                    }
                }


                //充气

                if (Read<float>(EnumBoardcardDefineInputIO.BoxPressure) < BoxPFUpPressure)
                {
                    Write<bool>(EnumBoardcardDefineOutputIO.BoxAerate, true);

                    while (!StopHeat)
                    {
                        float BoxPressure = Read<float>(EnumBoardcardDefineInputIO.BoxPressure);

                        if (BoxPressure > BoxPFUpPressure)
                        {
                            Write<bool>(EnumBoardcardDefineOutputIO.BoxAerate, false);
                            break;
                        }
                        Thread.Sleep(200);
                    }

                    if (StopHeat)
                    {
                        Write<bool>(EnumBoardcardDefineOutputIO.BoxAerate, false);

                        IOManager.Instance.ChangeIOValue("BoxPurgeResidueTime", 0);

                        StopHeat = false;

                        return;
                    }
                }

                IOManager.Instance.ChangeIOValue("BoxPurgeResidueTime", i);

                //间隔时间
                Thread.Sleep(BoxPFinterval * 1000);

            }
            IOManager.Instance.ChangeIOValue("BoxPurgeResidueTime", 0);
        }


        #endregion



        #region Public Mothed

        public EnumOvenBoxStates ReadAllOvenBoxStates(EnumOvenBoxNum num)
        {
            return ReadAllOvenBoxStatesMothed(num);
        }

        public bool ReadBoolOvenBoxStates(EnumBoardcardDefineInputIO name)
        {
            return ReadBoolOvenBoxStatesMothed(name);
        }
        public float ReadfloatOvenBoxStates(EnumBoardcardDefineInputIO name)
        {
            return ReadfloatOvenBoxStatesMothed(name);
        }
        public short ReadshortOvenBoxStates(EnumBoardcardDefineInputIO name)
        {
            return ReadshortOvenBoxStatesMothed(name);
        }

        public bool ReadBoolOvenBoxStates(EnumBoardcardDefineOutputIO name)
        {
            return ReadBoolOvenBoxStatesMothed(name);
        }
        public float ReadfloatOvenBoxStates(EnumBoardcardDefineOutputIO name)
        {
            return ReadfloatOvenBoxStatesMothed(name);
        }
        public short ReadshortOvenBoxStates(EnumBoardcardDefineOutputIO name)
        {
            return ReadshortOvenBoxStatesMothed(name);
        }


        public int WriteBoolOvenBoxStates(EnumBoardcardDefineOutputIO name, bool value)
        {
            return WriteBoolOvenBoxStatesMothed(name, value);
        }
        public int WritefloatOvenBoxStates(EnumBoardcardDefineOutputIO name, float value)
        {
            return WritefloatOvenBoxStatesMothed(name, value);
        }
        public int WriteshortOvenBoxStates(EnumBoardcardDefineOutputIO name, short value)
        {
            return WriteshortOvenBoxStatesMothed(name, value);
        }





        /// <summary>
        /// 读取节点
        /// </summary>
        /// <typeparam name="T"> bool int float</typeparam>
        /// <param name="Note"> 节点</param>
        /// <returns></returns>
        public T Read<T>(EnumBoardcardDefineInputIO name)
        {
            try
            {
                Type t = typeof(T);
                if(t == typeof(bool))
                {
                    bool V = ReadBoolOvenBoxStates(name);


                    return (T)Convert.ChangeType("" + V, typeof(T));
                }
                else if (t == typeof(float))
                {
                    float V = ReadfloatOvenBoxStates(name);


                    return (T)Convert.ChangeType("" + V, typeof(T));
                }
                else if (t == typeof(short))
                {
                    short V = ReadshortOvenBoxStates(name);


                    return (T)Convert.ChangeType("" + V, typeof(T));
                }


                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public T Read<T>(EnumBoardcardDefineOutputIO name)
        {
            try
            {
                Type t = typeof(T);
                if (t == typeof(bool))
                {
                    bool V = ReadBoolOvenBoxStates(name);


                    return (T)Convert.ChangeType("" + V, typeof(T));
                }
                else if (t == typeof(float))
                {
                    float V = ReadfloatOvenBoxStates(name);


                    return (T)Convert.ChangeType("" + V, typeof(T));
                }
                else if (t == typeof(short))
                {
                    short V = ReadshortOvenBoxStates(name);


                    return (T)Convert.ChangeType("" + V, typeof(T));
                }

                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }



        public void Write<T>(EnumBoardcardDefineOutputIO name, T Data)
        {
            try
            {
                Type t = typeof(T);

                if (t == typeof(bool))
                {

                    WriteBoolOvenBoxStates(name, Convert.ToBoolean(Data));

                }
                else if (t == typeof(float))
                {
                    WritefloatOvenBoxStates(name, Convert.ToSingle(Data));
                }
                else if (t == typeof(short))
                {
                    WriteshortOvenBoxStates(name, Convert.ToInt16(Data));
                }
            }
            catch (Exception ex)
            {

            }
        }



        public void BoxPurge(int BakeOvenPFUpPressure, int BakeOvenPFDownPressure, int BakeOvenPFnum, int BakeOvenPFinterval)
        {
            try
            {
                if (heatthd != null && heatthd.IsAlive)
                {
                    return;
                }

                heatthd = new Thread(() => BoxPurgeMothed(BakeOvenPFUpPressure, BakeOvenPFDownPressure, BakeOvenPFnum, BakeOvenPFinterval));

                StopHeat = false;

                heatthd.Start();


            }
            catch (Exception ex)
            {

            }
        }

        public void StopBoxPurge()
        {
            if (heatthd != null && heatthd.IsAlive)
            {
                StopHeat = true;

                heatthd.Join();
            }
        }


        public void Purge(EnumOvenBoxNum num, int BakeOvenPFUpPressure, int BakeOvenPFDownPressure, int BakeOvenPFnum, int BakeOvenPFinterval)
        {
            try
            {
                if (heatthd != null && heatthd.IsAlive)
                {
                    return;
                }

                heatthd = new Thread(() => PurgeMothed(num, BakeOvenPFUpPressure, BakeOvenPFDownPressure, BakeOvenPFnum, BakeOvenPFinterval));

                StopHeat = false;

                heatthd.Start();


            }
            catch (Exception ex)
            {

            }
        }

        public void StopPurge()
        {
            if (heatthd != null && heatthd.IsAlive)
            {
                StopHeat = true;

                heatthd.Join();
            }
        }

        public void ManualHeat(EnumOvenBoxNum num, int HeatTargetTemperature, int HeatPreservationMinute, int OverTemperatureThreshold)
        {

            try
            {
                if(heatthd != null &&  heatthd.IsAlive)
                {
                    return;
                }

                heatthd = new Thread(() => ManualHeatMothed(num, HeatTargetTemperature, HeatPreservationMinute, OverTemperatureThreshold));

                StopHeat = false;

                heatthd.Start();


            }
            catch(Exception ex)
            {

            }
        }

        public void StopManualHeat()
        {
            if (heatthd != null && heatthd.IsAlive)
            {
                StopHeat = true;

                heatthd.Join();
            }
        }

        public void AutoHeat(EnumOvenBoxNum num, int HeatTargetTemperature, int HeatPreservationMinute, int OverTemperatureThreshold, int BakeOvenPFUpPressure, int BakeOvenPFDownPressure, int BakeOvenPFnum, int BakeOvenPFinterval)
        {
            try
            {
                if (heatthd != null && heatthd.IsAlive)
                {
                    return;
                }

                heatthd = new Thread(() => AutoHeatMothed(num, HeatTargetTemperature, HeatPreservationMinute, OverTemperatureThreshold, BakeOvenPFUpPressure, BakeOvenPFDownPressure, BakeOvenPFnum, BakeOvenPFinterval));

                StopHeat = false;

                heatthd.Start();


            }
            catch (Exception ex)
            {

            }
        }


        public void StopAutoHeat()
        {
            if (heatthd != null && heatthd.IsAlive)
            {
                StopHeat = true;

                heatthd.Join();
            }
        }


        public void OpenOvenboxInnerDoor(EnumOvenBoxNum num)
        {

        }

        public void CloseOvenboxInnerDoor(EnumOvenBoxNum num)
        {

        }


        #endregion



    }

}
