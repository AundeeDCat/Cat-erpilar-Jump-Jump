using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger_Manager : MonoBehaviour
{
    public bool isPlayerFeet;
    public bool isPlayerHead;
    public bool isTrap;

    // This code is placed on Player Triggerboxes, they check for what part of the player has touched 
    // the trigger/collider and what kind of trigger/collider did it touch
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform" && isPlayerFeet) Player_Controller.isOnFloor = true;

        if (other.tag == "Goalpoint" && isPlayerFeet)
        {
            Debug.Log("End of Level!"); // Place Transition or Next Scene Here
            Scene_Manager.NextScene();
        }

        if (other.tag == "Platform" && isPlayerHead)
        {
            Player_Controller.isTouchCeiling = true;
            other.GetComponent<Window_Controller>().isInWindow = true;
        }

        if (other.tag == "Switch" && isPlayerHead)
        {
            other.GetComponent<Window_Controller>().appWindow.GetComponent<Window_Controller>().Toggle();
        }



        if (other.tag == "Codecrumb1" && isPlayerHead)
        {
            CodeCrumb_Manager.Level1_Crumbs++;
            Destroy(other.gameObject);
            Debug.Log("Crumb Collected! You have " + CodeCrumb_Manager.Level1_Crumbs + " crumbs!");
        }

        if (other.tag == "Codecrumb2" && isPlayerHead)
        {
            CodeCrumb_Manager.Level2_Crumbs++;
            Destroy(other.gameObject);
            Debug.Log("Crumb Collected! You have " + CodeCrumb_Manager.Level3_Crumbs + " crumbs!");
        }

        if (other.tag == "Codecrumb3" && isPlayerHead)
        {
            CodeCrumb_Manager.Level3_Crumbs++;
            Destroy(other.gameObject);
            Debug.Log("Crumb Collected! You have " + CodeCrumb_Manager.Level2_Crumbs + " crumbs!");
        }



        // This code is for other interactables in the game
        if (other.tag == "Player" && isTrap)
        {
            other.GetComponent<Animator>().SetTrigger("Dies");
            StartCoroutine(RespawnDelay(resDelay, other));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform" && isPlayerHead)
        {
            other.GetComponent<Window_Controller>().isInWindow = false;
            Player_Controller.isTouchCeiling = false;
        }
    }

    float resDelay = 0.5f;
    IEnumerator RespawnDelay(float wait, Collider2D player)
    {
        yield return new WaitForSeconds(wait);
        player.transform.position = Checkpoint_Manager.curr_checkpoint;

        StartCoroutine(Respawn(2f, player));
    }

    IEnumerator Respawn(float wait, Collider2D player)
    {
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(wait);
        
        player.gameObject.SetActive(true);
        player.transform.position = Checkpoint_Manager.curr_checkpoint;
    }
}
