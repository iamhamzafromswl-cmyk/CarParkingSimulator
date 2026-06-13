# Project Report: Car Parking Simulator

## Submitted To

Riphah International University

## Submitted By

[Your Name/Team Name]
[Student ID(s)]
[Course Name]
[Submission Date: June 11, 2026]

## 1. Executive Summary

This report details the development of the **Car Parking Simulator**, a high-fidelity 3D driving and simulation game engineered for mobile and PC platforms. The project diverges from typical open-world simulators by focusing on a core experience centered around hyper-realistic driving physics, tactile vehicle mechanics, and challenging, puzzle-like parking scenarios. By targeting the mid-core simulation market and driving enthusiasts, the project aims to deliver specialized, mechanics-driven retention rather than expansive, open-world bloat. The game utilizes a robust modular C# architecture within the Unity Engine to enforce a tight gameplay loop, allowing players to earn in-game currency through successful parking maneuvers. This currency can then be reinvested into dynamic performance upgrades and diverse vehicle tiers, ensuring a highly scalable economy. Ultimately, the Car Parking Simulator balances a demanding skill ceiling with accessible pick-up-and-play mechanics, providing an efficiently designed framework for strong user engagement and rapid content scalability.

## 2. Introduction

The Car Parking Simulator project addresses the demand for realistic driving simulation experiences, particularly within the niche of precision parking. This document outlines the project's objectives, design philosophy, technical implementation, and development process, culminating in a functional prototype suitable for academic evaluation. The game aims to provide an engaging and challenging experience that tests players' spatial awareness, vehicle control, and strategic thinking in various parking environments.

## 3. Project Objectives

The primary objectives for the Car Parking Simulator project were:

*   To develop a realistic vehicle physics system for accurate car handling, braking, and acceleration.
*   To design and implement diverse parking environments that offer escalating challenges.
*   To create a structured career progression system that guides players through different gameplay acts.
*   To integrate a robust scoring and reward system based on parking precision and efficiency.
*   To build the game using a modular C# architecture within the Unity Engine for scalability and maintainability.
*   To optimize performance for deployment on both mobile (iOS/Android) and PC (Steam) platforms.

## 4. Game Design and Core Mechanics

### 4.1. Core Gameplay Loop

The fundamental gameplay loop is designed around skill acquisition and monetization, consistently challenging the player's spatial awareness and vehicle control. The process involves several key stages:

1.  **Choose Vehicle & Level:** Players select an unlocked vehicle class and a specific spatial map grid.
2.  **Drive & Navigate Obstacles:** Players manually navigate complex 3D architecture, utilizing precision steering, realistic brake/throttle coefficients, and active gear shifting. This phase includes physics-based feedback and collision detection.
3.  **Perfect Park & Shift to P:** The vehicle must be brought to a complete stop inside the designated parking bay, perfectly aligned within bounds, and shifted into Park [P] for a sustained duration of 3 seconds.
4.  **Earn Currency & Star Rating:** Players are awarded soft currency and performance-based stars, determined by remaining time and vehicle structural integrity.
5.  **Upgrade Specs / Buy Higher-Class Cars:** Earnings are directly reinvested into upgrading powertrain attributes or purchasing specialized commercial vehicle tiers.

### 4.2. Career Scenario (Three-Phase Programmatic Progression)

To simulate professional growth and incentivize player retention, the game follows a distinct three-phase programmatic progression:

*   **ACT I: THE ACADEMY ROOKIE**
    *   **Environment:** Clean, closed driving school courses and open lots.
    *   **Vehicles:** Subcompact hatchbacks and standard front-wheel-drive sedans.
    *   **Challenges:** Stationary traffic cones, basic parallel parking, and foundational 90-degree backing maneuvers.
*   **ACT II: THE LUXURY VALET HUSTLE**
    *   **Environment:** Dense, multi-tiered urban hotel garages and tight underground shopping mall structures.
    *   **Vehicles:** High-torque mid-engine supercars and long premium luxury SUVs.
    *   **Challenges:** Dynamic path obstructions, moving pedestrian AI, low-clearance support pillars, and unforgiving turning radii.
*   **ACT III: THE INDUSTRIAL LOGISTICS KINGPIN**
    *   **Environment:** High-clutter shipping container terminals, active freight ports, and complex rail yards.
    *   **Vehicles:** Heavy diesel prime movers and multi-axis articulated cargo trailers.
    *   **Challenges:** Complex reverse-articulation jackknife physics, blind spot camera limitations, and strict spatial docking bays.

### 4.3. Game Flow & User Journey

The user experience journey is engineered to cleanly guide players through high-stakes gameplay and seamless user interface loops:

1.  Start-up
2.  Main Menu / Hub
3.  Shop
4.  Garage & Customization
5.  Level Selection
6.  Loading Screen
7.  Gameplay Session (HUD Engine Loop)
8.  Win Condition (Parked & Settled)
9.  Loss Condition (Damage/Time Limit)
10. Return to Menu

## 5. Technical Implementation

### 5.1. Unity Engine and C# Scripting

The project is developed using the Unity Engine, leveraging its robust 3D rendering capabilities, physics engine, and extensive asset pipeline. All core game logic is implemented in C#, adhering to object-oriented programming principles for modularity and reusability.

### 5.2. Core Scripts

*   **`VehicleController.cs`:** Manages vehicle physics, including acceleration, braking, steering, and gear shifting. It integrates with Unity's WheelCollider system to simulate realistic wheel behavior and applies forces to the vehicle's Rigidbody. Input is handled for both keyboard and potential mobile touch controls.
*   **`ParkingZone.cs`:** Defines the boundaries of a parking spot and detects when a vehicle has successfully parked within it. It utilizes trigger colliders and coroutines to validate parking conditions (e.g., vehicle in park gear, stationary for a set duration).
*   **`GameManager.cs`:** Acts as the central orchestrator for the game, managing overall game states (e.g., main menu, gameplay, pause, win/lose), loading levels, and coordinating between different game systems like scoring and UI.
*   **`ScoreManager.cs`:** Handles the calculation and display of player scores, star ratings, and rewards based on performance metrics such as time taken, damage incurred, and parking accuracy.
*   **`TimerManager.cs`:** Provides time-keeping functionality for various in-game elements, such as countdown timers for challenges or tracking the duration a vehicle remains parked in a `ParkingZone`.
*   **`CameraFollow.cs`:** Implements a dynamic camera system that smoothly follows the player's vehicle, providing an optimal view for gameplay while allowing for adjustments based on vehicle speed or player actions.

### 5.3. Asset Pipeline

3D models were created using [mention 3D software if known, e.g., Blender/Maya/3ds Max] and textured using PBR workflows. These assets were then imported into Unity, where they were optimized for performance and configured as prefabs for efficient level design.

## 6. Development Process (Sprint-based Approach)

The project followed an agile, sprint-based development methodology to manage tasks and track progress. Each sprint focused on a specific aspect of game development, ensuring iterative progress and continuous integration.

### 6.1. Sprint 1: Modeling

*   **Focus:** Creation of foundational 3D models for vehicles, environmental props, and modular level blockout pieces.
*   **Outcome:** Basic car chassis, wheels, parking barriers, cones, and architectural elements.

### 6.2. Sprint 2: Texturing

*   **Focus:** Application of textures and materials to 3D models, utilizing PBR workflows.
*   **Outcome:** Textured vehicle bodies, wheels, and environmental assets with realistic surface properties.

### 6.3. Sprint 3: Importing

*   **Focus:** Importing all 3D models and textures into the Unity project, ensuring correct scaling, material assignments, and prefab creation.
*   **Outcome:** All visual assets integrated into Unity, organized within the `Assets` folder, and configured as reusable prefabs.

### 6.4. Sprint 4: Level Design

*   **Focus:** Construction of playable environments and challenging parking scenarios using imported assets.
*   **Outcome:** Multiple level layouts designed, including obstacle placement and definition of parking zones.

### 6.5. Sprint 5: Scripting

*   **Focus:** Implementation of core gameplay mechanics through C# scripting.
*   **Outcome:** Functional `VehicleController`, `ParkingZone`, `GameManager`, `ScoreManager`, `TimerManager`, and `CameraFollow` scripts.

### 6.6. Sprint 6: Rendering

*   **Focus:** Visual polish, lighting enhancements, post-processing effects, and performance optimization.
*   **Outcome:** Enhanced graphical fidelity, optimized rendering, and integrated UI/HUD elements.

## 7. Challenges and Solutions

*   **Challenge:** Achieving realistic vehicle physics with Unity's built-in WheelColliders.
    *   **Solution:** Extensive tuning of WheelCollider parameters (suspension, friction, motor/brake torque) and custom force application within `VehicleController.cs`.
*   **Challenge:** Ensuring accurate parking detection and validation across various vehicle sizes and parking angles.
    *   **Solution:** Implementing a robust `ParkingZone.cs` script with trigger colliders, `OnTriggerEnter`/`OnTriggerExit` events, and a coroutine for timed validation while the vehicle is in 'Park' gear.
*   **Challenge:** Optimizing game performance for both mobile and PC platforms.
    *   **Solution:** Careful management of polygon counts, texture resolutions, draw calls, and strategic use of Unity's Universal Render Pipeline (URP) settings and batching techniques.

## 8. Future Work

Potential future enhancements for the Car Parking Simulator include:

*   **Expanded Content:** Additional vehicles, levels, and career acts.
*   **Multiplayer Mode:** Implementation of competitive or cooperative online parking challenges.
*   **Advanced AI:** More sophisticated pedestrian and traffic AI for dynamic environments.
*   **Customization Options:** Deeper vehicle customization, including paint jobs, rims, and performance upgrades.
*   **Sound Design:** Comprehensive sound effects and background music to enhance immersion.

## 9. Conclusion

The Car Parking Simulator project successfully demonstrates the application of game development principles and Unity C# scripting to create a compelling simulation experience. Through a structured sprint-based approach, the project delivered a functional prototype that meets the core objectives of realistic physics, engaging level design, and robust gameplay mechanics. This assignment provides a strong foundation for further development and exploration within the realm of simulation games.

## 10. References

[1] Car Parking Simulator Proposal. (May 2026). Game Design & Production Team. (Internal Project Document).

## 11. Screenshots

### Final Gameplay Screenshots

![Final Gameplay Screenshot 1](screenshots/final_gameplay_01.png)
*Description: In-game view of a vehicle successfully parked in a challenging urban environment.*

![Final Gameplay Screenshot 2](screenshots/final_gameplay_02.png)
*Description: Screenshot of the main menu or level selection screen, showcasing the game's UI.*

![Final Gameplay Screenshot 3](screenshots/final_gameplay_03.png)
*Description: Action shot of a vehicle navigating obstacles in an industrial logistics environment.*
