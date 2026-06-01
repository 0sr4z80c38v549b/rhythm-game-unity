using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;

    public double NoteTime { get; private set; }
    public int Lane { get; private set; }

    public void Initialize(double noteTime, int lane)
    {
        NoteTime = noteTime;
        Lane = lane;
    }

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}