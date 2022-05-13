using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKeeper : MonoBehaviour
{
    static public float BPM = 120.0f;
    static public float Times = 0.0f;
    public int Game_mode = 0;
    public static bool GameEnd = false;
    static bool fastTime = false;
    static public float haba = 1.0f;
    [Header("判定幅の分母(２以上推奨)")]
    public float line = 4.0f;
    static float ex_len = (60.0f / BPM) / haba;

    public static float ReCount = 4.0f;
    public static bool PoseOn = false;

    //private float old_time = 0.0f;
    // Start is called before the first frame update

    public GameObject[] Traps;
    void Start()
    {

    }

    private void Update()
    {
        //ゲームが終了すればロビーやタイトルに戻される
        Times += Time.deltaTime;
        if (!Player.PoseChance)
        {
            if (!PoseOn)
            {
                PoseOn = true;
                ReCount = 4.0f;
                Player.PoseChance = true;
            }
            else
            {
                if (ReCount == 0.0f)
                {
                    PoseOn = false;
                    Player.PoseChance = true;
                }
            }
        }
        haba = line;
        //トラップをランダムで設置する
        //トラップはプレイヤーからある程度離れた位置に出現
        //トラップに出現上限を付ける
    }
    private void LateUpdate()
    {
        GameKeeper.ex_len = (60.0f / BPM) / haba;
        //最終処理
        switch (Game_mode)
        {
            case 0:
                SoloMode.Game();
                break;
            case 1:
                PvP_Mode.Game();
                break;
        }
        float ex_len = (60.0f / BPM) / haba;
        if (60.0f / BPM > (Times % (60.0f / BPM)) + ex_len)
        {
            if (fastTime)
            {
                fastTime = false;
                if (ReCount > 0.0f && !Player.PoseChance) ReCount -= 1.0f;
            }
        }
        else fastTime = true;
    }
    public void TrapKeeper()
    {
        //Instantiate(Trap1);
    }
    public static int TempoGet(bool Timing,bool sousa)
    {
        if (PoseOn) return 0;
        //時間経過を測りつつ、Timingを合わせる
        if (60.0f / BPM > (Times % (60.0f / BPM)) + ex_len && fastTime)
        {
            if (Timing) return 1;
            return 3;
        }
        if ((Times % (60.0f / BPM)) - ex_len <= 60.0f / BPM &&
            60.0f / BPM <= (Times % (60.0f / BPM)) + ex_len)
        {
            if (sousa) return 2;
        }
        else if (sousa) return 1;
        return 0;
    }
}
