using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Contains information on the configuration for the game
/// </summary>
[XmlRootAttribute("GameConfig")]
[Serializable]
public struct GameConfig
{
    /// <summary>
    /// True if cartridges should be wiped on the title screen
    /// </summary>
    [XmlElement("WipeCartridgesOnTitleScreen")]
    [Tooltip("True if cartridges should be wiped on the title screen")]
    public bool WipeCartridgesOnTitleScreen;

    /// <summary>
    /// If true, the player will receive a new cartrige each level. 
    /// False means the player has to play through 16 levels to get them all
    /// </summary>
    [XmlElement("EasyCartridgeAcquiring")]
    [Tooltip("If true, the player will receive a new cartrige each level. False means the player has to play through 16 levels to get them all")]
    public bool EasyCartridgeAcquiring;

    /// <summary>
    /// True if we should prevent exiting from the game
    /// </summary>
    [XmlElement("PreventExiting")]
    [Tooltip("True if the game cannot be exited in-game")]
    public bool PreventExiting;

    [XmlElement("IsArcadeCabinet")]
    [Tooltip("True if this game is going on an arcade cabinet")]
    public bool IsArcadeCabinet;

    [XmlElement("IdleTimeout")]
    [Tooltip("Time in seconds that we should wait on a menu screen before exiting the game, if the IsArcadeCabinet value is true")]
    public float IdleTimeout;

    /// <summary>
    /// Saves this config to the given path
    /// </summary>
    /// <param name="path"></param>
    public void Save(string path)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameConfig));
            using (TextWriter tw = new StreamWriter(path))
            {
                serializer.Serialize(tw, this);
                Debug.LogWarning("Game config saved to \"" + path + "\"");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("ERROR: Unable to save game config to path \"" + path + "\": " + e);
        }
    }
}