using SQLite;

using System;

namespace TodoList.Models
{
    public class Item
    {
        [PrimaryKey , AutoIncrement]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}