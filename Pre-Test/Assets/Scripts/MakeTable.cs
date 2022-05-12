using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;


public class MakeTable : MonoBehaviour
{

    public GameObject Left_Hand;
    public GameObject Right_Hand;
    private Vector3 V1;
    private Vector3 V2;
    private float time;
    private float T1;
    private float T2;
    [SerializeField]
    private bool Is_Left_S = false;
    [SerializeField]
    private bool Is_Left_P = false;
    [SerializeField]
    private bool Is_Right_S = false;
    [SerializeField]
    private bool Is_Right_P = false;

    //
    // public GameObject[] CornerSpot;
    //public GameObject cylinder;
    public GameObject table;
    public Transform tablespot;
    private GameObject table_new = null;
    private Vector3 lastFrame_P;
   
    public  bool Step1 = false;
    public  bool Step2 = false;
    public bool Step3 = false;
    private bool inAction = false;
    void Start() {
        

        
    }
    // Update is called once per frame
    void Update()
    {
       
       
        if (Is_Left_S && Is_Right_S && !Step1 && !Step2 && !Step3) {
            StartAndSpawn();
            Step1 = true;
            Step3 = true;
        }
        if (Is_Left_P && Is_Right_P && Step1 && !Step2 )
        {
            ExtrudeOut();
            Step2 = true;
        }
        if (Is_Left_S && Is_Right_S && Step1 && Step2)
        {
            StopExtrude();
            Step1 = false;
            Step2 = false;
        }
        if (inAction)
        {
            time = Time.deltaTime;

            Vector3 lastFrame_L = Left_Hand.GetComponent<Transform>().localPosition;
            Vector3 lastFrame_R = Right_Hand.GetComponent<Transform>().localPosition;
            lastFrame_P = (lastFrame_L + lastFrame_R) / 2;
            print(lastFrame_P);
        }

    }
    public void LeftHand_Stone() {
        Is_Left_S = true;
        Is_Left_P = false;
    }
    public void RightHand_Stone() {
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
    

    void StartAndSpawn() {
        //Debug.Log("Step1");
        inAction = true;
        StartTable();
        Vector3 V1_L = Left_Hand.GetComponent<Transform>().localPosition;
        Vector3 V1_R = Right_Hand.GetComponent<Transform>().localPosition; 
        V1 = (V1_L + V1_R) / 2;
        //Debug.Log(V1);
    }
    void ExtrudeOut()
    {
        //Debug.Log("Step2");
        inAction = false;
        Vector3 V2_L = Left_Hand.GetComponent<Transform>().localPosition;
        Vector3 V2_R = Right_Hand.GetComponent<Transform>().localPosition;
        V2 = (V2_L + V2_R) / 2;
        
        StartCoroutine(Acc_Cal());
    }
    void StopExtrude() {
        inAction = false;
        ScaleTest st = table_new.GetComponent<ScaleTest>();
        st.stop = true;
    }
    IEnumerator Acc_Cal() {
      
        var temp = (V2 - lastFrame_P) / time;
        float a = temp.z;
        print(V2 +"||"+ a);

        //print("V1" + V1);
        //print("V2" + V2);
        //print("T1" + T1);
        //print("T2" + T2);
        ScaleTest st = table_new.GetComponent<ScaleTest>();
        st.setTable(a);
        time = 0f;

        Invoke("destroy",4.5f);
       
        yield return  null;
    }
    void destroy() {
        var tmp = table_new;
        table_new = null;
        Destroy(tmp);
        Step3 = false;

    }
    void StartTable() {
        GameObject a = Instantiate(table,tablespot.position,Quaternion.Euler(0,tablespot.rotation.eulerAngles.y,0),null);
        //ScaleTest st = a.GetComponent<ScaleTest>();
        table_new = a;
    }
    
}
