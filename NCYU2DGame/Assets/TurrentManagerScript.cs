using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurrentManagerScript : MonoBehaviour {

    private Animator _animator;

    const int DirectionCount = 8;
    public Ease RotateEaseFunction;
    public float rotateDuration;

    public Camera GameCamera;
    public float CameraShakeDuration;
    public float CameraShakeStrenth;

    // Use this for initialization
    void Start () {
        _animator = this.GetComponent<Animator>();
	}

    private void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
        GameCamera.transform.DOShakePosition(CameraShakeDuration,CameraShakeStrenth);
    }

    private void PlayRotateAnimation()
    {
        float targetDegree = 360.0f / DirectionCount * Random.Range(0, DirectionCount);
        this.transform.DORotate(new Vector3(0, 0, targetDegree), rotateDuration);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayShootAnimation();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayRotateAnimation();
        }
    }
}
