## test-case-001 - Capture Point Progress

### Preconditions
- Player is alive
- Capture point exists

### Steps
1. Move player into capture zone
2. Wait several seconds

### Expected Result
Capture progress increased by an amount equal to "number of seconds * number of captures per second".

3. exit the point capture zone

### Expected Result
Capture progress stops and starts to roll back to 0 by an amount equal to "number of seconds * number of captures per second".
