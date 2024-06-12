using Gym.Models;
using Gym.Views.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Gym.ViewModels
{
    class AdminViewModel : INotifyPropertyChanged
    {
        public static User AdminUser { get; set; } = null;
        //user tab
        private RelayCommand userAddBtnCommand;
        public RelayCommand UserAddBtnCommand => userAddBtnCommand ?? (userAddBtnCommand = new RelayCommand(obj =>
        {
            UserEditViewModel.UserToEdit = null;
            UserEditWindow userEditWindow = new UserEditWindow();
            userEditWindow.ShowDialog();
            UserUpdateCommand.Execute(this);
        }));
        private RelayCommand userRemoveBtnCommand;
        public RelayCommand UserRemoveBtnCommand => userRemoveBtnCommand ?? (userRemoveBtnCommand = new RelayCommand(obj =>
        {
            if(MessageBox.Show($"Would you remove {selectedUser.Login}", "Confimation", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                GymAppDbContext.GetContext().Users.Remove(selectedUser);
                GymAppDbContext.GetContext().SaveChanges();
                UserUpdateCommand.Execute(this);
            }
        }));
        private RelayCommand userEditBtnCommand;
        public RelayCommand UserEditBtnCommand => userEditBtnCommand ?? (userEditBtnCommand = new RelayCommand(obj =>
        {
            UserEditViewModel.UserToEdit = selectedUser;
            UserEditWindow userEditWindow = new UserEditWindow();
            userEditWindow.ShowDialog();
            UserUpdateCommand.Execute(this);
        }));
        private RelayCommand userUpdateCommand;
        public RelayCommand UserUpdateCommand => userUpdateCommand ?? (userUpdateCommand = new RelayCommand(obj =>  
        {
            Users = new ObservableCollection<User>(GymAppDbContext.GetContext().Users);
        }));
        private User selectedUser;
        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        //equipment
        private Equipment selectedEquipment;
        public Equipment SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                selectedEquipment = value;
                OnPropertyChanged("SelectedEquipment");
            }
        }

        private ObservableCollection<Equipment> equipments;
        public ObservableCollection<Equipment> Equipments
        {
            get => equipments;
            set
            {
                equipments = value;
                OnPropertyChanged(nameof(Equipments));
            }
        }

        private RelayCommand equipmentAddBtnCommand;
        public RelayCommand EquipmentAddBtnCommand => equipmentAddBtnCommand ?? (equipmentAddBtnCommand = new RelayCommand(obj => 
        {
            EquipmentEditViewModel.EquipmentToEdit = null;
            EquipmentEditWindow equipmentEditWindow = new EquipmentEditWindow();
            equipmentEditWindow.ShowDialog();
            EquipmentUpdateBtnCommand.Execute(this);

        }));
        private RelayCommand equipmentRemoveBtnCommand;
        public RelayCommand EquipmentRemoveBtnCommand => equipmentRemoveBtnCommand ?? (equipmentRemoveBtnCommand = new RelayCommand(obj =>
        {
            if(MessageBox.Show($"Do you really want remove {selectedEquipment.Title} equipment?", "Remove Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                GymAppDbContext.GetContext().Equipment.Remove(SelectedEquipment);
                GymAppDbContext.GetContext().SaveChanges();
                EquipmentUpdateBtnCommand.Execute(this);
            }
        }));
        private RelayCommand equipmentEditBtnCommand;
        public RelayCommand EquipmentEditBtnCommand => equipmentEditBtnCommand ?? (equipmentEditBtnCommand = new RelayCommand(obj =>
        {
            EquipmentEditViewModel.EquipmentToEdit = SelectedEquipment;
            EquipmentEditWindow equipmentEditWindow = new EquipmentEditWindow();
            equipmentEditWindow.ShowDialog();
            EquipmentUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand equipmentUpdateBtnCommand;
        public RelayCommand EquipmentUpdateBtnCommand => equipmentUpdateBtnCommand ?? (equipmentUpdateBtnCommand = new RelayCommand(obj =>
        {
            Equipments = new ObservableCollection<Equipment>(GymAppDbContext.GetContext().Equipment);
        }));
        //clients
        private Client selectedClient;
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private RelayCommand clientAddBtnCommand;
        public RelayCommand ClientAddBtnCommand => clientAddBtnCommand ?? (clientAddBtnCommand = new RelayCommand(obj =>
        {
            ClientEditViewModel.ClientToEdit = null;
            var cew = new ClientEditWindow();
            cew.ShowDialog();
            ClientUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand clientRemoveBtnCommand;
        public RelayCommand ClientRemoveBtnCommand => clientRemoveBtnCommand ?? (clientRemoveBtnCommand = new RelayCommand(obj =>
        {
            if(MessageBox.Show($"Do you really want remove {selectedClient.Name} client?", "Remove Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                GymAppDbContext.GetContext().Clients.Remove(selectedClient);
                GymAppDbContext.GetContext().SaveChanges();
                ClientUpdateBtnCommand.Execute(this);
            }
        }));
        private RelayCommand clientEditBtnCommand;
        public RelayCommand ClientEditBtnCommand => clientEditBtnCommand ?? (clientEditBtnCommand = new RelayCommand(obj =>
        {
            ClientEditViewModel.ClientToEdit = SelectedClient;
            var cew = new ClientEditWindow();
            cew.ShowDialog();
            ClientUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand clientUpdateBtnCommand;
        public RelayCommand ClientUpdateBtnCommand => clientUpdateBtnCommand ?? (clientUpdateBtnCommand = new RelayCommand(obj =>
        {
            Clients = new ObservableCollection<Client>(GymAppDbContext.GetContext().Clients);
        }));
        //reports

        //aboniments
        private Aboniment selectedAboniment;
        public Aboniment SelectedAboniment { get => selectedAboniment; set { selectedAboniment = value; OnPropertyChanged("SelectedAboniment"); } }

        private ObservableCollection<Aboniment> aboniments;
        public ObservableCollection<Aboniment> Aboniments { get => aboniments; set { aboniments = value; OnPropertyChanged("Aboniments"); } }

        private RelayCommand abonimentAddBtnCommand;
        public RelayCommand AbonimentAddBtnCommand => abonimentAddBtnCommand ?? (abonimentAddBtnCommand = new RelayCommand(obj =>
        {
            AbonimentEditViewModel.AbonimentToEdit = null;
            var aew = new AbonimentEditWindow();
            aew.ShowDialog();
            AbonimentUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand abonimentRemoveBtnCommand;
        public RelayCommand AbonimentRemoveBtnCommand => abonimentRemoveBtnCommand ?? (abonimentRemoveBtnCommand = new RelayCommand(obj =>
        {
            if(MessageBox.Show($"Do you really want remove {selectedAboniment.AbonimentId} aboniment?", "Remove Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                GymAppDbContext.GetContext().Aboniments.Remove(SelectedAboniment);
                GymAppDbContext.GetContext().SaveChanges();
                AbonimentUpdateBtnCommand.Execute(this);
            }
        }));
        private RelayCommand abonimentEditBtnCommand;
        public RelayCommand AbonimentEditBtnCommand => abonimentEditBtnCommand ?? (abonimentEditBtnCommand = new RelayCommand(obj =>
        {
            AbonimentEditViewModel.AbonimentToEdit = SelectedAboniment;
            var aew = new AbonimentEditWindow();
            aew.ShowDialog();
            AbonimentUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand abonimentUpdateBtnCommand;
        public RelayCommand AbonimentUpdateBtnCommand => abonimentUpdateBtnCommand ?? (abonimentUpdateBtnCommand = new RelayCommand(obj =>
        {
            Aboniments = new ObservableCollection<Aboniment>(GymAppDbContext.GetContext().Aboniments);
        }));
        //trainers
        private TrainerInfo selectedTrainer;
        public TrainerInfo SelectedTrainer { get => selectedTrainer; set { selectedTrainer = value; OnPropertyChanged("SelectedTrainer"); } }

        private ObservableCollection<TrainerInfo> trainers;
        public ObservableCollection<TrainerInfo> Trainers { get => trainers; set { trainers = value; OnPropertyChanged("Trainers"); } }

        private RelayCommand trainderAddBtnCommand;
        public RelayCommand TrainderAddBtnCommand => trainderAddBtnCommand ?? (trainderAddBtnCommand = new RelayCommand(obj =>
        {
            TrainersEditViewModel.TrainerToEdit = null;
            TrainerEditWindow tew = new TrainerEditWindow();
            tew.ShowDialog();
            TrainderUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand trainderRemoveBtnCommand;
        public RelayCommand TrainderRemoveBtnCommand => trainderRemoveBtnCommand ?? (trainderRemoveBtnCommand = new RelayCommand(obj =>
        {
            if(MessageBox.Show($"Do you really want remove info about {selectedTrainer.User.Login} user", "Remove Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) ==MessageBoxResult.Yes)
            {
                GymAppDbContext.GetContext().TrainerInfos.Remove(selectedTrainer);
                GymAppDbContext.GetContext().SaveChanges();
                TrainderUpdateBtnCommand.Execute(this);
            }
        }));
        private RelayCommand trainderEditBtnCommand;
        public RelayCommand TrainderEditBtnCommand => trainderEditBtnCommand ?? (trainderEditBtnCommand = new RelayCommand(obj =>
        {
            TrainersEditViewModel.TrainerToEdit = SelectedTrainer;
            TrainerEditWindow tew = new TrainerEditWindow();
            tew.ShowDialog();
            TrainderUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand trainderUpdateBtnCommand;
        public RelayCommand TrainderUpdateBtnCommand => trainderUpdateBtnCommand ?? (trainderUpdateBtnCommand = new RelayCommand(obj =>
        {
            Trainers = new ObservableCollection<TrainerInfo>(GymAppDbContext.GetContext().TrainerInfos);
        }));
        //session
        private Session selectedSession;
        public Session SelectedSession { get => selectedSession; set { selectedSession = value; OnPropertyChanged("SelectedSession"); } }

        private ObservableCollection<Session> sessions;
        public ObservableCollection<Session> Sessions { get => sessions; set { sessions = value; OnPropertyChanged("Sessions"); } }

        private RelayCommand sessionAddBtnCommand;
        public RelayCommand SessionAddBtnCommand => sessionAddBtnCommand ?? (sessionAddBtnCommand = new RelayCommand(obj =>
        {
            SessionEditViewModel.SessionToEdit = null;
            var sew = new SessionEditWindow();
            sew.ShowDialog();
            SessionUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand sessionRemoveBtnCommand;
        public RelayCommand SessionRemoveBtnCommand => sessionRemoveBtnCommand ?? (sessionRemoveBtnCommand = new RelayCommand(obj =>
        {
            if(MessageBox.Show($"Do you really want remove {SelectedSession.SessionId} Session?", "Remove Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                GymAppDbContext.GetContext().Sessions.Remove(SelectedSession);
                GymAppDbContext.GetContext().SaveChanges();
                SessionUpdateBtnCommand.Execute(this);
            }
        }));
        private RelayCommand sessionEditBtnCommand;
        public RelayCommand SessionEditBtnCommand => sessionEditBtnCommand ?? (sessionEditBtnCommand = new RelayCommand(obj =>
        {
            SessionEditViewModel.SessionToEdit = SelectedSession;
            var sew = new SessionEditWindow();
            sew.ShowDialog();
            SessionUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand sessionUpdateBtnCommand;
        public RelayCommand SessionUpdateBtnCommand=> sessionUpdateBtnCommand ?? (sessionUpdateBtnCommand = new RelayCommand(obj => 
        {
            Sessions = new ObservableCollection<Session>(GymAppDbContext.GetContext().Sessions);
        }));


        //common
        private RelayCommand exitBtnCommand;
        public RelayCommand ExitBtnCommand => exitBtnCommand ?? (exitBtnCommand = new RelayCommand(obj => 
        {
            MainViewModel.ChangePage("login");
        }));
        //add on closing command on all edit windows to clear static prop


        public AdminViewModel()
        {
            Users = new ObservableCollection<User>(GymAppDbContext.GetContext().Users);
            Equipments = new ObservableCollection<Equipment>(GymAppDbContext.GetContext().Equipment);
            Clients = new ObservableCollection<Client>(GymAppDbContext.GetContext().Clients);
            Trainers = new ObservableCollection<TrainerInfo>(GymAppDbContext.GetContext().TrainerInfos);
            Aboniments = new ObservableCollection<Aboniment>(GymAppDbContext.GetContext().Aboniments);
            Sessions = new ObservableCollection<Session>(GymAppDbContext.GetContext().Sessions);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
