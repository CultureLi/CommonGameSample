using GameEngine.Runtime.Base;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameEngine.Runtime.Module
{
    /// <summary>
    /// 游戏模块管理器
    /// </summary>
    public class ModuleComponentManager:Singleton<ModuleComponentManager>
    {
        private readonly List<ModuleComponentBase> s_ModuleComponents = new List<ModuleComponentBase>();

        /// <summary>
        /// 游戏框架所在的场景编号。
        /// </summary>
        internal const int GameFrameworkSceneId = 0;

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <typeparam name="T">要获取的游戏框架组件类型。</typeparam>
        /// <returns>要获取的游戏框架组件。</returns>
        public T GetComponent<T>() where T : ModuleComponentBase
        {
            return (T)GetComponent(typeof(T));
        }

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <param name="type">要获取的游戏框架组件类型。</param>
        /// <returns>要获取的游戏框架组件。</returns>
        public ModuleComponentBase GetComponent(Type type)
        {
            foreach(var com in s_ModuleComponents)
            {
                if (com.GetType() == type)
                {
                    return com;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取游戏框架组件。
        /// </summary>
        /// <param name="typeName">要获取的游戏框架组件类型名称。</param>
        /// <returns>要获取的游戏框架组件。</returns>
        public ModuleComponentBase GetComponent(string typeName)
        {
            foreach (var com in s_ModuleComponents)
            {
                Type type = com.GetType();
                if (type.FullName == typeName || type.Name == typeName)
                {
                    return com;
                }
            }

            return null;
        }

        /// <summary>
        /// 关闭游戏框架。
        /// </summary>
        /// <param name="shutdownType">关闭游戏框架类型。</param>
        public void Shutdown(ShutdownType shutdownType)
        {
            ModuleManager.Instance.Release();

            s_ModuleComponents.Clear();

            if (shutdownType == ShutdownType.None)
            {
                return;
            }

            if (shutdownType == ShutdownType.Restart)
            {
                SceneManager.LoadScene(GameFrameworkSceneId);
                return;
            }

            if (shutdownType == ShutdownType.Quit)
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                return;
            }
        }

        /// <summary>
        /// 注册游戏框架组件。
        /// </summary>
        /// <param name="gameFrameworkComponent">要注册的游戏框架组件。</param>
        internal void RegisterComponent(ModuleComponentBase moduleComponent)
        {
            if (moduleComponent == null)
            {
                Log.Error("Game Framework component is invalid.");
                return;
            }

            if(!s_ModuleComponents.Contains(moduleComponent))
                s_ModuleComponents.Add(moduleComponent);
        }
    }
}
