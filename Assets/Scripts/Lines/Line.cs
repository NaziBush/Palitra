using UnityEngine;
using System.Collections;

public abstract class Line : MonoBehaviour
{
    protected SpriteRenderer sprite_rend;
    protected float height;
    protected Transform tran;
    protected bool active;

    void Update()
    {
        CheckIfCrossed();
    }

    void CheckIfCrossed()
    {
        if ((active) && (tran.position.y - height < Ball.ball.tran.position.y))
        {
            CheckIfPassed();
            active = false;
        }
    }

    void Awake()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
        tran = GetComponent<Transform>();
        height = sprite_rend.sprite.bounds.extents.y;
        InitLine();
    }

    protected virtual void InitLine()
    {

    }
    
    protected virtual void OnEnable()
    {
        active = true;
        ChangeColor();
    }

    //IEnumerator Delay()
    //{
    //    yield return new WaitForEndOfFrame();

    //}
    protected abstract void ChangeColor();
    protected abstract void CheckIfPassed();
}
