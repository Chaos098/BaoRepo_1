using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public float firespeed;
    public GameObject dustShootEffect;
    private GameObject dustShoot;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * firespeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            Destroy(gameObject);
            dustShoot = Instantiate(dustShootEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(dustShoot, 1f);
        }

        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.SendMessageUpwards("OnDamaged");
        }
    }
}
