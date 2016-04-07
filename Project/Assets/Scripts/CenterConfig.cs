
namespace FATEC.ClansOfDragons {
    public class CenterConfig{

        public float unitLightHealt = 18f;
        public float unitMediumHealt = 54f;
        public float unitHeavyHealt = 92f;
        public float baseHealt = 300f;

        public float unitLightSpeed = 1f;
        public float unitMediumSpeed = 0.7f;
        public float unitHeavySpeed = 0.4f;

        public float unitLightFireRate = 0.5f;
        public float unitMediumFireRate = 1f;
        public float unitHeavyFireRate = 2f;
        public float BaseFireRate = 1f;

        public float unitLightRestoreRate = 1f;
        public float unitMediumRestoreRate = 1f;
        public float unitHeavyRestoreRate = 1f;
        public float BaseRestoreRate = 1f;

        public float unitLightPower = 1f;
        public float unitMediumPower = 3f;
        public float unitHeavyPower = 12f;
        public float BasePower = 6f;

        public int unitLightValue = 50;
        public int unitMediumValue = 100;
        public int unitHeavyValue = 150;

        private float defaut = 1f;

        /// <summary>Type of this.unit for dropdown on inspector</summary>
        public enum unitType {
            UnitLight, UnitMedium, UnitHeavy, Base
        }

        public float GetHealt(int type) {
            if (type == (int)unitType.UnitLight) {
                return this.unitLightHealt;
            }
            else if (type == (int)unitType.UnitMedium) {
                return this.unitMediumHealt;
            }
            else if (type == (int)unitType.UnitHeavy) {
                return this.unitHeavyHealt;
            }
            else if (type == (int)unitType.Base) {
                return baseHealt;
            }
            else {
                return this.defaut;
            }
        }

        public float GetSpeed(int type) {
            if (type == (int)unitType.UnitLight) {
                return this.unitMediumSpeed;
            }
            else if (type == (int)unitType.UnitMedium) {
                return this.unitMediumSpeed;
            }
            else if (type == (int)unitType.UnitHeavy) {
                return this.unitHeavySpeed;
            }
            else {
                return this.defaut;
            }
        }

        public float GetFireRate(int type) {
            if (type == (int)unitType.UnitLight) {
                return this.unitLightFireRate;
            }
            else if (type == (int)unitType.UnitMedium) {
                return this.unitMediumFireRate;
            }
            else if (type == (int)unitType.UnitHeavy) {
                return this.unitHeavyFireRate;
            }
            else if (type == (int)unitType.Base) {
                return BaseFireRate;
            }
            else {
                return this.defaut;
            }
        }

        public float GetRestoreRate(int type) {
            if (type == (int)unitType.UnitLight) {
                return this.unitLightRestoreRate;
            }
            else if (type == (int)unitType.UnitMedium) {
                return this.unitMediumRestoreRate;
            }
            else if (type == (int)unitType.UnitHeavy) {
                return this.unitHeavyRestoreRate;
            }
            else if (type == (int)unitType.Base) {
                return BaseRestoreRate;
            }
            else {
                return this.defaut;
            }
        }

        public float GetPower(int type) {
            if (type == (int)unitType.UnitLight) {
                return this.unitLightPower;
            }
            else if (type == (int)unitType.UnitMedium) {
                return this.unitMediumPower;
            }
            else if (type == (int)unitType.UnitHeavy) {
                return this.unitHeavyPower;
            }
            else if (type == (int)unitType.Base) {
                return BasePower;
            }
            else {
                return this.defaut;
            }
        }


        public int GetValue(int type) {
            if (type == (int)unitType.UnitLight) {
                return this.unitLightValue;
            }
            else if (type == (int)unitType.UnitMedium) {
                return this.unitMediumValue;
            }
            else if (type == (int)unitType.UnitHeavy) {
                return this.unitHeavyValue;
            }
            else {
                return (int)this.defaut;
            }
        }


    }
}