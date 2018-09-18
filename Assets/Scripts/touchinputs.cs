using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchinputs : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{


    private Vector3 inputVector;
    private Image BGimg;

    private void Start()
    {
        BGimg = GetComponent<Image>();
        //Thumbimg = transform.GetChild(0).GetComponent<RawImage>();
    }

    // Use this for initialization
    public void OnPointerDown(PointerEventData PED)
    {
        OnDrag(PED);
        //Debug.Log("OnpointerDown");
    }

    public void OnPointerUp(PointerEventData PED)
    {
        inputVector = Vector3.zero;
        //Debug.Log("onpointerUP");
    }

    public void OnDrag(PointerEventData PED)
    {
        Vector2 Pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BGimg.rectTransform, PED.position, PED.pressEventCamera, out Pos))
        {
            //Debug.Log("ONDRAG");
            //Debug.Log("clicked on joystick");
            Pos.x = (Pos.x / BGimg.rectTransform.sizeDelta.x);
            Pos.y = (Pos.y / BGimg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(Pos.x * 2f, 0, Pos.y * 2f);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            Debug.Log(inputVector);
            //Thumbimg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (BGIMG.rectTransform.sizeDelta.x / 2), inputVector.z * (BGIMG.rectTransform.sizeDelta.y / 2));
        }
    }
}
