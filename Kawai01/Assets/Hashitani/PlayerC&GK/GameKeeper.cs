using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKeeper : MonoBehaviour
{
    static public float BPM = 120.0f;
    public float openBPM = 120.0f;
    static public float Times = 0.0f;
    public int Game_mode = 0;
    static public bool GameEnd = false;
    static public bool fastTime = false;
    static public float haba = 1.0f;
    [Header("���蕝�̕���(�Q�ȏ㐄��)")]
    public float line = 4.0f;
    static float ex_len = (60.0f / BPM) / haba;

    static public float ReCount = 4.0f;
    static public bool PoseOn = false;

    //private float old_time = 0.0f;
    // Start is called before the first frame update

    public List<GameObject> Traps;
    [Header("�g���b�v�̍ő�R�X�g")]
    public int CostLimit = 0;
    static public int TrapPopCost = 0;
    void Start()
    {
        BPM = openBPM;
    }

    private void Update()
    {
        //�Q�[�����I������΃��r�[��^�C�g���ɖ߂����
        Times += Time.deltaTime;
        if (!Player_R.PoseChance)
        {
            if (!PoseOn)
            {
                PoseOn = true;
                ReCount = 4.0f;
                Player_R.PoseChance = true;
            }
            else
            {
                if (ReCount == 0.0f)
                {
                    PoseOn = false;
                    Player_R.PoseChance = true;
                }
                
            }
        }
        haba = line;
        //�g���b�v�������_���Őݒu����
        //�g���b�v�̓v���C���[���炠����x���ꂽ�ʒu�ɏo��
        //�g���b�v�ɏo�������t����
        GameKeeper.ex_len = (60.0f / BPM) / haba;
        //�ŏI����
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
                //�g���b�v����
                if (!PoseOn) TrapKeeper();
                fastTime = false;
                if (ReCount > 0.0f && !Player_R.PoseChance) ReCount -= 1.0f;
            }
        }
        else fastTime = true;
    }
    public void TrapKeeper()
    {
        //�g���b�v�̈�ď���
        if (fastTime)
        {
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject tPlayer in Players)
            {
                //�J�E���g��i�߂�
                if (tPlayer.GetComponent<Player_R>().muteki_tempo > 0)
                    tPlayer.GetComponent<Player_R>().muteki_tempo -= 1;
            }
            GameObject[] Traps = GameObject.FindGameObjectsWithTag("Trap");
            foreach (GameObject Trap in Traps)
            {
                //�J�E���g��i�߂�
                Trap.GetComponent<TrapG>().TrapMoves();
            }
        }
        //�g���b�v�̎����o��
        for (int SetTC = Random.Range(0, 3); 0 < SetTC; SetTC--)
        {
            //�R�X�g�I�[�o�[����Ȃ�
            if (TrapPopCost > CostLimit) break;
            if (Traps.Count == 0) break;
            int Gimmick_Number = Random.Range(1, Traps.Count);
            switch (Gimmick_Number)
            {
                case 1:
                case 2:
                case 3:
                    Instantiate(Traps[Gimmick_Number - 1]);
                    break;
                case 4:
                    if (!UpUpScore.CheckOnMap) Instantiate(Traps[Gimmick_Number - 1]);
                    break;
                default:
                    //��{�Ȃɂ�����ĂȂ���
                    break;
            }
        }
    }
    public static int TempoGet(bool Timing,bool sousa)
    {
        if (PoseOn) return 0;
        //���Ԍo�߂𑪂�ATiming�����킹��
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
