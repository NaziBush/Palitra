using UnityEngine;
using System.Collections;

public class BlockMove : MonoBehaviour
{
    public float speed;
    float half_window_size;

	void Start ()
    {
        half_window_size = (Edges.rightEdge - Edges.leftEdge)/2.0f;
        //print(half_window_size);
    }

	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x - half_window_size-5.0f > Edges.rightEdge)
        {
            Vector3 new_position = transform.position;
            new_position.x = Edges.leftEdge - half_window_size;
            transform.position = new_position;
        }
	}
}
