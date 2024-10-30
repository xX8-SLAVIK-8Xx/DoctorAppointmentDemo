﻿using MyDoctorAppointment.Domain.Entities;


namespace MyDoctorAppointment.Data.Interfaces //Мой врач Appointment .Data. Интерфейсы
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {
        TSource Create(TSource source);

        TSource? GetById(int id);

        TSource Update(int id, TSource source);

        IEnumerable<TSource> GetAll();

        bool Delete(int id);
    }
}
