﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class HorarioMedico
    {
        public long DniMedico { get; set; }
        public int DiaSemana { get; set; }  
        public TimeSpan HoraInicio { get; set; }   

        public TimeSpan HoraFin { get; set; }   
    }
}
