namespace AIM.Tools.DBA
{
	public abstract class Task
	{
		protected string _rootDir;

		public string RootDir
		{
			get { return _rootDir; }
			set { _rootDir = value; }
		}

		public Task()
		{
			_rootDir = null;
		}

		public abstract void Execute();
	}
}