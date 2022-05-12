using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshbyCode : MonoBehaviour
{
    //public float ValueX = 1;
    //public float ValueY = 1;
    //public float ValueZ = 1;
    //[SerializeField]
    //private Vector3 vertLeftTopFront = new Vector3(-1, 1, 1);
    //[SerializeField]
    //private Vector3 vertRightTopFront = new Vector3(1, 1, 1);
    //[SerializeField]
    //private Vector3 vertLeftTopBack = new Vector3(-1, 1, -1);
    //[SerializeField]
    //private Vector3 vertRightTopBack = new Vector3(1, 1, -1);
    //[SerializeField]
    //private Vector3 vertLeftBottomFront = new Vector3(-1, -1, 1);
    //[SerializeField]
    //private Vector3 vertLeftBottomBack = new Vector3(-1, -1, -1);
    //[SerializeField]
    //private Vector3 vertRightBottomFront = new Vector3(1, -1, 1);
    //[SerializeField]
    //private Vector3 vertRightBottomBack = new Vector3(1, -1, -1);
  
    //public Vector3 vertLeftTopFront = new Vector3(-1, 1, 1);
    //public Vector3 vertRightTopFront = new Vector3(1, 1, 1);
    //public Vector3 vertLeftTopBack = new Vector3(-1, 1, -1);
    //public Vector3 vertRightTopBack = new Vector3(1, 1, -1);
    //public Vector3 vertLeftBottomFront = new Vector3(-1, -1, 1);
    //public Vector3 vertLeftBottomBack = new Vector3(-1, -1, -1);
    //public Vector3 vertRightBottomFront = new Vector3(1, -1, 1);
    //public Vector3 vertRightBottomBack = new Vector3(1, -1, -1);

    public GameObject vertLeftTopFront;
    public GameObject vertRightTopFront;
    public GameObject vertLeftTopBack;
    public GameObject vertRightTopBack ;
    public GameObject vertLeftBottomFront;
    public GameObject vertLeftBottomBack;
    public GameObject vertRightBottomFront;
    public GameObject vertRightBottomBack;

    private float waitN = 3f;
    public float scale = 0.5f;
    bool switch_t = false;
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;
        

        Vector3[] vertices = new Vector3[]
        {
            //front face
            vertLeftTopFront.transform.localPosition,   //left top front, 0
            vertRightTopFront.transform.localPosition,    //right top front, 1
            vertLeftBottomFront.transform.localPosition,  //left bottom front, 2 
            vertRightBottomFront.transform.localPosition,   //right bottom front, 3

            //back face
            vertRightTopBack.transform.localPosition,   //right top back, 4
            vertLeftTopBack.transform.localPosition,  //left top back, 5
            vertRightBottomBack.transform.localPosition,  //right bottom back, 6 
            vertLeftBottomBack.transform.localPosition, //left bottom back, 7

            //left face
            vertLeftTopBack.transform.localPosition,   //left top back, 8
            vertLeftTopFront.transform.localPosition,  //left top front, 9
            vertLeftBottomBack.transform.localPosition,  //left bottom back, 10 
            vertLeftBottomFront.transform.localPosition, //left bottom front, 11


            //right face
            vertRightTopFront.transform.localPosition,   //right top front, 12
            vertRightTopBack.transform.localPosition,  //right top back, 13
            vertRightBottomFront.transform.localPosition,  //right bottom front, 14 
            vertRightBottomBack.transform.localPosition, //right bottom back, 15

            //top face
            vertLeftTopBack.transform.localPosition, //left top back, 16
            vertRightTopBack.transform.localPosition,  //right top back, 17
            vertLeftTopFront.transform.localPosition,  //left top front, 18
            vertRightTopFront.transform.localPosition,   //right top front, 19

            //bottom face
            vertLeftBottomFront.transform.localPosition,   //left bottom front, 20
            vertRightBottomFront.transform.localPosition,  //right bottom front, 21
            vertLeftBottomBack.transform.localPosition, //left bottom back, 22
            vertRightBottomBack.transform.localPosition,  //right bottom back, 23 
            


        };
        //Triangles // 3 points, clockwise determines which side is invisible
        int[] triangles = new int[] 
        { 
            //front face
            0,2,3,//first triangle
            3,1,0,//second triangle

            //back face
            4,6,7,//first triangle
            7,5,4, //second triangle

            //left face
            8,10,11,//first triangle
            11,9,8, //second triangle

            //right face
            12,14,15,//first triangle
            15,13,12, //second triangle

            //top face
            16,18,19,//first triangle
            19,17,16, //second triangle

            //bottom face
            20,22,23,//first triangle
            23,21,20 //second triangle

        };
        //UVs
        Vector2[] uvs = new Vector2[]
        {
            //front face //0,0 is bottom left 1,1 is front left
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();

       // this.transform.position = (vertRightBottomFront.transform.position + vertLeftTopBack.transform.position) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.J)) {
        //    MeshEdgeTimes_X();
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    MeshEdgeTimes_Y();
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    MeshEdgeTimes_Z();
        //}


        //if (true) {
        //    vertLeftTopFront.z += 0.1f;
        //    vertRightTopFront.z += 0.1f;
        //    vertLeftBottomFront.z += 0.1f;
        //    vertRightBottomFront.z += 0.1f;
        //}
        var tmp = vertRightTopFront.transform.localPosition;
        if (switch_t)
        {
            tmp.x += 0.02f;
            if (tmp.x > 1.0f) { switch_t = !switch_t; }
        }
        else {
            tmp.x -= 0.02f;
            if (tmp.x < -0.2f) { switch_t = !switch_t; }
        }
       
        vertRightTopFront.transform.localPosition = tmp;
       
        Start();
        
    }

    //void MeshEdgeTimes_X() {
    //    vertLeftTopFront.x *= ValueX;
    //    vertRightTopFront.x *= ValueX;
    //    vertLeftTopBack.x *= ValueX;
    //    vertRightTopBack.x *= ValueX;
    //    vertLeftBottomFront.x *= ValueX;
    //    vertLeftBottomBack.x *= ValueX;
    //    vertRightBottomFront.x *= ValueX;
    //    vertRightBottomBack.x *= ValueX;

    //}
    //void MeshEdgeTimes_Y()
    //{
    //    vertLeftTopFront.y *= ValueY;
    //    vertRightTopFront.y *= ValueY;
    //    vertLeftTopBack.y *= ValueY;
    //    vertRightTopBack.y *= ValueY;
    //    vertLeftBottomFront.y *= ValueY;
    //    vertLeftBottomBack.y *= ValueY;
    //    vertRightBottomFront.y *= ValueY;
    //    vertRightBottomBack.y *= ValueY;

    //}
    //void MeshEdgeTimes_Z()
    //{
    //    vertLeftTopFront.z *= ValueZ;
    //    vertRightTopFront.z *= ValueZ;
    //    vertLeftTopBack.z *= ValueZ;
    //    vertRightTopBack.z *= ValueZ;
    //    vertLeftBottomFront.z *= ValueZ;
    //    vertLeftBottomBack.z *= ValueZ;
    //    vertRightBottomFront.z *= ValueZ;
    //    vertRightBottomBack.z *= ValueZ;

    //}
    void ResetMesh() {

    }
}
