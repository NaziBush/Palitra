using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager skin_manager;
    [SerializeField]
    SkinData[] skin_data;
    int totalSkinCount=1;
    int active_skin=0;

    public int GetSkinNumber()
    {
        return active_skin;
    }

    public void SetActiveSkin(int new_skin_number)
    {
        active_skin = Mathf.Clamp(new_skin_number, 0, totalSkinCount);
       // PlayerPrefs.SetInt("ActiveSkin", new_skin_number);
        EventManager.TriggerEvent("SkinChanged");
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
        //if (PlayerPrefs.HasKey("ActiveSkin"))&&(PlayerPrefs.HasKey())
        //{
        //    SetActiveSkin(PlayerPrefs.GetInt("ActiveSkin"));
        //}
    }

 

    public SkinData GetCurrentSkin()
    {
        return skin_data[active_skin];
    }

    public SkinData GetSkinByNumber(int number)
    {
        return skin_data[number];
    }

}



