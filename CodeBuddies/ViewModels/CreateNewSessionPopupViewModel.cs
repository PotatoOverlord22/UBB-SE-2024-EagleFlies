using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;

namespace CodeBuddies.ViewModels
{
    internal class CreateNewSessionPopupViewModel : ViewModelBase
    {

        private SessionRepository repository;
        public CreateNewSessionPopupViewModel()
        {
            repository = new SessionRepository();
        }

        public void AddNewSession(string sessionName)
        {
            long sessionId = repository.AddNewSession(sessionName, Constants.CLIENT_BUDDY_ID);
            GlobalEvents.RaiseBuddyAddedToSessionEvent(Constants.CLIENT_BUDDY_ID, sessionId);
        }

    }
}
