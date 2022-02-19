using System;
using LinqToDB.Mapping;

namespace App.Models
{
    /// <summary>
    /// Игрок.
    /// </summary>
    [Table(Name = "Player")]
    public class Player
    {
        /// <summary>
        /// Id.
        /// </summary>
        [PrimaryKey, Identity]
        public Guid PLayerId { get; set; }
        
        /// <summary>
        /// Nickname.
        /// </summary>
        [Column]
        public string Nickname { get; set; }
        
        /// <summary>
        /// Дата создания.
        /// </summary>
        [Column]
        public DateTime CreateDate { get; set; }
        
        /// <summary>
        /// Является ли профессионалом.
        /// </summary>
        [Column]
        public bool Professional { get; set; }
    }
}