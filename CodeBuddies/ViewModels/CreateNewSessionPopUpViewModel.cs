using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using static CodeBuddies.Models.Validators.ValidationForNewSession;

namespace CodeBuddies.ViewModels
{
    internal class CreateNewSessionPopUpViewModel : ViewModelBase
    {
        private SessionRepository sessionRepository;
        public CreateNewSessionPopUpViewModel()
        {
            sessionRepository = new SessionRepository();
        }

        public void AddNewSession(string sessionName, string maxParticipants)
        {
            ValidateSessionId(sessionRepository.GetFreeSessionId());
            ValidateSessionName(sessionName);
            ValidateMaxNoOfBuddies(maxParticipants);
            ValidateBuddyId(Constants.CLIENT_BUDDY_ID);

            long sessionId = sessionRepository.AddNewSession(sessionName, Constants.CLIENT_BUDDY_ID, Int32.Parse(maxParticipants));
            GlobalEvents.RaiseBuddyAddedToSessionEvent(Constants.CLIENT_BUDDY_ID, sessionId);
        }
    }
}
