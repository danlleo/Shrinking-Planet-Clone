using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClipRefsSO _audioClipRefsSO;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Unit.OnUnitSelectingJob += Unit_OnUnitSelectingJob;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        Judge.OnJudgeAsking += Judge_OnJudgeAsking;
        Judge.OnJudgeReviewedAnswer += Judge_OnJudgeReviewedAnswer;
        ButtonSounds.OnButtonHover += ButtonHover_OnButtonHover;
        ButtonSounds.OnButtonPressed += ButtonSounds_OnButtonPressed;
        ResolveWorkIssueUI.OnResolvingFailedWorkIssue += ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
    }

    private void OnDestroy()
    {
        Unit.OnUnitSelectingJob -= Unit_OnUnitSelectingJob;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
        Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
        Judge.OnJudgeReviewedAnswer -= Judge_OnJudgeReviewedAnswer;
        ButtonSounds.OnButtonHover -= ButtonHover_OnButtonHover;
        ButtonSounds.OnButtonPressed -= ButtonSounds_OnButtonPressed;
        ResolveWorkIssueUI.OnResolvingFailedWorkIssue -= ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
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

    private void Judge_OnJudgeReviewedAnswer(object sender, Judge.ReceivedAnswerArgs e)
    {
        if (e.IsAnswerCorrect)
        {
            PlaySound(_audioClipRefsSO.CorrectInterviewQuestion, transform.position);
            return;
        }

        PlaySound(_audioClipRefsSO.WrongInterviewQuestion, transform.position);
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
