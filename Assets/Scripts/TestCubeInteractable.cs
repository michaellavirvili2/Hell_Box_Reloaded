using UnityEngine;

public class TestCubeInteractable :MonoBehaviour, Interactable 
{
    public string GetPrompt()
    {
        return "Press 'E' to Interact";
    }
    public void Interact()
    {
        Debug.Log("Interact with Cube");
    }
}
  