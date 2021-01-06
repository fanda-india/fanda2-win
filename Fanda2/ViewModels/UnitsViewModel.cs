using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fanda2.ViewModels
{
    public class UnitsViewModel : ViewModelBase
    {
        //private readonly Fanda2.Backend.Database.Unit _unit;
        //private readonly Fanda2.Backend.Repositories.UnitRepository _repository;

        private readonly DelegateCommand _saveCommand;
        private readonly DelegateCommand _cancelCommand;

        private int id;
        private string code;
        private string name;
        private string description;
        private bool isEnabled;

        public UnitsViewModel()
        {
            _saveCommand = new DelegateCommand(OnSave, CanSave);
            _cancelCommand = new DelegateCommand(OnCancel, (arg) => true);
        }

        private bool CanSave(object arg)
        {
            //throw new NotImplementedException();
            return true;
        }

        private void OnSave(object obj)
        {
            //throw new NotImplementedException();
            _saveCommand.InvokeCanExecuteChanged();
        }

        private void OnCancel(object obj)
        {
            // throw new NotImplementedException();
            _cancelCommand.InvokeCanExecuteChanged();
        }

        public ICommand SaveCommand => _saveCommand;
        public ICommand CancelCommand => _cancelCommand;

        public int Id { get => id; set => SetProperty(ref id, value); }
        public string Code { get => code; set => SetProperty(ref code, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Description { get => description; set => SetProperty(ref description, value); }
        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value); }
    }
}
