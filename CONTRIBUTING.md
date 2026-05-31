# Contributing

## Requirements

- Unity **6000.3.8f1** (Unity 6 LTS)
- Git LFS (if enabled for the repo)

## Setup

1. Clone the repository.
2. Open the project folder in Unity Hub with editor **6000.3.8f1**.
3. Let Unity import assets and resolve packages.

## Branch workflow

- `main` — stable branch; CI must pass before merge
- `develop` — integration branch for features
- `feature/*` — single-topic branches opened as PRs

## Before opening a PR

1. Run **EditMode** tests: Window → General → Test Runner → EditMode → Run All
2. Smoke-test in Play Mode on scene `Assets/_Project/Scenes/Worlds/1-1.unity`
3. Fill in the PR template checklist

## CI

GitHub Actions uses [Game CI](https://game.ci/). Workflows:

- `ci.yml` — EditMode and PlayMode tests on push/PR
- `build.yml` — Windows standalone build on `main`
- `activation.yml` — one-time Unity license file generation (manual dispatch)

### One-time GitHub setup

1. Run **Actions → Acquire Unity Activation File → Run workflow**
2. Download the artifact and copy its contents into repo secret **`UNITY_LICENSE`**
3. Optionally add **`UNITY_EMAIL`** and **`UNITY_PASSWORD`**

See [Unity activation docs](https://game.ci/docs/github/activation).

## Code conventions

- Scripts live under `Assets/Scripts/` with namespaces `SuperMario.*`
- Gameplay events go through `SuperMario.Core.GameEvents` instead of direct singleton calls
- Keep `.meta` files with moved assets to preserve GUID references

---

## Proje Sahibi

| | |
|---|---|
| **Organizasyon** | [Aksiyonsoft](https://github.com/aksiyonsoft) |
| **Proje sorumlusu** | [Yusuf Bozkurt](https://github.com/bbozkurtyusuf) |
| **Repository** | [aksiyonsoft/super-mario-refactored-unity-app](https://github.com/aksiyonsoft/super-mario-refactored-unity-app) |

Bu proje Aksiyonsoft ekibi tarafından geliştirilmiş olup proje yönetimi ve teslimi Yusuf Bozkurt tarafından yürütülmüştür. Atıf detayları için [CREDITS.md](CREDITS.md) dosyasına bakın.
