/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     UGuiForm.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-08-10
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
namespace GameFrameworkDemo
{
    public class UGuiForm : UIFormLogic
    {
        private Canvas m_CachedCanvas = null;
        public const int DepthFactor = 100;
        private static Font s_MainFont = null;


        public int OriginalDepth
        {
            get;
            private set;
        } 
        public int Depth
        {
            get
            {
                return m_CachedCanvas.sortingOrder;
            }
        } 
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>();
            m_CachedCanvas.overrideSorting = true;
            OriginalDepth = m_CachedCanvas.sortingOrder;

            RectTransform transform = GetComponent<RectTransform>();
            transform.anchorMin = Vector2.zero;
            transform.anchorMax = Vector2.one;
            transform.anchoredPosition = Vector2.zero;
            transform.sizeDelta = Vector2.zero;

            gameObject.GetOrAddComponent<GraphicRaycaster>();

            //Text[] texts = GetComponentsInChildren<Text>(true);
            //for (int i = 0; i < texts.Length; i++)
            //{
            //    texts[i].font = s_MainFont;
            //    if (!string.IsNullOrEmpty(texts[i].text))
            //    {
            //        texts[i].text = GameEntry.Localization.GetString(texts[i].text);
            //    }
            //}


        } 
        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            int oldDepth = Depth;
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            int deltaDepth = UGuiGroupHelper.DepthFactor * uiGroupDepth + DepthFactor * depthInUIGroup - oldDepth +
                             OriginalDepth;
            Canvas[] canvases = GetComponentsInChildren<Canvas>(true);
            for (int i = 0; i < canvases.Length; i++)
            {
                canvases[i].sortingOrder += deltaDepth;
            }
        }

       

        public void PlayUISound(int uiSoundId)
        {
            GameEntry.Sound.PlayUISound(uiSoundId);
        }

        public static void SetMainFont(Font mainFont)
        {
            if (mainFont == null)
            {
                Log.Error("Main font is invalid.");
                return;
            }

            s_MainFont = mainFont;
        }





    }
     
} 