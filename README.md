# SecretEye - Cybersecurity Awareness Chatbot (PROG6221 POE)

SecretEye is a cybersecurity awareness assistant built for PROG6221.
**Part 1** is a C# console application; **Part 2** rebuilds it as a Windows Forms
GUI and makes it smarter with keyword recognition, random responses, conversation
flow, memory and sentiment detection.

## Student Details

- Name: Ethan Fourie
- Student Number: ST10499894

## Project Overview

SecretEye greets the user with a recorded voice message and an ASCII logo,
recognises cybersecurity topics in what the user types, and responds with
helpful guidance on staying safe online. In Part 2 it also remembers details
the user shares, adjusts its tone to the user's mood, and runs inside a
graphical chat window.

## Part 1 (Console Application)

The original console chatbot: a WAV voice greeting, ASCII header, a personalised
greeting that asks for and validates the user's name, keyword-based responses,
input validation and a coloured console interface. Project folder: `SecretEyeBot`.

## Part 2 (Windows Forms GUI)

Part 2 carries all of Part 1 into a graphical interface and adds dynamic
behaviour. Project folder: `SecretEyeGUI`.

### Part 2 Features

- Windows Forms GUI with a title, ASCII branding, chat history, input box and Send button
- Voice greeting and ASCII branding from Part 1, translated into the GUI
- **Keyword recognition** across a range of topics, including common wording variations
- **Random responses** so repeated questions stay varied
- **Conversation flow** - "tell me more" and similar continue the current topic
- **Memory and recall** - remembers the user's name and favourite topic and reuses them
- **Sentiment detection** - notices worried / curious / frustrated wording and adjusts tone while still giving a tip
- Error handling so blank, unknown or unexpected input never crashes the app
- A **generic collection** (`Dictionary<string, List<string>>`) and a **delegate** (`BotResponseHandler`)

### GUI Overview

The window shows a title bar, the SecretEye ASCII logo, a scrolling chat area
(user messages in cyan, bot replies in green), a text box and a Send button.
Press **Enter** or click **Send** to chat; type **exit** to close.

### Cybersecurity Topics Supported

Passwords, phishing, scams, safe browsing, 2FA, privacy, malware and social engineering.

### Memory and Sentiment Features

- Say "my name is ..." and the bot remembers and reuses your name.
- Say "I'm interested in ..." to set a favourite topic it recalls later.
- Express a feeling (e.g. "I'm worried about scams") and the bot adapts its tone
  while still giving real cybersecurity guidance.

## How to Run the Project

1. Clone or download this repository.
2. Open `SecretEyeBot.slnx` in Visual Studio 2022 or later.
3. For Part 2, set **SecretEyeGUI** as the startup project (right-click it -> Set as Startup Project).
   For Part 1, set **SecretEyeBot** instead.
4. Build the solution (Ctrl + Shift + B).
5. Run (Ctrl + F5).

Make sure `SecretEyeGUI/Audio/greeting.wav` is present so the voice greeting plays.

## Project Structure

```
SecretEye (solution)
+-- SecretEyeBot        Part 1 console application
+-- SecretEyeGUI        Part 2 Windows Forms application
    +-- Program.cs
    +-- ChatbotForm.cs / ChatbotForm.Designer.cs   GUI and events
    +-- ChatBot.cs           coordinator + BotResponseHandler delegate
    +-- ResponseHandler.cs   keyword recognition, random + follow-up responses
    +-- MemoryStore.cs       remembered name, favourite topic, current topic
    +-- SentimentDetector.cs mood detection (Sentiment enum)
    +-- AsciiArt.cs          ASCII branding
    +-- VoiceGreeting.cs     plays the WAV greeting
    +-- Audio/greeting.wav   recorded voice greeting
```

## Requirements

- Visual Studio 2022+ with the ".NET desktop development" workload
- .NET 8 SDK
- Windows (required for `System.Media.SoundPlayer` audio)

## GitHub & Continuous Integration

This repository uses GitHub Actions to restore and build the project on every
push. A successful run shows a green check mark under the **Actions** tab.

<img width="1303" height="413" alt="image" src="https://github.com/user-attachments/assets/a3ff9a2e-8373-4d0d-825f-c7517d8c0950" />

## Tags and Releases

- `v2.0-gui` - Part 2 GUI with Part 1 voice, branding and responses
- `v2.1-dynamic-responses` - keyword recognition, random responses and conversation flow
- `v2.2-memory-sentiment` - memory, sentiment detection, error handling and final polish

## Video Presentations

- Part 1 (console): https://youtu.be/X3wan-jAqdU
- Part 2 (GUI): https://youtu.be/z4XlbjML-WU
