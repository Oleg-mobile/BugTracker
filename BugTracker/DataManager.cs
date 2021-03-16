using System;
using System.Collections.Generic;

namespace BugTracker
{
    class DataManager
    {
        private List<User> users = new List<User>();
        private List<Project> projects = new List<Project>();
        private List<Task> tasks = new List<Task>();

        public DataManager()
        {}
        //-----------users-----------------------------------------
        public void addUser(User user)
        {
            users.Add(user);
        }
        public List<User> getUsers()
        {
            return new List<User>(users);
        }
        public void deleteUser(string name)
        {
            bool isUser = false;
            for (int i = 0; i < users.Count; i++)
            {
                User u = users[i];
                if (u.getName().Equals(name))
                {
                    users.RemoveAt(i--);
                    isUser = true;
                }
            }
            if (!isUser)
            {
                Console.WriteLine("Такого пользователя нет.");
                Console.ReadLine();
            }
        }
        public void PrintUserList()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i]);
            }
        }
        public User getUser(string name)
        {
            foreach (User u in users)
            {
                if (u.getName().Equals(name))
                {
                    return u;
                }
            }
            return null;
        }
        //-----------projects--------------------------------------
        public void addProject(Project project)
        {
            projects.Add(project);
        }
        public List<Project> getProjects()
        {
            return new List<Project>(projects);
        }
        public void deleteProject(string name)
        {
            bool isProject = false;
            for (int i = 0; i < projects.Count; i++)
            {
                Project p = projects[i];
                if (p.getName().Equals(name))
                {
                    projects.RemoveAt(i--);
                    isProject = true;
                }
            }
            if (!isProject)
            {
                Console.WriteLine("Такого проекта нет.");
                Console.ReadLine();
            }
        }
        public void PrintProjectList()
        {
            for (int i = 0; i < projects.Count; i++)
            {
                Console.WriteLine(projects[i]);
            }
        }
        public Project getProject(string name)
        {
            foreach (Project p in projects)
            {
                if (p.getName().Equals(name))
                {
                    return p;
                }
            }
            return null;
        }
        //-----------tasks-----------------------------------------
        public void addTask(Task task)
        {
            tasks.Add(task);
        }
        public List<Task> getTasks()
        {
            return new List<Task>(tasks);
        }
        public void deleteTask(string name)
        {
            bool isTask = false;
            for (int i = 0; i < tasks.Count; i++)
            {
                Task t = tasks[i];
                if (t.getName().Equals(name))
                {
                    tasks.RemoveAt(i--);
                    isTask = true;
                }
            }
            if (!isTask)
            {
                Console.WriteLine("Такой задачи нет.");
                Console.ReadLine();
            }
        }
        public void PrintTaskList()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine(tasks[i]);
            }
        }
        public Task getTask(string name)
        {
            foreach (Task t in tasks)
            {
                if (t.getName().Equals(name))
                {
                    return t;
                }
            }
            return null;
        }
        public List<Task> getTasksByProject(string projectName)
        {
            List<Task> result = new List<Task>();
            for (int i = 0; i < tasks.Count; i++)
            {
                Task t = tasks[i];
                if (t.getProject().getName().Equals(projectName))
                {
                    result.Add(t);
                }
            }
            return result;
        }
        public List<Task> getTasksByUser(string userName)
        {
            List<Task> result = new List<Task>();
            for (int i = 0; i < tasks.Count; i++)
            {
                Task t = tasks[i];
                if (t.getUser().getName().Equals(userName))
                {
                    result.Add(t);
                }
            }
            return result;
        }
    }
}
