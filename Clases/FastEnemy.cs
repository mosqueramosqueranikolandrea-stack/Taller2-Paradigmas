using Godot;
using System;

public partial class FastEnemy : Enemy
{
	[Export] public float Speed = 120f;

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

			changeTimer = 2f; // cambia cada 2 segundos
		}

		Velocity = direction * Speed;
		MoveAndSlide();
	}
}
