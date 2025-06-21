import os
import sys
import yt_dlp
from pathlib import Path

def download_with_ytdlp(link, target_path):
    download_target_path = ""
    if target_path == "":
        download_target_path = str(Path.home() / "Downloads")
    else:
        download_target_path = str(target_path)
    
    ydl_opts = {
        'format': 'bestaudio/best',
        'outtmpl': f'{download_target_path}/%(title)s.%(ext)s',
        'postprocessors': [{
            'key': 'FFmpegExtractAudio',
            'preferredcodec': 'mp3',
            'preferredquality': '192',
        }],
    }
    try:
        with yt_dlp.YoutubeDL(ydl_opts) as ydl:
            ydl.download([link])
        print("Pobieranie zakończone pomyślnie przy użyciu yt-dlp.")
    except Exception as e:
        print(f"Błąd w yt-dlp: {e}")

if __name__ == "__main__":
    link = str(sys.argv[1])
    target_path = str(sys.argv[2])
    download_with_ytdlp(link, target_path)

