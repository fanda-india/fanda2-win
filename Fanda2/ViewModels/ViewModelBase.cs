using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Fanda2.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public bool ThrowOnInvalidPropertyName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            VerifyPropertyName(propertyName);
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        protected bool SetProperty<T, U>(T obj, string memberName, U newValue, [CallerMemberName] string propertyName = null)
        {
            VerifyPropertyName(propertyName);
            var pi = obj.GetType().GetProperty(memberName);
            var member = pi.GetValue(obj);
            if (!EqualityComparer<object>.Default.Equals(member, newValue))
            {
                // field = newValue;
                pi.SetValue(obj, newValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    VerifyPropertyName(propertyName);
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }
    }
}
