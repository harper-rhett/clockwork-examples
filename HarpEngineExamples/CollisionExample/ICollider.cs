using HarpEngine.Shapes;
using System.Numerics;

internal interface ICollider : ICollidesWithRectangle, ICollidesWithCircle
{
	public Vector2 CenterPosition { set; }
	public bool IsSelected { set; }

	public bool IsColliding(out ICollider otherCollider);
}