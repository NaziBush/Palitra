using UnityEngine;
using System.Collections;

//[CreateAssetMenu(fileName = "Lvl_Data")]
[CreateAssetMenu()]
public class LvlData : ScriptableObject
{
    public float min_speed;
    public float max_speed;
    
    public float max_dist;
    public float min_dist;
}
