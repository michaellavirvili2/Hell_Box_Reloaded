using System;
using Unity.VisualScripting;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    [SerializeField] private Rigidbody chainShackle1;
    [SerializeField] private Rigidbody chainShackle2;
    [SerializeField] private Transform chainMagnet1;
    [SerializeField] private Transform chainMagnet2;
    
    [SerializeField] private GameManager gameManager;
    private FixedJoint _jointshackle1Joint;
    private FixedJoint _jointshackle2Joint;

    private void Awake()
    {
        chainShackle1.position = chainMagnet1.position;
        chainShackle2.position = chainMagnet2.position;
    }

    void Start()
    {
        _jointshackle1Joint = gameObject.AddComponent<FixedJoint>();
        _jointshackle2Joint = gameObject.AddComponent<FixedJoint>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.chainsSolved = true;
            chainShackle1.isKinematic = false;
            chainShackle2.isKinematic = false;
            Destroy(_jointshackle1Joint);
            Destroy(_jointshackle2Joint);
            
        }
        
    }
}
