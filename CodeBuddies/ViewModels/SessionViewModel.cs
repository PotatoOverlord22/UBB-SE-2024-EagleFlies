using CodeBuddies.MVVM;
using CodeBuddies.Repositories;

namespace CodeBuddies.ViewModels
{
    internal class SessionViewModel : ViewModelBase
    {

        private SessionRepository repository;
        public SessionViewModel()
        {
            // TODO Inject this cleaner
            repository = new SessionRepository();
        }


    }
}
