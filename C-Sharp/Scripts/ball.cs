using Godot;
using System;

// This class controls all the ball functionality
public partial class ball : CharacterBody2D
{
	// Variables for the balls movement speed
	public float Horizonal_Speed = 300.0f;
	public float Vertical_Speed = 0.0f;
	// Determines if the ball will bounce up or down
	public int UpOrDown = 0;
	// Determines the balls direction
	public int direction = 1;
	// Determines if the ball can bounce
	public bool can_bounce = true;
	Timer bounce = null;
	// A timer for respawn so its not immediate
	Timer spawn_wait = null;

	Vector2 spawn;

    public override void _Ready()
    {
        base._Ready();
		// All of this is instancing the timers and storing the initial spawn location
		bounce = GetNode<Timer>("../BounceTime");
		spawn_wait = GetNode<Timer>("../SpawnWait");
		spawn = Position;
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Controls the balls movement
		velocity.X = direction * Horizonal_Speed;
		velocity.Y = direction * Vertical_Speed;

		// Bounces ball if it hits a wall or ceiling
		if(IsOnWall() && can_bounce){
			direction *= -1;
			Horizonal_Speed *= 1.1f;
			if (UpOrDown == 1){
				Vertical_Speed = -300;
			}
			else if(UpOrDown == -1){
				Vertical_Speed = 300;
			}
			bounce.Start();
			can_bounce = false;
		}
		if((IsOnFloor() || IsOnCeiling()) && can_bounce){
			Vertical_Speed *= -1;
			bounce.Start();
			can_bounce = false;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void SetVertical(int new_direction){
		UpOrDown = new_direction;
		// Control if they will bounce up(1), down(-1), or continue at current angle(0)
	}

	// Respawns the ball
	public void Respawn(){
		Horizonal_Speed = 0.0f;
		Vertical_Speed = 0.0f;
		Position = spawn;
		spawn_wait.Start();
	}

	// Timer timeouts to make the program continue
	public void OnBounceTimeTimeout(){
		can_bounce = true;
	}

	public void OnSpawnWaitTimeout(){
		Horizonal_Speed = 300.0f;
		direction *= -1;
	}
}
