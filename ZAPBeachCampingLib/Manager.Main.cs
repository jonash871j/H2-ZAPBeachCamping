namespace ZAPBeachCampingLib
{
    public partial class Manager
    {
        private DataAccess dal = new DataAccess();
        public event ErrorEventHandler Failure;

        public Manager()
        {
            dal.DataAccessFailure += OnFailure;
        }

        private void OnFailure(string message)
        {
            Failure.Invoke(message);
        }
    }
}
