## 1. Overview

Combat Sandbox is a simplified gameplay environment designed to simulate core mechanics of a combat game.

The system includes:
- infantry unit (player)
- vehicle interaction
- weapon and ammo system
- module-based vehicle damage

---

## 2. Functional Requirements

### 2.1 Player Movement

- Player must be able to move in four directions using keyboard input
- Player movement must be disabled when inside a vehicle
- Player must not move when dead

---

### 2.2 Weapon System

#### 2.2.1 Firing

- Player must be able to fire a weapon when:
  - player is alive
  - player is not reloading
  - player is not inside a vehicle
  - weapon has ammo in magazine

- Each shot must:
  - reduce ammo in magazine by 1
  - trigger hit detection using raycast
  - apply damage if a valid target is hit

#### 2.2.2 Reload

- Player must be able to start reload when:
  - magazine is not full
  - ammo reserve is greater than 0
  - player is not inside a vehicle

- Reload must:
  - take a fixed amount of time
  - transfer ammo from reserve to magazine
  - update player state to `Reloading` during process
  - return player to `Idle` after completion

- Reload must be safely handled if interrupted by:
  - player death
  - player entering vehicle

---

### 2.3 Ammo System

- Ammo must be split into:
  - magazine ammo
  - reserve ammo

- Ammo must:
  - never be negative
  - not exceed magazine capacity
  - not allow firing if magazine is empty

---

### 2.4 Player State Machine

Player must have the following states:

- Idle
- Moving
- Reloading
- EnteringVehicle
- InsideVehicle
- ExitingVehicle
- Capturing
- Dead

#### State Constraints

- Player cannot:
  - fire while reloading
  - reload while inside vehicle
  - move while inside vehicle
  - perform any action when dead

- State transitions must be consistent and not leave player in invalid states

---

### 2.5 Vehicle Interaction

#### 2.5.1 Enter Vehicle

- Player must be able to enter vehicle when:
  - player is within interaction radius
  - driver seat is not occupied

- After entering:
  - player state must be `InsideVehicle`
  - player must not move independently
  - player must not use infantry weapon

#### 2.5.2 Exit Vehicle

- Player must be able to exit vehicle at any time

- Exit logic must:
  - place player in a valid, non-blocked position near vehicle
  - avoid placing player inside geometry

---

### 2.6 Vehicle Movement

- Vehicle must move only when:
  - driver seat is occupied

- Vehicle movement must depend on engine state:
  - if engine is destroyed, vehicle must not move or must be severely limited

---

### 2.7 Vehicle Damage System

- Vehicle must consist of modules:
  - Engine
  - Track
  - Gun
  - FuelTank

- Each module must:
  - have health
  - receive damage
  - be able to reach destroyed state

- Destroyed modules must affect gameplay:
  - destroyed engine → affects movement
  - destroyed gun → affects shooting (optional extension)

---

### 2.8 Capture Point System

- Capture point must detect players inside a defined area

- Capture progress must:
  - increase when valid players are inside zone
  - stop or decrease when no valid players are inside

- Only valid players must contribute:
  - player must be alive
  - player must be inside zone

---

### 2.9 Death System

- Player must transition to `Dead` state when health reaches zero

- Dead player must:
  - not move
  - not interact
  - not fire
  - not contribute to capture point

---

### 2.10 Debug System

- System must provide debug overlay displaying:
  - player state
  - ammo
  - capture progress
  - vehicle engine state

- System must allow running predefined test scenarios

---

## 3. Non-Functional Requirements

- System must be testable manually
- System must allow fast reproduction of edge cases
- System must expose internal state via debug UI
- Code must be readable and modular
- Gameplay systems must be loosely coupled

---

## 4. Acceptance Criteria

The system is considered valid if:

- all core mechanics are functional in normal conditions
- state transitions behave consistently
- debug overlay reflects actual state
