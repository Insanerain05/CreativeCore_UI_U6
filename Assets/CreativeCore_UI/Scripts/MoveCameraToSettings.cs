using System.Collections;
using UnityEngine;

public class MoveCameraToSettings : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(-16.7f, 8.3f, 17f); 
    public Vector3 targetRotation = new Vector3(0f, -30f, 0f);
    public float moveDuration = 1.0f;

    private bool isMoving = false;
    private bool isMenuOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveCameraToSettings_()
    {
        if (!isMoving && !isMenuOpen)
            StartCoroutine(MoveCamera());
    }

    IEnumerator MoveCamera()
    {
        isMoving = true;
        isMenuOpen = true;

        Transform cam = Camera.main.transform;
        Vector3 startPos = cam.position;
        Quaternion startRot = cam.rotation;

        Quaternion targetQuat = Quaternion.Euler(targetRotation);

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            float t = elapsed / moveDuration;
            cam.position = Vector3.Lerp(startPos, targetPosition, t);
            cam.rotation = Quaternion.Slerp(startRot, targetQuat, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        //cam.position = targetPosition;
        //cam.rotation = targetQuat;

        while(isMenuOpen) //bad decision :(
        {
            cam.position = targetPosition;
            cam.rotation = targetQuat;
            yield return null;
        }
        isMoving = false;
    }
    public void OnMenuClosed()
    {
        isMenuOpen = false;
    }
}
