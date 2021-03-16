using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker
{
    class FileManager
    {
        private string fileName;
        public FileManager(string fileName)
        {
            this.fileName = fileName;
        }
        public void FileLoad(DataManager dataManager)
        {
            if (!File.Exists(fileName))
            {
                try
                {
                    _ = File.Create(fileName);
                    Console.WriteLine("Файл создан!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: {0}", e.ToString());
                    Console.ReadLine();
                }
            }
            else
            {
                string[] str = File.ReadAllLines(fileName);
                if (str.Length == 0)
                {
                    Console.WriteLine("Файл пуст.");
                }
                else
                {
                    Console.WriteLine("Файл \"{0}\" найден.", fileName);
                    Console.WriteLine("Директория:  " + Directory.GetCurrentDirectory());
                    Console.WriteLine("Нажмите Enter");
                    Console.ReadLine();
                    
                    string[] readText = File.ReadAllLines(fileName);
                    for (int count = 0; count < readText.Length; count++)
                    {
                        if (readText[count].Equals("users"))
                        {
                            try
                            {
                                int amount = int.Parse(readText[count + 1]);
                                for (int i = (count + 2); i < (count + 2 + amount); i++)
                                {
                                    User user = new User(readText[i]);
                                    dataManager.addUser(user);
                                }
                                count = count + amount + 1;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка: {0}", e.ToString());
                                Console.ReadLine();
                            }
                        }
                        else if (readText[count].Equals("projects"))
                        {
                            try
                            {
                                int amount = int.Parse(readText[count + 1]);
                                for (int i = (count + 2); i < (count + 2 + amount); i++)
                                {
                                    Project project = new Project(readText[i]);
                                    dataManager.addProject(project);
                                }
                                count = count + amount + 1;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка: {0}", e.ToString());
                                Console.ReadLine();
                            }        
                        }
                        else if (readText[count].Equals("tasks"))
                        {
                            try
                            {
                                int amount = int.Parse(readText[count + 1]);
                                for (int i = (count + 2); i < (count + 2 + amount); i++)
                                {
                                    Task task = new Task();

                                    string[] data = readText[i].Split('#');

                                    task.initFromString(data[0]);
                                    User user = dataManager.getUser(data[1]);
                                    Project project = dataManager.getProject(data[2]);
                                    task.setUser(user);
                                    task.setProject(project);

                                    dataManager.addTask(task);
                                }
                                count = count + amount + 1;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ошибка: {0}", e.ToString());
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Данные в файле не корректные");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }

        public void FileSave(DataManager dataManager)
        {
            List<User> users = dataManager.getUsers();
            List<Project> projects = dataManager.getProjects();
            List<Task> tasks = dataManager.getTasks();

            try
            {
                StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine("users");
                sw.WriteLine(users.Count());
                foreach (var elem in users)
                {
                    sw.WriteLine(elem.getName());
                }

                sw.WriteLine("projects");
                sw.WriteLine(projects.Count());
                foreach (var elem in projects)
                {
                    sw.WriteLine(elem.getName());
                }

                sw.WriteLine("tasks");
                sw.WriteLine(tasks.Count());
                foreach (var elem in tasks)
                {
                    sw.WriteLine(elem.toSave());
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.ToString());
                Console.ReadLine();
            }
        }
        //---------------log---------------------------------------
        public void CreateFileLog()
        {
            string FileLogName = "log.txt";
            if (!File.Exists(FileLogName))
            {
                try
                {
                    _ = File.Create(FileLogName);
                    Console.WriteLine("Файл для логирования создан!");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: {0}", e.ToString());
                    Console.ReadLine();
                }
            }
        }

        public void WriteLog(List<string> logs)
        {
            StreamWriter sw = new StreamWriter("log.txt", true);
            try
            {
                foreach (var elem in logs)
                {
                    sw.WriteLine(elem);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.ToString());
                Console.ReadLine();
            }
        }
        // В текущей реализации ПО не используется
        public void SelectFile()
        {
            int count = 0;
            try
            {
                Console.WriteLine("Выберите файл: ");
                foreach (var file in Directory.GetFiles(".", "*."))
                {
                    count++;
                    Console.WriteLine(count + " - " + file);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.ToString());
            }
        }






    }
}
