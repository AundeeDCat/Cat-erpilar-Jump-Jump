using UnityEngine;

public class Trigger_Interact : MonoBehaviour
{
    public bool isCorruptedFiles;
    public bool isExecutables;
    public bool isFolders;
    public bool isPlayerFeet;
    public bool isPlayerLeft;
    public bool isPlayerRight;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform" && isPlayerFeet) Player_Controls.isOnFloor = true;
        if (other.tag == "Platform" && isPlayerLeft) Player_Controls.isTouchLeft = true;
        if (other.tag == "Platform" && isPlayerRight) Player_Controls.isTouchRight = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform" && isPlayerLeft) Player_Controls.isTouchLeft = false;
        if (other.tag == "Platform" && isPlayerRight) Player_Controls.isTouchRight = false;
    }
}
