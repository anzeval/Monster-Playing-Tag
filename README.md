# Monster-Playing-Tag
A small 2D survival arena game made in Unity. The player moves freely inside a closed arena while enemies spawn outside and move directly toward the player. The goal is to survive as long as possible. The project focuses on clean architecture, game state management, and event-driven systems.

# 🎮 2D Survival Arena Game

---

## 📸 Screenshots

<img width="1685" height="941" alt="Screenshot 2026-02-19 at 22 51 27" src="https://github.com/user-attachments/assets/9a0aff27-d488-45d6-bfad-2b818ea83503" />
<img width="1684" height="943" alt="Screenshot 2026-02-19 at 22 50 27" src="https://github.com/user-attachments/assets/e41d582f-29a4-42c3-aafb-e25da4e6e228" />
<img width="1689" height="942" alt="Screenshot 2026-02-19 at 22 50 52" src="https://github.com/user-attachments/assets/eb19fcd6-fc27-4098-a97c-0c04aafd3f46" />

---

## 🕹️ Gameplay

- The player moves freely on the X/Y axis using **WASD**
- Enemies spawn outside the arena boundaries
- Each enemy moves directly toward the player with constant speed
- Collision with any enemy results in **Game Over**
- The goal is to survive as long as possible and beat the best score

---

## ✨ Features

- 2D top-down survival gameplay
- Rigidbody2D-based movement
- Infinite enemy spawning
- Time-based score system
- Best score tracking
- Game Over screen with restart button
- Clean and minimal UI

---

## 🧱 Architecture Overview

The project is structured with clear separation of responsibilities:

- **GameManager**
  - Controls game states (Playing / Game Over)
  - Tracks survival time
  - Stops the game on defeat

- **Player**
  - Handles movement input and physics
  - Detects collisions with enemies

- **Enemy**
  - Moves directly toward the player
  - Signals defeat on collision

- **EnemySpawner**
  - Spawns enemies at a fixed interval
  - Chooses random spawn positions outside the arena

- **UI**
  - Displays survival time and best score
  - Reacts to game state changes

Communication between systems is handled using events where appropriate.

---

## 🛠️ Technologies Used

- Unity (2D)
- C#
- Rigidbody2D
- Canvas UI
- Event-driven architecture

---

## 🚀 Possible Improvements

- Object pooling for enemies
- Dynamic difficulty scaling
- Pause system
- Additional enemy types

---

## 📂 How to Run

1. Clone the repository  
2. Open the project in **Unity Hub**
3. Load the main scene
4. Press **Play**

---

## 📌 Project Purpose

This project was created as a **portfolio piece**, focusing on:
- Clean code
- Proper architecture
- Separation of concerns
- Stable and reproducible gameplay

---
