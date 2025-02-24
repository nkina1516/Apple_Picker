using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int         numBaskets     = 4;
    public float       basketBottomY  = -14f;
    public float       basketSpacingY = 2f;
    public List<GameObject> basketList;
    public Round_Number roundNumber;
   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        basketList = new List<GameObject>(); 

        for (int i=0; i <numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO );
        }

        GameObject scoreGO = GameObject.Find( "Round_Number" );
        roundNumber = scoreGO.GetComponent<Round_Number>();


    }

    public void AppleMissed() {                                                
        // Destroy all of the falling Apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");      
        foreach ( GameObject tempGO in appleArray ) {
            Destroy( tempGO );
        }

        // Destroy one of the Baskets                                    
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count -1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];

        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt( basketIndex );
        Destroy( basketGO );

        roundNumber.round += 1;

        // If there are no Baskets left, restart the game 
        if ( basketList.Count == 0 ) {
             SceneManager.LoadScene( "Game_Over" );                       
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
