/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     UGuiGroupHelper.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2019-11-21
 *Description:   
 *History:
*/ 
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace GameFrameworkDemo
{
    /// <summary>
    /// 选择他的时候每一个uI都会带canvas
    /// </summary>
    public class UGuiGroupHelper : UIGroupHelperBase
    {

        public const int DepthFactor = 101;
        private int m_Depth = 0;
        private Canvas m_CachedCanvas = null;
        /// <summary>
        /// 设置界面组深度
        /// </summary>
        /// <param name="depth"></param>
        public override void SetDepth(int depth)
        {

            m_Depth = depth;
            m_CachedCanvas.overrideSorting = true;
            m_CachedCanvas.sortingOrder = DepthFactor * depth;
        }

        private void Awake()
        {
            m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>();
            gameObject.GetOrAddComponent<GraphicRaycaster>();

        }
        private void Start()
        {
            m_CachedCanvas.overrideSorting = true;
            m_CachedCanvas.sortingOrder = DepthFactor * m_Depth;

            RectTransform transform = GetComponent<RectTransform>();
            transform.anchorMin = Vector2.zero;
            transform.anchorMax = Vector2.one;
            transform.anchoredPosition = Vector2.zero;
            transform.sizeDelta = Vector2.zero;
        }
        
    }
}