using UnityEngine;
using System.Collections;

public abstract class Line : MonoBehaviour
{
   // protected SpriteRenderer sprite_rend;
    protected float height;
    protected Transform tran;
    protected bool active;
    public GameObject left;
    public GameObject right;
    protected AnimationComponent anim;

    protected virtual void Update()
    {
        CheckIfCrossed();
    }
    public Transform GetTransform()
    {
        return tran;
    }
    public float GetHeight()
    {
        return height;
    }
    protected virtual void CheckIfCrossed()
    {
        if ((active) && (tran.position.y - height <= Ball.ball.collision_point.position.y))
        {
            CheckIfPassed();
            active = false;
        }
    }

    protected virtual void Awake()
    {
        anim = GetComponent<AnimationComponent>();
       // sprite_rend = GetComponent<SpriteRenderer>();
        tran = GetComponent<Transform>();
        // height = sprite_rend.sprite.bounds.extents.y*transform.localScale.y;
        height = left.GetComponent<Renderer>().bounds.extents.y;
        // Debug.DrawLine(new Vector3(0.0f, transform.position.y - height, 0.0f), 
        //   new Vector3(0.0f, transform.position.y + height, 0.0f), Color.red, 10.0f);
        SetPartsPosition();
        InitLine();
    }


    void SetPartsPosition()
    {
        float width = left.GetComponent<Renderer>().bounds.extents.x;
        float screen_size = Edges.rightEdge - Edges.leftEdge;
    }

    public virtual void InitLine()
    {
        active = true;
        ChangeColor();
    }

    protected void SetTexture(Texture2D[] texture)
    {
        left.GetComponent<MeshRenderer>().materials[1].mainTexture = texture[0];
        right.GetComponent<MeshRenderer>().materials[1].mainTexture = texture[1];
        left.GetComponent<MeshRenderer>().materials[0].mainTexture = texture[0];
        right.GetComponent<MeshRenderer>().materials[0].mainTexture = texture[1];
    }

    protected virtual void OnEnable()
    {
        
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
