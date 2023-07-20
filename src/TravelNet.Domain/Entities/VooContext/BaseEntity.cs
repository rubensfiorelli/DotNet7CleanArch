﻿using System.ComponentModel.DataAnnotations;

namespace TravelNet.Domain.Entities.VooContext
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }

        private DateTime? _createAt;

        protected BaseEntity(DateTime? createAt, DateTime? updateAt, string descricao)
        {
            Id = Guid.NewGuid();
            CreateAt = createAt;
            CreateAt = createAt;
            UpdateAt = updateAt;
            Descricao = descricao;
        }

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdateAt { get; set; }
        public string Descricao { get; private set; }
    }
}