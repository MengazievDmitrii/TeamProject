namespace TeamProject.DatabaseModule
{
    /// <summary>
    /// Конфигурация базы данных (разработчик: Петров П.П.)
    /// </summary>
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
        public int TimeoutSeconds { get; set; } = 30;
        public bool EnableLogging { get; set; } = true;
    }
}