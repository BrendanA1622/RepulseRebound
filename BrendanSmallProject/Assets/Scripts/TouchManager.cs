using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TouchManager : MonoBehaviour
{
    // These variables need to be modified or tested in the inspector
    [SerializeField]
    private GameObject explosionPoint;
    [SerializeField]
    private GameObject forcePrefab;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject guidePoint;
    [SerializeField]
    private float guideSpeed;

    // These variables are only of use within this specific class and do not need to be modified beforehand
    private PlayerInput playerInput;
    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private Vector3 currentInputTouch;

    private bool haveTouched;
    private bool firstTouch;
    private bool guidePointRight;


    // Determine that the player has not yet touched the screen at the very beginning
    void Start()
    {
        guidePointRight = true;
        firstTouch = true;
        haveTouched = false;
    }


    void Update()
    {
        // If there is at least one touch being detected we take note of that here
        if (Input.touchCount > 0)
        {
            haveTouched = true;

            Touch touch = Input.GetTouch(0);

            currentInputTouch = touch.position;

            Debug.Log("IN TOUCH METHOD");
        }

        // Once the player touches the screen, the green repulse ball follows their finger on the screen
        if (haveTouched)
        {
            // Take note of the player touching the screen
            firstTouch = false;

            // Use a built in function to translate the coordinates of the player's touch on screen to coordinates in the game
            Vector3 positionCam = Camera.main.ScreenToWorldPoint(currentInputTouch);
            
            // An explosion point is put on the repulse ball so that the falling triangle is repulsed away from it
            explosionPoint.transform.position = new Vector3(positionCam.x, positionCam.y, -1.0f);
        } else
        {
            // The hand that prompts the user to touch the screen moves back and forth
            updateGuidePoint();
        }
        // The hand that prompts the user to touch the screen goes away once they have touched the screen
        if (!firstTouch)
        {
            guidePoint.SetActive(false);
        }
    }

    // Oscilates the guiding hand from left to right until the player touches the screen
    private void updateGuidePoint()
    {
        if (guidePointRight)
        {
            guidePoint.transform.Translate(Time.deltaTime * guideSpeed, 0, 0);
        } else {
            guidePoint.transform.Translate(-Time.deltaTime * guideSpeed, 0, 0);
        }

        if (guidePoint.transform.position.x > 8)
        {
            guidePointRight = false;
        }
        
        if (guidePoint.transform.position.x < 3)
        {
            guidePointRight = true;
        }
    }

    // Receives the screen input information and assigns it to playerInput
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["ForcePress"];
        touchPositionAction = playerInput.actions["ForcePosition"];
    }

    // Handles input information at the start of playing
    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    // Handles input at the very end of playing
    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }
}