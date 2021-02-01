using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject columnobj;
    public float movementSpeed = 15;
    public GameObject playerObj;
    private Vector3 _spawnPos;
    private GameObject[] columnsObjList;
    private float _spawnDistance = 30f;
    private float _spawnTime = 2f;
    public GameObject coinObj;
    void Start()
    {
        
        Transform playerTransf = playerObj.GetComponent<Rigidbody>().transform;
        _spawnPos = new Vector3(playerTransf.position.x, playerTransf.position.y, playerTransf.position.z + _spawnDistance);
        InvokeRepeating ("spawnColumn", 0, _spawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        moveColumns();
        // columnsObjList = GameObject.FindGameObjectsWithTag("Column");
        // Debug.Log(columnsObjList[1].transform.position.y);
    }

    void spawnColumn(){
        float size = columnobj.GetComponent<Renderer>().bounds.size.y;
        
        float spawnPosY = Random.Range(-5f, 5f);
        float gap = 5f;
        Instantiate(coinObj, new Vector3(0, spawnPosY + gap / 2,_spawnPos.z), new Quaternion(0, 0, 0, 0));
        coinObj.GetComponent<Animator>().Rebind();
        Instantiate(columnobj, new Vector3(_spawnPos.x, spawnPosY - size ,_spawnPos.z), Quaternion.identity);
        Instantiate(columnobj, new Vector3(_spawnPos.x, spawnPosY + gap ,_spawnPos.z), Quaternion.identity);
    }

    void moveColumns(){
        columnsObjList = GameObject.FindGameObjectsWithTag("Column");
        foreach(GameObject obj in columnsObjList)
             {
                     obj.transform.position =new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - movementSpeed * Time.deltaTime);
                     if(obj.transform.position.z < -25){
                        Destroy(obj);
                        return;
                    }
             }
        columnsObjList = GameObject.FindGameObjectsWithTag("Coin");
        foreach(GameObject obj in columnsObjList)
             {
                     obj.transform.position =new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - movementSpeed * Time.deltaTime);
                     if(obj.transform.position.z < -25){
                        Destroy(obj);
                        return;
                    }
             }
    }

}
