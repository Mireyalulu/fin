using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fin
{
    class asignaciontareas
    {
        string id;
        string id_usuario;
        string tarea;
        string prioridad;
        DateTime fechaAsig;
        DateTime fechaTerm;
        string estatus;
        String dependencia;


        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "id_usuario")]
        public string Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        [JsonProperty(PropertyName = "tarea")]
        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }
        [JsonProperty(PropertyName = "prioridad")]
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        [JsonProperty(PropertyName = "fecha_asignacion")]
        public DateTime FechaTerm
        {
            get { return fechaTerm; }
            set { fechaTerm = value; }
        }

        [JsonProperty(PropertyName = "fecha_termino")]
        public DateTime FechaAsig
        {
            get { return fechaAsig; }
            set { fechaAsig = value; }
        }
        [JsonProperty(PropertyName = "estatus")]
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
        [JsonProperty(PropertyName = "dependencia")]
        public string Dependencia
        {
            get { return dependencia; }
            set { dependencia = value; }
        }
    }
}

