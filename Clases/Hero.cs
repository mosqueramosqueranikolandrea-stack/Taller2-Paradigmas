using Godot;
using System;

public partial class Hero : Character
{
	private Area2D attackArea;

	public override void _Ready()
	{
		attackArea = GetNode<Area2D>("AttackArea");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsActionPressed("ui_right"))
			direction.X += 1;
		if (Input.IsActionPressed("ui_left"))
			direction.X -= 1;
		if (Input.IsActionPressed("ui_down"))
			direction.Y += 1;
		if (Input.IsActionPressed("ui_up"))
			direction.Y -= 1;

		MoveCharacter(direction.Normalized());
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept"))
		{
			Attack();
		}
	}

	private void Attack()
	{
		var bodies = attackArea.GetOverlappingBodies();

		foreach (Node body in bodies)
		{
			if (body is Character enemy && body != this)
			{
				enemy.TakeDamage(Damage);
			}
		}
	}
}
