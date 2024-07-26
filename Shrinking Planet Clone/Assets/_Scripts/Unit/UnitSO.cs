using UnityEngine;
using UnityEngine.Serialization;

namespace Unit
{
    [CreateAssetMenu]
    public class UnitSO : ScriptableObject
    {
        [field: FormerlySerializedAs("UnitName")]
        [field: SerializeField] public string UnitName { get; private set; } 
        
        [field: FormerlySerializedAs("Greetings")]
        [field: SerializeField] public string Greetings { get; private set; } 

        [field: FormerlySerializedAs("DefaultOccupation")]
        [field: SerializeField] public UnitOccupationType DefaultOccupation { get; private set; } 

        [field: FormerlySerializedAs("UnitSpawnPosition")]
        [field: SerializeField] public Vector3 UnitSpawnPosition { get; private set; } 
        
        [field: FormerlySerializedAs("UnitSpawnRotation")]
        [field: SerializeField] public Vector3 UnitSpawnRotation { get; private set; } 
        
        [field: FormerlySerializedAs("UnitTargetDeskPosition")]
        [field: SerializeField] public Vector3 UnitTargetDeskPosition { get; private set; } 
        
        [field: FormerlySerializedAs("UnitTargetReachedDeskRotation")]
        [field: SerializeField] public Vector3 UnitTargetReachedDeskRotation { get; private set; } 
        
        [field: FormerlySerializedAs("UnitPlaceOnChairPosition")]
        [field: SerializeField] public Vector3 UnitPlaceOnChairPosition { get; private set; } 
        
        [field: FormerlySerializedAs("UnitDisplayImage")]
        [field: SerializeField] public Sprite UnitDisplayImage { get; private set; } 
        
        [field: FormerlySerializedAs("UnitOccupationImage")]
        [field: SerializeField] public Sprite UnitOccupationImage { get; private set; } 

        [field: FormerlySerializedAs("GreetingSound")]
        [field: SerializeField] public AudioClip GreetingSound { get; private set; } 

        [field: FormerlySerializedAs("TypingSound")]
        [field: SerializeField] public AudioClip TypingSound { get; private set; } 
        
        [field: FormerlySerializedAs("AvailableOnlyOnInterview")]
        [field: SerializeField] public bool AvailableOnlyOnInterview { get; private set; } 
    }
}
