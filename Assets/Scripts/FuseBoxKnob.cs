using UnityEngine;

public class FuseBoxKnob : MonoBehaviour
{
  [SerializeField] private bool isEnabled = true;
  [SerializeField] private Transform knobTransform;
  
  [SerializeField] private Vector3 enablePosition;
  [SerializeField] private Vector3 disablePosition;
  [SerializeField] private Vector3 enableRotation;
  [SerializeField] private Vector3 disableRotation;

  public void ToggleStatus()
  {
    SetStatus(!isEnabled);
  }
  void Start()
  {
      SetStatus(isEnabled);
  }
    // access modifier (private/protected/public) -- return type (void/bool/etc) -- Name(parameters)
    public void SetStatus(bool status) {
      isEnabled = status;
      //                           ifThisIsTrue ? returnThis : ifFalseReturnThis
      knobTransform.localPosition = isEnabled ? enablePosition : disablePosition;
      knobTransform.localEulerAngles = isEnabled ? enableRotation : disableRotation;
    }
  }


