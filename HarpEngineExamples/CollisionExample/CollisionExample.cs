using HarpEngine;
using HarpEngine.Graphics;
using HarpEngine.Input;
using HarpEngine.Shapes;
using HarpEngine.Utilities;
using HarpEngine.Windowing;

internal class CollisionExample : Game
{
	private CollisionScene collisionScene = new();

	public CollisionExample()
	{
		Window.SetRendererUnclipped(Colors.Gray);
		Window.SetResizable(true);
	}

	public override void Update()
	{
		collisionScene.Update();
	}

	public override void Draw()
	{
		collisionScene.Draw();
	}
}

internal class CollisionScene : Scene
{
	public ICollidesWithRectangle[] Colliders = new ICollidesWithRectangle[25];
	private const int MinimumSize = 25;
	private const int MaximumSize = 50;

	public CollisionScene()
	{
		new MouseRectangle(this);

		for (int colliderIndex = 0; colliderIndex < Colliders.Length; colliderIndex++)
		{
			if (colliderIndex % 2 == 0) AddRectangle(colliderIndex);
			else AddCircle(colliderIndex);
		}
	}

	private void AddRectangle(int colliderIndex)
	{
		int width = Generate.Integer(MinimumSize, MaximumSize);
		int height = Generate.Integer(MinimumSize, MaximumSize);
		RectangleShape rectangleShape = new RectangleShape(this, width, height, Colors.Green);
		int x = Generate.Integer(0, Engine.GameWidth - width);
		int y = Generate.Integer(0, Engine.GameHeight - height);
		rectangleShape.Transform.WorldPosition = new(x, y);
		Colliders[colliderIndex] = rectangleShape;
	}

	private void AddCircle(int colliderIndex)
	{
		float radius = Generate.Float(MinimumSize / 2f, MaximumSize / 2f);
		CircleShape circleShape = new CircleShape(this, radius, Colors.Green);
		float x = Generate.Integer(Engine.GameWidth);
		float y = Generate.Integer(Engine.GameHeight);
		circleShape.Transform.WorldPosition = new(x, y);
		Colliders[colliderIndex] = circleShape;
	}
}
