namespace DT.CustomExceprions
{
    public class RegionAddException : Exception
    {
        /// <summary>
        /// Ошибка в случае ошибки добавления Региона в БД
        /// </summary>
        /// <param name="error"></param>
        public RegionAddException(string error) : base(error) { }
    }
}
