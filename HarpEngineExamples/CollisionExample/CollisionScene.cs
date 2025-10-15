using HarpEngine;
using HarpEngine.Utilities;

internal class CollisionScene : Scene
{
	public ICollider[] Colliders = new ICollider[25];
	private const int MinimumSize = 25;
	private const int MaximumSize = 50;

	public CollisionScene()
	{
		for (int colliderIndex = 0; colliderIndex < Colliders.Length; colliderIndex++)
		{
			if (colliderIndex % 2 == 0) AddRectangle(colliderIndex);
			else AddCircle(colliderIndex);
		}

		new Selector(this, Colliders[0]);
	}

	private void AddRectangle(int colliderIndex)
	{
		int width = Generate.Integer(MinimumSize, MaximumSize);
		int height = Generate.Integer(MinimumSize, MaximumSize);
		RectangleCollider rectangleCollider = new(this, width, height);
		int x = Generate.Integer(0, Engine.GameWidth - width);
		int y = Generate.Integer(0, Engine.GameHeight - height);
		rectangleCollider.Transform.WorldPosition = new(x, y);
		Colliders[colliderIndex] = rectangleCollider;
	}

	private void AddCircle(int colliderIndex)
	{
		float radius = Generate.Float(MinimumSize / 2f, MaximumSize / 2f);
		CircleCollider circleCollider = new(this, radius);
		float x = Generate.Integer(Engine.GameWidth);
		float y = Generate.Integer(Engine.GameHeight);
		circleCollider.Transform.WorldPosition = new(x, y);
		Colliders[colliderIndex] = circleCollider;
	}
}