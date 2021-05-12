using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;


public class Dragon : MonoBehaviour
{
    public static event Action OnSnakeDied;

    public event Action<int> OnSnakeGrowed, OnSnakeReduced;
    GameObject BonePrefab;


    public List<DragonBone> bones = new List<DragonBone>();
    public int defaultBoneCount;

    public IntValue bonesCount;
    public IntValue currentGrowthBonus;

    private int lastGrowthBonus = 0;
    public int growthBonusToUpgradeBody = 10;




    public void Init()
    {
        BonePrefab = GameAssets.instance.bonePrefab;
        CreateDragon();
        SetSortingLayers();
    }



    private void CreateDragon()
    {
        // Reference Head
        bones.Add(GetComponent<DragonHead>());
        DragonHeadCollision dragonHeadCollision = transform.GetComponent<DragonHeadCollision>();
        dragonHeadCollision.OnBoneCollided += IncreaseGrowthBonus;

        // Instantiate the fisrt Body
        Transform objectToAdd = CreateBodyPart(BonePrefab, (Vector2)transform.position - new Vector2(0, 2f), Quaternion.identity).transform;
        bones.Add(objectToAdd.GetComponent<DragonBone>());
        objectToAdd.GetComponent<DragonBoneCollision>().OnBoneCollided += DecreaseGrowthBonus;

        // Instantiate the rest of the tail
        int boneCountTemp = bones.Count;
        for (int i = 0; i < defaultBoneCount - boneCountTemp; i++)
        {
            AddBone();
        }


        currentGrowthBonus.value = 0;
        //FindObjectOfType<UIOroFillImage>().Init();
    }
    private void SetSortingLayers()
    {
        for (int i = 0; i < bones.Count; i++)
        {
            bones[i].GetComponent<SpriteRenderer>().sortingOrder = bones.Count - i;
        }
    }
    public void CutTail(int cutedBodyNumber)
    {
        int totalBodypartCount = bones.Count;
        int numberOfBoneToDelete = totalBodypartCount - cutedBodyNumber;

        List<DragonBone> bonesToDelete = new List<DragonBone>();

        for (int i = 0; i < numberOfBoneToDelete; i++)
        {
            bonesToDelete.Add(bones[totalBodypartCount - 1 - i]);
        }

        if (bonesToDelete.Count != 0)
        {
            DeleteMultipleBodyParts(bonesToDelete);
        }
    }


    private void DeleteMultipleBodyParts(List<DragonBone> bodiesToDelete)
    {
        for (int i = 0; i < bodiesToDelete.Count; i++)
        {
            bodiesToDelete[i].GetComponent<Collider2D>().enabled = false;

            currentGrowthBonus.value -= 10;
            lastGrowthBonus = currentGrowthBonus.value;
            DeleteLastBone();

        }
    }

    private void DeleteLastBone()
    {
        if (bones.Count > 5)
        {
            DragonBone boneToDelete = bones[bones.Count - 1];
            boneToDelete.Die();
            RemoveLastBone();
        }

        else
            OnSnakeDied?.Invoke();
    }

    private void RemoveLastBone()
    {
        bones.RemoveAt(bones.Count - 1);
        SetSortingLayers();
        OnSnakeReduced?.Invoke(bones.Count);
        bonesCount.value = bones.Count;
    }

    void IncreaseGrowthBonus()
    {
        int ammountToAdd = 0;
        while (currentGrowthBonus.value > lastGrowthBonus)
        {
            lastGrowthBonus++;
            if (lastGrowthBonus % 10 == 0)
            {
                ammountToAdd++;
            }
        }

        for (int i = 0; i < ammountToAdd; i++)
        {
            AddBone();
        }
    }
    void DecreaseGrowthBonus()
    {
        int ammountToDelete = 0;
        while (lastGrowthBonus > currentGrowthBonus.value)
        {
            lastGrowthBonus--;
            if (lastGrowthBonus % 10 == 0)
            {
                ammountToDelete++;
            }
        }

        for (int i = 0; i < ammountToDelete; i++)
        {
            DeleteBodyPart();
        }

    }
    public void AddBone()
    {
        Vector3 direction = bones[bones.Count - 2].transform.position - bones[bones.Count - 1].transform.position;
        Vector3 spawnPos = bones[bones.Count - 1].transform.position - direction;

        DragonBone newBone = CreateBodyPart(BonePrefab, spawnPos, bones[bones.Count - 1].transform.rotation).GetComponent<DragonBone>();
        newBone.GetComponent<DragonBoneCollision>().OnBoneCollided += DecreaseGrowthBonus;
        bones.Add(newBone);
        newBone.gameObject.name = "Body " + (bones.Count - 1);

        SetSortingLayers();

        OnSnakeGrowed?.Invoke(bones.Count);

        bonesCount.value = bones.Count;

    }
    public void DeleteBodyPart()
    {
        if (bones.Count > 5)
        {
            DragonBone bodyPartToDelete = bones[bones.Count - 1];

            bones.RemoveAt(bones.Count - 1);

            //bodyPartToDelete.GetComponent<dragonBoneToLoot>().isDisolving = true;
            Destroy(bodyPartToDelete.gameObject);

            SetSortingLayers();

            OnSnakeReduced?.Invoke(bones.Count);

            bonesCount.value = bones.Count;
        }

        else
            OnSnakeDied?.Invoke();
    }

    public GameObject CreateBodyPart(GameObject pBodyPartPrefab, Vector2 pPosition, Quaternion pRotation)
    {
        GameObject newBody = Instantiate(pBodyPartPrefab, pPosition, pRotation);
        return newBody;
    }

    private void OnApplicationQuit()
    {
        currentGrowthBonus.value = 0;
        bonesCount.value = 0;
    }

}
