using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroySelfTime;
    [SerializeField] private float impact;

    private Vector3 forward;
    private float destroySelfTimer;


    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        destroySelfTimer = destroySelfTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroySelfTimer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            destroySelfTimer -= Time.deltaTime;
        }
        transform.Translate(forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(forward * impact);
            Vector3 torque;
            torque.x = Random.Range(-200, 200);
            torque.y = Random.Range(-200, 200);
            torque.z = Random.Range(-200, 200);

            col.collider.gameObject.GetComponent<Rigidbody>().AddTorque(torque);
            col.collider.SendMessage("Die");
        }
        Destroy(gameObject);

    }
}
