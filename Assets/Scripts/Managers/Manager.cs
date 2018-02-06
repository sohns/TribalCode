using System.CodeDom.Compiler;
using System.Collections.Generic;
using Buildings;
using Enum;
using UnityEngine;

namespace Managers
{
    public class Manager : MonoBehaviour
    {
        /*
        READ ME:
        Naming conventions:
        Global Variables:
        public int CapitalLetters;
        private static readonly int CapitalLetters;
        private <static or not> int _underscoreLowerThenUpper;
        <public or private> int CapitalLetters {get; set;}  <---Always try to make things propertys if possible by doing get/sets like this. If you want public get private set {get; private set;}
        */
        //Things to do
        //Create Save Functions
        //Settings
        //Display

        //Create Generation Per Turn

        //Create Time
        //Called Every .1 Sec
        //Time.fixedDeltaTime;
        //Time.fixedDeltaTime = 1;
        private void FixedUpdate()
        {
            /*var tmp = Time.fixedDeltaTime;
            Debug.LogWarning(tmp);
            Time.fixedDeltaTime = 1;*/
        }

        private void Awake()
        {
            
        }

       
    }
}