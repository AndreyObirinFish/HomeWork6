namespace MyCity.Core.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        ///     Флаг активности записи
        /// </summary>
        public bool IsActive { get; set; } = true;

        public DateTime DateCreated { get; set; }

        /// <summary>
        ///     Id пользователя, который создал запись
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        ///     Id пользователя, который перевел запись в не активные
        /// </summary>
        public Guid? LockedBy { get; set; }

        public DateTime? DateLocked { get; set; }

        public BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
