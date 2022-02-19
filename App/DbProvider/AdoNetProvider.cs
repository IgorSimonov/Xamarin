using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using App.Exceptions;
using App.Models;

namespace App.DbProvider
{
    /// <summary>
    /// Подключение к БД через Ado.Net.
    /// </summary>
    public class AdoNetProvider : DbProvider
    {
        /// <summary>
        /// Возвращает всех героев из БД, вместе с связаными таблицами.
        /// </summary>
        /// <returns>Коллекцию героев, коллекция пустая, если в базе данных нет записей.</returns>
        /// <exception cref="SqlNotDataException">В БД нет данных.</exception>
        public override List<Hero> GetHeroes()
        {
            using var connection = new SqlConnection(ConnectionString);

            try
            {
                const string query = "SELECT" +
                                         " [Hero].[HeroId]" +
                                         ",[Hero].[Name]" +
                                         ",[Hero].[CreateDate]" +
                                         ",[Hero].[Description]" +
                                         ",[Hero].[MainAttributeId]" +
                                         ",[Hero].[SideId]" +
                                         ",[Hero].[StartMoveSpeed]" +
                                         ",[Hero].[StartDamage]" +
                                         ",[Hero].[StartHealth]" +
                                         ",[Side].[SideId]" +
                                         ",[Side].[Name]" +
                                         ",[MainAttribute].[MainAttributeId]" +
                                         ",[MainAttribute].[Name]" +
                                     "FROM [Hero]" +
                                         "INNER JOIN [Side] ON" +
                                            "[Hero].[SideId] = [Side].[SideId]" +
                                         "INNER JOIN [MainAttribute] ON" +
                                            "[Hero].[MainAttributeId] = [MainAttribute].[MainAttributeId];";

                connection.Open();

                var command = new SqlCommand(query, connection);
                var dataReader = command.ExecuteReader();

                if (!dataReader.HasRows)
                {
                    throw new SqlNotDataException("В БД нет данных!");
                }
                
                var heroes = new List<Hero>();

                while (dataReader.Read())
                {
                    heroes.Add(new Hero()
                    {
                        HeroId = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        CreateDate = dataReader.GetDateTime(2),
                        Description = dataReader[3] is DBNull
                            ? " "
                            : dataReader.GetString(3),
                        MainAttributeId = dataReader.GetInt32(4),
                        SideId = dataReader.GetInt32(5),
                        StartMoveSpeed = dataReader.GetInt32(6),
                        StartDamage = dataReader.GetInt32(7),
                        StartHealth = dataReader.GetInt32(8),
                        Side = new Side()
                        {
                            SideId = dataReader.GetInt32(9),
                            Name = dataReader.GetString(10)
                        },
                        MainAttribute = new MainAttribute()
                        {
                            MainAttributeId = dataReader.GetInt32(11),
                            Name = dataReader.GetString(12)
                        }
                    });
                }

                return heroes;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Добавляет запись в таблицу Player.
        /// </summary>
        /// <param name="newNickname">Nickname игрока.</param>
        /// <param name="professional">True, если игрок является профессионалом, в противном случае false.</param>
        /// <returns>True, если добаваление успешно, в противно случае false. </returns>
        /// <exception cref="ArgumentException">Пустая строка.</exception>
        public override bool AddPlayer(string newNickname, bool professional)
        {
            if (string.IsNullOrEmpty(newNickname))
            {
                throw new ArgumentException("Пустая строка.", nameof(newNickname));
            }

            using var connection = new SqlConnection(ConnectionString);

            try
            {
                const string query = "INSERT INTO [Player]" +
                                     "(" +
                                         "[PlayerId]" +
                                         ",[Nickname]" +
                                         ",[CreateDate]" +
                                         ",[Professional]" +
                                     ")" +
                                     "VALUES" +
                                     "(" +
                                         "NEWID()," +
                                         "@nickname," +
                                         "GETDATE()," +
                                         "@professional" +
                                     ");";

                connection.Open();

                var command = new SqlCommand(query, connection);
                command.Parameters.Add("@nickname", SqlDbType.VarChar).Value = newNickname;
                command.Parameters.Add("@professional", SqlDbType.Bit).Value = professional;

                return command.ExecuteNonQuery() > 0;
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

            using var connection = new SqlConnection(ConnectionString);

            try
            {
                const string query = "DELETE FROM [Player]" +
                                     "WHERE [PlayerId] = @playerId";

                connection.Open();

                var command = new SqlCommand(query, connection);
                command.Parameters.Add("@playerId", SqlDbType.UniqueIdentifier).Value = playerId;

                return command.ExecuteNonQuery() > 0;
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

            using var connection = new SqlConnection(ConnectionString);

            try
            {
                const string query = "UPDATE [Player]" +
                                     "SET [Nickname] = @nickname " +
                                     "WHERE [PlayerId] = @playerId;";

                connection.Open();

                var command = new SqlCommand(query, connection);
                command.Parameters.Add("@nickname", SqlDbType.VarChar).Value = newNickname;
                command.Parameters.Add("@playerId", SqlDbType.UniqueIdentifier).Value = playerId;

                return command.ExecuteNonQuery() > 0;
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}