using SqlitePrueba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SqlitePrueba.ViewsModels
{
   public class ConsultaViewModel:BaseViewModel
    {
        private ObservableCollection<User> usersCollection;
        public ObservableCollection <User> UsersColleciton 
        { 

            get { return this.usersCollection; }
            set { SetValue(ref this.usersCollection, value); }
        }

        public void LoadUsers()
        {
            var allUsers = UserRepository.Instancia.GetAllUsers();
            this.UsersColleciton = new ObservableCollection<User>(allUsers);
        }

            public ConsultaViewModel()
            {

                 LoadUsers();
            
            }



        }
}
