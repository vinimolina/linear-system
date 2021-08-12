using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformacaoLinear : MonoBehaviour
{
    public Slider rotateSliderX;
    public Slider rotateSliderY;
    public Slider scaleSliderX;
    public Slider scaleSliderY;
    public Toggle reflectionToggleX;
    public Toggle reflectionToggleY;
    public Transform pikachuTransform;
    public Transform pointPikachu;
    public Text scaleTextX;
    public Text scaleTextY;
    public Text rotateTextX;
    public Text rotateTextY;

    float xPosAux = 0f;
    float yPos = 1f;
    float xPos = 1f;
    void Update() {
        
        Rotate();
        Scale();

        scaleTextX.text = "X : " + scaleSliderX.value;
        scaleTextY.text = "Y : " + scaleSliderY.value;

        rotateTextX.text = "X : " + rotateSliderX.value;
        rotateTextY.text = "Y : " + rotateSliderY.value;
    }
     
    private void Rotate()
    {
        //pikachuTransform.transform.rotation = Quaternion.Euler(rotateSliderX.value, rotateSliderY.value, 0);
        //return;

        float xPos = pikachuTransform.transform.rotation.eulerAngles.x;
        float yPos = pikachuTransform.transform.rotation.eulerAngles.y;

        if (rotateSliderX.value != pikachuTransform.transform.rotation.eulerAngles.x)
        {
            xPos = Mathf.Abs(Mathf.Cos(rotateSliderX.value * Mathf.Deg2Rad) - Mathf.Sin(rotateSliderX.value * Mathf.Deg2Rad) + rotateSliderX.value);
        }
        if (rotateSliderY.value != pikachuTransform.transform.rotation.eulerAngles.y)
        {
            yPos = Mathf.Abs(Mathf.Sin(rotateSliderY.value * Mathf.Deg2Rad) + Mathf.Cos(rotateSliderY.value * Mathf.Deg2Rad) + rotateSliderY.value);
        }

        pikachuTransform.transform.rotation = Quaternion.Euler(xPos, yPos, 0);
    }

    private void Scale() {
        float vX = 1;
        float vY = 1;

        if (reflectionToggleX.isOn)
        {
            vY = -1;
        }
        if (reflectionToggleY.isOn)
        {
            vX = -1;
        }


        if (scaleSliderX.value != 0 && scaleSliderY.value != 0 )
        {
            pikachuTransform.transform.localScale = new Vector2(((1 * scaleSliderX.value)*vX), ((1 * scaleSliderY.value)*vY));          
        }
    }


}