using LinqToDB.Mapping;

namespace App.Models
{
    /// <summary>
    /// Позиция.
    /// </summary>
    [Table(Name = "Position")]
    public class Position
    {
        /// <summary>
        /// Id.
        /// </summary>
        [PrimaryKey, Identity]
        public int PositionId { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        [Column]
        public string Name { get; set; }
    }
}