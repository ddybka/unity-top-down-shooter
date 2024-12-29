using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float dumping = 3.6f;

    private void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);

        transform.position = currentPosition;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
