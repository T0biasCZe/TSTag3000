using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTag3000.db;

namespace TSTag3000.scripts {
	public class ffmpeg {
		public static List<string> images = new List<string> { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
		public static Bitmap GetThumbnail(string path) {
			Bitmap thumb;
			//if file has the images file extension
			if(images.Contains(System.IO.Path.GetExtension(path).ToLower())) {
				Bitmap inputBitmap = new Bitmap(path);
				if(inputBitmap.Width > inputBitmap.Height) {
					thumb = new Bitmap(inputBitmap, 160, 160 * inputBitmap.Height / inputBitmap.Width);
				}
				else {
					thumb = new Bitmap(inputBitmap, 160 * inputBitmap.Width / inputBitmap.Height, 160);
				}
				inputBitmap.Dispose();
				return thumb;
			}
			else {
				string thumbDir = Database.AppDataPath + "\\thumbnails";
				//get number of frames of the video from ffmpeg
				string command = $"ffprobe -v error -select_streams v:0 -count_frames -show_entries stream=nb_read_packets -of csv=p=0 '{path}'";
				ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + command) {
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				Process process = Process.Start(psi);
				process.WaitForExit();
				int frames = int.Parse(process.StandardOutput.ReadToEnd());
				process.Close();

				int frameToExtract;
				if(frames > 10) {
					frameToExtract = frames / 4;
				}
				else {
					frameToExtract = frames / 2;
				}

				//extract frame from video and downscale it to 160x160 (keeping aspect ratio, and dont downscale if smaller than 160x160)
				string outFileName = thumbDir + "\\" + System.IO.Path.GetFileNameWithoutExtension(path) + ".jpg";
				command = $"ffmpeg -i '{path}' -vf \"select='eq(n\\,{frameToExtract})',scale=w=160:h=160:force_original_aspect_ratio=decrease\" -q:v 0 -vframes 1 -y {outFileName}";
				psi = new ProcessStartInfo("cmd.exe", "/c " + command) {
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				process = Process.Start(psi);
				process.WaitForExit();
				process.Close();
				return new Bitmap(outFileName);
			}
		}
		
		public static bool CheckAnimated(string path) {
			if(File.Exists(path)) {
				//check with ffmpeg is the file has a video stream
				string command = $"ffprobe -select_streams v:0 -show_entries stream=codec_type -of csv=p=0 \"{path}\"";

				Process process = new Process();
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.Arguments = $"/c {command}";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				process.WaitForExit();
				string output = process.StandardOutput.ReadToEnd();

				process.Close();
				if(output.Contains("video")) {
					return true;
				}
				return false;
			}
			return false;
		}
		public static bool CheckSound(string path) {
			if(File.Exists(path)) {
				string command = $"ffmpeg -to 0:10 -i  \"{path}\"-map 0:a? -filter:a volumedetect -f null /dev/null";

				Process process = new Process();
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.Arguments = $"/c {command}";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				process.WaitForExit();
				string output = process.StandardOutput.ReadToEnd();
				process.Close();
				if(output.Contains("mean_volume")) {	
					float volume = float.Parse(output.Split("mean_volume: ")[1].Split(" dB")[0]);
					if(volume < -0.1f) {
						return true;
					}
				}
			}
			return false;
		}
	}
}
