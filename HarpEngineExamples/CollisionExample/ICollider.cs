using HarpEngine.Shapes;
using System.Numerics;

internal interface ICollider : ICollidesWithRectangle, ICollidesWithCircle
{
	public Vector2 CenterPosition { get; set; }
	public bool IsSelected { set; }
	public bool IsCollidedWith { get; set; }

	public bool IsColliding(out ICollider otherCollider);
}