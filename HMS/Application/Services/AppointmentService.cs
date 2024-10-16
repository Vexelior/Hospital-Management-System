﻿using Application.DTOs;
using Application.Interfaces;
using Core.Entities.Appointments;
using Core.Interfaces;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            var appointmentDto = new AppointmentDto();

            foreach (var property in appointment.GetType().GetProperties())
            {
                var appointmentDtoProperty = appointmentDto.GetType().GetProperty(property.Name);
                if (appointmentDtoProperty != null) appointmentDtoProperty.SetValue(appointmentDto, property.GetValue(appointment));
            }

            return appointmentDto;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.ListAllAsync();
            var appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                var appointmentDto = new AppointmentDto();
                foreach (var property in appointment.GetType().GetProperties())
                {
                    var appointmentDtoProperty = appointmentDto.GetType().GetProperty(property.Name);
                    if (appointmentDtoProperty != null) appointmentDtoProperty.SetValue(appointmentDto, property.GetValue(appointment));
                }
                appointmentDtos.Add(appointmentDto);
            }

            return appointmentDtos;
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(char status)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByStatusAsync(status);
            var appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                var appointmentDto = new AppointmentDto();
                foreach (var property in appointment.GetType().GetProperties())
                {
                    var appointmentDtoProperty = appointmentDto.GetType().GetProperty(property.Name);
                    if (appointmentDtoProperty != null) appointmentDtoProperty.SetValue(appointmentDto, property.GetValue(appointment));
                }
                appointmentDtos.Add(appointmentDto);
            }

            return appointmentDtos;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByTypeAsync(char type)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByTypeAsync(type);
            var appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                var appointmentDto = new AppointmentDto();
                foreach (var property in appointment.GetType().GetProperties())
                {
                    var appointmentDtoProperty = appointmentDto.GetType().GetProperty(property.Name);
                    if (appointmentDtoProperty != null) appointmentDtoProperty.SetValue(appointmentDto, property.GetValue(appointment));
                }
                appointmentDtos.Add(appointmentDto);
            }

            return appointmentDtos;
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment != null)
            {
                await _appointmentRepository.DeleteAsync(appointment);
            }
        }
    }
}
