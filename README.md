# Steering Behaviors in Unity 🚗💨  
*A modular implementation of autonomous agent movement behaviors (e.g., seek, flee, wander) for game AI, inspired by Craig Reynolds' research.*  

[![Unity Version](https://img.shields.io/badge/Unity-2021.3+-black?logo=unity)](https://unity.com)  
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)  

**Demo GIF**  
<!-- Add a short GIF showing agents using different behaviors -->
![Steering Demo](media/demo.gif)  

---

## 🧩 Implemented Behaviors  
| Behavior                | Description                                                                 |  
|-------------------------|-----------------------------------------------------------------------------|  
| **Seek**                | Moves toward a target position.                                            |  
| **Flee**                | Moves away from a target position.                                         |  
| **Arrive**              | Decelerates smoothly upon reaching the target.                             |  
| **Wander**              | Randomizes movement direction using a projected circle.                    |  
| **Obstacle Avoidance**  | Detects and navigates around obstacles using raycasting.                   |  
| **Follow Path**         | Follows a predefined path (waypoints) with smoothing.                      |  
| **Offset Pursuit**      | Follows a target while maintaining a specified offset position.            |  

---

## 🚀 Getting Started  
### Installation  
1. **Clone the repository**:  
   ```bash
   git clone https://github.com/comedianhhh/SteeringBehaiour.git

📊 Optimization Tips
Object Pooling: Use for agents in large crowds (e.g., RTS units).

Spatial Partitioning: Optimize obstacle detection with grids/quadtrees.

Burstable Math: For CPU-heavy calculations in ECS architectures.

## 🎮 Why Steering Behaviors?
Natural Movement: Creates lifelike AI navigation (used in games like Red Dead Redemption 2 for ambient wildlife).

Flexibility: Easily combine behaviors for complex AI (e.g., "Flee + Wander" for panicked NPCs).

Performance: Lightweight compared to pathfinding algorithms like A*.

## 📚 Learning Resources
Craig Reynolds' Original Paper (1999)

Game AI Pro: Steering Behaviors
