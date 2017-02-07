using UnityEngine;
using System.Collections;

//[CreateAssetMenu(fileName = "Lvl_Data")]
[CreateAssetMenu()]
public class LvlData : ScriptableObject
{
    [Header("Lines")]
    public float max_dist;
    public float min_dist;
    public int lines_to_chng_dist;
    public float chng_dist_val;

    [Header("Ball")]
    public float min_speed;
    public float max_speed;
    public int lines_to_accel;
    public float accel;

    [Header("Sectors")]
    public Color[] colors;

    [Header("Level")]
    public int lines_to_chng_lvl;
}
