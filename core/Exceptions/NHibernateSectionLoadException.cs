namespace AIM.PBC.Core.Exceptions
{
	public sealed class NHibernateSectionLoadException : CoreException
	{
		private const string message = "Nhibernate section could not be loaded.";

		public NHibernateSectionLoadException() : base(message)
		{
		}
	}
}