using HarpEngine.Graphics;
using HarpEngine.Shapes;
using System.Numerics;

internal class CircleCollider : CircleShape, ICollider
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
		set => Transform.WorldPosition = value;
	}

	public CircleCollider(CollisionScene collisionScene, float radius) : base(collisionScene, radius, Colors.Blue)
	{
		this.collisionScene = collisionScene;
	}

	public bool IsColliding(out ICollider otherCollider)
	{
		otherCollider = null;
		foreach (ICollider collider in collisionScene.Colliders)
		{
			if (collider == this) continue;
			if (collider.CollidesWithCircle(this))
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