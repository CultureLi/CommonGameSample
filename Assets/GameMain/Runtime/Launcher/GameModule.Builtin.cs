using GameEngine.Runtime.Module.Event;
using GameEngine.Runtime.Module;
using GameEngine.Runtime.Module.Timer;
using GameEngine.Runtime.Module.Procedure;
using GameEngine.Runtime.Module.Fsm;

namespace GameMain.Runtime
{
    public static partial class GameModule
    {

        public static EventModule EventModule
        { get; private set; }

        public static TimerModule TimerModule
        { get; private set; }

        public static ProcedureModule ProcedureModule
        { get; private set; }

        public static FsmModule FsmModule
        { get; private set; }

        public static void InitBuiltinModules()
        {
            EventModule = ModuleManager.Instance.GetModule<EventModule>();
            TimerModule = ModuleManager.Instance.GetModule<TimerModule>();
            ProcedureModule = ModuleManager.Instance.GetModule<ProcedureModule>();
            FsmModule = ModuleManager.Instance.GetModule<FsmModule>();
        }
    }
}
