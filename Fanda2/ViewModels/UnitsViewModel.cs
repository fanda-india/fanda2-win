using Fanda2.Backend.Database;
using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Fanda2.ViewModels
{
    public class UnitsViewModel : ViewModelBase
    {
        private readonly UnitRepository _repository;

        private readonly DelegateCommand _saveCommand;
        private readonly DelegateCommand _cancelCommand;
        private readonly DelegateCommand _refreshCommand;
        private readonly DelegateCommand _searchCommand;
        private readonly DelegateCommand _addCommand;
        private readonly DelegateCommand _deleteCommand;
        private readonly DelegateCommand _fetchCommand;

        public UnitsViewModel()
        {
            _repository = new UnitRepository();

            _saveCommand = new DelegateCommand(OnSave, CanSave);
            _cancelCommand = new DelegateCommand(OnCancel, (arg) => true);
            _addCommand = new DelegateCommand(OnAdd, (arg) => true);
            _deleteCommand = new DelegateCommand(OnDelete, (arg) => true);
            _refreshCommand = new DelegateCommand(OnRefresh, (arg) => true);
            _searchCommand = new DelegateCommand(OnSearch, (arg) => true);
            _fetchCommand = new DelegateCommand(OnFetch, (arg) => true);

            RefreshList();
        }

        public ICommand SaveCommand => _saveCommand;
        public ICommand CancelCommand => _cancelCommand;
        public ICommand AddCommand => _addCommand;
        public ICommand DeleteCommand => _deleteCommand;
        public ICommand RefreshCommand => _refreshCommand;
        public ICommand SearchCommand => _searchCommand;
        public ICommand FetchCommand => _fetchCommand;

        public int Id { get => Current.Id; set => SetProperty(Current, nameof(Current.Id), value); }
        public string Code { get => Current.Code; set => SetProperty(Current, nameof(Current.Code), value); }
        public string Name { get => Current.UnitName; set => SetProperty(Current, nameof(Current.UnitName), value); }
        public string Description { get => Current.UnitDesc; set => SetProperty(Current, nameof(Current.UnitDesc), value); }
        public bool IsEnabled { get => Current.IsEnabled; set => SetProperty(Current, nameof(Current.IsEnabled), value); }

        public IList<Unit> List { get; private set; }
        public Unit Current { get; set; }
        public string SearchTerm { get; set; }

        private void OnAdd(object obj)
        {
            Current = new Unit();
        }

        private void OnDelete(object obj)
        {
            if (Current.Id > 0)
            {
                _repository.Remove(Current.Id);
            }
        }

        private void OnSave(object obj)
        {
            //Unit unit = new Unit { Id = Id, Code = Code, UnitName = Name, UnitDesc = Description, IsEnabled = IsEnabled, OrgId = 1 };
            //UnitRepository repository = new UnitRepository();

            if (Current.Id == 0)
                _repository.Add(1, Current);
            else
                _repository.Update(Current.Id, Current);

            _saveCommand.InvokeCanExecuteChanged();
        }

        private void OnCancel(object obj)
        {
            _cancelCommand.InvokeCanExecuteChanged();
        }

        private void OnRefresh(object obj)
        {
            RefreshList();
        }

        private void OnSearch(object obj)
        {
            RefreshList();
        }

        private void OnFetch(object obj)
        {
            Unit listItem = obj as Unit;
            if (listItem != null)
                Current = _repository.GetById(listItem.Id);
        }

        private bool CanSave(object arg)
        {
            if (string.IsNullOrWhiteSpace(Code) || string.IsNullOrWhiteSpace(Name))
                return false;
            return true;
        }

        #region Private methods

        private void RefreshList()
        {
            List = _repository.GetAll(orgId: 1, includeDisabled: true, searchTerm: SearchTerm);
            if (List.Count > 0)
                Current = _repository.GetById(List[0].Id);
            else
                Current = new Unit();
        }

        #endregion Private methods
    }
}