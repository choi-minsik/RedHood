using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility_obj_player : MonoBehaviour
{
    private CapsuleCollider bounder;

    private List<Transform> listPrevObstacleObject = new List<Transform>();
    public List<Transform> piece_listPrevObstacleObject = new List<Transform>();
    private List<Transform> reset_Objects = new List<Transform>();
    private List<Transform> set_Objects = new List<Transform>();
    private Dictionary<Transform, Shader> shader_case = new Dictionary<Transform, Shader>();

    public Camera camera;

    public float size_ray;

    private void Awake()
    {
        bounder = GetComponent<CapsuleCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            listRay[i] = new Ray();
            point_vec[i] = new Vector3();
        }
    }

    // Update is called once per frame
    Vector3 piece_vec = new Vector3(0, 0, 0);
    //List<Ray> listRay = new List<Ray>();

    Ray[] listRay= new Ray[5];
   public Vector3[] point_vec = new Vector3[5];


    float[] length_Ray = new float[5];
    Ray piece_Ray;
    void Update()
    {
        point_vec[0] = transform.TransformPoint(bounder.center);
        piece_vec.Set(bounder.radius - size_ray, 0, 0);
        point_vec[1] = transform.TransformPoint(bounder.center) - piece_vec;
        piece_vec.Set(bounder.radius - size_ray, 0, 0);
        point_vec[2] = transform.TransformPoint(bounder.center) + piece_vec;
        piece_vec.Set(0, (bounder.height / 2.0f) - size_ray, 0);
        point_vec[3] = transform.TransformPoint(bounder.center) + piece_vec;
        piece_vec.Set(0, (bounder.height / 2.0f) - size_ray, 0);
        point_vec[4] = transform.TransformPoint(bounder.center) - piece_vec;
        

        for(int i=0; i<5;i++)
        {

            listRay[i].direction = (point_vec[i] - camera.transform.position).normalized;
            listRay[i].origin = camera.transform.position;
            length_Ray[i] = Vector3.Distance(point_vec[i], camera.transform.position)-1f;
        }

        for(int i=0; i<5;i++)
        {
            Ray ray = listRay[i];
            RaycastHit[] hitInfo = Physics.RaycastAll(ray, length_Ray[i]);
            foreach (RaycastHit data in hitInfo)
            {
                bool tf = false;
                foreach (Transform data_tr in listPrevObstacleObject)
                {
                    if (data_tr == data.transform)
                        tf = true;
                }
                if (tf == false)
                {
                    if(data.transform.tag != "Player")
                        listPrevObstacleObject.Add(data.transform);
                   
                }
            }
            Debug.DrawRay(ray.origin, ray.direction* length_Ray[i], Color.red);
        }
        //----------------------------------------------------------------------------------------------------



        foreach (Transform piece_data_tr in piece_listPrevObstacleObject)
        {
            bool bo = false;
            foreach (Transform data_tr in listPrevObstacleObject)
            {
                if (piece_data_tr == data_tr)
                    bo = true;
            }
            if (bo == false)
                Reset_objectMaterialShader(piece_data_tr);
        }
        foreach (Transform data_tr in listPrevObstacleObject)
        {
            bool bo = false;
            foreach (Transform piece_data_tr in piece_listPrevObstacleObject)
            {
                if (data_tr == piece_data_tr) 
                    bo = true;
            }
            if (bo == false)
                Set_objectMaterialShader(data_tr);
        }

        piece_listPrevObstacleObject.Clear();
        piece_listPrevObstacleObject.AddRange(listPrevObstacleObject);
        listPrevObstacleObject.Clear();
        

    }

    void Reset_objectMaterialShader(Transform data)
    {
        if (data.tag != "Collider_wall")
        {
            MeshRenderer meshRenderer = data.GetComponent<MeshRenderer>();
            meshRenderer.material.shader = shader_case[data];
            shader_case.Remove(data);
        }
    }
    void Set_objectMaterialShader(Transform data)
    {
        if (data.tag != "Collider_wall")
        {
            MeshRenderer meshRenderer = data.GetComponent<MeshRenderer>();
            if (!shader_case.ContainsKey(data))
            {
                shader_case.Add(data, meshRenderer.material.shader);
            }
            meshRenderer.material.shader = Shader.Find("Transparent/Diffuse");
            meshRenderer.material.color = new Color(1, 1, 1, 0.5f);
        }
      
    }

}
