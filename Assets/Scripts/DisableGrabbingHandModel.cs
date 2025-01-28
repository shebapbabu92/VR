using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    private void Start()
    {
        // Ensure the XRGrabInteractable component is present and attach listeners.
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(HideGrabbingHand);
            grabInteractable.selectExited.AddListener(ShowGrabbingHand);
        }
        else
        {
            Debug.LogError("XRGrabInteractable component is missing on this object.");
        }
    }

    private void HideGrabbingHand(SelectEnterEventArgs args)
    {
        // Cast the interactorObject to XRBaseInteractor
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            if (interactor.CompareTag("Left Hand"))
            {
                leftHandModel.SetActive(false);
            }
            else if (interactor.CompareTag("Right Hand"))
            {
                rightHandModel.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("Interactor is not of type XRBaseInteractor.");
        }
    }

    private void ShowGrabbingHand(SelectExitEventArgs args)
    {
        // Cast the interactorObject to XRBaseInteractor
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            if (interactor.CompareTag("Left Hand"))
            {
                leftHandModel.SetActive(true);
            }
            else if (interactor.CompareTag("Right Hand"))
            {
                rightHandModel.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Interactor is not of type XRBaseInteractor.");
        }
    }
}
