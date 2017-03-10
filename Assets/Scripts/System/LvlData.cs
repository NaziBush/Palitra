using UnityEngine;
using System.Collections;

//[CreateAssetMenu(fileName = "Lvl_Data")]
[CreateAssetMenu()]
public class LvlData : ScriptableObject
{
    [Header("Dist")]
    public float max_dist;
    public float min_dist;
    public float chng_dist_val;

    [Header("Lines")]
    public int lines_to_chng_dist;
    public int changable_lines_count;
    public int block_lines_count;
    public int invert_lines_count;
    public int closing_lines_count;
    public int lines_to_chng_lvl;
    
    [Header("Ball")]
    public float min_speed;
    public float max_speed;
    public int lines_to_accel;
    public float accel;

    [Header("Sectors")]
    public Color[] colors;

    [Header("Coins")]
    public int lines_to_coin;
    public int coins_reward;
}
