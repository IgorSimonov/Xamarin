using LinqToDB.Mapping;

namespace App.Models
{
    /// <summary>
    /// Основной аттрибут.
    /// </summary>
    [Table(Name = "MainAttribute")]
    public class MainAttribute
    {
        /// <summary>
        /// Id.
        /// </summary>
        [PrimaryKey, Identity]
        public int MainAttributeId { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        [Column]
        public string Name { get; set; }
    }
}