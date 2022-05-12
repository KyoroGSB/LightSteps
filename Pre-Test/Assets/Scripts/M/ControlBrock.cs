using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBrock : MonoBehaviour
{
    public GameObject bricks;
    public GameObject Goal;
    //public GameObject TrackObj;
    public GameObject Left_Hand;
    public GameObject Right_Hand;
    public GameObject vfx;
    public GameObject CenterAnchor;
    public GameObject Count_text;
    public GameObject thumb;
    private float count = 0;
    //Gestures Status
    public bool Is_Right_ThumbUp;
    public bool Is_Left_S;
    public bool Is_Left_P;
    public bool Is_Right_S;
    public bool Is_Right_P;
    [SerializeField]
    private Vector3 V1;
    [SerializeField]
    private Vector3 V2;
    [SerializeField]
    private float time;
    private Vector3 tmp_Hand1;
    //Blocks Status
    [SerializeField]
    private Vector3 Original_pos;
    [SerializeField]
    private Vector3 distoEnd;
    private float tmp_y;
   

    public float duration = 1.0f;
    private float timer = 0f;
    public float speed = 0.5f;
    public float HeightSpeed = 0.5f;
    public float anglespeed = 0.5f;
    public float TimeScale = 0.1f;
    public float Stat_scale = 2f;
    // 程序
    public bool Step1 = false;
    public bool Step2 = false;
    public bool Step3 = false;
    public bool arrived;
    public bool inAction;
    Task[] t;
    // Start is called before the first frame update
    void Start()
    {
        vfx.SetActive(false);
        Count_text.SetActive(false);
        Original_pos = this.transform.position;
        distoEnd = Original_pos - Goal.transform.position;
        t = FindObjectsOfType<Task>();
    }

   
    // Update is called once per frame
    void Update()
    {
       
        Vector3 tmp_hand2 = (Left_Hand.transform.position + Right_Hand.transform.position) / 2;

        if (Is_Right_ThumbUp) {
            thumb.SetActive(false);
        //////////////////程序只Run 1次
        if (Is_Left_S && Is_Right_S && !Step1)
        {
            //紀錄手高度 // 進入第一階段
            
            tmp_y = tmp_hand2.y;
            vfx.SetActive(true);
            Step1 = true;
            tmp_Hand1 = (Left_Hand.transform.position + Right_Hand.transform.position) / 2;
        }
        if (Is_Left_P && Is_Right_P && Step1 && !Step2) {//開始伸長
            inAction = true;
            Step2 = true;
            Vector3 V2_L = Left_Hand.GetComponent<Transform>().localPosition;
            Vector3 V2_R = Right_Hand.GetComponent<Transform>().localPosition;
            V2 = (V2_L + V2_R) / 2;
            Count_text.SetActive(true);
            StartCoroutine(Acc_Cal());
            //StartCoroutine(LerpLength(2));
        }
        if (Is_Left_S && Is_Right_S && Step1 && Step2 && !Step3) {
            //重製
            inAction = false;
            arrived = true;
            Invoke("Restart", 2.0f);
        }


        if (Step2 && inAction)
        {

            //跟著Tracker移動(雙手高低
            //紀錄
            //transform.position = new Vector3(transform.position.x, tmp_y, transform.position.z);
            Vector3 gap = tmp_hand2 - tmp_Hand1;
            transform.Translate(new Vector3 (0, gap.y , 0) * Time.deltaTime * HeightSpeed);
            //if (tmp_hand2.y > tmp_y)
            //{//手比上幀高
            //  transform.Rotate(Vector3.left * anglespeed * Time.deltaTime);

            //}
            //else if (tmp_hand2.y < tmp_y)
            //{//手比上幀低
            //   transform.Translate(Vector3.down * HightSpeed * Time.deltaTime);
            //   transform.Rotate(Vector3.right * anglespeed * Time.deltaTime);
            //}
            //else
            //{//高低無變化回調角度
            //    float original_Y = transform.eulerAngles.y;
            //    float original_Z = transform.eulerAngles.z;
            //    Vector3 finalRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), anglespeed * 0.2f * Time.deltaTime).eulerAngles;
            //    finalRotation.y = original_Y;
            //    finalRotation.z = original_Z;
            //    transform.rotation = Quaternion.Euler(finalRotation);
            //}


            //頭部控制
            Debug.Log(CenterAnchor.transform.rotation.z);
            //左轉
            if (CenterAnchor.transform.rotation.z * 100  < -15f)
            {
                transform.Rotate(Vector3.up * anglespeed * Time.deltaTime);
                Debug.Log("Right" + CenterAnchor.transform.rotation.z);
                
            }
            if (CenterAnchor.transform.rotation.z * 100  > 15f) {
                transform.Rotate(Vector3.down * anglespeed * Time.deltaTime);
                Debug.Log("Left" + CenterAnchor.transform.rotation.z);
            }
           


            //紀錄上幀數
            tmp_y = tmp_hand2.y;

            


            //生方塊

            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Time.time - timer > duration)
            {
                GameObject a = Instantiate(bricks, transform.position, transform.rotation, null);
                timer = Time.time;
                //計算離終點的距離
                Vector3 dis = Goal.transform.position - transform.position;
                count = (dis.z / distoEnd.z) * -100 ;
                count -= 100;
                count *= -1;
                Count_text.GetComponent<Text>().text = count.ToString("0") + "%";
            }

        }
        //if (Is_Left_S && Is_Right_S && Step1 && Step2)
        //{


        //}
        if (arrived) {
            inAction = false;
        }
        if (Step1)
        {
            time = Time.deltaTime;
            Vector3 lastFrame_L = Left_Hand.GetComponent<Transform>().localPosition;
            Vector3 lastFrame_R = Right_Hand.GetComponent<Transform>().localPosition;
            V1 = (lastFrame_L + lastFrame_R) / 2;
           
        }



        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Rotate(Vector3.left * anglespeed * Time.deltaTime);

            TrackObj.transform.Translate(Vector3.up * HightSpeed * 10f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Rotate(Vector3.right * anglespeed * Time.deltaTime);
            TrackObj.transform.Translate(Vector3.down * HightSpeed *10f* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * anglespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * anglespeed * Time.deltaTime);
        }*/

        if (!inAction && !arrived) {
            DestroyAnim();
        }

        }
    }
    public void Right_Hand_ThumbUp() {
        Is_Right_ThumbUp = true;
    }
    public void LeftHand_Stone()
    {
        Is_Left_S = true;
        Is_Left_P = false;
    }
    public void RightHand_Stone()
    {
        Is_Right_S = true;
        Is_Right_P = false;
    }
    public void LeftHand_Paper()
    {
        Is_Left_P = true;
        Is_Left_S = false;
    }
    public void RightHand_Paper()
    {
        Is_Right_P = true;
        Is_Right_S = false;
    }
    IEnumerator Acc_Cal()
    {

        var temp = (V2 - V1) / time;
        float a = temp.z;
        //Debug.Log(a);
        StartCoroutine(LerpLength(a));
        yield return null;
    }
    IEnumerator LerpLength(float a)
    {
        if (a < 0)
        {
            a = -a;
        }
        float progress = 0;

        
        while (progress <= 1)
        {
           


            transform.Translate(Vector3.forward * a * Time.deltaTime * speed );
           
            if (arrived)
            {
                inAction = false;
                Invoke("Restart",2.0f);
                break;
            }
           // a -= Time.deltaTime * TimeScale;
            //if (a < 0) {
            //    arrived = true;
            //    break;
            //}
            yield return null;
           
        }


        yield return null;

    }

    void Restart() {
       
        Step1 = false;
        Step2 = false;
        Step3 = false;
        inAction = false;
        arrived = false;
        count = 0;
        Count_text.SetActive(false);
        vfx.SetActive(false);
        //StartCoroutine(DestroyAnim());
        this.transform.rotation = Quaternion.Euler(0,0,0);
        this.transform.position = Original_pos;
        foreach (Task tt in t) {
            tt.Change_pos();
        }
    }

    void DestroyAnim() {

        GameObject[] All_blocks;
        All_blocks = GameObject.FindGameObjectsWithTag("Bricks");
        if (All_blocks.Length != 0) {
            foreach (GameObject a in All_blocks)
            {
                a.transform.Translate(new Vector3(0,-5,0) * Time.deltaTime);
            }
            for (int i = 0; i < All_blocks.Length; i++)
            {
                Destroy(All_blocks[i], 2.0f);

            }

        }


    }
}
