# Combat QA Sandbox

Combat QA Sandbox is a small Unity-based testing playground created to demonstrate QA and engineering skills.

The project focuses on:
- infantry controls
- vehicle interaction
- weapon and reload logic
- module-based vehicle damage
- capture point logic
- reproducible gameplay bugs
- debugging and validation tools

## Goal
The goal of the project is not to build a full game, but to build a testable gameplay sandbox that demonstrates strong QA thinking, debugging approach, system understanding, and automation.

## QA Documentation
Project documentation is available in the `docs` folder:
- test plan on last version (It's easiest to study the documentation through it) [link](https://github.com/coldborne/CombatSandboxWithBugs/blob/master/docs/test-plans/0.1-test-plan.md)
- test cases
- smoke checklist
- bug reports

## Implemented Systems
- character movement
- weapon firing and reload
- vehicle enter/exit
- vehicle mobility and module damage
- capture point
- debug overlay
- session logging

## Intentional Bugs
This sandbox includes several intentionally enabled bugs for demonstration purposes:
- vehicle can move with destroyed engine
- player exits vehicle into blocked geometry
- weapon can fire with zero ammo
- capture progress does not reset
- dead player still counts for capture
- capture progress is not displayed on the player`s screen 

## Controls
- WASD - move
- Mouse - view
- Left Mouse Button - fire
- R - reload
- E - interact
- F1 - debug overlay
- F2 - scenario menu
- F3 - reset scene

## Tech Stack
- Unity
- C#
