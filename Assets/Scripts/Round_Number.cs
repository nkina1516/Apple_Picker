using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round_Number : MonoBehaviour
{
    [Header("Dynamic")]
    public int round = 1;

    private Text stuff;
    // Start is called before the first frame update
    void Start()
    {
        stuff = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        stuff.text = round.ToString("#,0");
    }
}
