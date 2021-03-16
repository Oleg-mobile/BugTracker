using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("Введите имя файла с данными:");
            string fileName = Console.ReadLine();

            DataManager dataManager = new DataManager();
            FileManager fileManager = new FileManager(fileName);
            fileManager.FileLoad(dataManager);

            fileManager.CreateFileLog();
            List<string> logs = new List<string>();

            string menu = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Добавить пользователя:");
                Console.WriteLine("2. Удалить пользователя:");
                Console.WriteLine("3. Список всех пользователей:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("4. Добавить проект:");
                Console.WriteLine("5. Удалить проект:");
                Console.WriteLine("6. Список всех проектов:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("7. Добавить задачу:");
                Console.WriteLine("8. Удалить задачу:");
                Console.WriteLine("9. Список задач по проекту:");
                Console.WriteLine("10. Список задач пользователя:");
                Console.WriteLine("11. Список всех задач:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("q. Выход:");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1": // Add User
                        Console.WriteLine("Введите имя пользователя:");
                        string userNameToCr = Console.ReadLine();
                        User user = new User(userNameToCr);
                        dataManager.addUser(user);
                        logs.Add(DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") + " add user " + userNameToCr);
                        break;
                    case "2": // Dell User
                        dataManager.PrintUserList();
                        Console.WriteLine("Выберите пользователя:");
                        string userNameToDel = Console.ReadLine();

                        List<Task> taskUser = dataManager.getTasksByUser(userNameToDel);
                        if (taskUser.Count == 0)
                        {
                            dataManager.deleteUser(userNameToDel);
                            logs.Add(DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") + " dell user " + userNameToDel);
                        }
                        else
                        {
                            Console.WriteLine("Этого пользователя удалять нельзя");
                            Console.ReadLine();
                        }
                        break;
                    case "3": // Show Users List
                        Console.WriteLine("Список пользователей:");
                        dataManager.PrintUserList();
                        Console.ReadLine();
                        break;
                    case "4": // Add Project
                        Console.WriteLine("Введите название проекта:");
                        string projectNameToCr = Console.ReadLine();
                        Project project = new Project(projectNameToCr);
                        dataManager.addProject(project);
                        logs.Add(DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") + " add project " + projectNameToCr);
                        break;
                    case "5": // Dell Project
                        dataManager.PrintProjectList();
                        Console.WriteLine("Выберите проект:");
                        string projectNameToDel = Console.ReadLine();

                        List<Task> taskProject = dataManager.getTasksByProject(projectNameToDel);
                        if (taskProject.Count == 0)
                        {
                            dataManager.deleteProject(projectNameToDel);
                            logs.Add(DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") + " dell project " + projectNameToDel);
                        }
                        else
                        {
                            Console.WriteLine("Этот проект удалять нельзя");
                            Console.ReadLine();
                        }
                        break;
                    case "6": // Show Projects List
                        Console.WriteLine("Список проектов:");
                        dataManager.PrintProjectList();
                        Console.ReadLine();
                        break;
                    case "7": // Add Task                                        
                        Task task = new Task();

                        task.createForm();

                        dataManager.PrintUserList();
                        Console.WriteLine("Выберите пользователя:");
                        string addUser = Console.ReadLine();
                        List<User> user2 = dataManager.getUsers();
                        if (user2.Count == 0)
                        {
                            Console.WriteLine("Пользователей нет");
                            Console.ReadLine();
                            break;
                        }

                        bool isUser = false, isProject = false;

                        for (int i = 0; i < user2.Count; i++)
                        {
                            if (user2[i].getName().Equals(addUser))
                            {
                                task.setUser(user2[i]);
                                isUser = true;
                                
                            }
                        }

                        if (!isUser)
                        {
                            Console.WriteLine("Пользователь не найден");
                            Console.ReadLine();
                            break;
                        }

                        dataManager.PrintProjectList();
                        Console.WriteLine("Выберите проект:");
                        string addProj = Console.ReadLine();
                        List<Project> proj2 = dataManager.getProjects();

                        if (proj2.Count == 0)
                        {
                            Console.WriteLine("Проектов нет");
                            Console.ReadLine();
                            break;
                        }

                        for (int i = 0; i < proj2.Count; i++)
                        {
                            if (proj2[i].getName().Equals(addProj))
                            {
                                task.setProject(proj2[i]);
                                isProject = true;
                            }
                        }

                        if (!isProject)
                        {
                            Console.WriteLine("Проект не найден");
                            Console.ReadLine();
                            break;
                        }

                        dataManager.addTask(task);
                        logs.Add(DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") + " add task " + task.getName());
                        break;
                    case "8": // Dell Task
                        dataManager.PrintTaskList();
                        Console.WriteLine("Выведите тему задачи:");
                        string taskNameToDel = Console.ReadLine();
                        dataManager.deleteTask(taskNameToDel);
                        logs.Add(DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss") + " dell task " + taskNameToDel);
                        break;
                    case "9": // Show Tasks List By Project
                        dataManager.PrintProjectList();
                        Console.WriteLine("Выберите проект:");
                        string projectInTask = Console.ReadLine();
                        List<Task> tasksByProject = dataManager.getTasksByProject(projectInTask);

                        if (tasksByProject.Count == 0)
                        {
                            Console.WriteLine("Нет задачи с таким проектом");
                            Console.ReadLine();
                            break;
                        }

                        foreach (Task tsk in tasksByProject)
                        {
                            Console.WriteLine(tsk);
                        }
                        Console.ReadLine();
                        break;
                    case "10": // Show Tasks List By User
                        dataManager.PrintUserList();
                        Console.WriteLine("Выберите пользователя:");
                        string userInTask = Console.ReadLine();
                        List<Task> tasksByUser = dataManager.getTasksByUser(userInTask);
                        
                        if (tasksByUser.Count == 0)
                        {
                            Console.WriteLine("Нет задачи с таким пользователем");
                            Console.ReadLine();
                            break;
                        }
                        
                        foreach (Task tsk in tasksByUser)
                        {
                            Console.WriteLine(tsk);
                        }
                        Console.ReadLine();
                        break;
                    case "11": //Show Tasks List
                        Console.WriteLine("Список задач:");
                        dataManager.PrintTaskList();
                        Console.ReadLine();
                        break;
                    case "q": // Quit
                        fileManager.FileSave(dataManager);

                        if (logs.Count != 0)
                        {
                            fileManager.WriteLog(logs);
                            logs.Clear();
                        }    
                        
                        Console.WriteLine("До свидания!");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Ошибка ввода");
                        Console.ReadLine();
                        break;
                }
                fileManager.FileSave(dataManager);
            }
        }
    }
}
