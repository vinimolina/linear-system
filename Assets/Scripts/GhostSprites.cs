using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostSprites : MonoBehaviour
{
    Image m_SpriteImage;
    public float m_RotationLimit = 1.0f;
    public float m_Speed = 1.0f;
    public float m_TransparenseSpeed = 1.0f;
    private float m_RotationTime = 0.0f;
    public float angularSpeed = 1f;
    public float circleRad = 1f;
    private Vector2 fixedPoint;
    private float currentAngle;
    private void Start()
    {
        m_SpriteImage = GetComponent<Image>();
        fixedPoint = transform.position;
    }
    private void Update()
    {        
        if (m_RotationTime == 0.0f)
            StartCoroutine("PendulumTimer");

        transform.Rotate(0.0f, 0.0f, Time.deltaTime * m_Speed);

        currentAngle += angularSpeed * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
        transform.position = fixedPoint + offset;

    }

    private IEnumerator PendulumTimer()
    {
        do
        {
            m_RotationTime += Time.deltaTime;
            yield return null;
        } while (m_RotationTime < m_RotationLimit);
        m_Speed = -m_Speed;
        m_RotationTime = 0.0f;
    }


}
