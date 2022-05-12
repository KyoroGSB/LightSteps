using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MTI_Manager : MonoBehaviour
{
    public Text hint;
    public string[] T_Array;
    private int count = 0;
    public GameObject[] Objects;
    public Material RGB;
    private float timer =0;
    public GameObject[] world;
    public bool move_w;
    private float w_timer = 0;
    private bool w;
    private Vector3[] pos = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject a in Objects) {
            a.SetActive(false);
        }
        for (int i = 0; i <pos.Length; i++) {
            pos[i] = world[i].transform.position;
        }
        StartCoroutine(FirstPart(count));
        //Objects[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        w_timer += Time.deltaTime;
        if (timer >= 1.5f)//change the float value here to change how long it takes to switch.
        {
            // pick a random color
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            // apply it on current object's material
            RGB.color = newColor;
            timer = 0;
        }
        if (move_w) {
            
                if (!w)
                {
                    Objects[26].transform.Translate(Vector3.back * Time.deltaTime);
                    foreach (GameObject a in world)
                    {
                        a.transform.Translate(Vector3.back * Time.deltaTime);
                    }

                }
                else {
                    Objects[26].transform.Translate(Vector3.forward * Time.deltaTime);
                    foreach (GameObject a in world)
                    {
                        a.transform.Translate(Vector3.forward * Time.deltaTime);
                    }

                }
            if (w_timer >= 2.0f)
            {
                w = !w;
                w_timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.O) || OVRInput.GetDown(OVRInput.Button.One)) {
            foreach (GameObject a in Objects)
            {
                a.SetActive(false);
            }
            if (count <= 4)
            {

                StartCoroutine(FirstPart(count));
            }
            else if (count >= 5 && count < 7)
            {
                StartCoroutine(Second_Stroke(count));
            }
            else if (count >= 7 && count < 9)
            {
                StartCoroutine(Third_Color(count));
            }
            else if (count >= 9 && count < 12)
            {
                StartCoroutine(Forth_Transform(count));
            }
            else if (count >= 12 && count < 18)
            {
                StartCoroutine(Fifth_Manipulate(count));
            }
            else if (count >= 18 && count < 20)
            {
                StartCoroutine(Sixth_Erase(count));
            }
            else if (count >= 20)
            {
                StartCoroutine(Others(count));
            }

        }


        if (Input.GetKeyDown(KeyCode.P)|| OVRInput.GetDown(OVRInput.Button.Two)) {
            foreach (GameObject a in Objects)
            {
                a.SetActive(false);
            }

            count++;
            if (count > 21) {
                count = 0;
               // w = false;
                move_w = false;
                for (int i = 0; i < pos.Length; i++)
                {
                     world[i].transform.position =pos[i] ;
                }
            }

            hint.text = T_Array[count];

            if (count <= 4)
            {

                StartCoroutine(FirstPart(count));
            }
            else if (count >= 5 && count < 7)
            {
                StartCoroutine(Second_Stroke(count));
            }
            else if (count >= 7 && count < 9) {
                StartCoroutine(Third_Color(count));
            }
            else if (count >= 9 && count < 12)
            {
                StartCoroutine(Forth_Transform(count));
            }
            else if (count >= 12 && count < 18)
            {
                StartCoroutine(Fifth_Manipulate(count));
            }
            else if (count >= 18 && count < 20)
            {
                StartCoroutine(Sixth_Erase(count));
            }
            else if (count >= 20)
            {
                StartCoroutine(Others(count));
            }


        }

    }
    

    IEnumerator FirstPart(int a) {
        yield return new WaitForSeconds(1);
        switch (a) {
            case 0:
                Objects[1].SetActive(true);
                yield return new WaitForSeconds(1);
                Objects[1].SetActive(false);
                Objects[0].SetActive(true);
                break;
            case 1:
                Objects[3].SetActive(true);
                yield return new WaitForSeconds(1);
                Objects[3].SetActive(false);
                Objects[2].SetActive(true);
                break;
            case 2:
                Objects[5].SetActive(true);
                yield return new WaitForSeconds(1);
                Objects[5].SetActive(false);
                Objects[4].SetActive(true);
                break;
            case 3:
                Objects[7].SetActive(true);
                yield return new WaitForSeconds(1);
                Objects[7].SetActive(false);
                Objects[6].SetActive(true);
                break;
            case 4:
                Objects[9].SetActive(true);
                yield return new WaitForSeconds(1);
                Objects[9].SetActive(false);
                Objects[8].SetActive(true);
                break;
        }

        yield return null;
    }

    IEnumerator Second_Stroke(int a) {
        yield return new WaitForSeconds(1);
        if (a == 5) {
            Objects[10].SetActive(true);
            Objects[11].SetActive(true);

        }
        if (a == 6)
        {
            Objects[10].SetActive(true);
            Objects[12].SetActive(true);

        }

        yield return null;
    }

    IEnumerator Third_Color(int a) {
        yield return new WaitForSeconds(1);
        Objects[13].SetActive(true);

        yield return null;
    }
    IEnumerator Forth_Transform(int a)
    {
        yield return new WaitForSeconds(1);
        if (a == 9) {
            Objects[14].SetActive(true);
        }
        if (a == 10)
        {
            Objects[15].SetActive(true);
        }
        if (a == 11)
        {
            Objects[16].SetActive(true);
        }
       

        yield return null;
    }
    IEnumerator Fifth_Manipulate(int a)
    {
        yield return new WaitForSeconds(1);
        if (a == 12) {
            Objects[17].SetActive(true);
        }
        if (a == 13)
        {
            Objects[18].SetActive(true);
            yield return new WaitForSeconds(1);
            var tmp = Objects[18].transform.localScale;
            tmp.x *= -1;
            Objects[18].transform.localScale = tmp;
        }
        if (a == 14)
        {
            Objects[19].SetActive(true);

        }
        if (a == 15)
        {
            Objects[20].SetActive(true);
        }
        if (a == 16)
        {
            Objects[21].SetActive(true);
        }
        if (a == 17)
        {
            Objects[22].SetActive(true);
        }

        yield return null;
    }
    IEnumerator Sixth_Erase(int a)
    {
        yield return new WaitForSeconds(1);
        if (a == 18)
        {
            Objects[23].SetActive(true);
        }
        if (a == 19)
        {
            Objects[24].SetActive(true);
        }

        yield return null;
    }
    IEnumerator Others(int a)
    {
        yield return new WaitForSeconds(1);
        if (a == 20)
        {
            Objects[25].SetActive(true);
        }
        if (a == 21)
        {
            Objects[26].SetActive(true);
            move_w = true;
        }

        yield return null;
    }

}
