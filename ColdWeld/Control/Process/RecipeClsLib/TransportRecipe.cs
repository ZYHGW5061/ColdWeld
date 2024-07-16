using ConfigurationClsLib;
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
using WestDragon.Framework.LoggerManagerClsLib;
using WestDragon.Framework.UtilityHelper;

namespace RecipeClsLib
{
    [Serializable]
    [XmlRoot("RecipeBody")]
    public class TransportRecipe
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public TransportRecipe()
        {
            RecipeName = string.Empty;
            MaterialboxSize = new XYZTCoordinateConfig();
            MaterialSize = new XYZTCoordinateConfig();

            MaterialboxHookSafePosition = new XYZTCoordinateConfig();
            MaterialboxHooktoMaterialboxPosition = new XYZTCoordinateConfig();
            MaterialboxHookPickupMaterialboxPosition = new XYZTCoordinateConfig();
            MaterialboxHooktoTargetPosition = new XYZTCoordinateConfig();
            MaterialboxHooktoWeldPosition = new XYZTCoordinateConfig();
            MaterialboxHookPutdownMaterialboxPosition = new XYZTCoordinateConfig();

            MaterialHookSafePosition = new XYZTCoordinateConfig();
            MaterialHooktoMaterialPosition = new XYZTCoordinateConfig();
            MaterialHookPickupMaterialPosition = new XYZTCoordinateConfig();
            MaterialHooktoTargetPosition = new List<XYZTCoordinateConfig>();
            MaterialHookPutdownMaterialPosition = new XYZTCoordinateConfig();


        }


        #region Recipe结构

        [XmlAttribute("RecipeName")]
        public string RecipeName { get; set; }


        #region 物料属性


        /// <summary>
        /// 料盒宽度、长度、厚度
        /// </summary>
        [XmlElement("MaterialboxSize")]
        public XYZTCoordinateConfig MaterialboxSize { get; set; }

        /// <summary>
        /// 料盒层数
        /// </summary>
        [XmlElement("MaterialBoxLayerNumber")]
        public int MaterialBoxLayerNumber { get; set; }

        /// <summary>
        /// 物料宽度、长度、厚度
        /// </summary>
        [XmlElement("MaterialSize")]
        public XYZTCoordinateConfig MaterialSize { get; set; }

        /// <summary>
        /// 物料行数
        /// </summary>
        [XmlElement("MaterialRowNumber")]
        public int MaterialRowNumber { get; set; }
        /// <summary>
        /// 物料行数
        /// </summary>
        [XmlElement("MaterialColNumber")]
        public int MaterialColNumber { get; set; }



        #endregion

        #region 料盒搬送


        //料盒钩爪到空闲位置

        /// <summary>
        /// 料盒钩爪空闲位置
        /// </summary>
        [XmlElement("MaterialboxHookSafePosition")]
        public XYZTCoordinateConfig MaterialboxHookSafePosition { get; set; }

        /// <summary>
        /// 料盒钩爪开
        /// </summary>
        [XmlElement("MaterialboxHookOpen")]
        public float MaterialboxHookOpen { get; set; }


        //料盒出烘箱

        /// <summary>
        /// 料盒出烘箱位置
        /// </summary>
        [XmlElement("OverTrackMaterialboxOutofoven")]
        public float OverTrackMaterialboxOutofoven { get; set; }


        //料盒钩爪到料盒上方

        /// <summary>
        /// 料盒钩爪到料盒上方
        /// </summary>
        [XmlElement("MaterialboxHooktoMaterialboxPosition")]
        public XYZTCoordinateConfig MaterialboxHooktoMaterialboxPosition { get; set; }


        //料盒钩爪拾起料盒

        /// <summary>
        /// 料盒钩爪拾起料盒位置
        /// </summary>
        [XmlElement("MaterialboxHookPickupMaterialboxPosition")]
        public XYZTCoordinateConfig MaterialboxHookPickupMaterialboxPosition { get; set; }

        /// <summary>
        /// 料盒钩爪合
        /// </summary>
        [XmlElement("MaterialboxHookClose")]
        public float MaterialboxHookClose { get; set; }

        /// <summary>
        /// 料盒抬升距离
        /// </summary>
        [XmlElement("MaterialboxHookUp")]
        public float MaterialboxHookUp { get; set; }


        //料盒钩爪到目标位置

        /// <summary>
        /// 料盒钩爪到目标位置
        /// </summary>
        [XmlElement("MaterialboxHooktoTargetPosition")]
        public XYZTCoordinateConfig MaterialboxHooktoTargetPosition { get; set; }


        //料盒钩爪到焊接位置

        /// <summary>
        /// 料盒钩爪到目标位置
        /// </summary>
        [XmlElement("MaterialboxHooktoWeldPosition")]
        public XYZTCoordinateConfig MaterialboxHooktoWeldPosition { get; set; }


        //料盒钩爪放下料盒

        /// <summary>
        /// 料盒钩爪放下料盒位置
        /// </summary>
        [XmlElement("MaterialboxHookPutdownMaterialboxPosition")]
        public XYZTCoordinateConfig MaterialboxHookPutdownMaterialboxPosition { get; set; }


        //料盒进烘箱

        /// <summary>
        /// 料盒进烘箱位置
        /// </summary>
        [XmlElement("OverTrackMaterialboxInofoven")]
        public float OverTrackMaterialboxInofoven { get; set; }



        #endregion

        #region 物料搬送


        //物料钩爪到空闲位置

        /// <summary>
        /// 物料钩爪到空闲位置
        /// </summary>
        [XmlElement("MaterialHookSafePosition")]
        public XYZTCoordinateConfig MaterialHookSafePosition { get; set; }

        /// <summary>
        /// 物料钩爪开
        /// </summary>
        [XmlElement("MaterialHookOpen")]
        public float MaterialHookOpen { get; set; }


        //物料钩爪到物料上方

        /// <summary>
        /// 物料钩爪到物料上方
        /// </summary>
        [XmlElement("MaterialHooktoMaterialPosition")]
        public XYZTCoordinateConfig MaterialHooktoMaterialPosition { get; set; }


        //物料钩爪拾起物料

        /// <summary>
        /// 物料钩爪拾起物料位置
        /// </summary>
        [XmlElement("MaterialHookPickupMaterialPosition")]
        public XYZTCoordinateConfig MaterialHookPickupMaterialPosition { get; set; }

        /// <summary>
        /// 物料钩爪合
        /// </summary>
        [XmlElement("MaterialHookClose")]
        public float MaterialHookClose { get; set; }

        /// <summary>
        /// 物料抬升距离
        /// </summary>
        [XmlElement("MaterialHookUp")]
        public float MaterialHookUp { get; set; }


        //物料钩爪到目标位置

        /// <summary>
        /// 物料钩爪到目标位置
        /// </summary>
        [XmlElement("MaterialHooktoTargetPosition")]
        public List<XYZTCoordinateConfig> MaterialHooktoTargetPosition { get; set; }


        //物料钩爪放下物料

        /// <summary>
        /// 物料钩爪放下物料位置
        /// </summary>
        [XmlElement("MaterialHookPutdownMaterialPosition")]
        public XYZTCoordinateConfig MaterialHookPutdownMaterialPosition { get; set; }

        /// <summary>
        /// 物料抬升距离
        /// </summary>
        [XmlElement("MaterialHookUp2")]
        public float MaterialHookUp2 { get; set; }


        #endregion


        #endregion

        /// <summary>
        /// Recipe xml完成的路径
        /// </summary>
        private static string _recipeFullName = string.Empty;

        /// <summary>
        /// Recip文件夹全路径
        /// </summary>
        public static string _recipeFolderFullName = string.Empty;

        /// <summary>
        /// Recipe存放系统默认路径
        /// </summary>
        [XmlIgnore]
        private static string SystemDefaultDirectory = SystemConfiguration.Instance.SystemDefaultDirectory;

        /// <summary>
        /// 异常日志记录器
        /// </summary>
        private static IBaseLogger _systemLogger
        {
            get { return LoggerManager.GetHandler().GetFileLogger(GlobalParameterSetting.SYSTEM_DEBUG_LOGGER_ID); }
        }

        [XmlIgnore]
        public EnumRecipeType Type
        {
            get { return EnumRecipeType.Heat; }
        }
        /// <summary>
        /// Recipe文件夹全路径
        /// </summary>
        [XmlIgnore]
        public string RecipeFolderFullName
        {
            get { return _recipeFolderFullName; }
        }

        

        /// <summary>
        /// 删除Recipe
        /// </summary>
        public void Delete()
        {
            try
            {
                Directory.Delete(string.Format(SystemDefaultDirectory + @"Recipes\{0}\{1}", EnumRecipeType.Transport.ToString(), this.RecipeName), true);
            }
            catch (Exception ex)
            {
                _systemLogger.AddErrorContent(string.Format("Delete Recipe {0} 信息异常", this.RecipeName), ex);
            }
        }

        /// <summary>
        /// 复制Recipe
        /// </summary>
        public bool Copy(string newRecipeName)
        {
            try
            {
                if (FileOperationHelper.CopyDirectory(string.Format(SystemDefaultDirectory + @"Recipes\{0}\{1}", EnumRecipeType.Transport.ToString(), this.RecipeName),
                    string.Format(SystemDefaultDirectory + @"Recipes\{0}\{1}", EnumRecipeType.Transport.ToString(), newRecipeName)))
                {
                    var srcFileName = string.Format(SystemDefaultDirectory + @"Recipes\{0}\{1}\{2}.xml", EnumRecipeType.Transport.ToString(), newRecipeName, RecipeName);
                    var dstFileName = string.Format(SystemDefaultDirectory + @"Recipes\{0}\{1}\{2}.xml", EnumRecipeType.Transport.ToString(), newRecipeName, newRecipeName);
                    if (File.Exists(srcFileName))
                    {
                        File.Move(srcFileName, dstFileName);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                _systemLogger.AddErrorContent(string.Format("Copy Recipe {0} Error!", this.RecipeName), ex);
                return false;
            }
            return false;
        }

        /// <summary>
        /// 验证recipe是否完整有效
        /// </summary>
        /// <param name="recipeName"></param>
        /// <param name="waferSize"></param>
        /// <returns></returns>
        public static bool Validate(string recipeName, EnumRecipeType recipeType)
        {
            var recipe = LoadRecipe(recipeName, recipeType);
            if (recipe != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 加载Recipe
        /// </summary>
        /// <param name="recipeFullName"></param>
        /// <returns></returns>
        public static TransportRecipe LoadRecipe(string recipeFullName)
        {
            if (!File.Exists(recipeFullName))
            {
                throw new FileNotFoundException(string.Format("recipe {0} is not found.", recipeFullName));
            }
            TransportRecipe loadedRecipe = new TransportRecipe();
            try
            {
                loadedRecipe = LoadMainParameters(recipeFullName);
                _recipeFullName = recipeFullName;
            }
            catch (Exception ex)
            {
                _systemLogger.AddErrorContent(string.Format("Load Recipe {0} 信息异常", recipeFullName), ex);
                loadedRecipe = null;
            }
            return loadedRecipe;
        }

        /// <summary>
        /// 加载Recipe
        /// </summary>
        public static TransportRecipe LoadRecipe(string recipeName, EnumRecipeType recipeType, string recipePath = null)
        {
            var recipeDirectory = string.Format(SystemDefaultDirectory + @"Recipes\{0}\{1}", recipeType.ToString(), recipeName);
            if (!Directory.Exists(recipePath ?? recipeDirectory))
            {
                throw new FileNotFoundException(string.Format("recipe {0} is not found.", recipeName));
            }
            _recipeFolderFullName = recipeDirectory;
            _recipeFullName = string.Format(recipeDirectory + @"\{0}.xml", recipeName);
            TransportRecipe loadedRecipe = new TransportRecipe();
            try
            {
                loadedRecipe = LoadMainParameters(_recipeFullName);
            }
            catch (Exception ex)
            {
                _systemLogger.AddErrorContent(string.Format("Load Recipe {0} 信息异常", recipeName), ex);
                loadedRecipe = null;
            }
            return loadedRecipe;
        }
        public static TransportRecipe CreateRecipe(string recipeName, EnumRecipeType recipeType)
        {
            var recipeDirectory = string.Format(SystemDefaultDirectory + @"Recipes\{0}\{1}", recipeType.ToString(), recipeName);
            CommonProcess.EnsureFolderExist(recipeDirectory);
            _recipeFolderFullName = recipeDirectory;
            _recipeFullName = string.Format(recipeDirectory + @"\{0}.xml", recipeName);
            TransportRecipe loadedRecipe = new TransportRecipe();
            return loadedRecipe;
        }
        /// <summary>

        /// 保存recipe到xml文件中
        /// </summary>
        /// <param name="recipeFullName"></param>
        public void SaveRecipe(string recipeFullName, string recipeFullFolder = "", EnumRecipeStep recipeStep = EnumRecipeStep.None)
        {
            if (string.IsNullOrEmpty(recipeFullName))
            {
                throw new Exception("Recipe full name can't be empty or null.");
            }
            if (!string.IsNullOrEmpty(recipeFullName))
            {
                _recipeFullName = recipeFullName;
            }
            if (!string.IsNullOrEmpty(recipeFullFolder))
            {
                _recipeFolderFullName = recipeFullFolder;
            }
            SaveRecipe(recipeStep);
        }

        /// <summary>
        /// 保存recipe到xml文件
        /// </summary>
        public void SaveRecipe(EnumRecipeStep recipeStep = EnumRecipeStep.None)
        {
            SaveMianParameters();
        }

        private static TransportRecipe LoadMainParameters(string fullName)
        {
            return XmlSerializeHelper.XmlDeserializeFromFile<TransportRecipe>(fullName, Encoding.UTF8);
        }
        /// <summary>
        /// 保存主要参数，保存其他如Map数据需单独调用其他方法
        /// </summary>
        private void SaveMianParameters()
        {
            XmlSerializeHelper.XmlSerializeToFile(this, _recipeFullName, Encoding.UTF8);
        }
    }

}
