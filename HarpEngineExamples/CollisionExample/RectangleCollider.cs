using HarpEngine.Graphics;
using HarpEngine.Shapes;
using System.Numerics;

internal class RectangleCollider : RectangleShape, ICollider
{
	private CollisionScene collisionScene;
	private bool isSelected;
	public bool IsSelected
	{
		set
		{
			isSelected = value;
			Color = isSelected ? Colors.Green : Colors.Blue;
		}
	}
	public Vector2 CenterPosition
	{
		set
		{
			Transform.WorldPosition = value - new Vector2(Width / 2f, Height / 2f);
		}
	}

	public RectangleCollider(CollisionScene collisionScene, int width, int height) : base(collisionScene, width, height, Colors.Blue)
	{
		this.collisionScene = collisionScene;
	}

	public bool IsColliding(out ICollider otherCollider)
	{
		otherCollider = null;
		foreach (ICollider collider in collisionScene.Colliders)
		{
			if (collider == this) continue;
			if (collider.CollidesWithRectangle(this))
			{
				otherCollider = collider;
				Color = Colors.Orange;
				return true;
			}
		}
		Color = Colors.Green;
		return false;
	}
}