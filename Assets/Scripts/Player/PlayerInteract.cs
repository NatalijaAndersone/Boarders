using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Camera cam;

    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;

    private InputManager inputManager;

    [SerializeField]
    private Transform objectGrabPointTransform;

    private ObjectGrabbable objectGrabbable;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //Cast a ray to interact with objects
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                //Update on screen text
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    if (objectGrabbable == null)
                    {
                        if (hitInfo.transform.TryGetComponent(out objectGrabbable))
                        {
                            objectGrabbable.Grab(objectGrabPointTransform);
                            Debug.Log("It is grabbed");
                            
                        } 
                    }
                    else
                    {
                        objectGrabbable.Drop();
                        objectGrabbable = null;
                    }

                    interactable.BaseInteract();
                }


            }
        }


    }
}
