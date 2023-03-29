using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    private Rigidbody rigid;
    private SpawnManager manager;
    private float minforce = 12;
    private float maxforce = 16;
    private float rangetorque = -10;
    private float xrange = 4;
    private float yspawn;

    public int value;
    public ParticleSystem hieu_ung_no;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(random_vector_force(),ForceMode.Impulse);
        rigid.AddTorque(random_vector_torque(),ForceMode.Impulse);
        transform.position = radom_vector_spawn();
        manager = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (gameObject.CompareTag("Bad"))
        {
          
            Destroy(gameObject);
        }
        else
            manager.Gameover();
    }
    private void OnMouseDown()
    {
        if (manager.isGameActive)
        {
            Destroy(gameObject);

            if (gameObject.CompareTag("Bad"))
            {
                manager.Gameover();
            }
            manager.Update_Diem(value);
            Instantiate(hieu_ung_no, transform.position, hieu_ung_no.transform.rotation);
        }
    }
    Vector3 random_vector_force()
    {
        return Vector3.up * Random.Range(minforce, maxforce);
    }
    Vector3 random_vector_torque() 
    {
        return new Vector3(Random.Range(-rangetorque, rangetorque), Random.Range(-rangetorque, rangetorque), Random.Range(-rangetorque, rangetorque));
    }
    Vector3 radom_vector_spawn()
    {
        return new Vector3(Random.Range(-xrange, xrange), yspawn,0);
    }
}
