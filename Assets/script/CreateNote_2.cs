using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateNote_2 : MonoBehaviour
{
    //八条音轨起始位置
    public GameObject area1_line1;
	public GameObject area1_line2;
    public GameObject area2_line1;
    public GameObject area2_line2;
    public GameObject area3_line1;
    public GameObject area3_line2;
    public GameObject area4_line1;
    public GameObject area4_line2;
    //4个打击点位置
    public GameObject area1_end;
    public GameObject area2_end;
    public GameObject area3_end;
    public GameObject area4_end;
    //普通音符
	public GameObject note;
    //敌人音符
    public GameObject attack_note;
    //玩家
    public GameObject player;
    //4个打击点特效
	public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    //得分栏
	public GameObject scoreText;
    //打击评价栏
    public GameObject standardText;
    //连击栏
    public GameObject comboText;
    //血条
    public Slider hp_slider;
    //蓝条
    public Slider mp_slider;
    //左右攻击点击tag
    bool l_attack_tag;
    bool r_attack_tag;
    //游戏结束tag
    bool game_over_tag;
    int score;
    int combo;
    int hp;
    int hp_max;
    int mp;
    int mp_max;
	float notePositon;
    float noteType;
	float speed;
    List<GameObject> tempList = new List<GameObject>();
    List<GameObject> noteList = new List<GameObject>();
    List<GameObject> attackNoteList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
		score = 0;
        combo = 0;
        hp = 100;
        hp_max = 100;
        mp = 0;
        mp_max = 100;
        l_attack_tag = false;
        r_attack_tag = false;
        game_over_tag = false;
        speed = 2.0f;
		this.InvokeRepeating("RandomCreate", 2.0f, Random.Range(1.0f,1.5f));
    }


    // Update is called once per frame
    void Update()
    {
        GameOver();
        if (!game_over_tag)
        {
            ControlPlayer();
            NoteMove();
        }
        SliderControl();
        OtherKey();
    }

    //更新血条、蓝条
    void SliderControl()
    {
        hp_slider.value = hp / (float)hp_max;
        mp_slider.value = mp / (float)mp_max;
        if(hp > hp_max)
        {
            hp = hp_max;
        }
        if (hp < 0)
        {
            hp = 0;
        }
        if (mp > mp_max)
        {
            mp = mp_max;
        }
        if (mp < 0)
        {
            mp = 0;
        }
    }

    //游戏结束处理
    void GameOver()
    {
        if(hp == 0) {
            game_over_tag = true;
            this.CancelInvoke();
            for (int i = 0; i < noteList.Count; ++i)
            {
                GameObject note = noteList[i];
                Destroy(note);

            }
            noteList.Clear();
            for (int i = 0; i < attackNoteList.Count; ++i)
            {
                GameObject attack_note = attackNoteList[i];
                Destroy(attack_note);
            }
            attackNoteList.Clear();
            comboText.GetComponent<Text>().text = "Game Over!\nPress R to restart";
            standardText.GetComponent<Text>().text = "";
        }
    }

    //其他游戏按键
    void OtherKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (game_over_tag && Input.GetKeyDown(KeyCode.R))
        {
            game_over_tag = false;
            SceneManager.LoadScene("demo_sence1");
        }

    }


    //随机生成音符
	void RandomCreate()
	{
        noteType = Random.Range(0, 1.0f);
        if (noteType <= 0.8f)
        {
            GameObject obj = GameObject.Instantiate<GameObject>(note);
            notePositon = Random.Range(0, 1.0f);
            if (notePositon <= 0.125f)
            {
                obj.transform.position = new Vector2(area1_line1.transform.position.x, area1_line1.transform.position.y);
            }
            if (notePositon > 0.125f && notePositon <= 0.250f)
            {
                obj.transform.position = new Vector2(area1_line2.transform.position.x, area1_line2.transform.position.y);
            }
            if (notePositon > 0.250f && notePositon <= 0.375f)
            {
                obj.transform.position = new Vector2(area2_line1.transform.position.x, area2_line1.transform.position.y);
            }
            if (notePositon > 0.375f && notePositon <= 0.50f)
            {
                obj.transform.position = new Vector2(area2_line2.transform.position.x, area2_line2.transform.position.y);
            }
            if (notePositon > 0.50f && notePositon <= 0.625f)
            {
                obj.transform.position = new Vector2(area3_line1.transform.position.x, area3_line1.transform.position.y);
            }
            if (notePositon > 0.625 && notePositon <= 0.750f)
            {
                obj.transform.position = new Vector2(area3_line2.transform.position.x, area3_line2.transform.position.y);
            }
            if (notePositon > 0.750f && notePositon <= 0.875f)
            {
                obj.transform.position = new Vector2(area4_line1.transform.position.x, area4_line1.transform.position.y);
            }
            if (notePositon > 0.875f)
            {
                obj.transform.position = new Vector2(area4_line2.transform.position.x, area4_line2.transform.position.y);
            }
            noteList.Add(obj);
        }
        else
        {
            GameObject obj = GameObject.Instantiate<GameObject>(attack_note);
            notePositon = Random.Range(0, 1.0f);
            if (notePositon <= 0.125f)
            {
                obj.transform.position = new Vector2(area1_line1.transform.position.x, area1_line1.transform.position.y);
            }
            if (notePositon > 0.125f && notePositon <= 0.250f)
            {
                obj.transform.position = new Vector2(area1_line2.transform.position.x, area1_line2.transform.position.y);
            }
            if (notePositon > 0.250f && notePositon <= 0.375f)
            {
                obj.transform.position = new Vector2(area2_line1.transform.position.x, area2_line1.transform.position.y);
            }
            if (notePositon > 0.375f && notePositon <= 0.50f)
            {
                obj.transform.position = new Vector2(area2_line2.transform.position.x, area2_line2.transform.position.y);
            }
            if (notePositon > 0.50f && notePositon <= 0.625f)
            {
                obj.transform.position = new Vector2(area3_line1.transform.position.x, area3_line1.transform.position.y);
            }
            if (notePositon > 0.625 && notePositon <= 0.750f)
            {
                obj.transform.position = new Vector2(area3_line2.transform.position.x, area3_line2.transform.position.y);
            }
            if (notePositon > 0.750f && notePositon <= 0.875f)
            {
                obj.transform.position = new Vector2(area4_line1.transform.position.x, area4_line1.transform.position.y);
            }
            if (notePositon > 0.875f)
            {
                obj.transform.position = new Vector2(area4_line2.transform.position.x, area4_line2.transform.position.y);
            }
            attackNoteList.Add(obj);
        }
	}

    //音符移动
    void NoteMove()
    {
        if (noteList.Count > 0)
        {
            for (int i = 0; i < noteList.Count; ++i)
            {
                GameObject note = noteList[i];
                note.transform.position = Vector3.MoveTowards(note.transform.position, player.transform.position, speed * Time.deltaTime);
                if (Vector3.Distance(note.transform.position, player.transform.position) <= 1.0f)
                {
                    noteList.Remove(note);
                    Destroy(note);
                    standardText.GetComponent<Text>().text = "Miss!";
                    combo = 0;
                    comboText.GetComponent<Text>().text = "";
                    hp -= 5;
                }
            }
        }
        if (attackNoteList.Count > 0)
        {
            for (int i = 0; i < attackNoteList.Count; ++i)
            {
                GameObject note = attackNoteList[i];
                note.transform.position = Vector3.MoveTowards(note.transform.position, player.transform.position, speed * Time.deltaTime);
                if (Vector3.Distance(note.transform.position, player.transform.position) <= 1.0f)
                {
                    attackNoteList.Remove(note);
                    Destroy(note);
                    standardText.GetComponent<Text>().text = "Miss!";
                    combo = 0;
                    comboText.GetComponent<Text>().text = "";
                    hp -= 10;
                }
            }
        }
    }


    //判断打击评价、得分
    void SetScore(GameObject note, GameObject fire)
    {
        if (Vector3.Distance(note.transform.position, fire.transform.position) <= 0.5f)
        {
            noteList.Remove(note);
            attackNoteList.Remove(note);
            Destroy(note);
            score += 20;
            scoreText.GetComponent<Text>().text = "Score:" + score;
            standardText.GetComponent<Text>().text = "Perfect!";
            combo += 1;
            comboText.GetComponent<Text>().text = combo + "combo!";
            mp += 5;
        }
        else if ((Vector3.Distance(note.transform.position, fire.transform.position) <= 1.0f && (Vector3.Distance(note.transform.position, fire.transform.position) > 0.5f)))
        {
            noteList.Remove(note);
            attackNoteList.Remove(note);
            Destroy(note);
            score += 15;
            scoreText.GetComponent<Text>().text = "Score:" + score;
            standardText.GetComponent<Text>().text = "Good!";
            combo += 1;
            comboText.GetComponent<Text>().text = combo + "combo!";
            mp += 2;
        }
        else if ((Vector3.Distance(note.transform.position, fire.transform.position) <= 1.5f && (Vector3.Distance(note.transform.position, fire.transform.position) > 1.0f)))
        {
            noteList.Remove(note);
            attackNoteList.Remove(note);
            Destroy(note);
            score += 10;
            scoreText.GetComponent<Text>().text = "Score:" + score;
            standardText.GetComponent<Text>().text = "OK!";
            combo += 1;
            comboText.GetComponent<Text>().text = combo + "combo!";
            mp += 1;
        }
    }

    //打击特效出现0.3s隐藏
    IEnumerator hide()
    {
        if (fire1.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.3f);
            fire1.SetActive(false);
        }
        if (fire2.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.3f);
            fire2.SetActive(false);
        }
        if (fire3.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.3f);
            fire3.SetActive(false);
        }
        if (fire4.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.3f);
            fire4.SetActive(false);
        }
    }


    //左位打击tag开启0.3s
    IEnumerator l_attack()
    {
        l_attack_tag = true;
        yield return new WaitForSeconds(0.3f);
        l_attack_tag = false;
    }

    //右位打击tag开启0.3s
    IEnumerator r_attack()
    {
        r_attack_tag = true;
        yield return new WaitForSeconds(0.3f);
        r_attack_tag = false;
    }

    //E F J I W O 空格 七个键位
    void ControlPlayer()
	{ 
        for (int i = 0; i < noteList.Count; ++i)
        {
            GameObject note = noteList[i];
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (l_attack_tag)
                {
                    for (int j = 0; j < attackNoteList.Count; ++j)
                    {
                        GameObject attack_note = attackNoteList[j];
                        SetScore(attack_note, fire1);
                    }
                    l_attack_tag = false;
                }
                fire1.SetActive(true);
                SetScore(note, fire1);
                StartCoroutine("hide");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (l_attack_tag)
                {
                    for (int j = 0; j < attackNoteList.Count; ++j)
                    {
                        GameObject attack_note = attackNoteList[j];
                        SetScore(attack_note, fire2);
                    }
                    l_attack_tag = false;
                }
                fire2.SetActive(true);
                SetScore(note, fire2);
                StartCoroutine("hide");
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (r_attack_tag)
                {
                    for (int j = 0; j < attackNoteList.Count; ++j)
                    {
                        GameObject attack_note = attackNoteList[j];
                        SetScore(attack_note, fire3);
                    }
                    r_attack_tag = false;
                }
                fire3.SetActive(true);
                SetScore(note, fire3);
                StartCoroutine("hide");
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (r_attack_tag)
                {
                    for (int j = 0; j < attackNoteList.Count; ++j)
                    {
                        GameObject attack_note = attackNoteList[j];
                        SetScore(attack_note, fire4);
                    }
                    r_attack_tag = false;
                }
                fire4.SetActive(true);
                SetScore(note, fire4);
                StartCoroutine("hide");
            }
        }


        for (int i = 0; i < attackNoteList.Count; ++i)
        {
            GameObject attack_note = attackNoteList[i];
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine("l_attack");
                if (fire1.activeInHierarchy)
                {
                    SetScore(attack_note, fire1);
                }
                if (fire2.activeInHierarchy)
                {
                    SetScore(attack_note, fire2);
                }
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                StartCoroutine("r_attack");
                if (fire3.activeInHierarchy)
                {
                    SetScore(attack_note, fire3);
                }
                if (fire4.activeInHierarchy)
                {
                    SetScore(attack_note, fire4);
                }
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && mp == 100)
        { 
            for (int i = 0; i < noteList.Count; ++i)
            {
                GameObject note = noteList[i];
                Destroy(note);
                combo += i;
                comboText.GetComponent<Text>().text = combo + "combo!";
                score += i * 20;
                scoreText.GetComponent<Text>().text = "Score:" + score;
            }
            noteList.Clear();
            for (int i = 0; i < attackNoteList.Count; ++i)
            {
                GameObject attack_note = attackNoteList[i];
                Destroy(attack_note);
                combo += i;
                comboText.GetComponent<Text>().text = combo + "combo!";
                score += i * 20;
                scoreText.GetComponent<Text>().text = "Score:" + score;
            }
            attackNoteList.Clear();
            standardText.GetComponent<Text>().text = "Boom!";
            mp = 0;
        }
    }
}
