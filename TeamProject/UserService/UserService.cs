using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamProject.UserService
{
    /// <summary>
    /// Сервис для работы с пользователями (разработчик: Иванов И.И.)
    /// </summary>
    public class UserService
    {
        private List<User> _users = new List<User>();
        private int _nextId = 1;

        public User RegisterUser(string name, string email)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Некорректный email");

            // Проверка на уникальность email
            if (_users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Пользователь с таким email уже существует");

            var user = new User(_nextId++, name, email);
            _users.Add(user);
            return user;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _users.ToList();
        }

        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
                return false;

            return _users.Remove(user);
        }

        public int GetUserCount()
        {
            return _users.Count;
        }
    }
}