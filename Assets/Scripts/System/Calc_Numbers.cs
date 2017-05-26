using UnityEngine;
using System.Collections;

public class Calc_Numbers : MonoBehaviour
{
    public SpriteRenderer sprite_rend;
    int number=0;
    //Sprite[] number_pic;

	void Start ()
    {
        //sprite_rend = GetComponent<SpriteRenderer>();
        //number = 0;
        
	}

    public void Increase()
    {
        number++;
        sprite_rend.sprite = NumberPicData.Instance.number_pic[number];
    }
	
	public void Decrease()
    {
        number--;
        sprite_rend.sprite = NumberPicData.Instance.number_pic[number];
    }

    public void SetNumber(int value)
    {
        number = value;
        sprite_rend.sprite = NumberPicData.Instance.number_pic[number];
    }

    void Calculate()
    {

    }
}
