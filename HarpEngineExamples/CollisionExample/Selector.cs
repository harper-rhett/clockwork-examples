using HarpEngine;
using HarpEngine.Input;

internal class Selector : Entity
{
	private ICollider selectedCollider;

	public Selector(Scene scene, ICollider selectedCollider) : base(scene)
	{
		this.selectedCollider = selectedCollider;
		selectedCollider.IsSelected = true;
	}

	public override void Update()
	{
		selectedCollider.CenterPosition = Mouse.GamePosition;
		bool isColliding = selectedCollider.IsColliding(out ICollider otherCollider);
		bool isMouseClicked = Mouse.IsButtonPressed(MouseButton.Left);
		if (isColliding && isMouseClicked)
		{
			selectedCollider.IsSelected = false;
			selectedCollider = otherCollider;
			selectedCollider.IsSelected = true;
		}
	}
}