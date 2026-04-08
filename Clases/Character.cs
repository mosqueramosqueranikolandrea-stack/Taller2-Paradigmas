using Godot;
using System;

public partial class Character : CharacterBody2D
{
	[Export] public int Speed = 100;
	[Export] public int Health = 100;
	[Export] public int Damage = 10;

	public virtual void MoveCharacter(Vector2 direction)
	{
		Velocity = direction * Speed;
		MoveAndSlide();
	}

	public virtual void TakeDamage(int amount)
	{
		Health -= amount;
		GD.Print(Name + " recibió daño: " + amount);

		if (Health <= 0)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		GD.Print(Name + " murió");
		QueueFree();
	}
}
