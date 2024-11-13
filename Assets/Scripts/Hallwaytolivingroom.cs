using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this door will take the player to the living room


public class Hallwaytolivingroom : MonoBehaviour
    
    
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    { if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Livingroom");
        }
    }
}

