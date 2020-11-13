# ProceduralSokoban
## Abstract

This project is a procedural level generator for Sokoban game. It's written in C#. This project was made for a Master 2 school project. With this project you can generate level for the Sokoban game. The scientific paper of Joshua Taylor and Ian Parberry entitled "Procedural Generation of Sokoban Levels" help us to create our algorithm. 

## Installation
### Windows

You just need to download .NET SDK and .NET runtime ([here](https://docs.microsoft.com/fr-fr/dotnet/core/install/windows?tabs=net50))

### MacOS

Download and install .NET SDK ([here](https://dotnet.microsoft.com/download))

### Linux

Run these commands to install .NET on Ubuntu 20.04

Add Microsoft Package Signature
```
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

Install SDK and runtime
```
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0 \
  sudo apt-get install -y aspnetcore-runtime-5.0

```

## How does it works ?
### Templates

### Level cleaning
### Crates placement
### Goals placement
### Player placement

## Result

You can just print the generated level in the terminal or you can export multiple generated level with the `export()` function

## Test

You can test generated level with JSoko ([link](https://www.sokoban-online.de/)). You just have to copy the generated level and import it in JSoko. We use the level format of JSoko, so there is no compatibilty issue.

## Unity

We have made an implementation of the project in Unity. You find the associated repository ([here]()) and you can download differents builds ([here]()). We chose Unity because we wanted improve our skills on that software.

## Improvements

List of improvement for this project :
- Dead Cell detection
- Automatic test for generate level (create metrics, then report)
- Clean useless wall around level

## Sources

- http://ianparberry.com/techreports/LARC-2011-01.pdf
- http://ianparberry.com/research/sokoban/

