using GameFrameworkDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQFramework;
namespace TanksDemo
{
    public class IntroducePanelLogic : UGuiForm
    {
        public Text textTitle;
        public Text textContent;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            GUIEventListener.Get(gameObject).onClick = _=> {
                OnClose(true, userData);
            };

            //GetComponent<Button>().onClick.AddListener(()=> {
            //    this.OnClose(false, userData);
            //});
        }

        public void SetContent(string title,string content)
        {
            textTitle.text = title;
            textContent.text = content; 
        }


        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            

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