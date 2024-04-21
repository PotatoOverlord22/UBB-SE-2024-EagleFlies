using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace CodeBuddies.ViewModels
{
    internal class SessionsListViewModel : ViewModelBase
    {
        private ObservableCollection<Session> sessions;
        private SessionRepository sessionRepository;

        public ObservableCollection<Session> Sessions
        {
            get { return sessions; }
            set { sessions = value; OnPropertyChanged(); }
        }


        public SessionsListViewModel()
        {
            GlobalEvents.BuddyAddedToSession += HandleBuddyAddedToSession;
            sessionRepository = new SessionRepository();
            Sessions = new ObservableCollection<Session>(sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID));

        }

        private string searchBySessionName;

        public string SearchBySessionName
        {
            get { return searchBySessionName; }
            set
            {
                searchBySessionName = value;
                FilterSessionsBySessionName();
            }
        }

        public void FilterSessionsBySessionName()
        {
            if (string.IsNullOrWhiteSpace(SearchBySessionName))
            {
                Sessions.Clear();
                Sessions = new ObservableCollection<Session>(sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID));
            }
            else
            {
                ObservableCollection<Session> filteredSessions = new ObservableCollection<Session>();
                foreach (var session in sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID))
                {
                    if (session.Name.ToLower().Contains(SearchBySessionName.ToLower()))
                    {
                        filteredSessions.Add(session);
                    }
                }
                Sessions = filteredSessions;
            }
        }

        public void HandleBuddyAddedToSession(long buddyId, long sessionId)
        {
            Sessions = new ObservableCollection<Session>(sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID));
        }

        public void filterSessionOnlyOwner(long buddyId)
        {
            Sessions = new ObservableCollection<Session>(Sessions.Where(Session => Session.OwnerId == buddyId).ToList()); 
        }


        public ICommand SendInviteNotification => new RelayCommand<Buddy>(InviteBuddyToSession);

        private void InviteBuddyToSession(Buddy buddy)
        {


        }
    }
}
