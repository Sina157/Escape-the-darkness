using UnityEngine;

public class MovingPart : MonoBehaviour
{
    public Transform cube;
    public Transform startPos;
    public Transform endPos;

    public float speed = 2f;

    private float t;

    void Update()
    {


        t += Time.deltaTime * speed;
        cube.position = Vector3.Lerp(startPos.position, endPos.position, Mathf.PingPong(t, 1));
    }
}
