using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    // Start is called before the first frame update
    public Object flower;
    public Object clouds1;
    public Object clouds2;
    public Object clouds3;
    private float _movementSpeed = 15;
    private float _spawnY = -10.19f;
    private Object[] _entities;
    private float _spawnTime = 1f;
    private Quaternion _q = new Quaternion(0, 0, 0, 0);
    private float _spawnX, _spawnZ;
    private Vector3 _spawnEnt;
    void Start()
    {
        _spawnEnt = new Vector3(_spawnX, _spawnY, _spawnZ);
        InvokeRepeating("_spawn", 0, _spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        _entities = GameObject.FindGameObjectsWithTag("Entity");
        foreach(GameObject obj in _entities)
             {
                     obj.transform.position =new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - _movementSpeed * Time.deltaTime);
                     if(obj.transform.position.z < -7){
                        Destroy(obj);
                        return;
                    }
             }
             
    }
    private void _spawn(){
        _spawnFlowers();
        _spawnClouds();
    }
    private void _spawnFlowers(){
        _spawnX = Random.Range(-9.2f, 15.67f);
        _spawnZ = Random.Range(39.6f , 45f);
        _spawnY = -9.22f;
        _spawnEnt = new Vector3(_spawnX, _spawnY, _spawnZ);
        Instantiate(flower, _spawnEnt, _q);
    }
    private void _spawnClouds(){
        _spawnX = Random.Range(-29f, -55f);
        _spawnZ = Random.Range(139f , 170f);
        _spawnY = Random.Range(-12f , 13f);
        _spawnEnt = new Vector3(_spawnX, _spawnY, _spawnZ);
        Instantiate(clouds1, _spawnEnt, _q);
        Instantiate(clouds2, _spawnEnt, _q);
        Instantiate(clouds3, _spawnEnt, _q);
    }

}
