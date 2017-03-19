using UnityEngine;
using System.Collections;

public class Multiple_Block : MonoBehaviour
{
    SpriteRenderer sprite_rend;
    Calc_Numbers calc_numb;
    int hp = 3;

    void OnEnable()
    {
        gameObject.SetActive(true);
        hp = Random.Range(1,5);
        calc_numb.SetNumber(hp);
    }
	
	void Awake ()
    {
        sprite_rend = GetComponent<SpriteRenderer>();
        calc_numb = GetComponentInChildren<Calc_Numbers>();
	}
	
	public void SetColor(Color color)
    {
        sprite_rend.color = color;
    }

    public bool Hit()
    {
        hp--;
        if (hp<=0)
        {
            Disable();
            return true;
        }

        calc_numb.SetNumber(hp);
        return false;
        
        
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    public Color GetColor()
    {
        return sprite_rend.color;
    }
}
