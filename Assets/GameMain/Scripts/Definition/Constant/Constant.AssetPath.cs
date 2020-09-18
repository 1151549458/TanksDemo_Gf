/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     Constant.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-08-18
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameFrameworkDemo
{
    public static partial class Constant
    {
        public static class AssetPath
        {
            public static string ScenePath = "";
            public static string UIPath = "";
            public static string EntityPath = "";

            public static class GetScene
            {
                public static string MainScenePath = "Assets/GameMain/Scenes/MainScene.unity"; 
                public static string MenuScenePath = "Assets/GameMain/Scenes/MenuScene.unity"; 
                public static string GameScenePath = "Assets/GameMain/Scenes/GameScene.unity";
            }

            public static class GetUI
            {
                public static string LoginPanlePath = "Assets/GameMain/Prefabs/UI/LoginPanel.prefab"; 
                public static string IntroducePanelPath = "Assets/GameMain/Prefabs/UI/IntroducePanel.prefab"; 
                public static string StartMenuPath = "Assets/GameMain/Prefabs/UI/StartMenuPanel.prefab";

            }
            public static class GetEntity
            {
                public static string CubePath = "Assets/GameMain/Prefabs/Model/Entity1.prefab"; 
            }
             
        }


    }
}