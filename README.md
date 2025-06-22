# 🎵Simple YouTube 2 MP3

A simple WPF desktop application for downloading audio from YouTube videos using [yt-dlp](https://github.com/yt-dlp/yt-dlp).  
It allows user to select a destination folder and converts the audio to `.mp3` using `ffmpeg`.

---

## 🚀 Features

- ✅ Download audio from YouTube videos via `yt-dlp`
- ✅ Convert to `.mp3` using `ffmpeg`
- ✅ User-friendly WPF interface
- ✅ Lets the user choose the output folder
- ✅ Handles basic errors and download status

---
## 🔮 Upcoming features
- Better error handling
- Better menu & layout
- Button to update `yt-dlp`

---

## 🧰 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Python 3.9+](https://www.python.org/)
- `yt-dlp` installed:
  ```bash
  pip install -U yt-dlp
  ```
- ffmpeg added to system PATH: [ffmpeg](https://ffmpeg.org/download.html)

---
## 📦 How to Build & Run
1. Clone the repo:
    ```bash
    git clone https://github.com/piotrjarz/SimpleYT2MP3.git
    ```
2. Open the .sln file in Visual Studio
3. Make sure the python script:
    - Is marked as Content
    - Has `Copy to Output Directory` set to `Copy if newer`
4. Build and run the project

---
## 🖥️ How it works
1. User enters a YouTube link
2. User chooses the output folder
3. Applicaton launches python script with link and selected folder as arguments
4. `yt-dlp` downloads and converts the file
5. Success/Error message(s) are shown

---
## ⚠️ Notes
* Some YouTube videos may fail due to signature encryption or age restrictions.
* Always ensure `yt-dlp` and `ffmpeg` are up to date.

---
## 📃 License
MIT License – feel free to use, modify, and distribute


---
## Credits
* [yt-dlp](https://github.com/yt-dlp/yt-dlp)
* [ffmpeg](https://ffmpeg.org/)
