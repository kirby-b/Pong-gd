using Godot;
using System;

public partial class enemy_paddle : CharacterBody2D
{
	public const float Speed = 700.0f;

	static Vector2 ballPos;
    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Gets the balls position and subtracts your position
		Vector2 direction = (ballPos - GlobalPosition).Normalized();
		if (direction != Vector2.Zero)
		{
			// Attemps to center on the balls Y
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

	// Controls what happens when the ball hits the zones or leaves them
	public void OnTopEntered(Node2D body){
		if (body is ball Ball){
			// Sends the ball up
			Ball.SetVertical(-1);
		}
	}
	public void OnBottomEntered(Node2D body){
		if (body is ball Ball){
			// Sends the ball down
			Ball.SetVertical(1);
		}
	}
	public void OnBodyExit(Node2D body){
		if (body is ball Ball){
			// Sends the ball on its normal path
			Ball.SetVertical(0);
		}
	}
	// Add to applicable places in ball.cs to make the computer paddle follow the ball
	// enemy_paddle.GetBallPos(GlobalPosition);
}