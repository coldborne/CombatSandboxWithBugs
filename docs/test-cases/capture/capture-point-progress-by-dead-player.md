## test-case-002 - Capture point progress by a dead player

### Preconditions
- Player is alive
- Second player alive (to deal damage)
- Capture point exists

### Steps
1. Move player into capture zone
2. Die at the moment of entering the capture zone (receive damage, for example, from another enemy)
3. Wait several seconds

### Expected Result
Capture progress has not increased by an amount equal to "number of seconds * number of captures per second". 

### Steps
4. Move second player into capture zone
5. Wait several seconds

### Expected Result
Capture progress increased by an amount equal to "number of seconds * number of captures per second" only for one player.
