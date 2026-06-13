# Installation Guide: Car Parking Simulator

This guide provides instructions on how to set up and run the Car Parking Simulator project. This project is developed using Unity Engine and C#.

## 1. Prerequisites

Before you begin, ensure you have the following software installed:

*   **Unity Hub:** Download and install Unity Hub from the [official Unity website](https://unity.com/download).
*   **Unity Editor:** Install Unity Editor version **2022.3.x LTS** (or a compatible version). You can install this through Unity Hub.
*   **Git:** Install Git from [git-scm.com](https://git-scm.com/downloads) to clone the repository.

## 2. Getting Started

Follow these steps to get the project up and running on your local machine.

### 2.1. Clone the Repository

Open your terminal or Git Bash and run the following command to clone the project repository:

```bash
git clone https://github.com/[YourGitHubUsername]/CarParkingSimulator.git
cd CarParkingSimulator
```

Replace `[YourGitHubUsername]` with the actual GitHub username where this repository will be hosted.

### 2.2. Open the Project in Unity

1.  **Open Unity Hub.**
2.  Click on the **"Add"** button.
3.  Navigate to the `CarParkingSimulator` folder you just cloned and select it. Click **"Add Project"**.
4.  Unity Hub will detect the project. If prompted to install a specific Unity Editor version, follow the instructions. Otherwise, click on the project entry to open it in the Unity Editor.

### 2.3. Configure the Project (Optional, if issues arise)

If you encounter any issues with missing packages or compilation errors, Unity usually resolves these automatically upon opening the project. If not, you might need to:

*   **Resolve Package Manager issues:** Go to `Window > Package Manager` in Unity Editor and ensure all necessary packages are installed and up-to-date.
*   **Re-import All Assets:** Sometimes, re-importing assets can resolve issues. Go to `Assets > Reimport All`.

## 3. Running the Game

Once the project is open in the Unity Editor:

1.  Navigate to the `Assets/Scenes` folder in the Project window.
2.  Open the main scene (e.g., `MainScene.unity` or `GameplayScene.unity`). The exact name might vary based on the project setup.
3.  Click the **Play** button (▶) in the Unity Editor toolbar to run the game.

## 4. Project Structure

For an overview of the project's folder structure and content, please refer to the main `README.md` file in the root of the repository.

## 5. Troubleshooting

*   **Missing scripts/references:** Ensure all `.cs` files are correctly placed in the `Assets/Scripts` folder and that Unity has compiled them without errors.
*   **Graphical glitches:** Check your Unity Editor version and ensure your graphics drivers are up-to-date.
*   **Performance issues:** Adjust quality settings in `Edit > Project Settings > Quality` or refer to the `Docs/Project Report.md` for optimization details.

If you encounter persistent issues, please consult the project documentation or contact the development team.
