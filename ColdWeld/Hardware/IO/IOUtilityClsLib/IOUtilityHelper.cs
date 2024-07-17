using BoardCardControllerClsLib;
using GlobalDataDefineClsLib;
using GlobalToolClsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOUtilityClsLib
{
    public class IOUtilityHelper
    {
        private static readonly object _lockObj = new object();
        private static volatile IOUtilityHelper _instance = null;
        private bool _enablePollingIO;
        IBoardCardController _boardCardController;
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

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenBleedstatus, "BakeOvenBleedstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenExhauststatus, "BakeOvenExhauststatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenAeratestatus, "BakeOvenAeratestatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoor1Pressstatus, "BakeOvenInnerdoor1Pressstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoor1Pressstatus, "BakeOvenOuterdoor1Pressstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoor1Releasestatus, "BakeOvenInnerdoor1Releasestatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoor1Releasestatus, "BakeOvenOuterdoor1Releasestatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoor2Upstatus, "BakeOvenInnerdoor2Upstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoor2Upstatus, "BakeOvenOuterdoor2Upstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoor2Downstatus, "BakeOvenInnerdoor2Downstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoor2Downstatus, "BakeOvenOuterdoor2Downstatus");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoorUpSta, "BakeOvenOuterdoorUpSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoorDownSta, "BakeOvenOuterdoorDownSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoorPressSta, "BakeOvenOuterdoorPressSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenOuterdoorReleaseSta, "BakeOvenOuterdoorReleaseSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoorUpSta, "BakeOvenInnerdoorUpSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoorDownSta, "BakeOvenInnerdoorDownSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoorPressSta, "BakeOvenInnerdoorPressSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenInnerdoorReleaseSta, "BakeOvenInnerdoorReleaseSta");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPressure, "BakeOvenPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenVacuum, "BakeOvenVacuum");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenUPtemp, "BakeOvenUPtemp");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenDowntemp, "BakeOvenDowntemp");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenTargettemp, "BakeOvenTargettemp");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenAlarmtemp, "BakeOvenAlarmtemp");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenHoldingTimeH, "BakeOvenHoldingTimeH");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenHoldingTimeM, "BakeOvenHoldingTimeM");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPassedTimeH, "BakeOvenPassedTimeH");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPassedTimeM, "BakeOvenPassedTimeM");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenAlarmPressure, "BakeOvenAlarmPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenUpHeatPID_P, "BakeOvenUpHeatPID_P");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenUpHeatPID_I, "BakeOvenUpHeatPID_I");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenUpHeatPID_D, "BakeOvenUpHeatPID_D");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenDownHeatPID_P, "BakeOvenDownHeatPID_P");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenDownHeatPID_I, "BakeOvenDownHeatPID_I");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenDownHeatPID_D, "BakeOvenDownHeatPID_D");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPFUpPressure, "BakeOvenPFUpPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPFDownPressure, "BakeOvenPFDownPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPFnum, "BakeOvenPFnum");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPFCompletednum, "BakeOvenPFCompletednum");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPFinterval, "BakeOvenPFinterval");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BakeOvenPF, "BakeOvenPF");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxBleedstatus, "BoxBleedstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxExhauststatus, "BoxExhauststatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxAeratestatus, "BoxAeratestatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorElePressstatus, "BoxOuterdoorElePressstatus");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorEleReleasestatus, "BoxOuterdoorEleReleasestatus");

            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorPressSta, "BoxOuterdoorPressSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorReleaseSta, "BoxOuterdoorReleaseSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorCloseSta, "BoxOuterdoorCloseSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorOpenSta, "BoxOuterdoorOpenSta");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPressure, "BoxPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxVacuum, "BoxVacuum");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPFUpPressure, "BoxPFUpPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPFDownPressure, "BoxPFDownPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPFnum, "BoxPFnum");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPFCompletednum, "BoxPFCompletednum");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPFinterval, "BoxPFinterval");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxPF, "BoxPF");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxAlarmPressure, "BoxAlarmPressure");
            _inputIOList.Add(EnumBoardcardDefineInputIO.BoxOuterdoorspeed, "BoxOuterdoorspeed");


            _outputIOList = new Dictionary<EnumBoardcardDefineOutputIO, string>();
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerRedLight, "TowerRedLight");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerYellowLight, "TowerYellowLight");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerGreenLight, "TowerGreenLight");

            // Adding remaining IO from enum EnumBoardcardDefineOutputIO

            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenBleed, "BakeOvenBleed");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenExhaust, "BakeOvenExhaust");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenAerate, "BakeOvenAerate");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoor1Press, "BakeOvenInnerdoor1Press");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenOuterdoor1Press, "BakeOvenOuterdoor1Press");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoor1Release, "BakeOvenInnerdoor1Release");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenOuterdoor1Release, "BakeOvenOuterdoor1Release");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoor2Up, "BakeOvenInnerdoor2Up");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenOuterdoor2Up, "BakeOvenOuterdoor2Up");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoor2Down, "BakeOvenInnerdoor2Down");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenOuterdoor2Down, "BakeOvenOuterdoor2Down");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoorOpen, "BakeOvenInnerdoorOpen");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenOuterdoorOpen, "BakeOvenOuterdoorOpen");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoorClose, "BakeOvenInnerdoorClose");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenOuterdoorClose, "BakeOvenOuterdoorClose");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenOuterdoorStop, "BakeOvenOuterdoorStop");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenInnerdoorStop, "BakeOvenInnerdoorStop");

            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPressure, "BakeOvenPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenVacuum, "BakeOvenVacuum");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenUPtemp, "BakeOvenUPtemp");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenDowntemp, "BakeOvenDowntemp");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenTargettemp, "BakeOvenTargettemp");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenAlarmtemp, "BakeOvenAlarmtemp");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenHoldingTimeH, "BakeOvenHoldingTimeH");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenHoldingTimeM, "BakeOvenHoldingTimeM");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPassedTimeH, "BakeOvenPassedTimeH");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPassedTimeM, "BakeOvenPassedTimeM");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenAlarmPressure, "BakeOvenAlarmPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenUpHeatPID_P, "BakeOvenUpHeatPID_P");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenUpHeatPID_I, "BakeOvenUpHeatPID_I");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenUpHeatPID_D, "BakeOvenUpHeatPID_D");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenDownHeatPID_P, "BakeOvenDownHeatPID_P");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenDownHeatPID_I, "BakeOvenDownHeatPID_I");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenDownHeatPID_D, "BakeOvenDownHeatPID_D");

            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPFUpPressure, "BakeOvenPFUpPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPFDownPressure, "BakeOvenPFDownPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPFnum, "BakeOvenPFnum");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPFCompletednum, "BakeOvenPFCompletednum");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPFinterval, "BakeOvenPFinterval");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenPF, "BakeOvenPF");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat1, "BakeOvenAutoHeat1");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BakeOvenAutoHeat2, "BakeOvenAutoHeat2");


            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxBleed, "BoxBleed");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxExhaust, "BoxExhaust");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxAerate, "BoxAerate");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorPressSta, "BoxOuterdoorPressSta");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorReleaseSta, "BoxOuterdoorReleaseSta");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorCloseSta, "BoxOuterdoorCloseSta");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorOpenSta, "BoxOuterdoorOpenSta");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorElePress, "BoxOuterdoorElePress");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorEleRelease, "BoxOuterdoorEleRelease");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorClose, "BoxOuterdoorClose");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorOpen, "BoxOuterdoorOpen");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorStop, "BoxOuterdoorStop");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorPress, "BoxOuterdoorPress");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorRelease, "BoxOuterdoorRelease");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxPressure, "BoxPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxVacuum, "BoxVacuum");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxPFUpPressure, "BoxPFUpPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxPFDownPressure, "BoxPFDownPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxPFnum, "BoxPFnum");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxPFCompletednum, "BoxPFCompletednum");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxPFinterval, "BoxPFinterval");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxPF, "BoxPF");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxAlarmPressure, "BoxAlarmPressure");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.BoxOuterdoorspeed, "BoxOuterdoorspeed");

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
            }
        }
        /// <summary>
        /// 解析字符串并更新该IO点Value值
        /// </summary>
        internal void ParseDataAndUpdateInputIOValue(List<int> msg)
        {

        }
        internal void ParseDataAndUpdateOutputIOValue(List<int> msg)
        {

            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerRedLight], msg[(int)EnumBoardcardDefineOutputIO.TowerRedLight - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerYellowLight], msg[(int)EnumBoardcardDefineOutputIO.TowerYellowLight - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerGreenLight], msg[(int)EnumBoardcardDefineOutputIO.TowerGreenLight - 1] == 1 ? true : false);
        }
    }


}
