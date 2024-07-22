namespace DT.CustomExceprions
{
    public class RegionNotFoundExceprion : Exception
    {
        /// <summary>
        /// Ошибка в случае отсутствия Региона в БД
        /// </summary>
        /// <param name="error"></param>
        public RegionNotFoundExceprion(string error) : base(error) { }
    }
}
