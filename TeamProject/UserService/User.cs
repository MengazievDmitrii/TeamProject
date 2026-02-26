using System;

namespace TeamProject.UserService
{
    /// <summary>
    /// Класс пользователя (разработчик: Иванов И.И.)
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Email} (создан: {CreatedAt.ToShortDateString()})";
        }
    }
}