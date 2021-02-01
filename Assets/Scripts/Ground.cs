using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    public Object prefab;
    public Object cam;
    private Vector3 _spawnCords = new Vector3(1.8f, -10.38f, 63.8f);
    private float _moveSpeed = 15; 
    private GameObject[] _objects;
    int a = 0;
    float s = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _objects = GameObject.FindGameObjectsWithTag("Ground");
        
        if(Mathf.Abs(_objects[_objects.Length - 1].transform.position.z)-36.3688 <= 0.001f)
        {
            a++;
            s+=_objects[_objects.Length - 1].transform.position.z;
            // Debug.Log(a);
            // Debug.Log(s);
            Instantiate(prefab, _spawnCords, new Quaternion(0, 0, 0, 0));
        }
            
       
        // Debug.Log(_objects[_objects.Length - 1].GetComponent<Renderer>().bounds.size[2]);
        foreach(GameObject obj in _objects){
            
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - _moveSpeed * Time.deltaTime);
            if(obj.transform.position.z < -37)
                Destroy(obj);
        }        
   }
}
