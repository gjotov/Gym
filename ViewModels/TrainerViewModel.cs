using Gym.Models;
using Gym.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gym.ViewModels
{
    class TrainerViewModel : INotifyPropertyChanged
    {
        public static User TrainerUser { get; set; } = null;
        //clients
        private Client selectedClient;
        public Client SelectedClient { get => selectedClient; set { selectedClient = value; OnPropertyChanged("SelectedClient"); } }

        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients { get => clients; set { clients = value; OnPropertyChanged("Clients"); } }

        private RelayCommand clientAddBtnCommand;
        public RelayCommand ClientSetSessionBtnCommand => clientAddBtnCommand ?? (clientAddBtnCommand = new RelayCommand(obj =>
        {
            SessionAddBtnCommand.Execute(this);
            ClientUpdateBtnCommand.Execute(this);
        }));
        
        private RelayCommand clientUpdateBtnCommand;
        public RelayCommand ClientUpdateBtnCommand => clientUpdateBtnCommand ?? (clientUpdateBtnCommand = new RelayCommand(obj =>
        {
            var tid = GymAppDbContext.GetContext().TrainerInfos.Where(ti => ti.UserId == TrainerUser.UserId).Select(ti => ti).First();
            Clients = new ObservableCollection<Client>(GymAppDbContext.GetContext().Clients.Where(c => c.TrainerId == tid.TrainerId).Select(c => c));
        }));
        //sessions
        private Session selectedSession;
        public Session SelectedSession { get => selectedSession; set { selectedSession = value; OnPropertyChanged("SelectedSession"); } }

        private ObservableCollection<Session> sessions;
        public ObservableCollection<Session> Sessions { get => sessions; set { sessions = value; OnPropertyChanged("Sessions"); } }

        private RelayCommand sessionAddBtnCommand;
        public RelayCommand SessionAddBtnCommand => sessionAddBtnCommand ?? (sessionAddBtnCommand = new RelayCommand(obj =>
        {
            SessionEditViewModel.TrainerInfo = GymAppDbContext.GetContext().TrainerInfos.Where(ti => ti.UserId == TrainerUser.UserId).Select(ti => ti).First();
            var sew = new SessionEditWindow();
            sew.ShowDialog();
            SessionEditViewModel.TrainerInfo = null;
            SessionUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand sessionUpdateBtnCommand;
        public RelayCommand SessionUpdateBtnCommand => sessionUpdateBtnCommand ?? (sessionUpdateBtnCommand = new RelayCommand(obj =>
        {
            var tid = GymAppDbContext.GetContext().TrainerInfos.Where(ti => ti.UserId == TrainerUser.UserId).Select(ti => ti).First();
            Sessions = new ObservableCollection<Session>(GymAppDbContext.GetContext().Sessions.Where(s => s.TrainerId == tid.TrainerId).Select(s => s));
        }));

        public TrainerViewModel()
        {
            var tid = GymAppDbContext.GetContext().TrainerInfos.Where(ti => ti.UserId == TrainerUser.UserId).Select(ti => ti).First();
            Clients = new ObservableCollection<Client>(GymAppDbContext.GetContext().Clients.Where(c => c.TrainerId == tid.TrainerId).Select(c => c));
            Sessions = new ObservableCollection<Session>(GymAppDbContext.GetContext().Sessions.Where(s => s.TrainerId == tid.TrainerId).Select(s => s));
        }

        private RelayCommand exitBtnCommand;
        public RelayCommand ExitBtnCommand => exitBtnCommand ?? (exitBtnCommand = new RelayCommand(obj =>
        {
            MainViewModel.ChangePage("login");
        }));

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
