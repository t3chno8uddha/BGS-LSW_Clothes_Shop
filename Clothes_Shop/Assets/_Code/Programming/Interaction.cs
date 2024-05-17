using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    bool isInReach = false;

    public UnityEvent interactionEvent;

    void Update()
    {
        if (isInReach)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                interactionEvent.Invoke();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        isInReach = true;
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        isInReach = false;
    }
}
