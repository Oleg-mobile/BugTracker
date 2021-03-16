using System;

namespace BugTracker
{
    class Task
    {
		private Project project;
		private User    user;
		private int     type;
		private int     priority;
		private string  name;
		private string  description;

		public void createForm()
		{
            Console.WriteLine("Введите тему задачи:");
			string name = Console.ReadLine();
			this.name = name;

			Console.WriteLine("Введите описание задачи:");
			string description = Console.ReadLine();
			this.description = description;

			Console.WriteLine("Выберите приоритет задачи:");
			Console.WriteLine("1 - Срочно");
			Console.WriteLine("2 - Не срочно");
            try
            {
				int priority = int.Parse(Console.ReadLine());
				this.priority = priority;
			}
            catch (Exception e)
            {
				Console.WriteLine("Ошибка: {0}", e.ToString());
				Console.ReadLine();
			}

			Console.WriteLine("Выберите тип задачи:");
			Console.WriteLine("1 - Задача");
			Console.WriteLine("2 - Ошибка");
			try
			{
				int type = int.Parse(Console.ReadLine());
				this.type = type;
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка: {0}", e.ToString());
				Console.ReadLine();
			}
		}
		public void setUser(User user)
		{
			this.user = user;
		}
		public User getUser()
		{
			return user;
		}
		public void setProject(Project project)
		{
			this.project = project;
		}
		public Project getProject()
		{
			return project;
		}
		public Task()
		{ }
		public override string ToString()
		{
			string result = "[ Задание ";
			result += "\tТема = " + name + "\n";
			result += "\t\tТип = " + type + "\n";
			result += "\t\tПриоритет = " + priority + "\n";
			result += "\t\tОписание = " + description + "\n";
			result += "\t\tИмя пользователя = " + user + "\n";
			result += "\t\tНазвание проекта = " + project + " ]";
			return result;
		}
		public void initFromString(string str)
		{
			string[] fields = str.Split(',');
			name = fields[0];
			type = int.Parse(fields[1]);
			priority = int.Parse(fields[2]);
			description = fields[3];
		}
		public string getName()
		{
			return name;
		}
		public string toSave()
		{
			string result = this.name + ",";
			result = result + this.type + ",";
			result = result + this.priority + ",";
			result = result + this.description + "#";
			result = result + this.user.getName() + "#";
			result = result + this.project.getName();
			return result;
		}
	}
}
