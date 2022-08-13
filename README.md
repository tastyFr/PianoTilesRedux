# Piano Tiles Redux

[![Build Status](https://github.com/tastyFr/PianoTilesRedux/actions/workflows/ci.yml/badge.svg?branch=development)](https://github.com/tastyFr/PianoTilesRedux/actions/workflows/ci.yml)
[![CodeFactor](https://www.codefactor.io/repository/github/tastyfr/pianotilesredux/badge)](https://www.codefactor.io/repository/github/tastyfr/pianotilesredux)

Piano Tiles Redux is a fan-made rewrite of [Cheetah Games](https://en.wikipedia.org/wiki/Cheetah_Mobile)' original [Piano Tiles 2 game](https://en.wikipedia.org/wiki/Piano_Tiles_2) that attempts to recreate the design and gameplay, eventually, revive it.

## Status

This project is under heavy development, is currently in the early stages of development, and is not yet playable.

`README.md` is a work in progress, and is not yet complete.

Refactoring and cleanup will be done in the future after an alpha release.

## Features

Piano Tiles Redux adds the following features that are not present in the original game:

- Soundfonts support!
- Level searching!
- Cross-platform!
- Better graphics!
- Skins!

## Developing Piano Tiles Redux

This project uses the [osu!framework](https://github.com/ppy/osu-framework), a 2D application/game framework written with C# and rhythm games in mind.

To develop Piano Tiles Redux, please make sure you have the following prerequisites:

- A desktop platform with the [.NET 6.0 SDK](https://dotnet.microsoft.com/download) installed.
- To develop for mobile, [Xamarin](https://docs.microsoft.com/en-us/xamarin/) is required, and it comes bundled with either Visual Studio or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
- We recommend using an IDE with intelligent code completion and syntax highlighting when working with the codebase, such as the latest version of [Visual Studio](https://visualstudio.microsoft.com/vs/), [JetBrains Rider](https://www.jetbrains.com/rider/) or [Visual Studio Code](https://code.visualstudio.com/).
- These instructions are for if you have the [CLI git client](https://git-scm.com/) installed, but any other GUI client such as GitKraken or TortoiseGit would work just as well.
- If you are using Windows 7 or Windows 8, please make sure that you meet the [additional requirements](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60#dependencies), which you may need to install if your operating system is not up-to-date manually.
- To support video decoding when running on Linux, please make sure you have a system-wide FFmpeg installation available.

## Getting started

### I just want to run the game

Clone the repository:

```shell
git clone https://github.com/tastyFr/PianoTilesRedux.git
cd ./PianoTilesRedux
```

Navigate to `PianoTilesRedux.Desktop` and run the following command:

```shell
cd ./PianoTilesRedux.Desktop
dotnet run
```

### I want to make changes to the game

Anyone is welcome to contribute to this project. Feel free to open an issue or pull request.

To update the source code, run the following command:

```shell
git pull
```

<p style="text-align: center">
  <a href="https://github.com/ppy/osu-framework">
    <img src="https://github.com/ppy/osu-framework/raw/master/assets/o!f%20Logo%20Powered%20Horizontal%20Large%20FC.svg" alt="Powered by osu!framework">
  </a>
</p>
