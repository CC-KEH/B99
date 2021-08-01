using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateGameObject : MonoBehaviour
{
    public float timer = 2f;
    void Start()
    {
        Invoke("deactivateAfterTime", timer);
    }

    // Update is called once per frame
    void deactivateAfterTime()
    {
        gameObject.SetActive(false);
    }
}
