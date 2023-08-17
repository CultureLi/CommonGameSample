using GameEngine.Runtime.Procedure;
using GameEngine.Runtime.Utilitys;
using System;
using ProcedureOwner = GameEngine.Runtime.Fsm.IFsm<GameEngine.Runtime.Procedure.IProcedureManager>;
namespace GameLauncher.Runtime.Procedure
{
    public class ProcedureFinished : ProcedureBase
    {
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            var entry = Utility.Assembly.GetType("GameMain.Runtime.Entrance.GameEntry");
            if (entry == null)
                throw new Exception("GameEntry Not Found!!!");
            entry.GetMethod("Entry").Invoke(null,null);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            
        }


        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }


        private void InitLanguageSettings()
        {
            
        }
    }
}

