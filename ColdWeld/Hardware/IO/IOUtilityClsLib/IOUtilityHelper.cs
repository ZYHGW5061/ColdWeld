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
            _inputIOList.Add(EnumBoardcardDefineInputIO.ChipPPVaccumNormally, "ChipPPVaccumNormally");
            _inputIOList.Add(EnumBoardcardDefineInputIO.SubmountPPVaccumNormally, "SubmountPPVaccumNormally");
            _inputIOList.Add(EnumBoardcardDefineInputIO.EutecticError, "EutecticError");
            _inputIOList.Add(EnumBoardcardDefineInputIO.EutecticComplete, "EutecticComplete");


            _outputIOList = new Dictionary<EnumBoardcardDefineOutputIO, string>();
            _outputIOList.Add(EnumBoardcardDefineOutputIO.SubmountPPVaccumSwitch, "SubmountPPVaccumSwitch");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.SubmountPPBlowSwitch, "SubmountPPBlowSwitch");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.ChipPPVaccumSwitch, "ChipPPVaccumSwitch");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.ChipPPBlowSwitch, "ChipPPBlowSwitch");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.EjectionSystemVaccumSwitch, "EjectionSystemVaccumSwitch");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.EutecticPlatformVaccumSwitch, "EutecticPlatformVaccumSwitch");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.MaterialPlatformVaccumSwitch, "MaterialPlatformVaccumSwitch");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.WaferTableVaccumSwitch, "WaferTableVaccumSwitch");

            _outputIOList.Add(EnumBoardcardDefineOutputIO.NitrogenValve, "NitrogenValve");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.StartEctectic, "StartEctectic");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerRedLight, "TowerRedLight");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerYellowLight, "TowerYellowLight");
            _outputIOList.Add(EnumBoardcardDefineOutputIO.TowerGreenLight, "TowerGreenLight");

            _boardCardController = BoardCardManager.Instance.GetCurrentController();
        }
        public void Start()
        {
            _enablePollingIO = true;
            Task.Run(new Action(ReadIOTask));
        }
        public bool IsChipPPVaccumOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.ChipPPVaccumSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开芯片吸嘴真空
        /// </summary>
        public void OpenChipPPVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.ChipPPVaccumSwitch, 1);
        }
        /// <summary>
        /// 关闭芯片吸嘴真空
        /// </summary>
        public void CloseChipPPVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.ChipPPVaccumSwitch, 0);
        }
        public bool IsSubmountPPVaccumOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.SubmountPPVaccumSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开衬底吸嘴真空
        /// </summary>
        public void OpenSubmountPPVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.SubmountPPVaccumSwitch, 1);
        }
        /// <summary>
        /// 关闭衬底吸嘴真空
        /// </summary>
        public void CloseSubmountPPVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.SubmountPPVaccumSwitch, 0);

        }
        public bool IsEutecticPlatformPPVaccumOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.EutecticPlatformVaccumSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开共晶平台真空
        /// </summary>
        public void OpenEutecticPlatformPPVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.EutecticPlatformVaccumSwitch, 1);
        }
        /// <summary>
        /// 关闭共晶平台真空
        /// </summary>
        public void CloseEutecticPlatformPPVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.EutecticPlatformVaccumSwitch, 0);
        }
        public bool IsESBaseVaccumOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.EjectionSystemVaccumSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开顶针座真空
        /// </summary>
        public void OpenESBaseVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.EjectionSystemVaccumSwitch, 1);
        }
        /// <summary>
        /// 关闭顶针座真空
        /// </summary>
        public void CloseESBaseVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.EjectionSystemVaccumSwitch, 0);
        }

        public bool IsMaterailPlatformVaccumOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.MaterialPlatformVaccumSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开物料平台真空
        /// </summary>
        public void OpenMaterailPlatformVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.MaterialPlatformVaccumSwitch, 1);
        }
        /// <summary>
        /// 关闭物料平台真空
        /// </summary>
        public void CloseMaterailPlatformVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.MaterialPlatformVaccumSwitch, 0);
        }
        public bool IsWaferTableVaccumOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.WaferTableVaccumSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开wafertable真空
        /// </summary>
        public void OpenWaferTableVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.WaferTableVaccumSwitch, 1);
        }
        /// <summary>
        /// 关闭wafertable真空
        /// </summary>
        public void CloseWaferTableVaccum()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.WaferTableVaccumSwitch, 0);
        }
        /// <summary>
        /// 获取芯片真空状态
        /// </summary>
        /// <returns>0：关闭，1：打开</returns>
        public int GetChipPPVaccumStatus()
        {
            int isOpen = 0;
            _boardCardController.IO_ReadInput(11, (int)EnumBoardcardDefineInputIO.ChipPPVaccumNormally, out isOpen);
            return isOpen;
        }

        /// <summary>
        /// 获取衬底真空状态
        /// </summary>
        /// <returns>0：关闭，1：打开</returns>
        public int GetSubmountPPVaccumStatus()
        {
            int isOpen = 0;
            _boardCardController.IO_ReadInput(11, (int)EnumBoardcardDefineInputIO.SubmountPPVaccumNormally, out isOpen);
            return isOpen;
        }
        public bool IsChipPPBlowOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.ChipPPBlowSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开芯片吹气
        /// </summary>
        public void OpenChipPPBlow()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.ChipPPBlowSwitch, 1);
        }
        /// <summary>
        /// 关闭芯片吹气
        /// </summary>
        public void CloseChipPPBlow()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.ChipPPBlowSwitch, 0);
        }
        public bool IsSubmountPPBlowOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.SubmountPPBlowSwitch, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 打开衬底吹气
        /// </summary>
        public void OpenSubmountPPBlow()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.SubmountPPBlowSwitch, 1);
        }
        /// <summary>
        /// 关闭衬底吹气
        /// </summary>
        public void CloseSubmountPPBlow()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.SubmountPPBlowSwitch, 0);
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
        public bool IsNitrogenValveOpened()
        {
            var ret = false;
            var status = 0;
            _boardCardController.IO_ReadOutput(11, (int)EnumBoardcardDefineOutputIO.NitrogenValve, out status);
            ret = status == 1;
            return ret;
        }
        /// <summary>
        /// 开氮气
        /// </summary>
        public void OpenNitrogen()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.NitrogenValve, 1);
        }
        /// <summary>
        /// 关氮气
        /// </summary>
        public void CloseNitrogen()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.NitrogenValve, 0);
        }
        /// <summary>
        /// 开加热
        /// </summary>
        public void OpenEctectic()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.StartEctectic, 1);
        }
        /// <summary>
        /// 关加热
        /// </summary>
        public void CloseEctectic()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.StartEctectic, 0);
        }

        public bool IsEctecticComplete()
        {
            var ret = false;
            int status = 0;
            _boardCardController.IO_ReadInput(11, (int)EnumBoardcardDefineInputIO.EutecticComplete, out status);
            ret = status == 1;
            return ret;
        }

        public void ResetEctecticComplete()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineInputIO.EutecticComplete, 0);
        }

        /// <summary>
        /// 复位
        /// </summary>
        public void ResetEctectic()
        {
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.ResetEutectic, 1);
            Thread.Sleep(200);
            _boardCardController.IO_WriteOutPut(11, (int)EnumBoardcardDefineOutputIO.ResetEutectic, 0);
        }

        public bool IsEctecticFault()
        {
            var ret = false;
            int status = 0;
            _boardCardController.IO_ReadInput(11, (int)EnumBoardcardDefineInputIO.EutecticError, out status);
            ret = status == 1;
            return ret;
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
                _boardCardController.IO_ReadAllInput(11,out data);
                if (data.Count>0)
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
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.ChipPPVaccumNormally], msg[(int)EnumBoardcardDefineInputIO.ChipPPVaccumNormally - 1] ==1? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.SubmountPPVaccumNormally], msg[(int)EnumBoardcardDefineInputIO.SubmountPPVaccumNormally - 1] ==1? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.EutecticError], msg[(int)EnumBoardcardDefineInputIO.EutecticError - 1] ==1? true : false);
            IOManager.Instance.ChangeIOValue(_inputIOList[EnumBoardcardDefineInputIO.EutecticComplete], msg[(int)EnumBoardcardDefineInputIO.EutecticComplete - 1] ==1? true : false);
            //IOManager.Instance.ChangeIOValue(_IOList[EnumBoardcardDefineIO.EjectionSystemVaccumNormally], msg[(int)EnumBoardcardDefineIO.EjectionSystemVaccumNormally] ==1? true : false);
            //IOManager.Instance.ChangeIOValue(_IOList[EnumBoardcardDefineIO.EutecticPlatformVaccumNormally], msg[(int)EnumBoardcardDefineIO.EutecticPlatformVaccumNormally] ==1? true : false);
        }
        internal void ParseDataAndUpdateOutputIOValue(List<int> msg)
        {
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.ChipPPVaccumSwitch], msg[(int)EnumBoardcardDefineOutputIO.ChipPPVaccumSwitch-1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.ChipPPBlowSwitch], msg[(int)EnumBoardcardDefineOutputIO.ChipPPBlowSwitch - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.SubmountPPVaccumSwitch], msg[(int)EnumBoardcardDefineOutputIO.SubmountPPVaccumSwitch - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.SubmountPPBlowSwitch], msg[(int)EnumBoardcardDefineOutputIO.SubmountPPBlowSwitch - 1] == 1 ? true : false);

            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.WaferTableVaccumSwitch], msg[(int)EnumBoardcardDefineOutputIO.WaferTableVaccumSwitch - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.MaterialPlatformVaccumSwitch], msg[(int)EnumBoardcardDefineOutputIO.MaterialPlatformVaccumSwitch - 1] == 1 ? true : false); 
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.EjectionSystemVaccumSwitch], msg[(int)EnumBoardcardDefineOutputIO.EjectionSystemVaccumSwitch - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.EutecticPlatformVaccumSwitch], msg[(int)EnumBoardcardDefineOutputIO.EutecticPlatformVaccumSwitch - 1] == 1 ? true : false);

            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.NitrogenValve], msg[(int)EnumBoardcardDefineOutputIO.NitrogenValve - 1] == 1 ? true : false);

            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerRedLight], msg[(int)EnumBoardcardDefineOutputIO.TowerRedLight - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerYellowLight], msg[(int)EnumBoardcardDefineOutputIO.TowerYellowLight - 1] == 1 ? true : false);
            IOManager.Instance.ChangeIOValue(_outputIOList[EnumBoardcardDefineOutputIO.TowerGreenLight], msg[(int)EnumBoardcardDefineOutputIO.TowerGreenLight - 1] == 1 ? true : false);
        }
    }


}
