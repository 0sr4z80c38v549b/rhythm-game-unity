using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [System.Serializable]
    public class NoteData
    {
        public double time;
        public int lane;

        public NoteData(double time, int lane)
        {
            this.time = time;
            this.lane = lane;
        }
    }

    [SerializeField] private MusicConductor musicConductor;
    [SerializeField] private GameObject notePrefab;

    [SerializeField] private double spawnBeforeTime = 2.0;
    [SerializeField] private Vector3 spawnPosition = new Vector3(0, 4, 0);

    private NoteData[] notes =
    {
        new NoteData(3.0, 0),
        new NoteData(4.0, 0),
        new NoteData(5.0, 0),
        new NoteData(6.0, 0),
    };

    private int nextNoteIndex = 0;

    private void Update()
    {
        if (nextNoteIndex >= notes.Length)
        {
            return;
        }

        NoteData nextNote = notes[nextNoteIndex];

        if (musicConductor.MusicTime >= nextNote.time - spawnBeforeTime)
        {
            Instantiate(notePrefab, spawnPosition, Quaternion.identity);
            nextNoteIndex++;
        }
    }
}