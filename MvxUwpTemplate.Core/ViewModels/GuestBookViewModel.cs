using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxUwpTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvxUwpTemplate.Core.ViewModels
{
    public class GuestBookViewModel : MvxViewModel
    {

        #region properties

        private MvxObservableCollection<PersonModel> people = new MvxObservableCollection<PersonModel>();

        public MvxObservableCollection<PersonModel> People { get => people; set => SetProperty(ref people, value); } //SetProperty will trigger the INotifyPropertyChanged

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                SetProperty(ref firstName, value);
                RaisePropertyChanged(() => FullName); //once this value is changed raise the property changed of the other attribute FullName
                RaisePropertyChanged(() => CanAddGuest);
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                SetProperty(ref lastName, value);
                RaisePropertyChanged(() => FullName); //once this value is changed raise the property changed of the other attribute FullName
                RaisePropertyChanged(() => CanAddGuest);
            }
        }

        public string FullName => $"{FirstName} {LastName}"; // a read only property that combines the first name and the last name for display

        public bool CanAddGuest => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName); // a boolean used to be bind the attribute isEnabled of the add button

        #endregion

        #region commands

        public IMvxCommand AddGuestCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Constructor
        /// </summary>
        public GuestBookViewModel()
        {
            this.AddGuestCommand = new MvxCommand(AddGuest); //wire the command to the function
        }

        /// <summary>
        /// function to add a guest to the people list
        /// </summary>
        public void AddGuest()
        {
            PersonModel p = new PersonModel
            {
                FirstName = this.FirstName,
                LastName = this.LastName
            };

            this.FirstName = string.Empty;
            this.LastName = string.Empty;

            this.People.Add(p);
        }

        #endregion
    }
}
