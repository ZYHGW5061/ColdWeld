using ConfigurationClsLib;
using GlobalDataDefineClsLib;
using RecipeClsLib;
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

        private TransportRecipe _transportRecipe;
        public TransportRecipe TransportRecipe
        {
            get { return _transportRecipe; }
            set { _transportRecipe = value; }
        }

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


        public int SetTransportParam(TransportRecipe recipe)
        {
            if (recipe != null)
            {
                try
                {
                    _transportRecipe = recipe;
                    return 0;
                }
                catch (Exception)
                {
                    _transportRecipe = null;
                    return -1;
                }
            }
            else
            {
                _transportRecipe = null;
            }

            return -1;
        }

        public TransportRecipe GetTransportParam()
        {

            return _transportRecipe;
        }


        public int OpenOvenBoxInteriorDoor(int OverBoxNum)
        {
            if (_transportRecipe != null)
            {
                try
                {

                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int CloseOvenBoxInteriorDoor(int OverBoxNum)
        {
            if (_transportRecipe != null)
            {
                try
                {

                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }


        public int MaterialboxHooktoSafePositionAction()
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialboxHook, _transportRecipe.MaterialboxHookOpen);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxZ, _transportRecipe.MaterialboxHookSafePosition.Z);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxT, _transportRecipe.MaterialboxHookSafePosition.Theta);

                    MaterialboxHookXYZAbsoluteMove(_transportRecipe.MaterialboxHookSafePosition.X, _transportRecipe.MaterialboxHookSafePosition.Y, _transportRecipe.MaterialboxHookSafePosition.Z);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialboxOutofovenAction(int OverBoxNum)
        {

            if (_transportRecipe != null)
            {
                try
                {
                    if (OverBoxNum == 0)
                    {
                        AxisAbsoluteMove(EnumStageAxis.OverTrack1, _transportRecipe.OverTrackMaterialboxOutofoven);
                    }
                    else if (OverBoxNum == 1)
                    {
                        AxisAbsoluteMove(EnumStageAxis.OverTrack1, _transportRecipe.OverTrack2MaterialboxOutofoven);
                    }


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialboxHooktoMaterialboxAction(int OverBoxNum)
        {

            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialboxHook, _transportRecipe.MaterialboxHookOpen);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxZ, _transportRecipe.MaterialboxHookSafePosition.Z);

                    double MaterialboxHookX = ReadCurrentAxisposition(EnumStageAxis.MaterialboxX);
                    double MaterialboxHookY = ReadCurrentAxisposition(EnumStageAxis.MaterialboxY);

                    if (OverBoxNum == 0)
                    {
                        AxisAbsoluteMove(EnumStageAxis.MaterialboxT, _transportRecipe.MaterialboxHooktoMaterialboxPosition1.Theta);

                        MaterialboxHookXYZAbsoluteMove(_transportRecipe.MaterialboxHooktoMaterialboxPosition1.X, _transportRecipe.MaterialboxHooktoMaterialboxPosition1.Y, _transportRecipe.MaterialboxHooktoMaterialboxPosition1.Z);
                    }
                    else if (OverBoxNum == 1)
                    {
                        AxisAbsoluteMove(EnumStageAxis.MaterialboxT, _transportRecipe.MaterialboxHooktoMaterialboxPosition2.Theta);

                        MaterialboxHookXYZAbsoluteMove(_transportRecipe.MaterialboxHooktoMaterialboxPosition2.X, _transportRecipe.MaterialboxHooktoMaterialboxPosition2.Y, _transportRecipe.MaterialboxHooktoMaterialboxPosition2.Z);
                    }





                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialboxHookPickupMaterialboxAction(double TargetZ)
        {
            if (_transportRecipe != null)
            {
                try
                {


                    AxisAbsoluteMove(EnumStageAxis.MaterialboxHook, _transportRecipe.MaterialboxHookOpen);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxZ, TargetZ);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxHook, _transportRecipe.MaterialboxHookClose);

                    AxisRelativeMove(EnumStageAxis.MaterialboxZ, _transportRecipe.MaterialboxHookUp);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialboxHooktoTargetPositionAction(XYZTCoordinateConfig Target)
        {

            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialboxZ, Target.Z + _transportRecipe.MaterialboxHookUp);

                    double MaterialboxHookX = ReadCurrentAxisposition(EnumStageAxis.MaterialboxX);
                    double MaterialboxHookY = ReadCurrentAxisposition(EnumStageAxis.MaterialboxY);


                    MaterialboxHookXYZAbsoluteMove(Target.X, Target.Y, Target.Z + _transportRecipe.MaterialboxHookUp);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxT, Target.Theta);

                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialboxHooktoWeldPositionAction()
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialboxZ, _transportRecipe.MaterialboxHooktoWeldPosition.Z);

                    double MaterialboxHookX = ReadCurrentAxisposition(EnumStageAxis.MaterialboxX);
                    double MaterialboxHookY = ReadCurrentAxisposition(EnumStageAxis.MaterialboxY);


                    MaterialboxHookXYZAbsoluteMove(_transportRecipe.MaterialboxHooktoWeldPosition.X, _transportRecipe.MaterialboxHooktoWeldPosition.Y, _transportRecipe.MaterialboxHooktoWeldPosition.Z);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxT, _transportRecipe.MaterialboxHooktoWeldPosition.Theta);

                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialboxHookPutdownMaterialboxAction(double TargetZ)
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialboxZ, TargetZ);

                    AxisAbsoluteMove(EnumStageAxis.MaterialboxHook, _transportRecipe.MaterialboxHookOpen);

                    AxisRelativeMove(EnumStageAxis.MaterialboxZ, _transportRecipe.MaterialboxHookUp);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialboxInofovenAction(int OverBoxNum)
        {
            if (_transportRecipe != null)
            {
                try
                {
                    if (OverBoxNum == 0)
                    {
                        AxisAbsoluteMove(EnumStageAxis.OverTrack1, _transportRecipe.OverTrack1MaterialboxInofoven);
                    }
                    else if (OverBoxNum == 1)
                    {
                        AxisAbsoluteMove(EnumStageAxis.OverTrack1, _transportRecipe.OverTrack2MaterialboxInofoven);
                    }



                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialHooktoSafePositionAction()
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialHook, _transportRecipe.MaterialHookOpen);

                    AxisAbsoluteMove(EnumStageAxis.MaterialZ, _transportRecipe.MaterialHookSafePosition.Z);

                    MaterialHookXYZAbsoluteMove(_transportRecipe.MaterialHookSafePosition.X, _transportRecipe.MaterialHookSafePosition.Y, _transportRecipe.MaterialHookSafePosition.Z);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialHooktoMaterialAction(XYZTCoordinateConfig MaterialPosition)
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialHook, _transportRecipe.MaterialboxHookOpen);

                    AxisAbsoluteMove(EnumStageAxis.MaterialZ, MaterialPosition.Z);

                    double MaterialboxHookX = ReadCurrentAxisposition(EnumStageAxis.MaterialboxX);
                    double MaterialboxHookY = ReadCurrentAxisposition(EnumStageAxis.MaterialboxY);

                    MaterialHookXYZAbsoluteMove(MaterialPosition.X, MaterialPosition.Y, MaterialPosition.Z);



                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialHookPickupMaterialAction(double TargetZ)
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialHook, _transportRecipe.MaterialHookOpen);

                    AxisAbsoluteMove(EnumStageAxis.MaterialZ, TargetZ);

                    AxisAbsoluteMove(EnumStageAxis.MaterialHook, _transportRecipe.MaterialHookClose);

                    AxisRelativeMove(EnumStageAxis.MaterialZ, _transportRecipe.MaterialHookUp);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialHooktoTargetPositionAction(int Num)
        {
            if (_transportRecipe != null)
            {
                try
                {
                    if (_transportRecipe.MaterialHooktoTargetPosition.Count > Num)
                    {



                        AxisAbsoluteMove(EnumStageAxis.MaterialZ, _transportRecipe.MaterialHooktoTargetPosition[Num].Z);

                        double MaterialHookX = ReadCurrentAxisposition(EnumStageAxis.MaterialX);
                        double MaterialHookY = ReadCurrentAxisposition(EnumStageAxis.MaterialY);


                        MaterialHookXYZAbsoluteMove(_transportRecipe.MaterialHooktoTargetPosition[Num].X, _transportRecipe.MaterialHooktoTargetPosition[Num].Y, _transportRecipe.MaterialHooktoTargetPosition[Num].Z);

                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int MaterialHookPutdownMaterialAction(double TargetZ)
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.MaterialZ, TargetZ);

                    AxisAbsoluteMove(EnumStageAxis.MaterialHook, _transportRecipe.MaterialHookOpen);

                    AxisRelativeMove(EnumStageAxis.MaterialZ, _transportRecipe.MaterialHookUp2);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int PressliftingLiftUpMaterialAction()
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.Presslifting, _transportRecipe.PressliftingWorkPosition);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int PressliftingPutdownMaterialAction()
        {
            if (_transportRecipe != null)
            {
                try
                {
                    AxisAbsoluteMove(EnumStageAxis.Presslifting, _transportRecipe.PressliftingSafePosition);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int WeldMaterialAction()
        {
            if (_transportRecipe != null)
            {
                try
                {
                    //AxisAbsoluteMove(EnumStageAxis.Presslifting, _transportRecipe.PressliftingSafePosition);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }

        }

        public int WeldResetAction()
        {
            if (_transportRecipe != null)
            {
                try
                {
                    //AxisAbsoluteMove(EnumStageAxis.Presslifting, _transportRecipe.PressliftingSafePosition);


                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }

        }


        #endregion

    }
}
