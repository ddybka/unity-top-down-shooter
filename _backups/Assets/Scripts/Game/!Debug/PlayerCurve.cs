using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurve curveX;
    [SerializeField] private AnimationCurve curveY;

    private void Update()
    {
        Keyframe keyframeX = new Keyframe(Time.time, transform.position.x, 0, 0, 0, 0);
        Keyframe keyframeY = new Keyframe(Time.time, transform.position.y, 0, 0, 0, 0);

        curveX.AddKey(keyframeX);
        curveY.AddKey(keyframeY);
    }
}
