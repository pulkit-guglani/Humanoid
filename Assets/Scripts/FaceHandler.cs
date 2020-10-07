using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceHandler : MonoBehaviour
{
    private const int LeftEyebrow = 3;
    private const int RightEyebrow = 2;
    SkinnedMeshRenderer skinnedMeshRenderer;
    private bool isEyebrowDown;
    private bool eyebrowIsMoving;
    private bool isEyebrowUp;

    // Start is called before the first frame update
    void Start()
    {
        isEyebrowDown = true;
        isEyebrowUp = false;
        eyebrowIsMoving = false;
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        StartCoroutine(CheckLipMovement());
       // GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(LeftEyeBrow,)
    }

    private IEnumerator CheckLipMovement()
    {
       while(true)
        {
           float weight = skinnedMeshRenderer.GetBlendShapeWeight(0);
            if(weight > 20 && isEyebrowDown && !eyebrowIsMoving)
            {
                StartCoroutine(MoveEyebrowUp());
            }
            else if(weight < 2 && isEyebrowUp && !eyebrowIsMoving)
            {
                StartCoroutine(MoveEyebrowDown());

            }
            yield return new WaitForSeconds(0.1f);

        }
    }

    // Update is called once per frame


    IEnumerator MoveEyebrowDown()
    {
        eyebrowIsMoving = true;
        int i = 0;
        while(true)
        {
            i += 20;
            if(i > 100)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(RightEyebrow, 100);
                skinnedMeshRenderer.SetBlendShapeWeight(LeftEyebrow, 100);
                break;
            }
            skinnedMeshRenderer.SetBlendShapeWeight(RightEyebrow, i);
            skinnedMeshRenderer.SetBlendShapeWeight(LeftEyebrow, i);
            yield return null;
        }
        eyebrowIsMoving = false;
        isEyebrowUp = false;
        isEyebrowDown = true;
        yield return null;
    }
    IEnumerator MoveEyebrowUp()
    {
        eyebrowIsMoving = true;
        int i = 100;
        while (true)
        {
            i -= 20;
            if (i < 0)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(RightEyebrow, 0);
                skinnedMeshRenderer.SetBlendShapeWeight(LeftEyebrow, 0);
                break;
            }
            skinnedMeshRenderer.SetBlendShapeWeight(RightEyebrow, i);
            skinnedMeshRenderer.SetBlendShapeWeight(LeftEyebrow, i);

            yield return null;
        }
        eyebrowIsMoving = false;
        isEyebrowUp = true;
        isEyebrowDown = false;
        yield return null;
    }

}
