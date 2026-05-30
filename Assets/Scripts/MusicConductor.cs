using UnityEngine;
using TMPro;

public class MusicConductor : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI musicTimeText;

    private double startDspTime;

    private void Start()
    {
        startDspTime = AudioSettings.dspTime;
        audioSource.Play();
    }

    private void Update()
    {
        double musicTime = AudioSettings.dspTime - startDspTime;

        if (musicTime < 0)
        {
            musicTime = 0;
        }

        musicTimeText.text = $"Music Time: {musicTime:F2}";
    }
}