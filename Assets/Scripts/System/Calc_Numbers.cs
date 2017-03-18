using UnityEngine;
using System.Collections;

public class Calc_Numbers : MonoBehaviour
{
    public SpriteRenderer sprite_rend;
    int number=0;
    //Sprite[] number_pic;


    int Number
    {
        get
        {
            return number;
        }
        set
        {
            number = Mathf.Clamp(value, NumberPicData.Instance.min, NumberPicData.Instance.max);
        }
    }

	void Start ()
    {
        //sprite_rend = GetComponent<SpriteRenderer>();
        //number = 0;
        
	}

    public void Increase()
    {
        Number++;
        sprite_rend.sprite = NumberPicData.Instance.number_pic[number];
    }
	
	public void Decrease()
    {
        Number--;
        sprite_rend.sprite = NumberPicData.Instance.number_pic[number];
    }

    public void SetNumber(int value)
    {
        Number = value;
        sprite_rend.sprite = NumberPicData.Instance.number_pic[number];
    }
}
