using GameEngine.Runtime.Procedure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLauncher.Runtime
{
    public partial class Launcher : MonoBehaviour
    {
        [SerializeField]
        private string[] m_AvailableProcedureNames = null;

        [SerializeField]
        private string m_EntranceProcedureName = null;


        ProcedureManager m_ProcedureMgr = new();
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
        }


        void Start()
        {
            //开始入口Procedure
            m_ProcedureMgr.StartProcedure(m_EntranceProcedure.GetType());
        }

        // Update is called once per frame
        void Update()
        {
            m_ProcedureMgr.Update(Time.deltaTime, Time.realtimeSinceStartup);
        }

        void OnDestroy()
        {
            m_ProcedureMgr.Release();
        }
    }

}
