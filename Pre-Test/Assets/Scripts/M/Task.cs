using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public enum BrockType {Obstacle , Goal ,None };
    public BrockType b_type = BrockType.Obstacle;
    ControlBrock cb;
    public AudioSource audi;
    public AudioClip good;
    // Start is called before the first frame update
    void Start()
    {
        cb = FindObjectOfType<ControlBrock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.name == "Spawner") {
            if (this.b_type == BrockType.Obstacle)
            {
                cb.arrived = true;
                
            }
            else if (this.b_type == BrockType.Goal)
            {
                cb.arrived = true;
                audi.PlayOneShot(good);
            }
            else if (this.b_type == BrockType.None)
            {
                cb.arrived = true;
                
            }
           


        }
    }

    public void Change_pos() {
        if (this.b_type == BrockType.Obstacle)
        {
            transform.position = new Vector3(Random.Range(30, -30), 2, Random.Range(4, 55));

        }
        
    }
}
