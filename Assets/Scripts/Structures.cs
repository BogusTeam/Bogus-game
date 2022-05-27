using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    public int moneyCount;
    public Dictionary<string, Target> TargetsList = new();
    public LocationNames locationName = LocationNames.StartingLocation;
}

[Serializable]
public class Target
{
    public VectorS targetPosition;
    public QuaternionS targetRotation;
    public TargetTypes targetType;
    public int healthPoints;
    public int armorRating;
    public int attackRating;
    public int cameraPosition;
}

[Serializable]
public class VectorS
{
    public float x;
    public float y;
    public float z;

    public VectorS(Vector3 vector3)
    {
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3
        {
            x = x,
            y = y,
            z = z
        };
    }
}

[Serializable]
public class QuaternionS
{
    public float w;
    public float x;
    public float y;
    public float z;

    public QuaternionS(Quaternion quaternion)
    {
        w = quaternion.w;
        x = quaternion.x;
        y = quaternion.y;
        z = quaternion.z;
    }

    public Quaternion GetQuaternion()
    {
        return new Quaternion
        {
            w = w,
            x = x,
            y = y,
            z = z
        };
    }
}

[Serializable]
public class DialogList
{
    public List<Dialog> dialogs;
}

[Serializable]
public class Dialog
{
    public int id;
    public string author;
    public string authorDialog;
    public List<Choice> choices;
    public bool chooseKassit;
}

[Serializable]
public class Choice
{
    public string choice;
    public int nextIdWithoutKassit = -1;
    public int nextIdWithKassit = -1;
    public bool isKassitWithUs;
    public int money;
    public bool quitGame;
}