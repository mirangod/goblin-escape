using UnityEngine;
using TMPro;

public class Administrator : MonoBehaviour
{
    public GameObject player; // the prefab's player
    
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>().text = "";

                // create a player's prefab at (0,0,0) position
                Instantiate(player, transform.position, Quaternion.identity);
            }
        }
    }
}
