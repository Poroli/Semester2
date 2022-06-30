using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonsActivate : MonoBehaviour
{
    public Buy Buy_Script;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hallalulia");
            Buy_Script.gameObject.SetActive(true);

        }
        
    }
    private void OnTriggerExit2D(Collider2D other)

    {
        if (other.gameObject.tag == "Player")
        { 
          Buy_Script.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        Buy_Script = FindObjectOfType<Buy>();
        Buy_Script.gameObject.SetActive(false);
    }
}
