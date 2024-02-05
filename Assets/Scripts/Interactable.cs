using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Note: This interface is to interact in a 3D Environment.


interface IInteractable
{
    public void Interact()
    {
        Debug.Log("interact");

    }
}

public class Interactable : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Ray r =new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                    
                }
            }
        }
    }
    
}
