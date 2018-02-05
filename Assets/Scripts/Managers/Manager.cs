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
        private static  int Chesse { get; set; }
        //Things to do
        //Create Converter Map
        //Create Storage Map
        //Create People Multiplyer Map
        //Create Save Functions
        //Settings
        //Display

        //Create Generation Per Turn

        //Create Time
        //Called Every .1 Sec
        private void FixedUpdate()
        {
            /*var tmp = Time.fixedDeltaTime;
            Debug.LogWarning(tmp);
            Time.fixedDeltaTime = 1;*/
        }
    }
}