using UnityEngine;

namespace GameMain.Runtime
{
    /// <summary>
    /// ��Ϸ������
    /// </summary>
    public partial class Launcher : MonoBehaviour
    {
        void Start()
        {
            //��ʼ������ģ��
            GameModule.InitBuiltinModules();
            //��ʼ���Զ���ģ��
            GameModule.InitCustomModules();
        }
    }
}

