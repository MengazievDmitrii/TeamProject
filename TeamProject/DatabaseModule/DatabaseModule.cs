using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TeamProject.DatabaseModule
{
    /// <summary>
    /// Модуль для работы с данными (разработчик: Петров П.П.)
    /// </summary>
    public class DatabaseModule
    {
        private DatabaseConfig _config;
        private List<string> _operationLog;
        private string _dataFile = "users.json";

        public DatabaseModule(DatabaseConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _operationLog = new List<string>();
        }

        public bool Connect()
        {
            Log("Попытка подключения к БД");

            if (string.IsNullOrEmpty(_config.ConnectionString))
            {
                Log("ОШИБКА: Connection string пуст");
                return false;
            }

            Log("Подключение успешно");
            return true;
        }

        public List<User> LoadUsers()
        {
            Log("Загрузка пользователей из файла");

            if (!File.Exists(_dataFile))
            {
                Log("Файл не найден, возвращаем пустой список");
                return new List<User>();
            }

            try
            {
                string json = File.ReadAllText(_dataFile);
                var users = JsonSerializer.Deserialize<List<User>>(json);
                Log($"Загружено {users?.Count ?? 0} пользователей");
                return users ?? new List<User>();
            }
            catch (Exception ex)
            {
                Log($"Ошибка загрузки: {ex.Message}");
                return new List<User>();
            }
        }

        public bool SaveUsers(List<User> users)
        {
            Log($"Сохранение {users.Count} пользователей");

            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(users, options);
                File.WriteAllText(_dataFile, json);
                Log("Сохранение успешно");
                return true;
            }
            catch (Exception ex)
            {
                Log($"Ошибка сохранения: {ex.Message}");
                return false;
            }
        }

        private void Log(string message)
        {
            if (_config.EnableLogging)
            {
                _operationLog.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            }
        }

        public List<string> GetLog()
        {
            return new List<string>(_operationLog);
        }
    }
}