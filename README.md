![Total downloads](https://img.shields.io/github/downloads/x0jony/Blackout/total)

# Blackout
Blackout is an EXILED plugin for SCP: Secret Laboratory which disables all facility lights and provides every player with a flashlight if they don't have one at the start of the round, based on a probability.

## Features
- Starts at the start of the round based on a probability.
- Force the blackout to occur next round with a command:
  - `.blackout/.bl force/f` (Remote Admin)
- If the blackout occurs:
  - Disables all facility lights.
  - Provides all players with a flashlight if they don't have one.
  - Announces the blackout with a cool C.A.S.S.I.E message.
  - Disables all tesla gates.

## Installation
1. Download the [latest release](https://github.com/x0jony/Blackout/releases/latest) of the plugin from the GitHub repository.
2. Place the `Blackout.dll` file in your `EXILED/Plugins` directory.
3. Restart your SCP: Secret Laboratory server.

## Configuration
Blackout can be configured via the EXILED config file at `EXILED/Configs/{port}-config.yml`.

### Default Configuration
```yaml
blackout:
  # Whether or not this plugin is enabled on the server.
  is_enabled: true
  # Whether or not to show logs used for debugging.
  debug: false
  # Probability of the blackout occuring. (1 out of X)
  rarity: 3
```

## Credits
This plugin was originally [joker-119](https://github.com/joker-119)'s [idea](https://github.com/joker-119/SCPSL-Gamemodes), but since his version of the blackout had no builds and it was outdated, I decided to remake it with some different features.