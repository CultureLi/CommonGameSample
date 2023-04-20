using UnityEngine;

namespace GameMain.Runtime
{
    /// <summary>
    /// 游戏启动器
    /// </summary>
    public partial class Launcher : MonoBehaviour
    {
        void Start()
        {
            //初始化内置模块
            GameModule.InitBuiltinModules();
            //初始化自定义模块
            GameModule.InitCustomModules();
        }
    }
}

