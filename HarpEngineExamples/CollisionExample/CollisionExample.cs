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
