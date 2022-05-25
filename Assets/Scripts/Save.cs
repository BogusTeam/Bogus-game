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
    public Vector targetPosition;
    public Vector targetRotation;
    public TargetTypes targetType;
    public int healthPoints;
    public int armorRating;
    public int attackRating;
}

[Serializable]
public class Vector
{
    public float x;
    public float y;
    public float z;

    public Vector(Vector3 vector3)
    {
        x = vector3.x;
        y = vector3.y;
        z = vector3.z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3()
        {
            x = x,
            y = y,
            z = z
        };
    }
}