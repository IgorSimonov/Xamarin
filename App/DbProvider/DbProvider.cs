using System;
using System.Collections.Generic;
using System.Configuration;
using App.Models;

namespace App.DbProvider
{
    /// <summary>
    /// Подключается к БД.
    /// </summary>
    public abstract class DbProvider
    {
        private const string StringConnectionParameterName = "DefaultConnection";
        protected static string ConnectionString =
            ConfigurationManager.ConnectionStrings[StringConnectionParameterName].ConnectionString;
        
        /// <summary>
        /// Возвращает всех студентов из БД, вместе с связаными таблицами.
        /// </summary>
        /// <returns>Коллекцию студентов, коллекция пустая, если в базе данных нет записей.</returns>
        public abstract List<Hero> GetHeroes();
        
        /// <summary>
        /// Добавляет запись в таблицу Player.
        /// </summary>
        /// <param name="nickname">Nickname игрока.</param>
        /// <param name="professional">True, если игрок является профессионалом, в противном случае false.</param>
        /// <returns>True, если добаваление успешно, в противно случае false. </returns>
        /// <exception cref="ArgumentException">Пустая строка.</exception>
        public abstract bool AddPlayer(string nickname, bool professional);

        /// <summary>
        /// Удаляет запись в таблице Player.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <returns>True, если удаление успешно, в противно случае false. </returns>
        /// <exception cref="ArgumentException">Пустой Id.</exception>
        public abstract bool DeletePlayer(Guid playerId);

        /// <summary>
        /// Обновляет запись в таблице Player.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="newNickname">Новый nickname игрока.</param>
        /// <returns>True, если обновление успешно, в противно случае false. </returns>
        /// <exception cref="ArgumentException">Пустая строка или пустой Id.</exception>
        public abstract bool UpdatePlayer(Guid playerId, string newNickname);
        
    }
}