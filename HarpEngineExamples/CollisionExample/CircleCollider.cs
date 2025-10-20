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
		get => Transform.WorldPosition;
		set => Transform.WorldPosition = value;
	}
	public bool IsCollidedWith { get; set; }

	public CircleCollider(CollisionScene collisionScene, float radius) : base(collisionScene, radius, Colors.Blue)
	{
		this.collisionScene = collisionScene;
	}

	public override void Update()
	{
		Color = IsCollidedWith ? Colors.SkyBlue : Colors.Blue;
	}

	public bool IsColliding(out ICollider otherCollider)
	{
		otherCollider = null;
		bool isCollision = false;
		foreach (ICollider collider in collisionScene.Colliders)
		{
			if (collider == this) continue;
			bool doesCollide = collider.CollidesWithCircle(this);
			collider.IsCollidedWith = doesCollide;
			isCollision = isCollision || doesCollide;
			if (doesCollide) otherCollider = collider;
		}
		Color = isCollision ? Colors.Green : Colors.Lime;
		return isCollision;
	}
}