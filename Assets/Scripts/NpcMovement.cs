using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public float speed = 5;
    public GameObject car1;
    public GameObject car2;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else
            if (car1.transform.position.z > 150 || car2.transform.position.z > 150) flag = true;
    }
}
