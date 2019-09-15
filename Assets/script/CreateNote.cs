using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNote : MonoBehaviour
{
	public GameObject area1_line1;
	public GameObject area1_line2;
    public GameObject area2_line1;
    public GameObject area2_line2;
    public GameObject area3_line1;
    public GameObject area3_line2;
    public GameObject area4_line1;
    public GameObject area4_line2;
    public GameObject area1_end;
    public GameObject area2_end;
    public GameObject area3_end;
    public GameObject area4_end;
	public GameObject note;
    public GameObject attack_note;
    public GameObject player;
	public GameObject bear;
    public GameObject right_note;
	public GameObject scoreText;
	public GameObject standardText;
    public GameObject standardRightText;
    int score;
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
		speed = 2.0f;
		this.InvokeRepeating("RandomCreate", 2.0f, Random.Range(1.0f,1.5f));
    }


    // Update is called once per frame
    void Update()
    {
		Controlbear();
        noteMove();
    }


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

    void noteMove()
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
                }
            }
        }
    }


    void SetScore(GameObject note)
    {
        if (Vector3.Distance(note.transform.position, bear.transform.position) <= 1.5f)
        {
            noteList.Remove(note);
            attackNoteList.Remove(note);
            Destroy(note);
            score += 10;
            scoreText.GetComponent<Text>().text = "Score:" + score;
            standardText.GetComponent<Text>().text = "OK!";
        }
        if ((Vector3.Distance(note.transform.position, bear.transform.position) < 1.0f && (Vector3.Distance(note.transform.position, player.transform.position) > 0.5f)))
        {
            noteList.Remove(note);
            attackNoteList.Remove(note);
            Destroy(note);
            score += 15;
            scoreText.GetComponent<Text>().text = "Score:" + score;
            standardText.GetComponent<Text>().text = "Good!";
        }
        if (Vector3.Distance(note.transform.position, bear.transform.position) <= 0.5f)
        {
            noteList.Remove(note);
            attackNoteList.Remove(note);
            Destroy(note);
            score += 20;
            scoreText.GetComponent<Text>().text = "Score:" + score;
            standardText.GetComponent<Text>().text = "Perfect!";
        }
    }

    

    void Controlbear()
	{
        
        for (int i = 0; i < noteList.Count; ++i)
        {
            GameObject note = noteList[i];
            if (Input.GetKeyDown(KeyCode.F))
            {
                bear.transform.position = area1_end.transform.position;
                SetScore(note);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                bear.transform.position = area2_end.transform.position;
                SetScore(note);
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                bear.transform.position = area3_end.transform.position;
                SetScore(note);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                bear.transform.position = area4_end.transform.position;
                SetScore(note);
            }
        }
        
        for (int i = 0; i < attackNoteList.Count; ++i)
        {
            GameObject attack_note = attackNoteList[i];
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (bear.transform.position == area1_end.transform.position || bear.transform.position == area2_end.transform.position)
                {
                    SetScore(attack_note);
                }

            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (bear.transform.position == area3_end.transform.position || bear.transform.position == area4_end.transform.position)
                {
                    SetScore(attack_note);
                }
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        { 
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
            standardText.GetComponent<Text>().text = "Boom!";
        }
    }
}
