using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.DbProvider;
using App.Models;
using Norbit.Crm.Simonov.TaskTwelve.DbConsoleApp;

namespace WebApi.Controllers
{
    /// <summary>
    /// Api к БД. 
    /// </summary>
    public class Dota2DbController : ApiController
    {
        /// <summary>
        /// Провайдер.
        /// </summary>
        private readonly DbProvider _dbProvider = DbProviderFactory.GetProvider(Providers.Default);

        /// <summary>
        /// Возвращает всех героев.
        /// </summary>
        /// <returns>Коллекция из героев.</returns>
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<IEnumerable<Hero>>(HttpStatusCode.OK, _dbProvider.GetHeroes());
        }

        /// <summary>
        /// Создаёт игрока.
        /// Нужно передать Nickname и Professional.
        /// </summary>
        /// <param name="player">Объект Player.</param>
        /// <returns>Код ответа.</returns>
        public HttpResponseMessage Post([FromBody] Player player)
        {
            return _dbProvider.AddPlayer(player.Nickname, player.Professional)
                ? Request.CreateResponse(HttpStatusCode.OK, $"Игрок с nickname - {player.Nickname} успешно добавлен!")
                : Request.CreateResponse(HttpStatusCode.BadRequest, $"Произошла ошибка!");
        }

        /// <summary>
        /// Удаляет игрока.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <returns>Код ответа.</returns>
        public HttpResponseMessage Delete(Guid playerId)
        {
            return _dbProvider.DeletePlayer(playerId)
                ? Request.CreateResponse(HttpStatusCode.OK, $"Игрок с ID - {playerId} удалён!")
                : Request.CreateResponse(HttpStatusCode.BadRequest, $"Произошла ошибка!");
        }

        /// <summary>
        /// Обновляет данные игрока.
        /// Нужно новый Nikcname.
        /// </summary>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="player">Объект Player.</param>
        /// <returns>Код ответа.</returns>
        public HttpResponseMessage Patch(Guid playerId, [FromBody] Player player)
        {
            return _dbProvider.UpdatePlayer(playerId, player.Nickname)
                ? Request.CreateResponse(HttpStatusCode.OK, $"Игрок с ID - {playerId} обновлён!")
                : Request.CreateResponse(HttpStatusCode.BadRequest, $"Произошла ошибка!");
        }
    }
}