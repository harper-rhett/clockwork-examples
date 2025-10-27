using HarpEngine;
using HarpEngine.Graphics;
using HarpEngine.Shapes;
using System.Numerics;

internal class LineCollider : LineShape, ICollider
{
	private CollisionScene collisionScene;
	public bool IsSelected { get; set; }
	public bool IsCollidedWith { get; set; }

	private Vector2 endOffset;
	public Vector2 Position
	{
		get => StartPosition;
		set
		{
			StartPosition = value;
			base.EndPosition = StartPosition + endOffset;
		}
	}
	public new Vector2 EndPosition
	{
		set
		{
			base.EndPosition = value;
			endOffset = base.EndPosition - StartPosition;
		}
	}

	public LineCollider(CollisionScene collisionScene, float thickness) : base(collisionScene, thickness, Colors.Blue)
	{
		this.collisionScene = collisionScene;
	}

	public override void Update()
	{
		if (IsSelected) Color = IsSelected ? Colors.Green : Colors.Blue;
		else Color = IsCollidedWith ? Colors.SkyBlue : Colors.Blue;
	}

	bool ICollider.IsColliding(out ICollider otherCollider)
	{
		otherCollider = null;
		bool isCollision = false;
		foreach (ICollider collider in collisionScene.Colliders)
		{
			if (collider == this) continue;
			bool doesCollide = collider.IntersectsWithLine(this);
			collider.IsCollidedWith = doesCollide;
			isCollision = isCollision || doesCollide;
			if (doesCollide) otherCollider = collider;
		}
		Color = isCollision ? Colors.Green : Colors.Lime;
		return isCollision;
	}
}
