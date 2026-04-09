using Godot;
using System;

public partial class StrongEnemy : Enemy
{
	[Export] public float Speed = 60f;

	private Vector2 direction;
	private float changeTimer = 0;

	public override void _PhysicsProcess(double delta)
	{
		changeTimer -= (float)delta;

		if (changeTimer <= 0)
		{
			direction = new Vector2(
				(float)GD.RandRange(-1, 1),
				(float)GD.RandRange(-1, 1)
			).Normalized();

			changeTimer = 3f; // más lento
		}

		Velocity = direction * Speed;
		MoveAndSlide();
	}
}
