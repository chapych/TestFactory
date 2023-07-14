using System;

public class AbstractFactoryA : IFactory
{
	public IObject CreateObject()
	{
		IObject created = new ObjectA();
		return created;
	}
}