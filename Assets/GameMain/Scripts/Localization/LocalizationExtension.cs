/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     LocalizationExtension.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-07-07
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
namespace GameFrameworkDemo
{
    public static class LocalizationExtension
    {
        /// <summary>
        /// 加载字典
        /// </summary>
        /// <param name="localizationComponent"></param>
        /// <param name="dictionaryName"></param>
        /// <param name="fromBytes"></param>
        /// <param name="userData"></param>
        public static void LoadDictionary(this LocalizationComponent localizationComponent, string dictionaryName, bool fromBytes, object userData = null)
        {
            if (string.IsNullOrEmpty(dictionaryName))
            {
                Log.Warning("Dictionary name is invalid.");
                return;
            }

            localizationComponent.LoadDictionary(dictionaryName, AssetUtility.GetDictionaryAsset(dictionaryName, fromBytes), Constant.AssetPriority.DictionaryAsset, userData);
        }
    }
}