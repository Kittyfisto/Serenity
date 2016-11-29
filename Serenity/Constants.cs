using System;
using System.IO;

namespace Serenity
{
	public static class Constants
	{
		public static readonly string ApplicationName;
		public static readonly string AppDataLocalFolder;
		public static readonly string ApplicationSettingsFileName;

		static Constants()
		{
			ApplicationName = "Serenity";

			var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			AppDataLocalFolder = Path.Combine(appData, ApplicationName);
			ApplicationSettingsFileName = Path.Combine(AppDataLocalFolder, "Settings.xml");
		}
	}
}