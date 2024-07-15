using CameraControllerClsLib;
using ConfigurationClsLib;
using GlobalDataDefineClsLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using WestDragon.Framework.UtilityHelper;

namespace PositioningSystemClsLib
{
    /// <summary>
    /// 定位系统，操作Stage硬件实现对指定坐标的定位，读数，坐标转换等.
    /// </summary>
    public class PositioningSystem
    {
        private static volatile PositioningSystem _instance = new PositioningSystem();
        private static readonly object _lockObj = new object();
        private SystemConfiguration _systemConfig
        {
            get { return SystemConfiguration.Instance; }
        }
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static PositioningSystem Instance
        {
            get
            {
                if(_instance==null)
                {
                    lock(_lockObj)
                    {
                        if(_instance==null)
                        {
                            _instance = new PositioningSystem();
                        }
                    }
                }
                return _instance;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private StageMotionControl _stageMotionControl
        {
            get { return StageMotionControl.Istance; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        private PositioningSystem()
        {
        }

        /// <summary>
        /// 读取所有轴的Stage位置
        /// </summary>
        /// <returns></returns>
        public double[] ReadCurrentStagePosition()
        {
            return _stageMotionControl.GetCurrentPosition();
        }
        /// <summary>
        /// 读取指定轴的Stage位置
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public double ReadCurrentStagePosition(EnumStageAxis axis)
        {
            return _stageMotionControl.GetCurrentPosition(axis);
        }
        /// <summary>
        /// Jog+
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="speed"></param>
        public void JogPositive(EnumStageAxis axis,float speed)
        {
            _stageMotionControl.JogPositive(axis, speed);
        }
        public void StopJogPositive(EnumStageAxis axis)
        {
            _stageMotionControl.StopJogPositive(axis);
        }
        /// <summary>
        /// Jog-
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="speed"></param>
        public void JogNegative(EnumStageAxis axis, float speed)
        {
            _stageMotionControl.JogNegative(axis, speed);
        }

        public void StopJogNegative(EnumStageAxis axis)
        {
            _stageMotionControl.StopJogNegative(axis);
        }      

        /// <summary>
        /// 移动指定轴到指定Stage坐标系位置
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="target"></param>
        /// <param name="type">绝对移动或者相对移动</param>
        public void MoveAixsToStageCoord(EnumStageAxis axis,double target, EnumCoordSetType type)
        {
            //var targetPos = new MillimeterUnitValue<double>() { Value = target };
            if (type == EnumCoordSetType.Absolute)
            {
                _stageMotionControl.AbsoluteMovingSync(axis, target);
            }
            else
            {
                _stageMotionControl.RelativeMovingSync(axis, target);
            }
        }
        public void MoveAixsToStageCoord(EnumStageAxis[] axis, double[] target, EnumCoordSetType type)
        {
            //var targetPos = new MillimeterUnitValue<double>() { Value = target };
            if (type == EnumCoordSetType.Absolute)
            {
                _stageMotionControl.AbsoluteMovingSync(axis, target);
            }
            else
            {
                _stageMotionControl.RelativeMovingSync(axis, target);
            }
        }
        public float GetAxisSpeed(EnumStageAxis axis)
        {
            var ret = 0f;
            ret =(float)_stageMotionControl.GetAxisSpeed(axis);
            return ret;
        }
        public bool SetAxisSpeed(EnumStageAxis axis,float speed)
        {
            return _stageMotionControl.SetAxisSpeed(axis, speed);
        }

        /// <summary>
        /// 读取轴状态
        /// 1 报警
        /// 5 正限位
        /// 6 负限位 
        /// 7 平滑停止 
        /// 8 急停 
        /// 9 使能 
        /// 10 规划运动 
        /// 11 电机到位
        /// </summary>
        public int GetAxisState(EnumStageAxis axis)
        {
            return _stageMotionControl.GetAxisState(axis);
        }

        /// <summary>
        /// 报警清除
        /// </summary>
        public void ClrAlarm(EnumStageAxis axis)
        {
            _stageMotionControl.ClrAlarm(axis);
        }

        /// <summary>
        /// 报警 / 限位无效
        /// action动作 ： 1 为生效，0为失效
        /// </summary>
        public void DisableAlarmLimit(EnumStageAxis axis)
        {
            _stageMotionControl.DisableAlarmLimit(axis);
        }
    }

}
