﻿using FluentValidator;
using FluentValidator.Validation;

namespace Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        #region Constructors
        public Document(string number)
        {
            Number = number;

            CallNotifications();
        }
        #endregion

        #region Properties
        public string Number { get; private set; }
        #endregion

        #region Methods
        private bool ValidadeCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private void CallNotifications() =>
            AddNotifications(
                 new ValidationContract()
                     .IsTrue(ValidadeCPF(Number), "Document", "CPF inválido")
                     .HasLen(Number, 11, "Number", "CPF inválido")
                 );

        public override string ToString() => Number;
        #endregion
    }
}