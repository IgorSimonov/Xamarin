using System;
using LinqToDB.Mapping;

namespace App.Models
{
    /// <summary>
    /// Связывает таблицу Hero и Player.
    /// </summary>
    [Table(Name = "HeroPlayerMap")]
    public class HeroPlayerMap
    {
        /// <summary>
        /// Id.
        /// </summary>
        [PrimaryKey, Identity]
        public Guid HeroPlayerMapId { get; set; }
        
        /// <summary>
        /// Id героя.
        /// </summary>
        [Column]
        public int HeroId { get; set; }
        
        /// <summary>
        /// Id игрока.
        /// </summary>
        [Column]
        public Guid PlayerId { get; set; }
        
        /// <summary>
        /// Количество игр.
        /// </summary>
        [Column]
        public int Matches { get; set; }
        
        /// <summary>
        /// Процент побед.
        /// </summary>
        [Column]
        public decimal Winrate { get; set; }
        
        /// <summary>
        /// Основная позиция.
        /// </summary>
        [Column]
        public int PositionId { get; set; }
        
        /// <summary>
        /// Связь с таблицей Hero.
        /// </summary>
        [Association(ThisKey = nameof(HeroId), OtherKey = nameof(Models.Hero.HeroId))]
        public Hero Hero { get; set; }
        
        /// <summary>
        /// Связь с таблицей Player.
        /// </summary>
        [Association(ThisKey = nameof(PlayerId), OtherKey = nameof(Models.Player.PLayerId))]
        public Player Player { get; set; }
    }
}