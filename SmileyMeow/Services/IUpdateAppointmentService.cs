using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileyMeow.Services;

public interface IUpdateAppointmentService
{
    Task GetAppointmentsFromDb();
}
