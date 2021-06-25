using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MailSender.Commands;
using MailSender.ViewModels.Base;

namespace MailSender.ViewModels
{
    public class SenderEditorDialogViewModel : ViewModel
    {
        public event EventHandler EditCompleted;
        public event EventHandler EditCanceled;

        #region Command OkCommand - Ok

        /// <summary>Ok</summary>
        private LambdaCommand _OkCommand;

        /// <summary>Ok</summary>
        public ICommand OkCommand => _OkCommand ??= new(OnOkCommandExecuted);

        /// <summary>Логика выполнения - Ok</summary>
        private void OnOkCommandExecuted(object p)
        {
            EditCompleted?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Command CancelCommand - Cancel

        /// <summary>Cancel</summary>
        private LambdaCommand _CancelCommand;

        /// <summary>Cancel</summary>
        public ICommand CancelCommand => _CancelCommand ??= new(OnCancelCommandExecuted);

        /// <summary>Логика выполнения - Cancel</summary>
        private void OnCancelCommandExecuted(object p)
        {
            EditCanceled?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Name : string - Имя Отправителя

        /// <summary>Имя отправителя</summary>
        private string _Name;

        /// <summary>Имя отправителя</summary>
        public string Name { get => _Name; set => Set(ref _Name, value); }

        #endregion

        #region Address : string - Адрес отправителя

        /// <summary>Адрес отправителя</summary>
        private string _Address;

        /// <summary>Адрес отправителя</summary>
        public string Address { get => _Address; set => Set(ref _Address, value); }

        #endregion

        

        #region Description : string - Описание

        /// <summary>Описание</summary>
        private string _Description;

        /// <summary>Описание</summary>
        public string Description { get => _Description; set => Set(ref _Description, value); }

        #endregion
    }
}
