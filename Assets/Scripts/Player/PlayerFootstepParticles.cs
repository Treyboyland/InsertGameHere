using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepParticles : MonoBehaviour
{
    [SerializeField]
    PlayerSpriteController spriteController;

    [SerializeField]
    ParticleSystem footstepParticle;

    [SerializeField]
    DirectionSO up, down, left, right;

    // Update is called once per frame
    void Update()
    {
        SetRotation();
    }

    void SetRotation()
    {
        var particleMain = footstepParticle.main;
        switch (spriteController.GetDirection())
        {
            case PlayerSpriteController.UP:
                particleMain.startRotation = Mathf.Deg2Rad * up.RotationFromNorth;
                break;
            case PlayerSpriteController.DOWN:
                particleMain.startRotation = Mathf.Deg2Rad * down.RotationFromNorth;
                break;
            case PlayerSpriteController.LEFT:
                particleMain.startRotation = -Mathf.Deg2Rad * left.RotationFromNorth;
                break;
            case PlayerSpriteController.RIGHT:
                particleMain.startRotation = -Mathf.Deg2Rad * right.RotationFromNorth;
                break;
        }
    }
}
