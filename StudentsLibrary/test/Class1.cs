﻿using System;
using System.Runtime.Serialization;

namespace DataLayer
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int StudentId { get; set; }

        [DataMember]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
