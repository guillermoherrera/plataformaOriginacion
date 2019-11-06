﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class Solicitud
    {
        public string solicitudID { get; set; }
        [FirestoreProperty]
        public DateTime fechaCaputra { get; set; }
        [FirestoreProperty]
        public string grupoID { get; set; }
        [FirestoreProperty]
        public string grupoNombre { get; set; }
        [FirestoreProperty]
        public double importe { get; set; }
        [FirestoreProperty]
        public int status { get; set; }
        [FirestoreProperty]
        public int tipoContrato { get; set; }
        [FirestoreProperty]
        public string userID { get; set; }
        [FirestoreProperty]
        public Persona persona { get; set; }
        [FirestoreProperty]
        public List<Documento> documentos { get; set; }
    }
}