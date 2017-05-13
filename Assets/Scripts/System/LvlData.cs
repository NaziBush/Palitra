using UnityEngine;
using System.Collections;

//[System.Serializable]
//public class LineType
//{
//    PoolType type;
//    int count = 0;
//}

[CreateAssetMenu()]
public class LvlData : ScriptableObject
{
    [Header("Dist")]
    public float max_dist;
    public float min_dist;
    public float chng_dist_val;
    public int lines_to_chng_dist;

    [Header("Ball")]
    public float min_speed;
    public float max_speed;
    public int lines_to_accel;
    public float accel;


    [Header("Coins")]
    public int lines_to_coin;
    public int coins_reward;


    [Header("Lines")]

    [Tooltip("Стандартная линия")]
    public LineProp line_prop;

    [Tooltip("Враждебная полоса из 1 цвета")]
    public LineInvertProp invert_prop_1_color;

    [Tooltip("Враждебная полоса из 2 цветов")]
    public LineInvertProp invert_prop_2_colors;

    [Tooltip("Враждебная сдвигающаяся стена из 1 цвета")]
    public ClosingInvertProp closing_invert_prop_1_color;

    [Tooltip("Враждебная сдвигающаяся стена из 2 цветов")]
    public ClosingInvertProp closing_invert_prop_2_colors;

    [Tooltip("Дружелюбная сдвигающаяся стена")]
    public ClosingProp closing_prop;

    [Tooltip("Полоса, меняющая цвет")]
    public SwitchProp switch_prop;

    [Tooltip("Полосы, которые двигаются слева направо/справа налево")]
    public BlockProp block_prop;

    [Tooltip("Полоса, на которой написаны цифры из 1 части")]
    public MultipleProp multiple_prop_1_part;
    [Tooltip("Полоса, на которой написаны цифры из 2 частей")]
    public MultipleProp multiple_prop_2_parts;
    [Tooltip("Полоса, на которой написаны цифры из 3 частей")]
    public MultipleProp multiple_prop_3_parts;

    [Tooltip("Комбо полоса из 3 частей")]
    public ComboProp combo_prop_3_parts;
    [Tooltip("Комбо полоса из 4 частей")]
    public ComboProp combo_prop_4_parts;
    [Tooltip("Комбо полоса из 5 частей")]
    public ComboProp combo_prop_5_parts;

    //[HideInInspector]
    //public int changable_lines_count;
    //[HideInInspector]
    //public int block_lines_count;
    //[HideInInspector]
    //public int invert_lines_count;
    //[HideInInspector]
    //public int closing_lines_count;
    //[HideInInspector]
    //public int multiple_lines_count;
    //[HideInInspector]
    //public int order_lines_count;
    [HideInInspector]
    public int lines_to_chng_lvl;



    //[Header("Sectors")]
    public Color[] colors;

    
}
