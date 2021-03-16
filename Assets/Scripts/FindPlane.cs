﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;
using System;

public class PlaneData
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
}


public class FindPlane : MonoBehaviour
{
    public UnityAction<PlaneData> OnValidPlaneData;
    public UnityAction OnValidPlaneDataNotFound;

    private ARRaycastManager RaycastManager;
    private readonly Vector3 ViewportCenter = new Vector3(.5f, .5f);


    private void Awake()
    {
        RaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        IList<ARRaycastHit> hits = GetPlaneHits();
        UpdateSubscribers(hits);
    }

    private void UpdateSubscribers(IList<ARRaycastHit> hits)
    {
        bool validPositionFound = hits.Count > 0;
        if (validPositionFound)
        {
            PlaneData Plane = new PlaneData
            {
                Position = hits[0].pose.position,
                Rotation = hits[0].pose.rotation
            };

            OnValidPlaneData?.Invoke(Plane);

        }
        else
        {
            OnValidPlaneDataNotFound?.Invoke();
        }
    }

    private IList<ARRaycastHit> GetPlaneHits()
    {
        Vector3 screenCenter = Camera.main.ViewportToScreenPoint(ViewportCenter);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
        return hits;
    }
}