namespace DT.CustomExceprions
{
    public class RegionNotFoundException : Exception
    {
        /// <summary>
        /// Ошибка в случае отсутствия Региона в БД
        /// </summary>
        /// <param name="error"></param>
        public RegionNotFoundException(string error) : base(error) { }
    }
}
