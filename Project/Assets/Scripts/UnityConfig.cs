using UnityEngine;
using System.Collections;


namespace FATEC.CubeWars.Behaviours {

    public class UnityConfig : MonoBehaviour{

        public float UnityLightHealt;
        public float UnityMediumHealt;
        public float UnityHeavyHealt;
        public float BaseHealt;

        public float UnityLightSpeed;
        public float UnityMediumSpeed;
        public float UnityHeavySpeed;

        public float UnityLightRange;
        public float UnityMediumRange;
        public float UnityHeavyRange;

        public float UnityLightPower;
        public float UnityMediumPower;
        public float UnityHeavyPower;

        public enum UnityType {
            UnityLight, UnityMedium, UnityHeavy, Base
        }

        public float GetHealt(int type) {
            if (type == (int)UnityType.UnityLight) {
                return 3f;
            }
            else if (type == (int)UnityType.UnityMedium) {
                return 5f;
            }
            else if (type == (int)UnityType.UnityHeavy) {
                return 8f;
            }
            else if (type == (int)UnityType.Base) {
                return 30f;
            }
            else {
                return 1f;
            }
        }

        public float GetSpeed(int type) {
            if (type == (int)UnityType.UnityLight) {
                return 1f;
            }
            else if (type == (int)UnityType.UnityMedium) {
                return 1f;
            }
            else if (type == (int)UnityType.UnityHeavy) {
                return 1f;
            }
            else if (type == (int)UnityType.Base) {
                return 1f;
            }
            else {
                return 1f;
            }
        }

        public float GetRange(int type) {
            if (type == (int)UnityType.UnityLight) {
                return 1f;
            }
            else if (type == (int)UnityType.UnityMedium) {
                return 1f;
            }
            else if (type == (int)UnityType.UnityHeavy) {
                return 1f;
            }
            else if (type == (int)UnityType.Base) {
                return 1f;
            }
            else {
                return 1f;
            }
        }

        public float GetPower(int type) {
            if (type == (int)UnityType.UnityLight) {
                return 1f;
            }
            else if (type == (int)UnityType.UnityMedium) {
                return 1f;
            }
            else if (type == (int)UnityType.UnityHeavy) {
                return 1f;
            }
            else if (type == (int)UnityType.Base) {
                return 1f;
            }
            else {
                return 1f;
            }
        }



    }
}