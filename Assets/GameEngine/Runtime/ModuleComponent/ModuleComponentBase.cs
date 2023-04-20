using UnityEngine;

namespace GameEngine.Runtime.ModuleComponent
{
    /// <summary>
    /// 模块组件抽象类。
    /// </summary>
    public abstract class ModuleComponentBase : MonoBehaviour
    {
        protected virtual void Awake()
        {
            //GameEntry.RegisterComponent(this);
        }
    }
}
