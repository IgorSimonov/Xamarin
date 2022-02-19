using System;
using LinqToDB.Mapping;

namespace App.Models
{
    /// <summary>
    /// Герой.
    /// </summary>
    [Table(Name = "Hero")]
    public class Hero
    {
        /// <summary>
        /// Id.
        /// </summary>
        [PrimaryKey, Identity]
        public int HeroId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        [Column]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [Column]
        public string Description { get; set; }

        /// <summary>
        /// Основной аттрибут.
        /// </summary>
        [Column]
        public int MainAttributeId { get; set; }

        /// <summary>
        /// Id стороны.
        /// </summary>
        [Column]
        public int SideId { get; set; }

        /// <summary>
        /// Начальная скорость бега.
        /// </summary>
        [Column]
        public int StartMoveSpeed { get; set; }

        /// <summary>
        /// Начальный наносимый урон.
        /// </summary>
        [Column]
        public int StartDamage { get; set; }

        /// <summary>
        /// Начальное здоровье.
        /// </summary>
        [Column]
        public int StartHealth { get; set; }

        /// <summary>
        /// Связь с таблицей Side.
        /// </summary>
        [Association(ThisKey = nameof(SideId), OtherKey = nameof(App.Models.Side.SideId))]
        public Side Side { get; set; }

        /// <summary>
        /// Связь с таблицей MainAttribute.
        /// </summary>
        [Association(ThisKey = nameof(MainAttributeId), OtherKey = nameof(App.Models.MainAttribute.MainAttributeId))]
        public MainAttribute MainAttribute { get; set; }
    }
}