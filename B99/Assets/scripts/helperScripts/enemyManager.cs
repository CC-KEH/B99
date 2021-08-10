using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static enemyManager instance;
    [SerializeField] private GameObject enemyPrefab;
    void Awake()
    {
        if(instance==null)
        instance=this;
    }

    void Start(){
        SpawnEnemy();
    }

    public void SpawnEnemy(){
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
    void Update()
    {
        
    }
}
