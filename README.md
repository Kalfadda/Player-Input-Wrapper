# Unity Input Mapping and Management

## Overview
This repository contains two key scripts for Unity game development: `PlayerInputMapping.cs` and `PlayerInputManager.cs`. These scripts are designed to facilitate customizable key bindings and input management in Unity games, enhancing player accessibility and control customization. 

The primary focus of this repository is to provide a reference for implementing accessible and flexible input systems in Unity games. While it's primarily for my personal reference in future projects, it's made public to assist developers in including essential accessibility features like key rebinding.

## Scripts

### `PlayerInputMapping.cs`
This script is responsible for mapping player actions to specific key codes. It includes functionality to save and load key bindings, allowing for customizable controls. The script uses a dictionary to map `PlayerAction` enums to `KeyCode`, making it easy to define and modify key bindings.

Key Features:
- Load and save key bindings to and from a JSON file.
- Define default key bindings.
- Easily extendable to include more player actions and key bindings.

### `PlayerInputManager.cs`
This script handles the detection of player inputs based on the defined key bindings in `PlayerInputMapping.cs`. It checks for inputs every frame and executes corresponding actions, such as moving forward or interacting with objects.

Key Features:
- Checks player input against current key bindings.
- Executes actions based on player input.
- Easy to integrate with other gameplay systems (e.g., movement, interaction).

## How to Use and Modify
To use these scripts in your Unity project:
1. Attach `PlayerInputManager.cs` to a GameObject in your scene, typically the player character.
2. Ensure that `PlayerInputMapping.cs` is included in your project scripts.

To modify these scripts for your specific needs:
- Add or remove entries in the `PlayerAction` enum to define the actions relevant to your game.
- Adjust default key bindings in `PlayerInputMapping.cs` as per your game's requirements.
- Modify `PlayerInputManager.cs` to change how inputs are processed and actions are executed.

## Contribution
While this repository is primarily for my reference, contributions are welcome, especially those that enhance accessibility and usability. Feel free to fork, modify, and make pull requests.

## License
This project is open-source and available under [MIT License](LICENSE).
