import librosa
import librosa.display
from pydub import AudioSegment
import pydub
import matplotlib.pyplot as plt


def MP32WAV():
    """
    这是MP3文件转化成WAV文件的函数
    :param mp3_path: MP3文件的地址
    :param wav_path: WAV文件的地址
    """
    pydub.AudioSegment.converter = r"D:\ffmpeg\bin\ffmpeg.exe"
    pydub.AudioSegment.ffmpeg = r"D:\ffmpeg\bin\ffmpeg.exe"
    pydub.AudioSegment.ffprobe = r"D:\ffmpeg\bin\ffprobe.exe"
    MP3_File = AudioSegment.from_mp3(file="D:\\CloudMusic\\1.mp3")
    MP3_File1 = AudioSegment.from_mp3(file="D:\\CloudMusic\\4.mp3")
    MP3_File.export("D:\\CloudMusic\\out.wav", format="wav")
    MP3_File1.export("D:\\CloudMusic\\beijing.wav", format="wav")


MP32WAV();
y, sr = librosa.load("D:\\CloudMusic\\out.wav", sr=None)
y1, sr1 = librosa.load("D:\\CloudMusic\\beijing.wav", sr=None)

plt.figure()
librosa.display.waveplot(y, sr)
plt.title("ceshi1")
plt.show()

plt.figure()
librosa.display.waveplot(y1, sr1)
plt.title("ceshi2")
plt.show()


melspec = librosa.feature.melspectrogram(y, sr, n_fft=1024, hop_length=512, n_mels=128)
logmelspec = librosa.power_to_db(melspec)
plt.figure()
librosa.display.specshow(logmelspec, sr=sr, x_axis='time', y_axis='mel')
plt.title('ccceshi')
plt.show()

melspec1 = librosa.feature.melspectrogram(y1, sr1, n_fft=1024, hop_length=512, n_mels=128)
logmelspec = librosa.power_to_db(melspec)
librosa.display.specshow(logmelspec, x_axis='time', y_axis='mel')
librosa.display.waveplot(y=y, sr=sr)
logmelspec1 = librosa.power_to_db(melspec1)

librosa.display.waveplot(y1, sr=sr1, x_axis='time', offset=0.0, ax=None)
print(logmelspec.shape)
print(logmelspec1.shape)
print(y1);
print(sr1);
print(y);
print(sr);
