using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reseter : MonoBehaviour
{

    public Button resetText;

    Vector3 startPos;
    Quaternion startRot;

    void Start()
    {
        resetText = resetText.GetComponent<Button>();

        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void ResetMenu()
    {
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
