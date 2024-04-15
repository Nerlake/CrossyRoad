using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject _camera;
    private float _lastPosXTriggedCameraMvt;
    private Animator _animator;

    private void Start()
    {
        _camera = GameObject.Find("Main Camera");
        _lastPosXTriggedCameraMvt = transform.localPosition.x;
        _animator = gameObject.GetComponent<Animator>();
        Debug.Log(_animator);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Mathf.Round(transform.localPosition.x) % 3 == 0 &&
                transform.localPosition.x > _lastPosXTriggedCameraMvt)
            {
                Camera cameraScript = _camera.GetComponent<Camera>();
                cameraScript.readyForForwardAnimation = true;
                _lastPosXTriggedCameraMvt = transform.localPosition.x;
            }

            _animator.SetTrigger("Forward");
            // StartCoroutine(WaitUntilAnimation());
            // transform.Translate(Vector3.right * 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // transform.Translate(Vector3.right * -1.0f);
            _animator.SetTrigger("Back");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // transform.Translate(Vector3.forward * -1.0f);
            _animator.SetTrigger("Right");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // transform.Translate(Vector3.forward * 1.0f);
            _animator.SetTrigger("Left");
        }
    }

    private IEnumerator WaitUntilAnimation()
    {
        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f);

        Debug.Log("finit");
        // transform.Translate(Vector3.right * 1.0f);
    }
}