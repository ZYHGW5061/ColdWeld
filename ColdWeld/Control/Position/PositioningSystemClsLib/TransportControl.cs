using ConfigurationClsLib;
using GlobalDataDefineClsLib;
using StageControllerClsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestDragon.Framework.UtilityHelper;

namespace PositioningSystemClsLib
{
    public class TransportControl
    {

        #region private file


        private static volatile TransportControl _instance = new TransportControl();
        private static readonly object _lockObj = new object();
        private SystemConfiguration _systemConfig
        {
            get { return SystemConfiguration.Instance; }
        }
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static TransportControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new TransportControl();
                        }
                    }
                }
                return _instance;
            }
        }

        private StageCore stage = StageControllerClsLib.StageCore.Instance;
        /// <summary>
        /// 定位系统
        /// </summary>
        private PositioningSystem _positioningSystem
        {
            get { return PositioningSystem.Instance; }
        }

        #endregion



        #region public file

        /// <summary>
        /// 搬送状态
        /// </summary>
        public int TransportStatus { get; set; } = -1;

        #endregion


        #region private mothd


        /// <summary>
        /// 料盒钩爪移动
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        private void MaterialboxHookXYZAbsoluteMove(double X, double Y, double Z)
        {
            //stage.AbloluteMoveSync(new EnumStageAxis[3] { EnumStageAxis.BondX, EnumStageAxis.BondY, EnumStageAxis.BondZ }, new double[3] { X, Y, Z });
            stage.ClrAlarm(EnumStageAxis.MaterialboxZ);
            stage.AbloluteMoveSync(EnumStageAxis.MaterialboxZ, Z);

            //stage.ClrAlarm(EnumStageAxis.BondX);
            //stage.AbloluteMoveSync(EnumStageAxis.BondX, X);

            //stage.ClrAlarm(EnumStageAxis.BondY);
            //stage.AbloluteMoveSync(EnumStageAxis.BondY, Y);


            EnumStageAxis[] multiAxis = new EnumStageAxis[2];
            multiAxis[0] = EnumStageAxis.MaterialboxX;
            multiAxis[1] = EnumStageAxis.MaterialboxY;

            double[] target1 = new double[2];

            target1[0] = X;
            target1[1] = Y;

            _positioningSystem.MoveAixsToStageCoord(multiAxis, target1, EnumCoordSetType.Absolute);
        }

        /// <summary>
        /// 物料钩爪移动
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        private void MaterialHookXYZAbsoluteMove(double X, double Y, double Z)
        {
            //stage.AbloluteMoveSync(new EnumStageAxis[3] { EnumStageAxis.BondX, EnumStageAxis.BondY, EnumStageAxis.BondZ }, new double[3] { X, Y, Z });
            stage.ClrAlarm(EnumStageAxis.MaterialZ);
            stage.AbloluteMoveSync(EnumStageAxis.MaterialZ, Z);

            //stage.ClrAlarm(EnumStageAxis.BondX);
            //stage.AbloluteMoveSync(EnumStageAxis.BondX, X);

            //stage.ClrAlarm(EnumStageAxis.BondY);
            //stage.AbloluteMoveSync(EnumStageAxis.BondY, Y);


            EnumStageAxis[] multiAxis = new EnumStageAxis[2];
            multiAxis[0] = EnumStageAxis.MaterialX;
            multiAxis[1] = EnumStageAxis.MaterialY;

            double[] target1 = new double[2];

            target1[0] = X;
            target1[1] = Y;

            _positioningSystem.MoveAixsToStageCoord(multiAxis, target1, EnumCoordSetType.Absolute);
        }


        private void AxisAbsoluteMove(EnumStageAxis axis, double target)
        {
            stage.ClrAlarm(axis);
            stage.AbloluteMoveSync(axis, target);
        }

        private void AxisRelativeMove(EnumStageAxis axis, double target)
        {
            stage.RelativeMoveSync(axis, (float)target);
        }

        private double ReadCurrentAxisposition(EnumStageAxis axis)
        {

            double position = stage.GetCurrentPosition(axis);
            //double position = 2;
            return position;
        }

        private void AxisHome(EnumStageAxis axis)
        {
            //stage.Home(axis);
        }



        #endregion


        #region public mothd


        public int MaterialboxHooktoSafePositionAction()
        {

            return -1;
        }

        public int MaterialboxOutofovenAction()
        {

            return -1;
        }

        public int MaterialboxHooktoMaterialboxAction()
        {

            return -1;
        }

        public int MaterialboxHookPickupMaterialboxAction()
        {

            return -1;
        }

        public int MaterialboxHooktoTargetPositionAction()
        {

            return -1;
        }

        public int MaterialboxHookPutdownMaterialboxAction()
        {

            return -1;
        }

        public int MaterialboxInofovenAction()
        {

            return -1;
        }

        public int MaterialHooktoSafePositionAction()
        {

            return -1;
        }

        public int MaterialHooktoMaterialAction()
        {

            return -1;
        }

        public int MaterialHookPickupMaterialAction()
        {

            return -1;
        }

        public int MaterialHooktoTargetPositionAction()
        {

            return -1;
        }

        public int MaterialHookPutdownMaterialAction()
        {

            return -1;
        }



        #endregion

    }
}
