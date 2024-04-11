using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    [SerializeField]
    GameConfig defaultConfig;

    GameConfig configuration;

    public GameConfig CurrentConfiguration => configuration;

    static ConfigManager _instance;

    public static ConfigManager Manager { get { return _instance; } }

    string configPath;

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        configPath = Application.streamingAssetsPath + "/Config.xml";

        _instance = this;
        DontDestroyOnLoad(gameObject);
        ReadConfig();
        //configuration.Save(configPath);
    }

    void ReadConfig()
    {

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameConfig));
            using (TextReader reader = new StreamReader(configPath))
            {
                configuration = (GameConfig)serializer.Deserialize(reader);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("ERROR: Unable to read config from path \"" + configPath + "\"\r\n " + e + "\r\n Defaulting to default config.");
            configuration = defaultConfig;
        }

    }
}
