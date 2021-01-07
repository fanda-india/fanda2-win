using Fanda2.Backend.Database;
using Fanda2.Backend.Repositories;

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
        private readonly Unit _unit;
        private readonly UnitRepository _repository;

        private readonly DelegateCommand _saveCommand;
        private readonly DelegateCommand _cancelCommand;

        //private int id;
        //private string code;
        //private string name;
        //private string description;
        //private bool isEnabled;

        public UnitsViewModel()
        {
            _unit = new Unit();
            _repository = new UnitRepository();
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

        public int Id { get => _unit.Id; set => SetProperty(ref _unit.Id, value, "Id"); }
        public string Code { get => code; set => SetProperty(ref code, value, "Code"); }
        public string Name { get => name; set => SetProperty(ref name, value, "Name"); }
        public string Description { get => description; set => SetProperty(ref description, value, "Description"); }
        public bool IsEnabled { get => isEnabled; set => SetProperty(ref isEnabled, value, "IsEnabled"); }
    }
}