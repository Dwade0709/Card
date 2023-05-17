namespace Core.Public
{
    /// <summary>
    /// Base interface for user data model
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// User idintificator
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Atrribute 
        /// </summary>
        bool IsOnline { get; set; }

    }
}

