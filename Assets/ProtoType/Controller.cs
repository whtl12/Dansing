using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Transform[] Hand_2;
    public RectTransform[] Hand_2_Node;

    public Camera Main_Camera;
    public Canvas MainCanvas;
    RectTransform CanvasRect;

    // Use this for initialization
    void Start () {
         CanvasRect = MainCanvas.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {

        
        for(int i =0; i < Hand_2.Length; i++)
        {
            Vector2 ViewportPosition = Main_Camera.WorldToViewportPoint(Hand_2[i].transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

            //now you can set the position of the ui element
            Hand_2_Node[i].anchoredPosition = WorldObject_ScreenPosition;
        }
       
      

    }
}
