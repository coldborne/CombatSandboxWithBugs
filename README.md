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
- test plan on last version
- test cases
- smoke checklist
- reproducible scenarios
- bug reports

## Implemented Systems
- character movement
- weapon firing and reload
- vehicle enter/exit
- vehicle mobility and module damage
- capture point
- debug overlay
- repro scenario runner
- session logging

## Intentional Bugs
This sandbox includes several intentionally enabled bugs for demonstration purposes:
- player remains in reloading state after entering vehicle
- vehicle can move with destroyed engine
- capture progress does not reset
- player exits vehicle into blocked geometry
- weapon can fire with zero ammo
- dead player still counts for capture

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
