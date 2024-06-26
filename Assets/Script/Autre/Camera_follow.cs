using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float Offset = -1f;

    private void Awake()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + Offset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}