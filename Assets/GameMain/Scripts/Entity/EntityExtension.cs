/**
 *Copyright(C) 2018 by DefaultCompany
 *All rights reserved.
 *FileName:     EntityExtension.cs
 *Author:       Pan
 *Version:      1.0
 *UnityVersion��2018.4.0f1
 *Date:         2020-08-13
 *Description:   
 *History:
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.DataTable;
using System;
using UnityGameFramework.Runtime;
using TanksDemo;
namespace GameFrameworkDemo
{
    public static class EntityExtension
    {
        private static int s_SerialId;

        public static Entity GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return entity;
        }
  
        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity);
        }

        public static void ShowPlayerTanks(this EntityComponent entityComponent,PlayerTankData data)
        {
            entityComponent.ShowEntity(typeof(PlayerTanks),Constant.EntityName.PlayerTanksName, Constant.AssetPriority.PlayerTanksAsset, data);
  
        }
        public static void ShowEnemtyTanks(this EntityComponent entityComponent,EnemtyTanksData data)
        {
            entityComponent.ShowEntity(typeof(EnemtyTanks), Constant.EntityName.EnemtyTanksName, Constant.AssetPriority.EnemtyTanksAsset, data);

        }
        public static void ShowEnemtyBossTanks(this EntityComponent entityComponent,EnemtyBossTankData data)
        {
            entityComponent.ShowEntity(typeof(EnemtyBossTanks), Constant.EntityName.EnemtyBossTanksName, Constant.AssetPriority.EnemtyBossTanksAsset, data);

        } 
         
        public static void ShowBullet(this EntityComponent entityComponent, BulletData data)
        {
            entityComponent.ShowEntity(typeof(Bullet), Constant.EntityName.BulletName, Constant.AssetPriority.BulletAsset, data);
        }

        public static void ShowEffect(this EntityComponent entityComponent, EffectData data )
        {
            entityComponent.ShowEntity(typeof(Effect), Constant.EntityName.EffectName, Constant.AssetPriority.EffectAsset, data); 
        }


        //public static void ShowCube(this EntityComponent entityComponent,)
        //{
        //    entityComponent.ShowEntity(typeof(CubeLogic),"cube",10,);
        //}

        private static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, priority, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

    }
}