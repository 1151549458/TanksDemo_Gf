using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameFrameworkDemo;
using System;

namespace TanksDemo
{
    public class StartMenuPanelLogic  : UGuiForm
    {

        public Button btnStart;
        public Button btnIntroduce;
        public Button btnExit;
        private ProcedureMenu procedureMenu;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            procedureMenu = null;

            btnExit.onClick.AddListener(() => {
                Application.Quit();
            });
        }

        public void InitOnClick(Action a = null,Action b= null)
        {
            btnStart.onClick.AddListener(() => {
                a?.Invoke();
            });
            btnIntroduce.onClick.AddListener(() => {
                b?.Invoke();
            });
        }
         

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            procedureMenu = (ProcedureMenu)userData;

            btnStart.onClick.AddListener(() => {
                procedureMenu.StartGameClick();
            });
            btnIntroduce.onClick.AddListener(() => {
                GameEntry.UI.OpenUIForm(UIFormId.SettingForm);
            });
          
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        protected override void OnReveal()
        {
            base.OnReveal();
        }
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }


    }

}
 