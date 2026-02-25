using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 視点回転
// アタッチ対象: OVRInput Rotaterオブジェクト
public class OVRInputRotaterVR : MonoBehaviour
{
    // スティック感度
    private float _stickSensitivity;
    // Transform
    private Transform _cameraRigTransform;


    private void Start()
    {
        GameObject cameraRig = GameObject.FindWithTag(Tags.Get(TagID.CameraRig));
        if (cameraRig == null) Debug.LogError($"{Tags.Get(TagID.CameraRig)}が見つかりませんでした");

        _cameraRigTransform = cameraRig.transform;

    }


    private void Update()
    {
        // 右スティックで視点回転
        Rotate();
    }


    private void Rotate()
    {
        // 右手のアナログスティックの向きを取得
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        float angleX = stickR.x;
        // CameraRigの角度変更
        _cameraRigTransform.Rotate(0, angleX, 0);

    }

}
