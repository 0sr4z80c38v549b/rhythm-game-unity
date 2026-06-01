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
    [SerializeField] private float spawnY = 4.0f;

    private readonly float[] laneXPositions =
    {
        -2.25f,
        -0.75f,
         0.75f,
         2.25f
    };

    private NoteData[] notes =
    {
        new NoteData(3.0, 0),
        new NoteData(3.5, 1),
        new NoteData(4.0, 2),
        new NoteData(4.5, 3),

        new NoteData(5.0, 0),
        new NoteData(5.5, 1),
        new NoteData(6.0, 2),
        new NoteData(6.5, 3),
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
            SpawnNote(nextNote);
            nextNoteIndex++;
        }
    }

    private void SpawnNote(NoteData noteData)
    {
        float x = laneXPositions[noteData.lane];
        Vector3 spawnPosition = new Vector3(x, spawnY, 0);

        GameObject noteObject = Instantiate(notePrefab, spawnPosition, Quaternion.identity);

        Note note = noteObject.GetComponent<Note>();
        note.Initialize(noteData.time, noteData.lane);
    }
}