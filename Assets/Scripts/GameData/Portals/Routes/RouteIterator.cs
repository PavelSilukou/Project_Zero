using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RouteIterator
{
    private Route collection;
    private int current = 0;
    private Vector3 targetPosition;

    public RouteIterator(Route collection)
    {
        this.collection = collection;
    }
    
    public Vector3 First()
    {
        current = 0;
        targetPosition = collection[current].GetPosition();
        return targetPosition;
    }

    public Vector3 Next()
    {
        current += 1;
        targetPosition = collection[current].GetPosition();
        return targetPosition;
    }

    public Vector3 Next(Vector3 position, float routeStep)
    {
        var target = Vector3.MoveTowards(position, targetPosition, routeStep);
        if (target == targetPosition)
        {
            routeStep -= Vector3.Distance(targetPosition, position);
            current += 1;
            if (!IsDone)
            {
                targetPosition = collection[current].GetPosition();
                target = Vector3.MoveTowards(position, targetPosition, routeStep);
            }
        }
        return target;
    }

    public float Distance(Vector3 position)
    {
        float distance = 0.0f;

        for (var routeIndex = current + 1; routeIndex < collection.Count - 1; routeIndex++)
        {
            distance += Vector3.Distance(collection[routeIndex].GetPosition(), collection[routeIndex + 1].GetPosition());
        }
        distance += Vector3.Distance(position, collection[current].GetPosition());

        return distance;
    }

    public bool IsDone
    {
        get { return current >= collection.Count; }
    }

    public Tile GetLastTile()
    {
        return collection[collection.Count-1];
    }
}
