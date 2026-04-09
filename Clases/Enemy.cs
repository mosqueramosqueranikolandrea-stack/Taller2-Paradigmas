using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	[Export] public int MaxHealth = 100;

	private int currentHealth;
	private ProgressBar healthBar;

	public override void _Ready()
	{
		currentHealth = MaxHealth;

		healthBar = GetNode<ProgressBar>("HealthBar");
		healthBar.Value = currentHealth;
	}

	public void TakeDamage(int damage)
	{
		GD.Print("RECIBI DAÑO");

		currentHealth -= damage;

		if (currentHealth < 0)
			currentHealth = 0;

		healthBar.Value = currentHealth;

		if (currentHealth <= 0)
		{
			QueueFree();
		}
	}
}
