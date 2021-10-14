using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetspawn : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] targets;
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning(){
        yield return new WaitForSeconds(4);
        for(int i = 0; i<4;i++){
            Instantiate(targets[0],spawnPoint[i].position,Quaternion.identity);
        }
        
    }
}
