using GameEngine.Runtime.Module;
using GameEngine.Runtime.Module.Event;
using UnityEngine;


namespace GameMain.Runtime.Global
{

    /// <summary>
    /// ÓÎÏ·Æô¶¯Æ÷
    /// </summary>
    public static class GModule
    {
        public static EventModule EventModule
        {
            get;
            private set;
        } = ModuleManager.GetModule<EventModule>();
    }
}

