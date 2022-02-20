using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private InputActionReference menuActionReference;
    public RectTransform rt;
    public InputField x;
    public InputField y;
    public GameObject cameraObj;
    public Camera camera;
    public Image image;

    void Start()
    {
        menuActionReference.action.performed += onMenu;
        rt = image.GetComponent<RectTransform>();
        cameraObj = camera.gameObject;
    }

    public void onMenu(InputAction.CallbackContext obj)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, cameraObj.transform.rotation.y * 125f, transform.rotation.z);
        transform.position = cameraObj.transform.forward;
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void clickBlue(GameObject obj)
    {
        if (obj.CompareTag("Screen")) image.color = new Color32(0, 71, 187, 255);

        if (obj.CompareTag("MainCamera")) camera.backgroundColor = new Color32(0, 71, 187, 255);
    }

    public void clickGreen(GameObject obj)
    {
        if (obj.CompareTag("Screen")) image.color = new Color32(0, 177, 64, 255);

        if (obj.CompareTag("MainCamera")) camera.backgroundColor = new Color32(0, 177, 64, 255);
    }

    public void onEdit()
    {
        rt.sizeDelta = new Vector2(int.Parse(x.text), int.Parse(y.text));
    }

    
}
