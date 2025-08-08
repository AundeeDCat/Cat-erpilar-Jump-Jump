//using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Trigger_Managert : MonoBehaviour
{
    public bool isPlayerFeet;
    public bool isPlayerHead;
    public bool isTrap;
    public bool isExecutables;
    public bool isCheckpoint;
    
    public bool isGoalpoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        // This code is for the Player Checkboxes, they check for what part of the player has touched 
        // the trigger/collider and what kind of trigger/collider did it touch

        if (other.tag == "Platform" && isPlayerFeet) Player_Controls.isOnFloor = true;
        if (other.tag == "Platform" && isPlayerHead)
        {
            Player_Controls.isTouchCeiling = true;
            other.GetComponent<Window_Controller>().isInWindow = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform" && isPlayerHead)
        {
            other.GetComponent<Window_Controller>().isInWindow = false;
            Player_Controls.isTouchCeiling = false;
        }    
    }
}
