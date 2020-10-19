using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){

    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "kale"){
            Debug.Log("The player has collided with the wall!");
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        //eger engele carptiysa ve hızı 0 olduysa scene tekrar calistir
        if(collision.gameObject.tag=="obstacle"){
            Debug.Log("engele carpti");
            if(rb.velocity.y==0){
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
            }
        }
    
    }
}
