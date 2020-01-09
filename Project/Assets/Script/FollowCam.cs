using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Range(0,10)]
    public float speed = 3;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player1").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        tar.y = Mathf.Clamp(tar.y, 0, 4.9f);
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
    }
}
