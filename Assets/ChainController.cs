using UnityEngine;

public class ChainController : MonoBehaviour
{
    [SerializeField] private Transform chainShackle1;
    [SerializeField] private Transform chainShackle2;
    [SerializeField] private Transform chainMagnet1;
    [SerializeField] private Transform chainMagnet2;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        chainShackle1.position = chainMagnet1.position;
        
    }
}
