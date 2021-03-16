﻿using UnityEditor;
using System;
using System.Collections;
using UnityEngine;



public class PlaceObjects : MonoBehaviour
{
    public GameObject[] ObjectToPlace;
    private FindPlane PlaneFinder;
    private PlaneData Plane = null;
    public bool isPlaced = false;

    private void Awake()
    {
        PlaneFinder = FindObjectOfType<FindPlane>();
    }

    private void LateUpdate()
    {
        if (ShouldPlaceObj())
        {
            Instantiate(ObjectToPlace[0], Plane.Position, Plane.Rotation);
            isPlaced = true;
            
        }
    }

    private bool ShouldPlaceObj()
    {

        if (Plane != null && Input.GetMouseButtonDown(0) && !isPlaced)
        {
            return true;
        }

        return false;
    }

    private void OnEnable()
    {
        PlaneFinder.OnValidPlaneData += StorePlaneData;
        PlaneFinder.OnValidPlaneDataNotFound += RemovePlaneData;
    }

    private void RemovePlaneData()
    {
        Plane = null;
    }

    private void OnDestroy()
    {
        PlaneFinder.OnValidPlaneData -= StorePlaneData;
        PlaneFinder.OnValidPlaneDataNotFound -= RemovePlaneData;
    }

    private void StorePlaneData(PlaneData Plane)
    {
        this.Plane = Plane;
    }

    public void RestoreMarker()
    {
        isPlaced = false;
    }
}