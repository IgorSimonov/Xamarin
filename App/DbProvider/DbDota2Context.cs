using App.Models;
using LinqToDB;
using LinqToDB.Data;

namespace App.DbProvider
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    public class DbDota2Context : DataConnection
    {
        /// <summary>
        /// Подлюкчается к БД используя провайдер и строку подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        public DbDota2Context(string connectionString) 
            : base(ProviderName.SqlServer2017, connectionString)
        {
        }

        /// <summary>
        /// Герои.
        /// </summary>
        public ITable<Hero> Hero
        {
            get
            {
                return GetTable<Hero>();
            }
        }
        
        /// <summary>
        /// Позиции.
        /// </summary>
        public ITable<Position> Position
        {
            get
            {
                return GetTable<Position>();
            }
        }
        
        /// <summary>
        /// Игроки.
        /// </summary>
        public ITable<Player> Player
        {
            get
            {
                return GetTable<Player>();
            }
        }
        
        /// <summary>
        /// Стороны.
        /// </summary>
        public ITable<Side> Side
        {
            get
            {
                return GetTable<Side>();
            }
        }
        
        /// <summary>
        /// Основные аттрибуты.
        /// </summary>
        public ITable<MainAttribute> MainAttribute
        {
            get
            {
                return GetTable<MainAttribute>();
            }
        }
        
        /// <summary>
        /// Связывает героев и игроков.
        /// </summary>
        public ITable<HeroPlayerMap> HeroPlayerMap
        {
            get
            {
                return GetTable<HeroPlayerMap>();
            }
        }
    }
}