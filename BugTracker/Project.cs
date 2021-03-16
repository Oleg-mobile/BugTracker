using System;

namespace BugTracker
{
    class Project
    {
		private string name;
		public Project(string projectName)
		{
			name = projectName;
		}
		public override string ToString()
		{
			return name;
		}
		public string getName()
		{
			return name;
		}
	}
}
