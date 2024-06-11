using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArabaHareket : MonoBehaviour
{
    bool oyunbitti = false;
    public int puan = 0;
    // Start is called before the first frame update
    void Start()
    {
        puan = 0;
    }

    // Update is called once per frame
   private void Update() 
    {
        if (oyunbitti == false)
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 20);
        else if (oyunbitti == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;


        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(40, 0, 0, ForceMode.Force);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(-40, 0, 0, ForceMode.Force);
        }

        if ((GetComponent<Rigidbody>().position.z >= 20 ) || (GetComponent<Rigidbody>().position.x < -9) || (GetComponent<Rigidbody>().position.x > 9))
        {
            oyunbitti = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("Restart", 3f);


        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            Invoke("Restart", 3f);
            oyunbitti = true;

        }
        if (collision.collider.tag == "Coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunbitti = false;
    }
}

