# SecretEye - Cybersecurity Awareness Chatbot (PROG6221 POE Part 1)

A C# console application that acts as a friendly cybersecurity awareness
assistant. It greets the user with a recorded voice message and an ASCII
logo, asks for their name, and answers questions about staying safe online.

## Student

- Name: Ethan Fourie
- Student Number: ST10499894

## Project Description

SecretEye is a rule-based chatbot. 
It plays a WAV voice greeting when it starts, shows a cybersecurity-themed ASCII header, 
personalises the chat with the user's name, and responds to questions about passwords, phishing, scams,
safe browsing, 2FA and privacy. It keeps running in a conversation loop until
the user types `exit`, and handles blank or unrecognised input gracefully.

## Features

- Recorded voice greeting (WAV, played with `System.Media.SoundPlayer`)
- Cybersecurity-themed ASCII art header
- Personalised greeting that asks for and validates the user's name
- Responses on passwords, phishing, scams, safe browsing, 2FA and privacy
- Varied answers for each topic
- Input validation for blank and unsupported input
- Coloured, structured console interface with dividers
- Code separated into classes: `Chatbot`, `VoiceGreeting`, `AsciiArt`,
  `ResponseHandler`, `UserProfile` (kept out of `Program.cs`)

## How to Run

1. Clone or download this repository.
2. Open `SecretEyeBot.slnx` in Visual Studio 2022 or later.
3. Build the solution.
4. Run.

## Requirements

- Visual Studio 2022+ with the ".NET desktop development" workload
- .NET 8 SDK
- Windows (required for `System.Media.SoundPlayer` audio)

## GitHub Actions (Continuous Integration)

This repository uses GitHub Actions to restore and build the project on every
push. A successful run shows a green check mark under the **Actions** tab.

<img width="1303" height="413" alt="image" src="https://github.com/user-attachments/assets/a3ff9a2e-8373-4d0d-825f-c7517d8c0950" />



## Video Presentation

Unlisted YouTube link: https://youtu.be/X3wan-jAqdU
