# SecretEye - Cybersecurity Awareness Chatbot (PROG6221 POE)

SecretEye is a cybersecurity awareness assistant built for PROG6221.
**Part 1** is a C# console application; **Part 2** rebuilds it as a Windows Forms
GUI and makes it smarter with keyword recognition, random responses, conversation
flow, memory and sentiment detection. **Part 3** extends the GUI into a full app
with a MySQL-backed task assistant, a cybersecurity quiz game, natural-language
command recognition and an activity log.

## Student Details

- Name: Ethan Fourie
- Student Number: ST10499894

## Project Overview

SecretEye greets the user with a recorded voice message and an ASCII logo,
recognises cybersecurity topics in what the user types, and responds with
helpful guidance on staying safe online. In Part 2 it also remembers details
the user shares, adjusts its tone to the user's mood, and runs inside a
graphical chat window. In Part 3 the window becomes a tabbed app: Chat, Tasks,
Quiz and Activity Log.

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

### Cybersecurity Topics Supported

Passwords, phishing, scams, safe browsing, 2FA, privacy, malware and social engineering.

## Part 3 (Final POE)

Part 3 reorganises the GUI into tabs and adds four new features. The existing
chat (Parts 1 and 2) still works and lives in the **Chat** tab.

### Part 3 Features

- **Tabbed interface** - Chat, Tasks, Quiz and Activity Log tabs in one window
- **Task Assistant with MySQL** - add cybersecurity tasks with a title, description and optional reminder date; tasks are saved in a MySQL database and persist between runs; mark complete, delete and refresh
- **Cybersecurity quiz game** - 12 questions (multiple choice and true/false), one at a time, with instant feedback, a running score and a final result
- **NLP command recognition** - typing things like "add a task", "set a reminder", "start the quiz" or "show my activity" in the chat opens the right tab
- **Activity log** - a running summary of recent actions (tasks added/completed/deleted, quiz started/finished, chat questions, NLP commands), newest first, showing the last 5 or up to 10

### GUI Overview

The window opens on the **Chat** tab (title bar, ASCII logo, scrolling chat area,
text box and Send button - user messages in cyan, bot replies in green). The
**Tasks**, **Quiz** and **Activity Log** tabs hold the Part 3 features. Press
**Enter** or click **Send** to chat; type **exit** to close.

## Database Setup (Part 3)

The Task Assistant stores tasks in a MySQL database. You need MySQL 8.0

1. Open MySQL and run:

   ```sql
   CREATE DATABASE CyberSecurityBotDB;
   USE CyberSecurityBotDB;

   CREATE TABLE cyber_tasks (
       task_id INT AUTO_INCREMENT PRIMARY KEY,
       title VARCHAR(255) NOT NULL,
       description TEXT,
       reminder_date DATE NULL,
       is_completed TINYINT(1) NOT NULL DEFAULT 0
   );
   ```

2. Open `SecretEyeGUI/DatabaseConfig.cs` and replace `YOUR_PASSWORD` with your
   own MySQL root password:

   ```
   Server=localhost;Port=3306;Database=CyberSecurityBotDB;Uid=root;Pwd=YOUR_PASSWORD;
   ```

3. The `MySql.Data` NuGet package is referenced by `SecretEyeGUI`

## How to Run the Project

1. Clone or download this repository.
2. Open `SecretEyeBot.slnx` in Visual Studio 2022 or later.
3. For Part 2/3, set **SecretEyeGUI** as the startup project (right-click it -> Set as Startup Project).
   For Part 1, set **SecretEyeBot** instead.
4. For Part 3, complete the **Database Setup** above first.
5. Build the solution (Ctrl + Shift + B).
6. Run (Ctrl + F5).

Make sure `SecretEyeGUI/Audio/greeting.wav` is present so the voice greeting plays.

## Project Structure

```
SecretEye (solution)
+-- SecretEyeBot        Part 1 console application
+-- SecretEyeGUI        Part 2 /Part 3 Windows Forms application
    +-- Program.cs
    +-- ChatbotForm.cs / ChatbotForm.Designer.cs   GUI, tabs and events
    +-- ChatBot.cs           coordinator + BotResponseHandler delegate
    +-- ResponseHandler.cs   keyword recognition, random + follow-up responses
    +-- MemoryStore.cs       remembered name, favourite topic, current topic
    +-- SentimentDetector.cs mood detection (Sentiment enum)
    +-- AsciiArt.cs          ASCII branding
    +-- VoiceGreeting.cs     plays the WAV greeting
    +-- DatabaseConfig.cs    MySQL connection string
    +-- CyberTask.cs         task model
    +-- TaskRepository.cs    task database CRUD (MySql.Data)
    +-- ActivityLogger.cs    in-session activity log
    +-- QuizQuestion.cs      quiz question model
    +-- QuizAnswerResult.cs  quiz answer feedback
    +-- QuizManager.cs       quiz questions and scoring
    +-- NlpProcessor.cs      command recognition from chat input
    +-- Audio/greeting.wav   recorded voice greeting
```

## Requirements

- Visual Studio 2022+ with the ".NET desktop development" workload
- .NET 8 SDK
- Windows (required for `System.Media.SoundPlayer` audio)
- MySQL 8.0

## GitHub & Continuous Integration

This repository uses GitHub Actions to restore and build both projects on every
push. A successful run shows a green check mark under the **Actions** tab.

<img width="1303" height="413" alt="image" src="https://github.com/user-attachments/assets/a3ff9a2e-8373-4d0d-825f-c7517d8c0950" />

## Tags and Releases

- `v2.0-gui` - Part 2 GUI with Part 1 voice, branding and responses
- `v2.1-dynamic-responses` - keyword recognition, random responses and conversation flow
- `v2.2-memory-sentiment` - memory, sentiment detection, error handling and final polish
- `v3.0-database` - tabbed layout, MySQL connection and task assistant CRUD
- `v3.1-quiz-nlp` - cybersecurity quiz game and NLP command recognition
- `v3.2-final` - activity log, full integration, README and final testing

## Video Presentations

- Part 1 (console): https://youtu.be/X3wan-jAqdU
- Part 2 (GUI): https://youtu.be/z4XlbjML-WU
- Part 3 (Final POE): 
