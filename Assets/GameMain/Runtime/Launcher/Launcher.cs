using GameEngine.Runtime.Module;
using GameEngine.Runtime.Fsm;
using GameEngine.Runtime.Procedure;
using GameEngine.Runtime.Utilitys;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMain.Runtime
{
    /// <summary>
    /// 游戏启动器
    /// </summary>
    public partial class Launcher : MonoBehaviour
    {
        [SerializeField]
        private string[] m_AvailableProcedureNames = null;

        [SerializeField]
        private string m_EntranceProcedureName = null;

        IEnumerator Start()
        {
            //初始化内置模块
           // GameModule.InitBuiltinModules();
            //初始化自定义模块
            GameModule.InitCustomModules();

            yield return null;

            //开始入口Procedure
            //GameModule.ProcedureModule.StartProcedure(m_EntranceProcedure.GetType());
        }
    }
}

