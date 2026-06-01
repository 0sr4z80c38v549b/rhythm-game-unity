using UnityEngine;
using TMPro;

public class JudgeManager : MonoBehaviour
{
    [SerializeField] private MusicConductor musicConductor;
    [SerializeField] private TextMeshProUGUI judgeText;

    [SerializeField] private double perfectRange = 0.10;
    [SerializeField] private double goodRange = 0.20;
    [SerializeField] private double badRange = 0.30;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Judge(0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Judge(1);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Judge(2);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Judge(3);
        }
    }

    private void Judge(int lane)
    {
        Note[] notes = FindObjectsOfType<Note>();

        Note nearestNote = null;
        double nearestDiff = double.MaxValue;

        foreach (Note note in notes)
        {
            if (note.Lane != lane)
            {
                continue;
            }

            double diff = System.Math.Abs(musicConductor.MusicTime - note.NoteTime);

            if (diff < nearestDiff)
            {
                nearestDiff = diff;
                nearestNote = note;
            }
        }

        if (nearestNote == null)
        {
            judgeText.text = "Miss";
            return;
        }

        if (nearestDiff <= perfectRange)
        {
            judgeText.text = "Perfect";
            Destroy(nearestNote.gameObject);
        }
        else if (nearestDiff <= goodRange)
        {
            judgeText.text = "Good";
            Destroy(nearestNote.gameObject);
        }
        else if (nearestDiff <= badRange)
        {
            judgeText.text = "Bad";
            Destroy(nearestNote.gameObject);
        }
        else
        {
            judgeText.text = "Miss";
        }
    }
}