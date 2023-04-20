using GameEngine.Runtime.Module.Event;
using GameEngine.Runtime.Module;
using UnityEngine;


namespace GameMain.Runtime
{
    public static partial class GameModule
    {

        public static EventModule EventModule
        {
            get;
            private set;
        }

        public static void InitBuiltinModules()
        {
            EventModule  = ModuleManager.GetModule<EventModule>();
        }
    }
}
