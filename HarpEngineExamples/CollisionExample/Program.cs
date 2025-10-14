using HarpEngine;

EngineSettings settings = new()
{
	WindowName = "Collision Example",
	GameWidth = 500,
	GameHeight = 500
};
Engine.Initialize(settings);
CollisionExample collisionExample = new();
Engine.Start(collisionExample);