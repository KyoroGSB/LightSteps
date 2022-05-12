using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGB : MonoBehaviour
{
    [SerializeField]
    float lerpTime;
    [SerializeField]
    Color background;


    float t = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        background = new Color(
            Random.Range(0f, 0.4f),
            Random.Range(0.7f, 1f),
            Random.Range(0f, 0.4f),
            1f
        );


        this.GetComponent<RawImage>().color = Color.Lerp(this.GetComponent<RawImage>().color , background, lerpTime*Time.deltaTime);

       
            

    }
}

