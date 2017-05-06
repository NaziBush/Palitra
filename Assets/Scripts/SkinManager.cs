using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager skin_manager;
    [SerializeField]
    SkinData[] skin_data;
    int totalSkinCount=1;
    int skin_number=0;

    public int GetSkinNumber()
    {
        return skin_number;
    }

    public int GetTotalSkinCount()
    {
        return totalSkinCount;
    }
    void Awake()
    {
        skin_manager = this;
        Object.DontDestroyOnLoad(gameObject);
        totalSkinCount = skin_data.Length;
    }

    public void NextSkin()
    {
        
        if (skin_number == skin_data.Length-1)
        {
            skin_number = 0;
        }
        else
        {
            skin_number++;
        }
    }

    public void PrevSkin()
    {
        if (skin_number == 0)
        {
            skin_number = skin_data.Length - 1;
        }
        else
        {
            skin_number--;
        }
    }

    public SkinData GetSkin()
    {
        return skin_data[skin_number];
    }
}



