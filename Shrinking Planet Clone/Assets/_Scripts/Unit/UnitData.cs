using UnityEngine;
using UnityEngine.Serialization;

namespace Unit
{
    [System.Serializable]
    public class UnitData
    {
        [field: SerializeField] public string UnitSOName { get; private set; }
        [field: SerializeField] public int UnitLevel { get; set; }

        [field: FormerlySerializedAs("_unitLeltOverXPs")]
        [field: FormerlySerializedAs("UnitLelfOverXPs")]
        [field: SerializeField]
        public int UnitLeftOverXPs { get; set; }

        public UnitData(string unitSOName, int unitLevel, int unitLeftOverXPs)
        {
            UnitSOName = unitSOName;
            UnitLevel = unitLevel;
            UnitLeftOverXPs = unitLeftOverXPs;
        }
    }
}
