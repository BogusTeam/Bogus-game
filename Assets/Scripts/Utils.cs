﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Utils
{
    public static string SaveName => "gamesave.save";

    private static List<GameObject> GetAllObjectsInScene()
    {
        var objectsInScene = new List<GameObject>();
        foreach (var go in (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (go.hideFlags is HideFlags.NotEditable or HideFlags.HideAndDontSave)
                continue;
            // if (!EditorUtility.IsPersistent(go.transform.root.gameObject))
            // continue;
            objectsInScene.Add(go);
        }

        return objectsInScene;
    }

    [CanBeNull]
    public static Stats GetStatsScript()
    {
        foreach (var obj in GetAllObjectsInScene())
            if (obj.GetComponent<Stats>() != null)
                return obj.GetComponent<Stats>();

        return null;
    }

    [CanBeNull]
    public static PauseMenu GetPausedScript()
    {
        foreach (var obj in GetAllObjectsInScene())
            if (obj.GetComponent<PauseMenu>() != null)
                return obj.GetComponent<PauseMenu>();

        return null;
    }

    [CanBeNull]
    public static GameObject GetPlayerObject()
    {
        foreach (var obj in GetAllObjectsInScene())
            if (obj.GetComponent<Player>() != null)
                return obj;

        return null;
    }

    public static List<GameObject> GetObjectsWithScriptEntity()
    {
        var list = new List<GameObject>();
        foreach (var obj in GetAllObjectsInScene())
            if (obj.GetComponent<Entity>() != null)
                list.Add(obj);

        return list;
    }

    public static Save CreateSaveGameObject(List<GameObject> targets)
    {
        var save = new Save();
        foreach (var targetGameObject in targets)
        {
            var entity = targetGameObject.GetComponent<Entity>();
            if (entity.type == TargetTypes.Trigger)
                continue;
            var camPos = targetGameObject.GetComponent<CameraMovement>() != null
                ? targetGameObject.GetComponent<CameraMovement>().currentCameraPos
                : 0;
            save.TargetsList[targetGameObject.name] = new Target
            {
                targetPosition = new VectorS(targetGameObject.transform.position),
                targetRotation = new QuaternionS(targetGameObject.transform.rotation),
                targetType = entity.type,
                healthPoints = entity.healthPoints,
                attackRating = entity.attackRating,
                armorRating = entity.armorRating,
                cameraPosition = camPos
            };
        }

        var script = GetStatsScript();
        if (script != null)
        {
            save.moneyCount = script.Money;
            save.locationName = script.locationName;
        }

        return save;
    }

    public static void LoadSavedGame()
    {
        var bf = new BinaryFormatter();
        var file = File.Open(Application.persistentDataPath + $"/{SaveName}", FileMode.Open);
        var save = (Save)bf.Deserialize(file);
        file.Close();
        foreach (var obj in GetObjectsWithScriptEntity())
        {
            var script = obj.GetComponent<Entity>();
            if (script.type == TargetTypes.Trigger)
                continue;
            var selectedTarget = save.TargetsList[obj.name];
            script.type = selectedTarget.targetType;
            script.armorRating = selectedTarget.armorRating;
            script.attackRating = selectedTarget.attackRating;
            script.healthPoints = selectedTarget.healthPoints;
            obj.transform.position = selectedTarget.targetPosition.GetVector3();
            obj.transform.rotation = selectedTarget.targetRotation.GetQuaternion();
            script.cameraPos = selectedTarget.cameraPosition;
        }

        // Money and location...
        var statsScript = GetStatsScript();
        if (statsScript != null)
        {
            statsScript.Money = save.moneyCount;
            statsScript.locationName = save.locationName;
        }

        Debug.Log("Game Loaded");
    }

    public static void ChangeHeroHp(int hp)
    {
        var playerObj = GetPlayerObject();
        if (playerObj != null)
            playerObj.GetComponent<Entity>().healthPoints = hp;

        var statsScript = GetStatsScript();
        if (statsScript != null)
        {
            statsScript.heroHp.GetComponent<Text>().text = $"Хп героя: {hp}";
        }
    }
}