using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class JoyStickController : MonoBehaviour
{
    public IsometricPlayerMovementController playerController;

    public TMP_Text directionText;
    private Vector2 touchStartPosition;

    public Transform touchBall;

    public Vector3 defaultPosition;

    public Vector3 _touchedPosition;
    public Vector3 thisTransformPos;

    bool isDrag = false;

    // DEBUGGING
    [Header("DEBUG")]
    public Vector3 _mousePos;
    public Vector2 _dragdir;
    public float _mag;
    
    public void Awake()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Input.mousePosition;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchedPosition = touch.position;
            _touchedPosition = touch.position;

            if (touch.phase == TouchPhase.Ended)
            {
                transform.position = defaultPosition;
                touchBall.position = defaultPosition;
                playerController.isMoving = false;
                isDrag = false;
            }

            if ((0 <= touchedPosition.x && touchedPosition.x <= Screen.width / 2) && (0 <= touchedPosition.y && touchedPosition.y <= Screen.height / 2))
            {

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPosition = touch.position;
                    transform.position = touch.position;
                    playerController.isMoving = true;
                    isDrag = true;
                }

                else if (isDrag && touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Vector2 dragDirection = Vector2.ClampMagnitude(touch.position - touchStartPosition, 100); // 100 is radius of circle
                    touchBall.position = touchStartPosition + dragDirection;
                    playerController.movementInput = dragDirection / 100;
                    _dragdir = dragDirection;
                    _mag = dragDirection.magnitude;
                }
            }
        }
    }
}
