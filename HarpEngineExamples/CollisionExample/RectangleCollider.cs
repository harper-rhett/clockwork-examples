using HarpEngine.Graphics;
using HarpEngine.Shapes;
using System.Numerics;

internal class RectangleCollider : RectangleShape, ICollider
{
	private CollisionScene collisionScene;
	private bool isSelected;
	private Vector2 offset;
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
		get
		{
			return Transform.WorldPosition - offset;
		}
		set
		{
			Transform.WorldPosition = value + offset;
		}
	}
	public bool IsCollidedWith { get; set; }

	public RectangleCollider(CollisionScene collisionScene, int width, int height) : base(collisionScene, width, height, Colors.Blue)
	{
		this.collisionScene = collisionScene;
		offset = new Vector2(-Width / 2f, -Height / 2f);
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
			bool doesCollide = collider.CollidesWithRectangle(this);
			collider.IsCollidedWith = doesCollide;
			isCollision = isCollision || doesCollide;
			if (doesCollide) otherCollider = collider;
		}
		Color = isCollision ? Colors.Green : Colors.Lime;
		return isCollision;
	}
}