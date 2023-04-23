using GameEngine.Runtime.Base;
using GameEngine.Runtime.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameMain.Runtime.ModuleComponent
{
    public class BaseComponent : ModuleComponentBase
    {

        [SerializeField]
        private int m_FrameRate = 30;

        /// <summary>
        /// 获取或设置游戏帧率。
        /// </summary>
        public int FrameRate
        {
            get
            {
                return m_FrameRate;
            }
            set
            {
                Application.targetFrameRate = m_FrameRate = value;
            }
        }


        protected override void Awake()
        {
            base.Awake();

            Application.targetFrameRate = m_FrameRate;

        }

        private void Update()
        {
            ModuleManager.Instance.Update(Time.deltaTime, Time.realtimeSinceStartup);
        }
    }
}
