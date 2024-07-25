using UnityEngine;

namespace Managers
{
    [CreateAssetMenu]
    public class AudioClipRefsSO : ScriptableObject
    {
        [field: SerializeField] public AudioClip UnitHover { get; private set; }
        [field: SerializeField] public AudioClip UnitSelect { get; private set; }
        [field: SerializeField] public AudioClip SetUnitOccupation { get; private set; }
        [field: SerializeField] public AudioClip UnitFail { get; private set; }
        [field: SerializeField] public AudioClip UnitSuccess { get; private set; }
        [field: SerializeField] public AudioClip EndDay { get; private set; }
        [field: SerializeField] public AudioClip UIElementSelect { get; private set; }
        [field: SerializeField] public AudioClip UIElementClick { get; private set; }
        [field: SerializeField] public AudioClip CollectCoin { get; private set; }
        [field: SerializeField] public AudioClip LevelUp { get; private set; }

        [field: SerializeField] public AudioClip JudgeAsking { get; private set; }
        [field: SerializeField] public AudioClip CorrectInterviewQuestion { get; private set; }
        [field: SerializeField] public AudioClip WrongInterviewQuestion { get; private set; }
        [field: SerializeField] public AudioClip[] UnitResponse { get; private set; }

        [field: SerializeField] public AudioClip CameraWhoosh { get; private set; }

        [field: SerializeField] public AudioClip TrashDispose { get; private set; }
        [field: SerializeField] public AudioClip DocumentDelivered { get; private set; }
        [field: SerializeField] public AudioClip WaterDrank { get; private set; }
        [field: SerializeField] public AudioClip WaterPouring { get; private set; }
        [field: SerializeField] public AudioClip ItemPick { get; private set; }
        [field: SerializeField] public AudioClip ItemDrop { get; private set; }

        [field: SerializeField] public AudioClip[] Steps { get; private set; }

        [field: SerializeField] public AudioClip SuccessPurchase { get; private set; }
    }
}
