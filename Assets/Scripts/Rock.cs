using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Interactable
{
    PlayerMotor motor;
    [SerializeField] GameObject player;
    [SerializeField] GameObject targetObject;
    [SerializeField] Vector3 teleportOffset;

    // Start is called before the first frame update
    void Start()
    {
        motor = player.GetComponent<PlayerMotor>();
    }


    protected override void Interact()
    {
        StartCoroutine(Teleport()); // Start the coroutine
        Debug.Log("Interacted with " + gameObject.name);
    }

    IEnumerator Teleport()
    {
        motor.disabled = true;
        yield return new WaitForSeconds(0.1f);
        Vector3 targetPosition = targetObject.transform.position + teleportOffset;
        player.transform.position = targetPosition;
        yield return new WaitForSeconds(0.1f);
        motor.disabled = false;
        
    }
}
