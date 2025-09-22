using UnityEngine;
using UnityEngine.InputSystem;

public class WaterDial : MonoBehaviour
{
    [Range(0, 240)]
    public byte DialGauge = 0;

    public float increaseRate = 50f;
    public float decreaseRate = 100f;

    private float currentGauge = 0f;

    // 1 to 4 NOT 1-6 since first and last position are too easy 
    private int targetRange;
    private float holdTimer = 0f;

    private float[] rangeMins = { 40f, 80f, 120f, 160f };
    private float[] rangeMaxs = { 80f, 120f, 160f, 200f };

    public GameObject[] objectsToEnable;
    public GameObject ArrowMarker;

    private InputAction pressAction;

    void Awake()
    {
        pressAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        pressAction.AddBinding("<Gamepad>/rightTrigger");
        pressAction.Enable(); 
    }

    void Start()
    {
        targetRange = Random.Range(1, 5);

        if (objectsToEnable != null && objectsToEnable.Length >= 4)
        {
            objectsToEnable[targetRange - 1].SetActive(true);
        }

        Debug.Log("Target range: " + targetRange + $" ({rangeMins[targetRange - 1]} - {rangeMaxs[targetRange - 1]})");
    }

    void Update()
    {
        bool isPressing = pressAction.ReadValue<float>() > 0.5f;

        // Gauge fill logic
        if (Mouse.current != null && Mouse.current.position.ReadValue().x > Screen.width / 2)
        {
            if (isPressing)
                currentGauge += increaseRate * Time.deltaTime;
            else
                currentGauge -= decreaseRate * Time.deltaTime;
        }
        else
        {
            currentGauge -= decreaseRate * Time.deltaTime;
        }

        currentGauge = Mathf.Clamp(currentGauge, 0f, 240f);
        DialGauge = (byte)currentGauge;

        // Handle gauge range hold detection

        float min = rangeMins[targetRange - 1];
        float max = rangeMaxs[targetRange - 1];

        if (currentGauge >= min && currentGauge <= max)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= 2f)
            {
                Debug.Log("YAY");
                holdTimer = -999f; // Prevent retriggering
            }
        }
        else
        {
            holdTimer = 0f;
        }

        if (ArrowMarker != null)
        {
            float angle = Mathf.Lerp(90f, -90f, currentGauge / 240f);
            ArrowMarker.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

    }

    void OnDisable()
    {
        pressAction?.Disable();
    }
}
