using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using System.Collections.ObjectModel;


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
            sessionRepository = new SessionRepository();
            Sessions = new ObservableCollection<Session>(sessionRepository.GetAllSessions());
  
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

        void FilterSessionsBySessionName()
        {
            if (string.IsNullOrWhiteSpace(SearchBySessionName))
            {
                Sessions.Clear();
                Sessions = new ObservableCollection<Session>(sessionRepository.GetAllSessions());
            }
            else
            {
                ObservableCollection<Session> filteredSessions = new ObservableCollection<Session>();
                foreach (var session in sessionRepository.GetAllSessions())
                {
                    if (session.Name.ToLower().Contains(SearchBySessionName.ToLower()))
                    {
                        filteredSessions.Add(session);
                    }
                }
                Sessions = filteredSessions;
            }
        }


    }
}
