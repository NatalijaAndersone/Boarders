using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : Interactable
{
    private bool doorOpen;
    [SerializeField]
    private GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
        Debug.Log("Interacted with " + gameObject.name);
    }
}
