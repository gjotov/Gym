using Gym.Models;
using Gym.Views.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Gym.ViewModels
{
    class ManagerViewModel : INotifyPropertyChanged
    {
        public static User ManagerUser { get; set; } = null;

        public ManagerViewModel()
        {
            Equipments = new ObservableCollection<Equipment>(GymAppDbContext.GetContext().Equipment);
            Clients = new ObservableCollection<Client>(GymAppDbContext.GetContext().Clients);
            Trainers = new ObservableCollection<TrainerInfo>(GymAppDbContext.GetContext().TrainerInfos);
            Aboniments = new ObservableCollection<Aboniment>(GymAppDbContext.GetContext().Aboniments);
        }

        //client
        private Client? selectedClient;
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

        private RelayCommand? clientUpdateBtnCommand;
        public RelayCommand ClientUpdateBtnCommand => clientUpdateBtnCommand ?? (clientUpdateBtnCommand = new RelayCommand(obj =>
        {
            Clients = new ObservableCollection<Client>(GymAppDbContext.GetContext().Clients);
        }));

        //equipment
        private Equipment? selectedEquipment;
        public Equipment SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                selectedEquipment = value;
                OnPropertyChanged("SelectedEquipment");
            }
        }

        private ObservableCollection<Equipment>? equipments;
        public ObservableCollection<Equipment> Equipments
        {
            get => equipments;
            set
            {
                equipments = value;
                OnPropertyChanged(nameof(Equipments));
            }
        }

        private RelayCommand? equipmentUpdateBtnCommand;
        public RelayCommand EquipmentUpdateBtnCommand => equipmentUpdateBtnCommand ?? (equipmentUpdateBtnCommand = new RelayCommand(obj =>
        {
            Equipments = new ObservableCollection<Equipment>(GymAppDbContext.GetContext().Equipment);
        }));

        //abon
        private Aboniment? selectedAboniment;
        public Aboniment SelectedAboniment { get => selectedAboniment; set { selectedAboniment = value; OnPropertyChanged("SelectedAboniment"); } }

        private ObservableCollection<Aboniment>? aboniments;
        public ObservableCollection<Aboniment>? Aboniments { get => aboniments; set { aboniments = value; OnPropertyChanged("Aboniments"); } }

        private RelayCommand? abonimentAddBtnCommand;
        public RelayCommand AbonimentAddBtnCommand => abonimentAddBtnCommand ?? (abonimentAddBtnCommand = new RelayCommand(obj =>
        {
            AbonimentEditViewModel.AbonimentToEdit = null;
            var aew = new AbonimentEditWindow();
            aew.ShowDialog();
            AbonimentUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand? abonimentRemoveBtnCommand;
        public RelayCommand AbonimentRemoveBtnCommand => abonimentRemoveBtnCommand ?? (abonimentRemoveBtnCommand = new RelayCommand(obj =>
        {
            if (MessageBox.Show($"Do you really want remove {selectedAboniment.AbonimentId} aboniment?", "Remove Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                GymAppDbContext.GetContext().Aboniments.Remove(SelectedAboniment);
                GymAppDbContext.GetContext().SaveChanges();
                AbonimentUpdateBtnCommand.Execute(this);
            }
        }));
        private RelayCommand? abonimentEditBtnCommand;
        public RelayCommand AbonimentEditBtnCommand => abonimentEditBtnCommand ?? (abonimentEditBtnCommand = new RelayCommand(obj =>
        {
            AbonimentEditViewModel.AbonimentToEdit = SelectedAboniment;
            var aew = new AbonimentEditWindow();
            aew.ShowDialog();
            AbonimentUpdateBtnCommand.Execute(this);
        }));
        private RelayCommand? abonimentUpdateBtnCommand;
        public RelayCommand AbonimentUpdateBtnCommand => abonimentUpdateBtnCommand ?? (abonimentUpdateBtnCommand = new RelayCommand(obj =>
        {
            Aboniments = new ObservableCollection<Aboniment>(GymAppDbContext.GetContext().Aboniments);
        }));

        //trens
        private TrainerInfo? selectedTrainer;
        public TrainerInfo? SelectedTrainer { get => selectedTrainer; set { selectedTrainer = value; OnPropertyChanged("SelectedTrainer"); } }

        private ObservableCollection<TrainerInfo>? trainers;
        public ObservableCollection<TrainerInfo>? Trainers { get => trainers; set { trainers = value; OnPropertyChanged("Trainers"); } }

        private RelayCommand? trainderUpdateBtnCommand;
        public RelayCommand TrainderUpdateBtnCommand => trainderUpdateBtnCommand ?? (trainderUpdateBtnCommand = new RelayCommand(obj =>
        {
            Trainers = new ObservableCollection<TrainerInfo>(GymAppDbContext.GetContext().TrainerInfos);
        }));

        private RelayCommand exitBtnCommand;
        public RelayCommand ExitBtnCommand => exitBtnCommand ?? (exitBtnCommand = new RelayCommand(obj =>
        {
            MainViewModel.ChangePage("login");
        }));

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
