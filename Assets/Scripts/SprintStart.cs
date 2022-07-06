using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintStart : MonoBehaviour
{
    private BoxCollider2D box;
    public GameObject SprintInstruction;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Sprint Trigger");
        SprintInstruction.SetActive(true);
    }
}
