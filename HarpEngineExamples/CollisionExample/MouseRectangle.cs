using HarpEngine;
using HarpEngine.Graphics;
using HarpEngine.Input;
using HarpEngine.Shapes;

internal class MouseRectangle : RectangleShape
{
	private CollisionScene collisionScene;
	private bool isColliding;

	public MouseRectangle(CollisionScene collisionScene) : base(collisionScene, 20, 10, Colors.Blue)
	{
		this.collisionScene = collisionScene;
	}

	public override void Update()
	{
		Transform.WorldPosition = Mouse.GamePosition;
		CheckCollisions();
		Color = isColliding ? Colors.Orange : Colors.Blue;
	}

	private void CheckCollisions()
	{
		isColliding = false;

		foreach (RectangleShape rectangleShape in collisionScene.Rectangles)
			if (CollidesWith(rectangleShape)) isColliding = true;
	}
}