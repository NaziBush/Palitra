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

    protected virtual void CheckIfCrossed()
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
        height = sprite_rend.sprite.bounds.extents.y*transform.localScale.y;
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
    public abstract void ChangeColor();
    protected abstract void CheckIfPassed();

    public void Disable()
    {
        active = false;
    }

    public bool CheckIfActive()
    {
        return active;
    }
}
