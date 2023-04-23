using GameEngine.Runtime.Module;
using GameEngine.Runtime.Fsm;
using GameEngine.Runtime.Procedure;
using GameEngine.Runtime.Utilitys;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameMain.Runtime
{
    /// <summary>
    /// 游戏启动器
    /// </summary>
    public partial class Launcher : MonoBehaviour
    {
        ProcedureBase m_EntranceProcedure = null;
        void Awake()
        {
            ///创建所有Procedure
            List<ProcedureBase> procedureList = new();
            
            foreach (var procedureName in m_AvailableProcedureNames)
            {
                Type procedureType = Type.GetType($"GameMain.Runtime.Procedure.{procedureName}");
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
                    m_EntranceProcedure = procedure;
                }
            }

            if (m_EntranceProcedure == null)
            {
                throw new Exception($"entranceProcedure {m_EntranceProcedureName} not exist !!");
            }

            //GameModule.ProcedureModule.Initialize(GameModule.FsmModule, procedureList.ToArray());
        }
    }
}

