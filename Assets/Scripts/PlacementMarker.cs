﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlacementMarker : MonoBehaviour
{
    private FindPlane PlaneFinder;
    [SerializeField] PlaceObjects placeObject;
    private void Awake()
    {
        PlaneFinder = FindObjectOfType<FindPlane>();
    }
    // Start is called before the first frame update
    void Start()
    {
        DisableObject();

        PlaneFinder.OnValidPlaneData += UpdateTransform;
        PlaneFinder.OnValidPlaneDataNotFound += DisableObject;
    }

    private void UpdateTransform(PlaneData Plane)
    {
        if (!placeObject.isPlaced)
        {
            gameObject.SetActive(true);
            transform.SetPositionAndRotation(Plane.Position, Plane.Rotation);
        }
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (placeObject.isPlaced)
        {
            DisableObject();
        }
        else if (!placeObject.isPlaced)
        {
            PlaneFinder.OnValidPlaneData += UpdateTransform;
            PlaneFinder.OnValidPlaneDataNotFound += DisableObject;
        }

    }

    private void OnDestroy()
    {
        PlaneFinder.OnValidPlaneData -= UpdateTransform;
        PlaneFinder.OnValidPlaneDataNotFound -= DisableObject;
    }
}