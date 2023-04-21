using GameEngine.Runtime.Module;
using GameEngine.Runtime.Module.Fsm;
using GameEngine.Runtime.Module.Procedure;
using GameEngine.Runtime.Utilitys;
using System;
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

        void Start()
        {
            //��ʼ������ģ��
            GameModule.InitBuiltinModules();
            //��ʼ���Զ���ģ��
            GameModule.InitCustomModules();

            InitAvailableProcedures();
        }

        void InitAvailableProcedures()
        {
            List<ProcedureBase> procedureList = new();
            ProcedureBase entranceProcedure = null;
            foreach (var procedureName in m_AvailableProcedureNames)
            {
                Type procedureType = Utility.Assembly.GetType($"GameMain.Runtime.Procedure.{procedureName}");
                if (procedureType == null)
                {
                    throw new Exception($"Can not create procedure instance '{procedureName}'.");
                }

                var procedure = (ProcedureBase)Activator.CreateInstance(procedureType);
                if (procedure == null)
                {
                    throw new Exception($"Can not create procedure instance '{procedureName}'.");
                }

                procedureList.Add(procedure);

                if (m_EntranceProcedureName == procedureName)
                {
                    entranceProcedure = procedure;
                }
            }

            if (entranceProcedure == null)
            {
                throw new Exception($"entranceProcedure {m_EntranceProcedureName} not exist !!");
            }

            GameModule.ProcedureModule.Initialize(GameModule.FsmModule, procedureList.ToArray());
            GameModule.ProcedureModule.StartProcedure(entranceProcedure.GetType());
        }

        private void Update()
        {
            GameModule.ProcedureModule.Update(Time.deltaTime, Time.realtimeSinceStartup);
        }
    }
}

