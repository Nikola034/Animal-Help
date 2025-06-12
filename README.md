# 🐾 AnimalHelp

A modular desktop application for an animal adoption agency, built using WPF and C#, following Clean Architecture principles with JSON-based data storage.

---

## 📋 Table of Contents
- [About the Project](#about-the-project)
- [Architecture & Design](#architecture--design)
- [Tech Stack](#tech-stack)
- [Modeling & Documentation](#modeling--documentation)
- [Team & Collaboration](#team--collaboration)
- [My Contributions](#my-contributions)

---

<a name="about-the-project"></a>
## 📖 About the Project

**AnimalHelp** is a desktop application developed for an animal adoption agency. It facilitates:

- 🐶 **Members** — browsing animals and submitting adoption requests  
- 🐕 **Volunteers** — assisting with animal care and adoption processing  
- 🛡️ **Admins** — managing users, animals, and agency data  

The application supports CRUD operations for animal profiles, adoption requests, and user management. Data is stored in JSON files, and the UI is built using WPF.

---

<a name="architecture--design"></a>
## 🧱 Architecture & Design

- **Modular Structure**: The solution is divided into multiple projects to promote separation of concerns:
  - `Wpf`: WPF UI layer
  - `App`: DTOs, Services and Validators
  - `Core`: Shared utilities
  - `Domain`: Business logic and entities
  - `Repositories`: Data persistence and access
- **Dependency Injection**: Managed via `HostBuilder` to configure services and dependencies.
- **Data Storage**: Utilizes JSON files for data persistence, providing a lightweight and flexible storage solution.
- **UI Framework**: Built using WPF, adhering to MVVM (Model-View-ViewModel) pattern for separation of concerns and testability.

---

<a name="tech-stack"></a>
## 🧰 Tech Stack

| Category             | Technologies Used             |
|----------------------|-------------------------------|
| **Language**         | C#                            |
| **UI Framework**     | WPF                           |
| **Architecture**     | Modular, Clean Architecture   |
| **Data Storage**     | JSON files                    |
| **Dependency Injection** | HostBuilder               |
| **Modeling Tools**   | MagicDraw                     |

---

<a name="modeling--documentation"></a>
## 📊 Modeling & Documentation

- Extensive use of **UML diagrams** to document the system:
  - Class diagrams
  - Sequence diagrams
  - Activity diagrams
  - Object diagrams
  - State diagrams
- Modeled and tracked requirements rigorously
- All diagrams created with **MagicDraw** for clarity and collaboration

---

<a name="team--collaboration"></a>
## 🤝 Team & Collaboration

- Developed collaboratively by a team of **5 members**
- Followed structured design and implementation process
- Regular code reviews and specification alignment meetings

---

<a name="my-contributions"></a>
## 👨‍💻 My Contributions

- Worked on key modules related to animal management and adoption requests
- Implemented dependency injection setup using HostBuilder
- Developed core business logic in the Domain and Core layers
- Participated in UML diagram creation and refinement
- Contributed to WPF UI components and data binding
- Collaborated closely with team members during specification and design phases

---
