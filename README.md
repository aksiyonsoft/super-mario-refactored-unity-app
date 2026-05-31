# Super Mario Bros (2D) — Unity 6

[![Unity](https://img.shields.io/badge/Unity-6000.3.8f1-000000?logo=unity)](https://unity.com/)
[![Repo](https://img.shields.io/badge/GitHub-aksiyonsoft%2Fsuper--mario--refactored--unity--app-blue?logo=github)](https://github.com/aksiyonsoft/super-mario-refactored-unity-app)

NES döneminin klasik 2D platformer deneyimini Unity 6 ile yeniden hayata geçiren eğitim ve referans projesi. Özel fizik, level tasarımı ve oyun hissi odaklı bir yapı sunar.

> **Bu proje [Aksiyonsoft](https://github.com/aksiyonsoft) ekibi tarafından geliştirilmiş olup; Unity 6 migrasyonu, mimari refactor, DevOps altyapısı ve proje teslimi [Yusuf Bozkurt](https://github.com/bbozkurtyusuf) tarafından yürütülmüştür.**

---

## Geliştirme Ekibi

<table>
  <tr>
    <td width="120">
      <img src="https://avatars.githubusercontent.com/u/211230291?s=400&u=57065f6086ad4f01db0cc27b0744f67752cf97cd&v=4" alt="Yusuf Bozkurt" width="120" style="border-radius: 50%;" />
    </td>
    <td>
      <strong>Yusuf Bozkurt</strong><br />
      Proje Lideri · Lead Developer<br />
      Software Engineer @ <a href="https://github.com/aksiyonsoft">Aksiyonsoft</a><br /><br />
      <a href="https://github.com/bbozkurtyusuf">GitHub</a> ·
      <a href="https://www.linkedin.com/in/yusuf-bozkurt-82b803294">LinkedIn</a>
    </td>
  </tr>
</table>

| | |
|---|---|
| **Organizasyon** | [Aksiyonsoft](https://github.com/aksiyonsoft) |
| **Proje sorumlusu** | Yusuf Bozkurt |
| **Repository** | [super-mario-refactored-unity-app](https://github.com/aksiyonsoft/super-mario-refactored-unity-app) |

---

## Özellikler

- Özel 2D fizik ve hareket sistemi (zıplama, koşma, kayma)
- Düşman etkileşimleri (Goomba, Koopa kabuğu)
- Power-up'lar (mantar, yıldız, coin, ekstra can)
- Boru geçişleri ve yeraltı bölümü
- Side-scrolling kamera
- `GameEvents` tabanlı gevşek bağlı mimari
- GitHub Actions CI/CD ve EditMode / PlayMode testleri

---

## Teknoloji Yığını

| Alan | Detay |
|------|-------|
| Motor | Unity **6000.3.8f1** (Unity 6 LTS) |
| Dil | C# · `SuperMario.*` namespace'leri |
| Input | Unity Input System + Legacy fallback |
| Test | Unity Test Framework |
| CI/CD | GitHub Actions · [Game CI](https://game.ci/) |

---

## Kurulum

1. [Unity Hub](https://unity.com/download) üzerinden **6000.3.8f1** sürümünü kurun.
2. Repoyu klonlayın:

```bash
git clone https://github.com/aksiyonsoft/super-mario-refactored-unity-app.git
```

3. Unity Hub → **Add** → proje klasörünü seçin.
4. Ana sahne: `Assets/_Project/Scenes/Worlds/1-1.unity`
5. Play Mode ile smoke test yapın.

---

## Proje Yapısı

```
Assets/
├── _Project/
│   ├── Art/              # Sprites, materials
│   ├── Prefabs/          # Characters, enemies, blocks, items, environment
│   ├── Scenes/Worlds/    # Level sahneleri
│   └── Settings/         # GameConfig, PlayerConfig, Input Actions
├── Scripts/
│   ├── Core/             # GameManager, GameEvents, InputReader
│   ├── Player/
│   ├── Enemies/
│   ├── Level/
│   ├── Blocks/
│   ├── Collectibles/
│   ├── UI/
│   └── Utilities/
├── Editor/
└── Tests/                # EditMode ve PlayMode testleri
```

---

## Test ve CI/CD

**Yerel test:**

```
Window → General → Test Runner → EditMode / PlayMode → Run All
```

**CI:** `.github/workflows/ci.yml` — her push'ta EditMode testleri. Cloud build için GitHub repo'ya `UNITY_LICENSE` secret ekleyin. Detaylar: [CONTRIBUTING.md](CONTRIBUTING.md)

---

## Katkıda Bulunma

Katkı kuralları, branch stratejisi ve PR checklist için [CONTRIBUTING.md](CONTRIBUTING.md) dosyasına bakın.

---

## Teşekkürler

Proje, eğitim amaçlı başlangıç kodu olarak [Zigurous Unity Super Mario Tutorial](https://github.com/zigurous/unity-super-mario-tutorial) üzerine inşa edilmiştir. Orijinal tutorial videosu: [YouTube Playlist](https://youtube.com/playlist?list=PLqlFiJjSZ2x1mrMpSQgYdRm8PyWRTg6He)

Detaylı atıf bilgisi: [CREDITS.md](CREDITS.md)

---

## Telif ve Yasal Not

Bu proje **eğitim ve portföy amaçlı** bir fan projesidir. **Nintendo** veya **Super Mario Bros** markaları ile resmi bir ilişkisi yoktur. Tüm orijinal oyun hakları ilgili sahiplerine aittir.
