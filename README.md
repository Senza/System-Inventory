# Inventory System

This project is an **Inventory Management System** built using **.NET Framework 4.7.2**. The system provides functionality to manage inventory items, track stock levels, and handle basic CRUD operations for inventory-related data.

---

## Project Structure

The solution consists of multiple projects organized into folders to maintain modularity and scalability:

### 1. **InvSysData**
- Handles the data layer of the application.
- Includes:
  - Database context and models.
  - Data access logic using **Entity Framework**.
  - Repository patterns for CRUD operations.

### 2. **InvSysUI.Library**
- Contains reusable components and logic shared between the user interface layers.
- Includes:
  - View models for data binding.
  - Validation utilities and common UI logic.

### 3. **InvSysUI**
- The user interface layer built with **Windows Forms** or **WPF** (depending on the setup).
- Includes:
  - Views for managing inventory, adding items, and viewing reports.
  - Interaction logic to communicate with the data layer.

### 4. **InventorySystem**
- The core project containing application logic.
- Includes:
  - Core business rules.
  - Interfaces for dependency injection.
  - Utilities and helpers for common functionality.

### 5. **InventorySystem.Library**
- A library of common code shared across the solution.
- Includes:
  - Utility methods for logging, file handling, and configuration management.
  - Constants and enums for the entire system.

---

## Prerequisites

- **.NET Framework 4.7.2**
- **SQL Server** for database storage.

---

## Getting Started

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Senza/System-Inventory.git
   cd System-Inventory
