using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetFloorMaterialOnStart : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Switch value;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        if(player)
        {
            player.SpriteController.FootstepMaterial = value;
        }
    }
}
