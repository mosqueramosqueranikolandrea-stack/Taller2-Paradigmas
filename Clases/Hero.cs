using Godot;
using System;

public partial class Hero : CharacterBody2D
{
	[Export] public float Speed = 200;

	private Area2D attackArea;
	private bool enemyInRange = false;

	public override void _Ready()
	{
		attackArea = GetNode<Area2D>("AttackArea");

		// Detectar cuando un enemigo entra
		attackArea.BodyEntered += OnBodyEntered;

		// Detectar cuando sale
		attackArea.BodyExited += OnBodyExited;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;

		direction.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		direction.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");

		Velocity = direction.Normalized() * Speed;
		MoveAndSlide();

		// ATAQUE SOLO SI HAY ENEMIGO CERCA
		if (enemyInRange && Input.IsActionJustPressed("attack"))
		{
			GD.Print("⚔️ Atacando enemigo cercano");

			foreach (var body in attackArea.GetOverlappingBodies())
			{
				if (body.IsInGroup("Enemies"))
				{
					body.QueueFree(); // elimina enemigo
				}
			}
		}
	}

	private void OnBodyEntered(Node body)
	{
		if (body.IsInGroup("Enemies"))
		{
			enemyInRange = true;
			GD.Print("👀 Enemigo cerca");
		}
	}

	private void OnBodyExited(Node body)
	{
		if (body.IsInGroup("Enemies"))
		{
			enemyInRange = false;
			GD.Print("🚫 Enemigo fuera de rango");
		}
	}
}
