## test-case-005 - Enter Vehicle During Reload

### Preconditions
- Player is alive
- Player has weapon
- Magazine is not full
- Ammo reserve is greater than 0
- Player is in radius of interaction with vehicle

### Steps
1. Fire one shot
2. Press `R`
3. Until reloading is complete press `E` near vehicle

### Expected Result
Reload should be safely completed before player starts driving the vehicle.
