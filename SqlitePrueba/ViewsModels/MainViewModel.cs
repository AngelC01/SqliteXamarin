using System;
using System.Collections.Generic;
using System.Text;

namespace SqlitePrueba.ViewsModels
{
    public class MainViewModel
    {
        #region ViewsModels
        public RegistroViewModel Registro
        {
            get;
            set;
        }
        public ConsultaViewModel Consulta
        {
            get;
            set;
        }

        #endregion


        #region

        #endregion
        #region Constructores
        public MainViewModel()
        {
            instance = this;
            this.Registro= new RegistroViewModel();
        }
        #endregion



        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion





    }


}
