using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);
    [SerializeField] private Vector3 offset2 = new Vector3(0, 3.3f, 1.8f);
    private float spaceInput;
    private float lastInput;
    private Vector3 currentOffset;
    // Start is called before the first frame update
    void Start()
    {
        lastInput = 0;
        spaceInput = 0;
        currentOffset = offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        spaceInput = Input.GetAxis("Jump" + player.name);

        if (spaceInput != lastInput)
        {
            lastInput = spaceInput;
            if (spaceInput != 0)
            {
                if (currentOffset == offset)
                    currentOffset = offset2;
                else
                    currentOffset = offset;
            }
        }

        transform.position = player.transform.position + currentOffset;
    }
}
