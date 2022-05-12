using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public GameObject task;
    public Sprite[] icons;
    public Text score;
    public Text BS;
    private float Sc = 0;
    public float BestSc = 0;
    public float PlayTime = 0;
    private float timer = 1.0f;
    private float currectTime;
    public AudioClip pop;
    private AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();


    }
    
    // Update is called once per frame
    void Update()
    {
        if (BestSc >= Sc)
        {
        }
        else {
            BestSc = Sc;
            BS.text = "Best :" + BestSc.ToString();
        }
        currectTime += Time.deltaTime;
        

        if (PlayTime <= 0)
        {
            //EndGame
            task.GetComponent<SpriteRenderer>().sprite = icons[3];

        }
        else {
            if (currectTime > timer)
            {
                PlayTime--;
                currectTime = 0;
            }
        }
    }
    public void StartGame() {
        if (PlayTime <= 0) {
           
            PlayTime = 60;
            ChangeTask();
            Sc = 0;
            score.text = "Score :" + Sc;
        }
        
    }
    public void GetPoint() {
        if (PlayTime > 0)
        {
            Sc++;
            score.text = "Score :" + Sc;
        }
    }
    public float GetTask() {
        if (task.GetComponent<SpriteRenderer>().sprite == icons[0])
        {
            return 0;
        }
        else if (task.GetComponent<SpriteRenderer>().sprite == icons[1])
        {
            return 1;
        }
        else {
            return 2;
        }
        
    }
    public void ChangeTask() {

        if (PlayTime > 0)
        {
            task.GetComponent<SpriteRenderer>().sprite = icons[Random.Range(0, 3)];
        }
        
    }
    public void PlayPOP() {
        audi.PlayOneShot(pop);
    }
}
