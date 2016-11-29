namespace Serenity.Settings
{
	public sealed class ApplicationSettings
		: Metrolib.Settings.ApplicationSettings
	{
		public void Restore()
		{
			RestoreFrom(Constants.ApplicationSettingsFileName);
		}

		public void Save()
		{
			Save(Constants.ApplicationSettingsFileName);
		}
	}
}