using LinqToDB.Mapping;

namespace App.Models
{
    /// <summary>
    /// Сторона.
    /// </summary>
    [Table(Name = "Side")]
    public class Side
    {
        /// <summary>
        /// Id.
        /// </summary>
        [PrimaryKey, Identity]
        public int SideId { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        [Column]
        public string Name { get; set; }
    }
}