using HarpEngine;
using HarpEngine.Input;
using System.Numerics;

internal class Selector : Entity
{
	private ICollider selectedCollider;
	private Vector2 colliderOffset = Vector2.Zero;
	private Vector2 mousePosition;

	public Selector(ICollider selectedCollider)
	{
		this.selectedCollider = selectedCollider;
		selectedCollider.IsSelected = true;
	}

	public override void Update()
	{
		mousePosition = Mouse.GamePosition;
		selectedCollider.Position = mousePosition + colliderOffset;
		bool isColliding = selectedCollider.IsColliding(out ICollider otherCollider);
		bool isMouseClicked = Mouse.IsButtonPressed(MouseButton.Left);
		if (isColliding && isMouseClicked) GrabCollider(otherCollider);
	}

	private void GrabCollider(ICollider otherCollider)
	{
		selectedCollider.IsSelected = false;
		selectedCollider = otherCollider;
		selectedCollider.IsSelected = true;
		colliderOffset = selectedCollider.Position - mousePosition;
	}
}