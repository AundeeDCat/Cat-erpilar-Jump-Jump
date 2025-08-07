using Unity.VisualScripting;
using UnityEngine;

public class Window_Controller : MonoBehaviour
{
    public bool isInWindow;
    public GameObject appWindow;
    bool isOpen;
    BoxCollider2D windowCollider;

    void Start()
    {
        windowCollider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walkthrough();
    }

    void Walkthrough()
    {
        if (isInWindow) windowCollider.isTrigger = true;
        else windowCollider.isTrigger = false;
    }

    public void Toggle()
    {
        if (isOpen) Close();
        else Expand();
    }

    void Expand()
    {
        this.gameObject.SetActive(true);
        isOpen = true;
    }

    void Close()
    {
        this.gameObject.SetActive(false);
        isOpen = false;
    }
}
