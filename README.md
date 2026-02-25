# Unity Game Development Workshops

This repository contains the project files and materials for a series of
game development workshops built with **Unity 2022.3.24f1 (LTS)**.

The workshops are structured progressively, covering core Unity concepts
such as:

-   Scene setup and project structure\
-   GameObjects and Components\
-   Input handling\
-   Physics and collisions\
-   Prefabs\
-   UI basics\
-   Basic scripting in C#\
-   Build and deployment workflow

Each workshop builds on previous concepts and is designed to be
practical and hands-on.

------------------------------------------------------------------------

## Requirements

Before cloning the project, make sure you have:

-   Unity Hub\
-   Unity Editor 2022.3.24f1 (LTS)\
-   Git installed

You must use the same Unity version to avoid serialization or
compatibility issues.

------------------------------------------------------------------------

## Getting the Project

### Option 1 --- Clone via Git (Recommended)

``` bash
git clone https://github.com/ADM2005/GameDevWorkshops2026.git
```

Then:

1.  Open Unity Hub\
2.  Click **Add**\
3.  Select the cloned project folder\
4.  Make sure Unity Hub selects **2022.3.24f1**\
5.  Open the project

Unity will reimport assets on first launch. This may take a few minutes.

------------------------------------------------------------------------

### Option 2 --- Pull Updates (If You Already Cloned)

Inside the project folder:

``` bash
git pull
```

After pulling:

-   Open Unity (or let it recompile if already open)\
-   Allow scripts and assets to reimport

------------------------------------------------------------------------

## Project Structure

    Assets/
        Scripts/
        Scenes/
        Prefabs/
        Materials/
    ProjectSettings/
    Packages/

-   `Assets/` contains all game content.\
-   `ProjectSettings/` stores Unity configuration.\
-   `Packages/` manages Unity packages and dependencies.

The `.gitignore` is configured for Unity and common IDEs, so generated
files (Library, Temp, etc.) are excluded.

------------------------------------------------------------------------

## Branching (Optional)

If the workshops are split into stages, branches may be structured as:

-   `main` → Final version\
-   `workshop-01` → Intro scene setup\
-   `workshop-02` → Player movement

Participants can switch branches using:

``` bash
git checkout workshop-02
```

------------------------------------------------------------------------

## Troubleshooting

**Project won't open?** - Confirm you are using Unity 2022.3.24f1.\
- Try closing Unity and reopening via Unity Hub.

**Compilation errors after pull?** - Close Unity\
- Delete the `Library/` folder\
- Reopen the project (Unity will regenerate it)

------------------------------------------------------------------------

## Notes for Participants

-   Do not commit the `Library/`, `Temp/`, or `Build/` folders.\
-   Always pull before starting a new session.\
-   If conflicts occur, ask the workshop instructor before resolving
    them manually.
