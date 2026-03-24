using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private float interactDistance;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private Transform cameraTransform;
     private Interactable currentInteractable;
    public void Update()
    {

        RaycastHit hit;
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward, new Color(0.5f, 0f, 1f));
           Interactable interactable = hit.collider.GetComponent<Interactable>();
           if (interactable != null && currentInteractable != interactable)
           {
               currentInteractable = hit.collider.GetComponent<Interactable>();
               Debug.Log(currentInteractable.GetPrompt());
           }
         
        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward, Color.red);
            currentInteractable = null;
        }

        if (Input.GetKeyDown(KeyCode.E)){
            if (currentInteractable != null) currentInteractable.Interact();

         }
    }
}
 
