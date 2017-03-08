using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnWaves : MonoBehaviour
{
    public static SpawnWaves spawn;
    float start_delay = 2.0f;
    public Pool normal_pool;
    public Pool chngbl_pool;
    public Pool blocks_pool;
    public Pool invert_pool;

    Pool[] pool=new Pool[(int)PoolType.Count];

    [Space(20)]
    public float startWait;

    public enum PoolType { Normal, Chngbl,Blocks,Invert,Count};
    List<PoolType> lines= new List<PoolType>();
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
        pool[(int)PoolType.Normal] = normal_pool;
        pool[(int)PoolType.Chngbl] = chngbl_pool;
        pool[(int)PoolType.Blocks] = blocks_pool;
        pool[(int)PoolType.Invert] = invert_pool;

        ReserveLines();
        lines_passed = 0;
        lines_spawned = 0;
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

    void ReserveLines()
    {
        lines.Clear();
        for (int i = 0;i < GameController.game_controller.GetLvlData().changable_lines_count;i++)
        {
            lines.Add(PoolType.Chngbl);
        }
        for (int i = 0; i < normal_lines_count;i++)
        {
            lines.Add(PoolType.Normal);
        }

        for (int i = 0; i < GameController.game_controller.GetLvlData().block_lines_count; i++)
        {
            lines.Add(PoolType.Blocks);
        }
        for (int i = 0; i < GameController.game_controller.GetLvlData().invert_lines_count; i++)
        {
            lines.Add(PoolType.Invert);
        }
    }

    Pool GetPool(PoolType id)
    {
        return pool[(int)id];
    }

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
        normal_lines_count = GameController.game_controller.GetLvlData().lines_to_chng_lvl - 
            GameController.game_controller.GetLvlData().changable_lines_count - 
            GameController.game_controller.GetLvlData().block_lines_count -
            GameController.game_controller.GetLvlData().invert_lines_count;
        if (normal_lines_count < 0)
            normal_lines_count = 0;

        ReserveLines();
        StartCoroutine(Delay());

    }
    IEnumerator Delay()
    {
        is_spawning = false;

        yield return new WaitForSeconds(start_delay);
        
        Dist = GameController.game_controller.GetLvlData().max_dist;
        edge = Edges.topEdge - Dist + 0.5f;
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
        pool[(int)current_line].Activate(new Vector2(0.0f, edge), Quaternion.identity);
    }





}
