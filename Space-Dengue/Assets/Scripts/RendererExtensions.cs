
using System.Collections;
using UnityEngine;

public static class RendererExtensions  {
    public static bool Visivel(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    }
