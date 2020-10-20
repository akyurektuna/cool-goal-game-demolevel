using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    private static int score;
    Rigidbody rb;
    public Text txt;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
        if(SceneManager.GetActiveScene().buildIndex == 1)
            score = 0;
        txt.text = txt.text +score;
    }

    // Update is called once per frame
    void Update(){

    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "kale"){
            updateScore();
            if(SceneManager.GetActiveScene().buildIndex<3)
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene (0);
        }
        
        //eger engele carptiysa ve hızı 0 olduysa scene tekrar calistir
        if(collision.gameObject.tag=="obstacle"){
            Debug.Log("engele carpti");
            if(rb.velocity.y==0){
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
            }
        }
    
    }
    private void updateScore(){
        score = score + 10;
        txt.text = txt.text +score;
    }
}
