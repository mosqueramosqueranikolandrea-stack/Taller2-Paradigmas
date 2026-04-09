using Godot;
using System;

public partial class Hero : CharacterBody2D
{
	[Export] public float Speed = 200f;

	private Area2D attackArea;
	private AnimatedSprite2D anim;

	private bool isAttacking = false;

	public override void _Ready()
	{
		attackArea = GetNode<Area2D>("AttackArea");
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		anim.Play("default");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (!isAttacking) // 👈 NO se mueve mientras ataca
		{
			if (Input.IsActionPressed("ui_right"))
				direction.X += 1;

			if (Input.IsActionPressed("ui_left"))
				direction.X -= 1;

			if (Input.IsActionPressed("ui_down"))
				direction.Y += 1;

			if (Input.IsActionPressed("ui_up"))
				direction.Y -= 1;

			Velocity = direction.Normalized() * Speed;
			MoveAndSlide();
		}

		if (Input.IsActionJustPressed("attack") && !isAttacking)
		{
			Attack();
		}
	}

	private async void Attack()
	{
		isAttacking = true;

		anim.Play("attack");

		var bodies = attackArea.GetOverlappingBodies();

		foreach (var body in bodies)
		{
			if (body.IsInGroup("Enemies"))
			{
				if (body is Enemy enemy)
				{
					enemy.TakeDamage(20);
				}
			}
		}

		// espera a que termine la animación
		await ToSignal(anim, "animation_finished");

		anim.Play("default");
		isAttacking = false;
	}
}
