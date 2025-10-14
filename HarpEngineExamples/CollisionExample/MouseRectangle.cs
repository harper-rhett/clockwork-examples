using HarpEngine;
using HarpEngine.Graphics;
using HarpEngine.Input;
using HarpEngine.Shapes;
using System.Numerics;

internal class MouseRectangle : RectangleShape
{
	private CollisionScene collisionScene;
	private bool isColliding;
	private const int size = 25;
	private const int halfSize = size / 2;

	public MouseRectangle(CollisionScene collisionScene) : base(collisionScene, size, size, Colors.Blue)
	{
		this.collisionScene = collisionScene;
	}

	public override void Update()
	{
		Transform.WorldPosition = Mouse.GamePosition - Vector2.One * halfSize;
		CheckCollisions();
		Color = isColliding ? Colors.Orange : Colors.Blue;
	}

	private void CheckCollisions()
	{
		isColliding = false;

		foreach (ICollidesWithRectangle collider in collisionScene.Colliders)
			if (collider.CollidesWithRectangle(this)) isColliding = true;
	}
}