﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelNet.Domain.Notifications;
using TravelNet.Domain.Validations.Interfaces;

namespace TravelNet.Domain.Entities.ProdutoContext
{


    public abstract class BaseEntity : IValidations
    {

        private List<Notification> _notifications;

        [Key]
        public Guid Id { get; protected set; }

        private DateTime? _createAt;

        protected BaseEntity(DateTime? createAt, DateTime? updateAt, string descricao, string nome)
        {
            Id = Guid.NewGuid();
            CreateAt = createAt;
            CreateAt = createAt;
            UpdateAt = updateAt;
            Descricao = descricao;
            Nome = nome;
        }

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }
        public DateTime? UpdateAt { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        [NotMapped]
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        protected void SetNotifications(List<Notification> notifications)
        {
            _notifications = notifications;
        }

        public virtual void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public abstract bool Validation();



    }
}