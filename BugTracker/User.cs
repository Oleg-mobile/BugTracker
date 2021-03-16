using System;

namespace BugTracker
{
    class User
    {
        private string name;
		public User(string userName)
		{
			name = userName;
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
