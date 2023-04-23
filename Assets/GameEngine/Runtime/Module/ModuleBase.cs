﻿using UnityEngine;

namespace GameEngine.Runtime.Module
{
    /// <summary>
    /// 模块抽象类。
    /// </summary>
    public abstract class ModuleBase : MonoBehaviour
    {
        /// <summary>
        /// 获取游戏框架模块优先级。
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行。</remarks>
        public virtual int Priority
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// 游戏框架模块轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        public abstract void OnUpdate(float elapseSeconds, float realElapseSeconds);
        public abstract void OnFixUpdate(float elapseSeconds, float realElapseSeconds);
        public abstract void OnLateUpdate(float elapseSeconds, float realElapseSeconds);
        /// <summary>
        /// 关闭并清理游戏框架模块。
        /// </summary>
        public abstract void Release();
    }
}
