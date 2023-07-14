using System;

public class LifeTimeSystem
{
    private List<IObject> createdObjects;
    private List<IObject> destroyedObjects;

    private IFactory factory;

    public LifeTimeSystem(IFactory factory) 
    {
        createdObjects = new List<IObject>();
        destroyedObjects = new List<IObject>();

        this.factory = factory;
    }

    ~LifeTimeSystem()
    {
        var objectsToDestroy = createdObjects.ToList();
        foreach(var objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }
    }

    public IObject Create()
    {
        var created = factory.CreateObject();
        createdObjects.Add(created);

        return created;
    }

    public void Destroy(IObject objectToDestroy)
    {
        objectToDestroy.Destroy();

        createdObjects.Remove(objectToDestroy);
        destroyedObjects.Add(objectToDestroy);
    }
}

