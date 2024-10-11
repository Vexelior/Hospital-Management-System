﻿using Application.DTOs;
using Core.Entities.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(char status);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByTypeAsync(char type);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Guid id);
    }
}
