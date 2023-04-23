using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameEngine.Runtime.Module
{
    public abstract class ModuleComponentBase:MonoBehaviour
    {
        protected virtual void Awake()
        {
            ModuleComponentManager.Instance.RegisterComponent(this);
        }
    }
}
