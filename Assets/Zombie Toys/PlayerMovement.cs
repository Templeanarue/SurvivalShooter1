using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float raycastDistance = 1f;
    public LayerMask raycastMask;

    Rigidbody rb;

    Vector3 input;
    Camera cachedCamera;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
       cachedCamera = Camera.main;
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        input.x = h;
        input.z = v;

        Ray ray = cachedCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, raycastDistance, raycastMask))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.LookAt(hit.point);
        }
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
    }

    private void FixedUpdate()
    {
        Vector3 velocity = input.normalized * speed;
        rb.velocity = velocity;
    }

}
