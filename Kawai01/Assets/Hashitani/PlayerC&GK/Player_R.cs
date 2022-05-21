using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_R : MonoBehaviour
{
    [Header("物理リンク")]
    public Rigidbody2D m_Rigidbody;
    //マップ範囲
    public float up_down = 5;
    public float right_left = 5;
    public float move_length = 1.0f;
    //リズム変数
    private bool Timing = false;
    private int Combo = 0;
    //操作
    public int Player_nm = 0;
    public Actions testinput;
    public static bool PoseChance = true;

    //体力
    public int m_Life = 12;
    public int m_old_Life = 12;
    public bool kisikaisei = false;
    public bool Keep_Life = true;
    public int muteki_tempo = 3;
    //初期座標

    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody2D>();
        if (Player_nm == 0) testinput = new Actions();
        //else if (Player_nm == 1) testinput = new Actions();
        testinput.Enable();
    }
    public void Sousa()
    {
        testinput.Enable();
        //操作時に、tempoの確認を取る
        //移動操作、そのほかを入力
        bool sousa = true;
        if (testinput.Player.Pose.triggered && PoseChance)
        {
            //ポーズに入ったら曲も止める
            Debug.Log("Pose");
            PoseChance = false;
            sousa = false;
        }
        else if (!GameKeeper.PoseOn)
        {
            if (testinput.Player.Up.triggered) m_Rigidbody.position += new Vector2(0.0f, move_length);
            else if (testinput.Player.Down.triggered) m_Rigidbody.position += new Vector2(0.0f, -move_length);
            else if (testinput.Player.Right.triggered) m_Rigidbody.position += new Vector2(move_length, 0.0f);
            else if (testinput.Player.Left.triggered) m_Rigidbody.position += new Vector2(-move_length, 0.0f);
            else sousa = false;
        }
        else sousa = false;
        switch (GameKeeper.TempoGet(Timing, sousa))
        {
            //0影響なし
            //1失敗
            //2成功
            //3権限回復
            case 1:
                Combo = 0;
                if (sousa) Timing = false;
                Debug.Log(Combo);
                break;
            case 2:
                Combo += 1;
                Timing = false;
                Debug.Log(Combo);
                break;
            case 3:
                Timing = true;
                break;
        }
        //座標修正
        RePos();
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム終了、もしくは体力が尽きると操作不能になる
        if (GameKeeper.GameEnd || !Keep_Life) 
        {
            testinput.Disable();
        }
    }
    //遅れて実行されるアップデート
    private void LateUpdate()
    {
        //ここを使って当たり判定を処理する
    }
    private void RePos()
    {
        //移動しすぎた場合に修正する
        Vector2 v4 = new Vector2(0.0f, 0.0f);
        if (m_Rigidbody.position.x < right_left * move_length) v4 += new Vector2(move_length, 0.0f);
        if (m_Rigidbody.position.x > -right_left * move_length) v4 -= new Vector2(move_length, 0.0f);
        if (m_Rigidbody.position.y < up_down * move_length) v4 += new Vector2(0.0f, move_length);
        if (m_Rigidbody.position.y > -up_down * move_length) v4 -= new Vector2(0.0f, move_length);
        m_Rigidbody.position += v4;
    }
}
