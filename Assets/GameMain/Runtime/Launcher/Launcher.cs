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
    /// ��Ϸ������
    /// </summary>
    public partial class Launcher : MonoBehaviour
    {
        [SerializeField]
        private string[] m_AvailableProcedureNames = null;

        [SerializeField]
        private string m_EntranceProcedureName = null;

        IEnumerator Start()
        {
            //��ʼ������ģ��
           // GameModule.InitBuiltinModules();
            //��ʼ���Զ���ģ��
            GameModule.InitCustomModules();

            yield return null;

            //��ʼ���Procedure
            //GameModule.ProcedureModule.StartProcedure(m_EntranceProcedure.GetType());
        }
    }
}

