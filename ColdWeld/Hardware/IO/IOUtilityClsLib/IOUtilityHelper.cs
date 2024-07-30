using BoardCardControllerClsLib;
using GlobalDataDefineClsLib;
using GlobalToolClsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TemperatureControllerClsLib;

namespace IOUtilityClsLib
{
    public class IOUtilityHelper
    {
        private static readonly object _lockObj = new object();
        private static volatile IOUtilityHelper _instance = null;
        private bool _enablePollingIO;
        IBoardCardController _boardCardController;
        private TemperatureControllerManager _TemperatureControllerManager
        {
            get { return TemperatureControllerManager.Instance; }
        }

        private Dictionary<EnumBoardcardDefineInputIO, string> _inputIOList;
        private Dictionary<EnumBoardcardDefineOutputIO, string> _outputIOList;
        public static IOUtilityHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new IOUtilityHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        private IOUtilityHelper()
        {
            _inputIOList = new Dictionary<EnumBoardcardDefineInputIO, string>();

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoorOpenstatus, "BakeOvenInnerdoorOpenstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoorOpenstatus, "BakeOvenOuterdoorOpenstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoorClosestatus, "BakeOvenInnerdoorClosestatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoorClosestatus, "BakeOvenOuterdoorClosestatus");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPressure, "BakeOvenPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenVacuum, "BakeOvenVacuum");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOven2InnerdoorOpenstatus, "BakeOven2InnerdoorOpenstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOven2OuterdoorOpenstatus, "BakeOven2OuterdoorOpenstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOven2InnerdoorClosestatus, "BakeOven2InnerdoorClosestatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOven2OuterdoorClosestatus, "BakeOven2OuterdoorClosestatus");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOven2Pressure, "BakeOven2Pressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOven2Vacuum, "BakeOven2Vacuum");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorCloseSta, "BoxOuterdoorCloseSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorOpenSta, "BoxOuterdoorOpenSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPressure, "BoxPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxVacuum, "BoxVacuum");


            _outputIOList = new Dictionary<EnumBoardcardDefineOutputIO, string>();
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerRedLight, "TowerRedLight");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerYellowLight, "TowerYellowLight");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerGreenLight, "TowerGreenLight");

            // Adding remaining IO from enum EnumBoardcardDefineOutputIO

            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenBleed, "BakeOvenBleed");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenExhaust, "BakeOvenExhaust");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenAerate, "BakeOvenAerate");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoorUp, "BakeOvenInnerdoorUp");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoorDown, "BakeOvenInnerdoorDown");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat, "BakeOvenAutoHeat");


            //烘箱2
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOven2Bleed, "BakeOven2Bleed");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOven2Exhaust, "BakeOven2Exhaust");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOven2Aerate, "BakeOven2Aerate");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOven2InnerdoorUp, "BakeOvenInnerdoorUp");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOven2InnerdoorDown, "BakeOvenInnerdoorDown");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOven2AutoHeat, "BakeOvenAutoHeat");


            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxBleed, "BoxBleed");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxExhaust, "BoxExhaust");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxAerate, "BoxAerate");

            _boardCardController = BoardCardManager.Instance.GetCurrentController();
        }
        public void Start()
        {
            _enablePollingIO = true;
            Task.Run(new Action(ReadIOTask));
        }
        public bool IsTowerRedLightOn()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.TowerRedLight, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 亮红灯
        /// </summary>
        public void TurnonTowerRedLight()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.TowerRedLight, 1);


        }
        /// <summary>
        /// 灭红灯
        /// </summary>
        public void TurnoffTowerRedLight()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.TowerRedLight, 0);
        }

        public bool IsTowerYellowLightOn()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.TowerYellowLight, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 亮黄灯
        /// </summary>
        public void TurnonTowerYellowLight()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.TowerYellowLight, 1);
        }
        /// <summary>
        /// 灭黄灯
        /// </summary>
        public void TurnoffTowerYellowLight()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.TowerYellowLight, 0);
        }
        public bool IsTowerGreenLightOn()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.TowerGreenLight, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 亮绿灯
        /// </summary>
        public void TurnonTowerGreenLight()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.TowerGreenLight, 1);
        }
        /// <summary>
        /// 灭绿灯
        /// </summary>
        public void TurnoffTowerGreenLight()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.TowerGreenLight, 0);
        }




        /// <summary>
        /// 读取IO状态的任务
        /// </summary>
        private void ReadIOTask()
        {
            while (_enablePollingIO)
            {
                Thread.Sleep(500);
                List<int> data = new List<int>(); ;
                _boardCardController.IO_ReadAllInput(11, out data);
                if (data.Count > 0)
                {
                    ParseDataAndUpdateInputIOValue(data);
                }
                _boardCardController.IO_ReadAllOutput(11, out data);
                if (data.Count > 0)
                {
                    ParseDataAndUpdateOutputIOValue(data);
                }

                List<int> data1 = new List<int>(); ;
                _boardCardController.IO_ReadAllInput(11, out data1);
                if (data.Count > 0)
                {
                    ParseDataAndUpdateInputIOIntValue(data);
                }


            }
        }




        /// <summary>
        /// 解析字符串并更新该IO点Value值
        /// </summary>
        internal void ParseDataAndUpdateInputIOValue(List<int> msg)
        {
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOvenInnerdoorOpenstatus], msg[(int)EnumBoardcardDefineInputIO.BakeOvenInnerdoorOpenstatus - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOvenOuterdoorOpenstatus], msg[(int)EnumBoardcardDefineInputIO.BakeOvenOuterdoorOpenstatus - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOvenInnerdoorClosestatus], msg[(int)EnumBoardcardDefineInputIO.BakeOvenInnerdoorClosestatus - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOvenOuterdoorClosestatus], msg[(int)EnumBoardcardDefineInputIO.BakeOvenOuterdoorClosestatus - 1] == 1 ? true : false);
            
            
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOven2InnerdoorOpenstatus], msg[(int)EnumBoardcardDefineInputIO.BakeOven2InnerdoorOpenstatus - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOven2OuterdoorOpenstatus], msg[(int)EnumBoardcardDefineInputIO.BakeOven2OuterdoorOpenstatus - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOven2InnerdoorClosestatus], msg[(int)EnumBoardcardDefineInputIO.BakeOven2InnerdoorClosestatus - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOven2OuterdoorClosestatus], msg[(int)EnumBoardcardDefineInputIO.BakeOven2OuterdoorClosestatus - 1] == 1 ? true : false);
            

            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BoxOuterdoorCloseSta], msg[(int)EnumBoardcardDefineInputIO.BoxOuterdoorCloseSta - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BoxOuterdoorOpenSta], msg[(int)EnumBoardcardDefineInputIO.BoxOuterdoorOpenSta - 1] == 1 ? true : false);
            

        }
        internal void ParseDataAndUpdateOutputIOValue(List<int> msg)
        {

            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerRedLight], msg[(int)EnumBoardcardDefineOutputIO.TowerRedLight - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerYellowLight], msg[(int)EnumBoardcardDefineOutputIO.TowerYellowLight - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerGreenLight], msg[(int)EnumBoardcardDefineOutputIO.TowerGreenLight - 1] == 1 ? true : false);

            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOvenBleed], msg[(int)EnumBoardcardDefineOutputIO.BakeOvenBleed - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOvenExhaust], msg[(int)EnumBoardcardDefineOutputIO.BakeOvenExhaust - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOvenAerate], msg[(int)EnumBoardcardDefineOutputIO.BakeOvenAerate - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOvenInnerdoorUp], msg[(int)EnumBoardcardDefineOutputIO.BakeOvenInnerdoorUp - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOvenInnerdoorDown], msg[(int)EnumBoardcardDefineOutputIO.BakeOvenInnerdoorDown - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOvenAutoHeat], msg[(int)EnumBoardcardDefineOutputIO.BakeOvenAutoHeat - 1] == 1 ? true : false);
            

            //烘箱2
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOven2Bleed], msg[(int)EnumBoardcardDefineOutputIO.BakeOven2Bleed - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOven2Exhaust], msg[(int)EnumBoardcardDefineOutputIO.BakeOven2Exhaust - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOven2Aerate], msg[(int)EnumBoardcardDefineOutputIO.BakeOven2Aerate - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOven2InnerdoorUp], msg[(int)EnumBoardcardDefineOutputIO.BakeOven2InnerdoorUp - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOven2InnerdoorDown], msg[(int)EnumBoardcardDefineOutputIO.BakeOven2InnerdoorDown - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BakeOven2AutoHeat], msg[(int)EnumBoardcardDefineOutputIO.BakeOven2AutoHeat - 1] == 1 ? true : false);




            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BoxBleed], msg[(int)EnumBoardcardDefineOutputIO.BoxBleed - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BoxExhaust], msg[(int)EnumBoardcardDefineOutputIO.BoxExhaust - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.BoxAerate], msg[(int)EnumBoardcardDefineOutputIO.BoxAerate - 1] == 1 ? true : false);
            



        }

        internal void ParseDataAndUpdateInputIOIntValue(List<int> msg)
        {
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOvenPressure], msg[(int)EnumBoardcardDefineInputIO.BakeOvenPressure - 1]);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOvenVacuum], msg[(int)EnumBoardcardDefineInputIO.BakeOvenVacuum - 1]);

            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOven2Pressure], msg[(int)EnumBoardcardDefineInputIO.BakeOven2Pressure - 1]);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BakeOven2Vacuum], msg[(int)EnumBoardcardDefineInputIO.BakeOven2Vacuum - 1]);

            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BoxPressure], msg[(int)EnumBoardcardDefineInputIO.BoxPressure - 1]);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.BoxVacuum], msg[(int)EnumBoardcardDefineInputIO.BoxVacuum - 1]);


        }

        internal void ParseDataAndUpdateInputIOIntValue()
        {
            float BakeOvenUPtemp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Up).Read(TemperatureRtuAdd.PV);
            IOManager.Instance.ChangeIOValue("BakeOvenUPtemp", BakeOvenUPtemp);

            float BakeOvenDowntemp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox1Low).Read(TemperatureRtuAdd.PV);
            IOManager.Instance.ChangeIOValue("BakeOvenDowntemp", BakeOvenDowntemp);

            float BakeOven2UPtemp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Up).Read(TemperatureRtuAdd.PV);
            IOManager.Instance.ChangeIOValue("BakeOven2UPtemp", BakeOven2UPtemp);

            float BakeOven2Downtemp = _TemperatureControllerManager.GetTemperatureController(EnumTemperatureType.OvenBox2Low).Read(TemperatureRtuAdd.PV);
            IOManager.Instance.ChangeIOValue("BakeOven2Downtemp", BakeOven2Downtemp);

        }

    }


}
