using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;

    private Vector3 target;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        target = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // moves the player to the mouse position
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            rig.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if touches circle you win
        if (collision.gameObject.CompareTag("Circle"))
        {
            GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>().text = "YOU WIN!";

            Destroy(this.gameObject); // destroy the player
        }

        // if touches goblin you lose
        if (collision.gameObject.CompareTag("Goblin"))
        {
            GameObject.Find("Feedback").GetComponent<TextMeshProUGUI>().text = "YOU LOSE!";

            Destroy(this.gameObject); // destroy the player
        }
    }
}
