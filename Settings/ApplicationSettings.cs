namespace DT.Settings
{
    public class ApplicationSettings
    {
        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
    }
}
