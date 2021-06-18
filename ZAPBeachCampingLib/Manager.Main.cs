namespace ZAPBeachCampingLib
{
    public delegate void ErrorEventHandler(string message);

    public partial class Manager
    {
        private DataAccess dal;
        public event ErrorEventHandler MissingInformation;

        public Manager()
        {
            dal = new DataAccess();
        }

        private void OnFailure(string message)
        {
            MissingInformation?.Invoke(message);
        }
    }
}
