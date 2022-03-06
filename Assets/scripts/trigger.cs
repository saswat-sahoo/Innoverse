using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject popup;
    [SerializeField]
    private GameObject player;
   

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player)
        {
            popup.SetActive(true);
            player.gameObject.GetComponent<playeController>().lockplayer(true);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == player)
        {
            popup.SetActive(false);
            player.gameObject.GetComponent<playeController>().lockplayer(false);
        }
    }
}
