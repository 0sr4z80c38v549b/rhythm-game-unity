using UnityEngine;
using TMPro;

public class MusicConductor : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI musicTimeText;

    [SerializeField] private double startDelay = 1.0;

    private double songStartDspTime;

    public double MusicTime { get; private set; }

    private void Start()
    {
        MusicTime = 0;
        songStartDspTime = AudioSettings.dspTime + startDelay;
        audioSource.PlayScheduled(songStartDspTime);
    }

    private void Update()
    {
        if (AudioSettings.dspTime < songStartDspTime)
        {
            MusicTime = 0;
        }
        else
        {
            MusicTime = AudioSettings.dspTime - songStartDspTime;
        }

        musicTimeText.text = $"Music Time: {MusicTime:F2}";
    }
}