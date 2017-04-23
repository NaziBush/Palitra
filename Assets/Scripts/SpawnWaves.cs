using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PoolType { Normal, Switch, Blocks, Invert_one_color, Invert_two_colors, Closing_invert_one_color,
    Closing_invert_two_colors, Multiple_1_part, Multiple_2_parts, Multiple_3_parts,
    Combo_3_parts,Combo_4_parts,Combo_5_parts, Count };

public class SpawnWaves : MonoBehaviour
{
    public static SpawnWaves spawn;
    float start_delay = 0.2f;
    
    LineHandler[] line_handler;

    [Space(20)]
    public float startWait;
    
    List<PoolType> lines = new List<PoolType>();
    int normal_lines_count;

    [HideInInspector]
    public float dist;
    float edge;
    int lines_passed;
    int lines_spawned;

    bool is_spawning;

    float Dist
    {
        get
        {
            return dist;
        }

        set
        {
            dist = Mathf.Clamp(value, GameController.game_controller.GetLvlData().min_dist, GameController.game_controller.GetLvlData().max_dist);
        }
    }

    void Awake()
    {
        spawn = this;
    }

    void Start ()
    {

        Pool[] pool;// = new Pool[(int)PoolType.Count];
        pool = GetComponentsInChildren<Pool>();


        line_handler = new LineHandler[(int)PoolType.Count];
        for (int i=0;i<line_handler.Length;i++)
        {
            line_handler[i]=ScriptableObject.CreateInstance<LineHandler>();
        }
        
        //print(line_handler.Length);
        for (int i=0;i<(int)PoolType.Count;i++)
        {
            line_handler[i].pool_type = (PoolType)i;
            for (int k=0;k < (int)PoolType.Count;k++)
            {
                if (pool[k].pool_type == (PoolType)i)
                {
                    line_handler[i].pool = pool[k];
                    break;
                }
            }
        }

        ChangeLvl();
        //ReserveLines();
        //lines_passed = 0;
        //lines_spawned = 0;
        StartCoroutine(Delay());
    }
    void OnEnable()
    {
        EventManager.StartListening("LinePassed", LinePassed);
        EventManager.StartListening("ChangeLvl", ChangeLvl);
    }
    void OnDisable()
    { 
        EventManager.StopListening("LinePassed", LinePassed);
        EventManager.StopListening("ChangeLvl", ChangeLvl);
    }


    void GetLineCountData()
    {
        line_handler[(int)PoolType.Normal].count = GameController.game_controller.GetLvlData().line_prop.count;
        line_handler[(int)PoolType.Switch].count = GameController.game_controller.GetLvlData().switch_prop.count;
        line_handler[(int)PoolType.Blocks].count = GameController.game_controller.GetLvlData().block_prop.count;
        line_handler[(int)PoolType.Invert_one_color].count = GameController.game_controller.GetLvlData().invert_prop_1_color.count;
        line_handler[(int)PoolType.Invert_two_colors].count = GameController.game_controller.GetLvlData().invert_prop_2_colors.count;
        line_handler[(int)PoolType.Closing_invert_one_color].count = 
            GameController.game_controller.GetLvlData().closing_invert_prop_1_color.count;
        line_handler[(int)PoolType.Closing_invert_two_colors].count = 
            GameController.game_controller.GetLvlData().closing_invert_prop_2_colors.count;
        line_handler[(int)PoolType.Multiple_1_part].count = GameController.game_controller.GetLvlData().multiple_prop_1_part.count;
        line_handler[(int)PoolType.Multiple_2_parts].count = GameController.game_controller.GetLvlData().multiple_prop_2_parts.count;
        line_handler[(int)PoolType.Multiple_3_parts].count = GameController.game_controller.GetLvlData().multiple_prop_3_parts.count;
        line_handler[(int)PoolType.Combo_3_parts].count = GameController.game_controller.GetLvlData().combo_prop_3_parts.count;
        line_handler[(int)PoolType.Combo_4_parts].count = GameController.game_controller.GetLvlData().combo_prop_4_parts.count;
        line_handler[(int)PoolType.Combo_5_parts].count = GameController.game_controller.GetLvlData().combo_prop_5_parts.count;
    }

    void ReserveLines()
    {
        lines.Clear();

        GetLineCountData();

        //вычисляем количество стандратных линий
        //int normal_count = GameController.game_controller.GetLvlData().lines_to_chng_lvl;
        //for (int i = 1; i < (int)PoolType.Count; i++)
        //{
        //    normal_count -= line_handler[i].count;
        //}
        //if (normal_count < 0)
        //    normal_count = 0;
        //line_handler[0].count = normal_count;

        //вычисляем общее количество линий на уровне
        GameController.game_controller.GetLvlData().lines_to_chng_lvl=0;
        for (int i = 0; i < (int)PoolType.Count; i++)
        {
            GameController.game_controller.GetLvlData().lines_to_chng_lvl += line_handler[i].count;
        }


        //заполняем массив линий
        for (int i=0;i<(int)PoolType.Count;i++)
        {
            for (int j=0;j<line_handler[i].count;j++)
            {
                lines.Add(line_handler[i].pool_type);
            }
        }
    }

    //Pool GetPool(PoolType id)
    //{
    //    return pool[(int)id];
    //}

    void LinePassed()
    {
        lines_passed++;
        if (lines_passed >= GameController.game_controller.GetLvlData().lines_to_chng_dist)
        {
            lines_passed = 0;
            Dist -= GameController.game_controller.GetLvlData().chng_dist_val;
        }
    }

    void ChangeLvl()
    {
        lines_passed = 0;
        lines_spawned = 0;

        ReserveLines();
        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        is_spawning = false;

        yield return new WaitForSeconds(start_delay);
        
        Dist = GameController.game_controller.GetLvlData().max_dist;
        edge = Edges.topEdge + Dist + 0.5f;
        //SpawnWave();
        is_spawning = true;
    }

    void Update()
    {
        //print(Time.time);
        if ((is_spawning)&&(Edges.topEdge >= edge+Dist)&&(lines_spawned < GameController.game_controller.GetLvlData().lines_to_chng_lvl))
        {
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        PoolType current_line = lines[Random.Range(0,lines.Count)];
        lines.Remove(current_line);

        lines_spawned++;
        edge += Dist;
        line_handler[(int)current_line].pool.Activate(new Vector2(0.0f, edge), Quaternion.identity);
    }





}
