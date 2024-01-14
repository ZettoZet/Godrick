using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            
            //ScoreScript.baseScore += 10;
            Destroy(collision.gameObject);
            ScoreScript.instance.AddScore();

        }
        else
        {
            
        Destroy(gameObject);
        }
    }
}
