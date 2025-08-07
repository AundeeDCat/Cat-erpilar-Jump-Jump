using UnityEngine;
using System.Collections.Generic;


public class Checkpoint_Manager : MonoBehaviour
{

    public static Vector3 curr_checkpoint;

    void Start()
    {
        curr_checkpoint = this.transform.position;
    }
}
