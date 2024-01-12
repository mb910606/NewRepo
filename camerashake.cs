using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public Animator camAnim;
    public CameraFollow cameraFollow;

    private void Start()
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    public void shake()
    {
        camAnim.SetTrigger("shake");
        StartCoroutine(ResetCameraPosition());
    }

    private IEnumerator ResetCameraPosition()
    {
        yield return new WaitForSeconds(camAnim.GetCurrentAnimatorClipInfo(0).Length);
    }
}