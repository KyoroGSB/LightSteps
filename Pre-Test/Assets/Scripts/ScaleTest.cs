using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    public GameObject[] CornerSpot;
    public GameObject cylinder;
    public float TimeScale = 0.1f;
    public float Stat_scale = 2f;
    public float Threshold_1 = 5.0f;
    public float Threshold_2 = 9.0f;
  
    // Start is called before the first frame update
    private MakeTable MT;
    private Rigidbody rb;
    private TaskManager TK;
    public GameObject smoke;
    public GameObject[] judgment;
    public bool stop;
    void Start()
    {
        MT = FindObjectOfType<MakeTable>();
        TK = FindObjectOfType<TaskManager>();
        rb = GetComponent<Rigidbody>();

        //StartCoroutine(LerpLength(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            //this.transform.localScale = new Vector3(transform.localScale.x,
            //    transform.localScale.y, transform.localScale.z*1.5f
             //);


            
        }
    }
    public void setTable(float a) {

        StartCoroutine(LerpLength(a));
       
    }

    IEnumerator LerpLength(float a) {
        if (a < 0)
        {
            a = -a;
        }
        float progress = 0;

        var FinalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * a  * Stat_scale);
        while (progress <= 1)
        {
            if (transform.localScale == FinalScale)
            {
                progress = 2;
            }
            transform.localScale = Vector3.Lerp(transform.localScale, FinalScale, progress);
            progress += Time.deltaTime * TimeScale;
            yield return null;
            if (transform.localScale == FinalScale)
            {
                progress = 2;
            }
            if (stop) {
                break;
            }
        }
        
        //transform.localScale = FinalScale;
        //make table feet
        MT.Step1 = false;
        MT.Step2 = false;
        TK.PlayPOP();

        GameObject s = Instantiate(smoke,this.transform.position,transform.rotation,null);
        Destroy(s,2.0f);
        
        for (int i = 0; i < 4; i++)
        {
            
                GameObject obj = Instantiate(cylinder, CornerSpot[i].transform.position, CornerSpot[i].transform.rotation, this.transform);
                obj.transform.localScale = new Vector3(0.2f, 0.4f, 0.2f / transform.localScale.z);
              
        }
        if (TK.GetTask() == 0 && transform.localScale.z > 1.0f && transform.localScale.z <= Threshold_1)
        {
            TK.GetPoint();
            GameObject j = Instantiate(judgment[0], new Vector3(transform.position.x - 0.5f, transform.position.y + 1.5f, transform.position.z + 0.5f), Quaternion.Euler (90,180, transform.rotation.z) , null);
            Destroy(j, 2.0f);
        }
        else if (TK.GetTask() == 1 && transform.localScale.z > Threshold_1 && transform.localScale.z <= Threshold_2)
        {
            TK.GetPoint();
            GameObject j = Instantiate(judgment[0], new Vector3(transform.position.x - 0.5f, transform.position.y + 1.5f, transform.position.z + 0.5f), Quaternion.Euler(90, 180, transform.rotation.z), null);
            Destroy(j, 2.0f);
        }
        else if (TK.GetTask() == 2 && transform.localScale.z >= Threshold_2)
        {
            TK.GetPoint();
            GameObject j = Instantiate(judgment[0], new Vector3(transform.position.x - 0.5f, transform.position.y + 1.5f, transform.position.z + 0.5f), Quaternion.Euler(90, 180, transform.rotation.z), null);
            Destroy(j, 2.0f);
        }
        else {
            GameObject j = Instantiate(judgment[1], new Vector3(transform.position.x - 0.5f, transform.position.y + 1.5f, transform.position.z + 0.5f), Quaternion.Euler(90, 180, transform.rotation.z), null);
            Destroy(j, 2.0f);
        }
        TK.ChangeTask();
        rb.isKinematic = false;

        yield return null;

    }
}
