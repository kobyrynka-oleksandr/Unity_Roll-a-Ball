Features Added:
1. Random Pickup Spawning and Lose Condition
Collectibles (Pickups) no longer appear all at once on the field. Instead, they spawn one at a time at a random. When a pickup is collected, the next one immediately spawns at a different location. The game ends when the player falls off the field or caught by the enemy, creating a continuous play-until-you-lose loop.

2. Main Menu and Settings
A main menu was added with the following screens:

Play with Level Select — choose between Level 1 and Level 2 before starting

Settings — adjust background music volume and the number of enemies that appear during gameplay

Quit — closes the game

All settings are preserved across scene transitions using a static GameSettings class.

3. Particle Effects
Visual particle effects were added to enhance gameplay feedback:

Pickup collection — a burst effect plays at the moment a collectible is picked up

Player movement — a continuous particle effect emits while the ball is moving, and stops when the ball is stationary

4. Sound Effects & Background Music
Audio was integrated throughout the game:

Pickup sound — plays when a collectible is collected

Rolling sound — looping audio that plays only while the ball is moving

Background music — persists seamlessly across all scenes (menu and levels) using a DontDestroyOnLoad, with volume controllable from the Settings menu

5. Kill Zone
A kill zone border has been added around the playing field. If a player rolls over the edge and enters this zone, the game is over.
