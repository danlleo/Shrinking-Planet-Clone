using UI.WorkingSceneUI;
using Unit;
using UnityEngine;

namespace Managers
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private AudioClipRefsSO _audioClipRefsSO;
        
        // private void Start()
        // {
        //     Unit.Unit.OnUnitSelectingJob += Unit_OnUnitSelectingJob;
        //     DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        //     Judge.Judge.OnJudgeAsking += Judge_OnJudgeAsking;
        //     Judge.Judge.OnJudgeReviewedAnswer += Judge_OnJudgeReviewedAnswer;
        //     ButtonSounds.OnButtonHover += ButtonHover_OnButtonHover;
        //     ButtonSounds.OnButtonPressed += ButtonSounds_OnButtonPressed;
        //     ResolveWorkIssueUI.OnResolvingFailedWorkIssue += ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
        //     InteractSystem.Instance.OnObjectPickUp += InteractSystem_OnObjectPickUp;
        //     InteractSystem.Instance.OnObjectDispose += InteractSystem_OnObjectDispose;
        //     ShopManager.Instance.OnItemBought += ShopManager_OnItemBought;
        //     UnitLevel.OnAnyLevelUp += UnitLevel_OnAnyLevelUp;
        // }
        //
        // private void OnDestroy()
        // {
        //     Unit.Unit.OnUnitSelectingJob -= Unit_OnUnitSelectingJob;
        //     DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
        //     Judge.Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
        //     Judge.Judge.OnJudgeReviewedAnswer -= Judge_OnJudgeReviewedAnswer;
        //     ButtonSounds.OnButtonHover -= ButtonHover_OnButtonHover;
        //     ButtonSounds.OnButtonPressed -= ButtonSounds_OnButtonPressed;
        //     ResolveWorkIssueUI.OnResolvingFailedWorkIssue -= ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
        //     InteractSystem.Instance.OnObjectPickUp -= InteractSystem_OnObjectPickUp;
        //     InteractSystem.Instance.OnObjectDispose -= InteractSystem_OnObjectDispose;
        //     ShopManager.Instance.OnItemBought -= ShopManager_OnItemBought;
        //     UnitLevel.OnAnyLevelUp -= UnitLevel_OnAnyLevelUp;
        // }

        private void UnitLevel_OnAnyLevelUp(object sender, System.EventArgs e)
        {
            PlaySound(_audioClipRefsSO.LevelUp, transform.position);
        }

        private void ShopManager_OnItemBought(object sender, System.EventArgs e)
        {
            PlaySound(_audioClipRefsSO.SuccessPurchase, transform.position);
        }

        private void InteractSystem_OnObjectDispose(object sender, System.EventArgs e)
        {
            PlayDropSound();
        }

        private void InteractSystem_OnObjectPickUp(object sender, InteractSystem.ObjectPickUpArgs e)
        {
            PlayPickUpSound();
        }

        private void ResolveWorkIssueUI_OnResolvingFailedWorkIssue(object sender, System.EventArgs e)
        {
            PlayUnitFail();
        }

        private void ButtonSounds_OnButtonPressed(object sender, System.EventArgs e)
        {
            PlaySound(_audioClipRefsSO.UIElementClick, transform.position);
        }

        private void ButtonHover_OnButtonHover(object sender, System.EventArgs e)
        {
            PlaySound(_audioClipRefsSO.UIElementSelect, transform.position);
        }

        private void Judge_OnJudgeReviewedAnswer(object sender, Judge.Judge.ReceivedAnswerArgs e)
        {
            if (e.IsAnswerCorrect)
            {
                PlaySound(_audioClipRefsSO.CorrectInterviewQuestion, transform.position);
                return;
            }

            PlaySound(_audioClipRefsSO.WrongInterviewQuestion, transform.position);
        }

        public void PlayFootStepsSound(Vector3 position, float volume)
        {
            PlaySound(_audioClipRefsSO.Steps, position, volume);
        }

        public void PlayCameraWhooshSound()
        {
            PlaySound(_audioClipRefsSO.CameraWhoosh, transform.position);
        }

        public void PlayInterviewUnitTalking()
        {
            PlaySound(_audioClipRefsSO.UnitResponse, transform.position);
        }

        public void PlayUnitMouseHover()
        {
            PlaySound(_audioClipRefsSO.UnitHover, transform.position);
        }

        public void PlayUnitSetOccupation()
        {
            PlaySound(_audioClipRefsSO.SetUnitOccupation, transform.position);
        }

        public void PlayUnitSuccess()
        {
            PlaySound(_audioClipRefsSO.UnitSuccess, transform.position);
        }

        public void PlayUnitFail()
        {
            PlaySound(_audioClipRefsSO.UnitFail, transform.position);
        }

        public void PlayCoinCollectSound()
        {
            PlaySound(_audioClipRefsSO.CollectCoin, transform.position);
        }

        public void PlayWaterPouringSound()
        {
            PlaySound(_audioClipRefsSO.WaterPouring, transform.position);
        }

        public void PlayTrashDisposeSound()
        {
            PlaySound(_audioClipRefsSO.TrashDispose, transform.position);
        }

        public void PlayDocumentDeliveredSound()
        {
            PlaySound(_audioClipRefsSO.DocumentDelivered, transform.position);
        }

        public void PlayWaterDrankSound()
        {
            PlaySound(_audioClipRefsSO.WaterDrank, transform.position);
        }

        public void PlayPickUpSound()
        {
            PlaySound(_audioClipRefsSO.ItemPick, transform.position);
        }

        public void PlayDropSound()
        {
            PlaySound(_audioClipRefsSO.ItemDrop, transform.position);
        }

        private void Judge_OnJudgeAsking(object sender, System.EventArgs e)
        {
            PlaySound(_audioClipRefsSO.JudgeAsking, transform.position);
        }

        private void DayManager_OnDayEnded(object sender, System.EventArgs e)
        {
            PlaySound(_audioClipRefsSO.EndDay, transform.position);
        }

        private void Unit_OnUnitSelectingJob(object sender, System.EventArgs e)
        {
            PlaySound(_audioClipRefsSO.UnitSelect, transform.position);
        }

        private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
        {
            AudioSource.PlayClipAtPoint(audioClip, position, volume);
        }

        private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
        {
            AudioClip audioClip = audioClipArray[Random.Range(0, audioClipArray.Length)];

            PlaySound(audioClip, position, volume);
        }
    }
}
