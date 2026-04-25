## test-case-003 - Reload Weapon

### Preconditions
- Magazine is not full
- Ammo reserve is greater than 0
- Player is not inside vehicle

### Steps
1. Press `R`
2. Wait until reload duration ends

### Expected Result
Reloading state starts.
After reload completes, magazine receives ammo from reserve.
Player returns to idle state.
