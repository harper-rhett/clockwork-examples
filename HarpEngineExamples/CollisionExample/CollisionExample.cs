using HarpEngine;
using HarpEngine.Graphics;
using HarpEngine.Input;
using HarpEngine.Shapes;
using HarpEngine.Utilities;

internal class CollisionExample : Game
{
	private CollisionScene collisionScene = new();

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
	public RectangleShape[] Rectangles = new RectangleShape[3];
	private const float MinimumSize = 10;
	private const float MaximumSize = 20;

	public CollisionScene()
	{
		new MouseRectangle(this);

		for (int rectangleIndex = 0; rectangleIndex < Rectangles.Length; rectangleIndex++)
		{
			int width = (int)Generate.Float(MinimumSize, MaximumSize);
			int height = (int)Generate.Float(MinimumSize, MaximumSize);
			RectangleShape rectangleShape = new RectangleShape(this, width, height, Colors.Green);
			float x = Generate.Float(0, Engine.GameWidth - width);
			float y = Generate.Float(0, Engine.GameHeight - height);
			rectangleShape.Transform.WorldPosition = new(x, y);
			Rectangles[rectangleIndex] = rectangleShape;
		}
	}
}
