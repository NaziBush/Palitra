using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public static Ball ball;
    SpriteRenderer sprite_renderer;

	void Awake()
    {
        ball = this;
	}

    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
    }

	public void SetColor(Color color)
    {
        sprite_renderer.color = color;
    }
}
