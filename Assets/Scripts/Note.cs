using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}