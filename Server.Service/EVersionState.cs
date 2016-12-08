namespace Server.Service
{
    public enum EVersionState
    {
        /// <summary>
        /// Production version
        /// </summary>
        Production = 1,

        /// <summary>
        /// Dev only version
        /// </summary>
        Dev = 2,

        /// <summary>
        /// For test version
        /// </summary>
        Test = 3
    }
}