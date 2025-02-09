using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Inscribed")]                                   
    
    // Prefab for instantiating apples
    public GameObject   applePrefab;

    // Speed at which the AppleTree moves
    public float        speed = 1f;

    // Distance where AppleTree turns around
    public float        leftAndRightEdge = 10f;
    // Chance that the AppleTree will change directions
    public float        changeDirChance = 0.1f;
    // Seconds between Apples instantiations
    public float        appleDropDelay = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start dropping apples                                          
        Invoke( "DropApple", 2f );

    }

    void DropApple() {                                                    
        GameObject apple = Instantiate<GameObject>( applePrefab );        
        apple.transform.position = transform.position;                    
        Invoke( "DropApple", appleDropDelay ); 
                                  
     }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;  

        pos.x += speed * Time.deltaTime;                         
        
        transform.position = pos;

        //Change Directions
        if ( pos.x < -leftAndRightEdge ) {                                        
             speed = Mathf.Abs( speed );   // Move right                           
         } else if ( pos.x > leftAndRightEdge ) {                                  
             speed = -Mathf.Abs( speed );  // Move left                            
         //} else if ( Random.value < changeDirChance ) {                         
           //speed *= -1;  // Change direction                                  
        }
    }

    void FixedUpdate()
    {
        if ( Random.value < changeDirChance ) {                         
           speed *= -1;  // Change direction 
        }
    }

}
