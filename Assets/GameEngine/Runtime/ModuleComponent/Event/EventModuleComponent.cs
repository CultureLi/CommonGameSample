using GameEngine.Runtime.Module;
using GameEngine.Runtime.Module.Event;
using GameEngine.Runtime.ModuleComponent;
using System;

namespace GameEngine.Runtime.ModuleComponent.Event
{
    public class EventModuleComponent : ModuleComponentBase
    {
        private EventModule m_Module;

        protected override void Awake()
        {
            base.Awake();
            m_Module = ModuleManager.GetModule<EventModule>();
            if(m_Module == null)
            {
                throw new Exception($"Create EventModule Failed !!!");
            }
        }
    }
}
