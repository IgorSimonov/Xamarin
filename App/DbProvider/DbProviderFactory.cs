using System;
using Norbit.Crm.Simonov.TaskTwelve.DbConsoleApp;

namespace App.DbProvider
{

    /// <summary>
    /// Создаёт провайдер для подключения к БД.
    /// </summary>
    public static class DbProviderFactory
    {
        /// <summary>
        /// Создаёт провайдер для подключения к БД.
        /// </summary>
        /// <param name="provider">Провайдер.</param>
        /// <returns>Экземпляр провайдера.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Не правильный провайдер.</exception>
        public static DbProvider GetProvider(Providers provider)
        {
            return provider switch
            {
                Providers.Lin2Db => new LinqToDbProvider(),
                Providers.Adonet => new AdoNetProvider(),
                Providers.Default => new AdoNetProvider(),
                _ => throw new ArgumentOutOfRangeException(nameof(provider), provider, "Не правильный провайдер.")
            };
        }
    }
}
