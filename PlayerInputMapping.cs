using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#region Key Press Type Enum
public enum KeyPressType
{
    Continuous,
    Single
}
#endregion

#region Player Actions
public enum PlayerAction
{
    // Movement
    Forward,
    Backwards,
    StrafeLeft,
    StrafeRight,
    // etc...

    // Actions
    Jump,
    Crouch,
    Sprint,
    Interact,
    // etc..
}
#endregion Player Actions

#region Input Mapping
public static class PlayerInputMapping
{
    private static string filePath = Path.Combine(Application.persistentDataPath, "KeyBindings.json");

    // Dictionary to hold the key bindings along with their press type
    public static Dictionary<PlayerAction, (KeyCode key, KeyPressType pressType)> keyBindings = new Dictionary<PlayerAction, (KeyCode, KeyPressType)>();

    public static List<SerializableKeyBinding> GetSerializableKeyBindings()
    {
        var bindings = new List<SerializableKeyBinding>();
        foreach (var binding in keyBindings)
        {
            bindings.Add(new SerializableKeyBinding(binding.Key, binding.Value.key, binding.Value.pressType));
        }
        return bindings;
    }

    public static void SaveBindings()
    {
        var bindings = GetSerializableKeyBindings();
        string json = JsonUtility.ToJson(new SerializableListWrapper<SerializableKeyBinding> { list = bindings });

        File.WriteAllText(filePath, json); // Write the json string to a file
    }

    public static void LoadBindings()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("Loading key bindings from " + filePath);
            string json = File.ReadAllText(filePath); // Read the json string from the file
            var bindings = JsonUtility.FromJson<SerializableListWrapper<SerializableKeyBinding>>(json).list;
            keyBindings.Clear();
            foreach (var binding in bindings)
            {
                keyBindings.Add(binding.action, (binding.key, binding.pressType));
            }
        }
        else
        {
            Debug.Log("No key bindings found at " + filePath + ". Loading default key bindings.");
            LoadDefaultKeybindings();
        }
    }

    public static void LoadDefaultKeybindings()
    {
        // load default keybindings
        keyBindings.Add(PlayerAction.Forward, (KeyCode.W, KeyPressType.Continuous));
        keyBindings.Add(PlayerAction.StrafeLeft, (KeyCode.A, KeyPressType.Continuous));
        keyBindings.Add(PlayerAction.Backwards, (KeyCode.S, KeyPressType.Continuous));
        keyBindings.Add(PlayerAction.StrafeRight, (KeyCode.D, KeyPressType.Continuous));
        keyBindings.Add(PlayerAction.Jump, (KeyCode.Space, KeyPressType.Single));
        keyBindings.Add(PlayerAction.Crouch, (KeyCode.LeftControl, KeyPressType.Continuous));
        keyBindings.Add(PlayerAction.Sprint, (KeyCode.LeftShift, KeyPressType.Continuous));
        keyBindings.Add(PlayerAction.Interact, (KeyCode.E, KeyPressType.Single));
        // Add other default bindings here...
        SaveBindings();
        LoadBindings();
    }
}
#endregion Input Mapping

#region Helper Classes
[System.Serializable]
public class SerializableKeyBinding
{
    public PlayerAction action;
    public KeyCode key;
    public KeyPressType pressType;

    public SerializableKeyBinding(PlayerAction action, KeyCode key, KeyPressType pressType)
    {
        this.action = action;
        this.key = key;
        this.pressType = pressType;
    }
}

[System.Serializable]
public class SerializableListWrapper<T>
{
    public List<T> list;
}
#endregion Helper Classes
