using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class enemy_paddle : CharacterBody2D
{
	public const float Speed = 700.0f;

	static Vector2 ballPos;
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = (ballPos - GlobalPosition).Normalized();
		if (direction != Vector2.Zero)
		{
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public static void GetBallPos(Vector2 pos){
		ballPos = pos;
	}

	public void OnTopEntered(Node2D body){
		if (body is ball Ball){
			Ball.SetVertical(-1);
		}
	}
	public void OnBottomEntered(Node2D body){
		if (body is ball Ball){
			Ball.SetVertical(1);
		}
	}
	public void OnBodyExit(Node2D body){
		if (body is ball Ball){
			Ball.SetVertical(0);
		}
	}
}
