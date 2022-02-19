using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using LinqToDB;
using LinqToDB.SqlQuery;

namespace App.DbProvider
{

    /// <summary>
    /// Подключение к БД через Linq2Bd.
    /// </summary>
    public class LinqToDbProvider : DbProvider
    {
        /// <summary>
        /// Возвращает всех героев из БД, вместе с связаными таблицами.
        /// </summary>
        /// <returns>Коллекцию героев, коллекция пустая, если в базе данных нет записей.</returns>
        public override List<Hero> GetHeroes()
        {
            try
            {
                using var connection = new DbDota2Context(ConnectionString);

                return connection
                    .Hero
                    .LoadWith(x => x.Side)
                    .LoadWith(t => t.MainAttribute)
                    .ToList();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Добавляет запись в таблицу Player.
        /// </summary>
        /// <param name="nickname">Nickname игрока.</param>
        /// <param name="professional">True, если игрок является профессионалом, в противном случае false.</param>
        /// <returns>True, если добаваление успешно, в противно случае false. </returns>
        /// <exception cref="ArgumentException">Пустая строка.</exception>
        public override bool AddPlayer(string nickname, bool professional)
        {
            if (string.IsNullOrEmpty(nickname))
            {
                throw new ArgumentException("Пустая строка.", nameof(nickname));
            }

            try
            {
                using var connection = new DbDota2Context(ConnectionString);

                return connection.Player
                    .Value(x => x.Nickname, nickname)
                    .Value(x => x.Professional, professional)
                    .Value(x => x.PLayerId, Guid.NewGuid())
                    .Value(x => x.CreateDate, DateTime.Now).Insert() > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Удаляет запись в таблице Player.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <returns>True, если удаление успешно, в противно случае false. </returns>
        /// <exception cref="ArgumentException">Пустой Id.</exception>
        public override bool DeletePlayer(Guid playerId)
        {
            if (Guid.Empty == playerId)
            {
                throw new ArgumentException("Пустой Id.", nameof(playerId));
            }

            try
            {
                using var connection = new DbDota2Context(ConnectionString);

                return connection.Player
                    .Where(x => x.PLayerId == playerId)
                    .Delete() > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Обновляет запись в таблице Player.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="newNickname">Новый nickname игрока.</param>
        /// <returns>True, если обновление успешно, в противно случае false. </returns>
        /// <exception cref="ArgumentException">Пустая строка или пустой Id.</exception>
        public override bool UpdatePlayer(Guid playerId, string newNickname)
        {
            if (Guid.Empty == playerId)
            {
                throw new ArgumentException("Пустой Id.", nameof(playerId));
            }

            if (string.IsNullOrEmpty(newNickname))
            {
                throw new ArgumentException("Пустая строка.", nameof(newNickname));
            }

            try
            {
                using var connection = new DbDota2Context(ConnectionString);

                return connection.Player
                    .Where(x => x.PLayerId == playerId)
                    .Set(x => x.Nickname, newNickname)
                    .Update() > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}