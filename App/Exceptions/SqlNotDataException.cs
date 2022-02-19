using System;

namespace App.Exceptions

{
    /// <summary>
    /// Нету данных в БД.
    /// </summary>
    public class SqlNotDataException : Exception
    {
        public SqlNotDataException()
        {
        }

        public SqlNotDataException(string message)
            : base(message)
        {
        }
    }
}